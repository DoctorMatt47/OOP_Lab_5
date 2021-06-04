using MathNet.Numerics.LinearAlgebra;

namespace OOP_Lab_5.Core.Algorithms
{
    public class LibraryFindDeterminant : IFindDeterminant
    {
        public long Execute(Matrix matrix)
        {
            var matrixBuilder = Matrix<double>.Build;
            var libMatrix = matrixBuilder.
                Dense(matrix.Count, matrix.Count, (i, j) => matrix[i, j]);
            return (long)libMatrix.Determinant();
        }
    }
}
