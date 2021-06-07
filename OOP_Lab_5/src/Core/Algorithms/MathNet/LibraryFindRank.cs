using MathNet.Numerics.LinearAlgebra;

namespace OOP_Lab_5.Core.Algorithms
{
    /// <summary>
    /// Finds rank of matrix using MathNet library algorithm.
    /// Implements IFindRank interface.
    /// </summary>
    public class LibraryFindRank : IFindRank
    {
        /// <summary>
        /// Gets rank of passed matrix.
        /// </summary>
        /// <param name="matrix">Matrix whose rank will be found.</param>
        /// <returns>Rank of passed matrix.</returns>
        public int Execute(Matrix matrix)
        {
            var matrixBuilder = Matrix<double>.Build;
            var libMatrix = matrixBuilder
                .Dense(matrix.Count, matrix.Count, (i, j) => matrix[i, j]);
            return libMatrix.Rank();
        }
    }
}
