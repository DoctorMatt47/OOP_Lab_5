using MathNet.Numerics.LinearAlgebra;

namespace OOP_Lab_5.Core.Algorithms
{
    /// <summary>
    /// Finds determinant of matrix using MathNet library algorithm.
    /// Implements IFindDeterminant interface.
    /// </summary>
    public class LibraryFindDeterminant : IFindDeterminant
    {
        /// <summary>
        /// Gets determinant of passed matrix.
        /// </summary>
        /// <param name="matrix">Matrix whose determinant will be found.</param>
        /// <returns>Determinant of passed matrix.</returns>
        public long Execute(Matrix matrix)
        {
            var matrixBuilder = Matrix<double>.Build;
            var libMatrix = matrixBuilder.
                Dense(matrix.Count, matrix.Count, (i, j) => matrix[i, j]);
            return (long)libMatrix.Determinant();
        }
    }
}
