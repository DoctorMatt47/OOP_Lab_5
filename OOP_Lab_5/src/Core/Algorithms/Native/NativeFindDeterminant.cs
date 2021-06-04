namespace OOP_Lab_5.Core.Algorithms
{
    public class NativeFindDeterminant : IFindDeterminant
    {
        public long Execute(Matrix matrix)
        {
            long det = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                long mul = 1;
                for (int j = 0; j < matrix.Count; j++)
                {
                    mul *= matrix[j, (j + i) % matrix.Count];
                }
                det += mul;
            }
            for (int i = 0; i < matrix.Count; i++)
            {
                long mul = 1;
                for (int j = 0; j < matrix.Count; j++)
                {
                    var k = matrix.Count - i - j - 1;
                    mul *= matrix[k >= 0 ? k : k + matrix.Count, j];
                }
                det -= mul;
            }
            return det;
        }
    }
}
