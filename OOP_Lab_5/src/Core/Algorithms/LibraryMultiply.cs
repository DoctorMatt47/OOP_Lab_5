using MathNet.Numerics.LinearAlgebra;

namespace OOP_Lab_5.Core.Algorithms
{
    public class LibraryMultiply
    {
        public Matrix Execute(Matrix left, Matrix right)
        {
            var matrixBuilder = Matrix<double>.Build;
            var libLeft = matrixBuilder.
                Dense(left.Count, left.Count, (i, j) => left[i, j]);
            var libRight = matrixBuilder.
                Dense(right.Count, right.Count, (i, j) => right[i, j]);
            var mul = libLeft.Multiply(libRight);
            var retMul = new Matrix(left.Count);
            for (int i = 0; i < retMul.Count; i++)
            {
                for (int j = 0; j < retMul.Count; j++)
                {
                    retMul[i, j] = (int)mul[i, j];
                }
            }
            return retMul;
        }
    }
}
