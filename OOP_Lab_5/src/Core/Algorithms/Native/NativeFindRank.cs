namespace OOP_Lab_5.Core.Algorithms
{
    public class NativeFindRank : IFindRank
    {
        public int Execute(Matrix matrix)
        {
            var triangular = matrix.Triangular();
            var rank = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                var isEnd = true;
                for (int j = i; j < matrix.Count; j++)
                {
                    if (triangular[i, j] != 0)
                    {
                        isEnd = false;
                        rank++;
                        break;
                    }
                }
                if (isEnd) break;
            }
            return rank;
        }
    }
}
