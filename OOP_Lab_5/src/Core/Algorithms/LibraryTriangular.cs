using MathNet.Numerics.LinearAlgebra;

namespace OOP_Lab_5.Core.Algorithms
{
    public class LibraryTriangular : ITriangular
    {
        public Matrix Execute(Matrix matrix)
        {
            var matrixBuilder = Matrix<double>.Build;
            var libMatrix = matrixBuilder.
                Dense(matrix.Count, matrix.Count, (i, j) => matrix[i, j]);
            var array = libMatrix.LU().U;
            var triangular = new Matrix(matrix.Count);
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix.Count; j++)
                {
                    triangular[i, j] = (int)array[i, j];
                }
            }
            return triangular;
        }
    }
}
