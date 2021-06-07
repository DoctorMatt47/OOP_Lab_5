namespace OOP_Lab_5.Core.Algorithms
{
    /// <summary>
    /// Finds rank of matrix using native algorithm.
    /// Implements IFindRank interface.
    /// </summary>
    public class NativeFindRank : IFindRank
    {
        /// <summary>
        /// Gets rank of passed matrix.
        /// </summary>
        /// <param name="matrix">Matrix whose rank will be found.</param>
        /// <returns>Rank of passed matrix.</returns>
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
