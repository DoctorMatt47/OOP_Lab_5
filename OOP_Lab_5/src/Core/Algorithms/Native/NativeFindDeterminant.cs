namespace OOP_Lab_5.Core.Algorithms
{
    /// <summary>
    /// Finds determinant of matrix using native algorithm.
    /// Implements IFindDeterminant interface.
    /// </summary>
    public class NativeFindDeterminant : IFindDeterminant
    {
        /// <summary>
        /// Gets determinant of passed matrix.
        /// </summary>
        /// <param name="matrix">Matrix whose determinant will be found.</param>
        /// <returns>Determinant of passed matrix.</returns>
        public long Execute(Matrix matrix)
        {
            if (matrix.Count == 1)
                return matrix[0, 0];

            if (matrix.Count == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];

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
