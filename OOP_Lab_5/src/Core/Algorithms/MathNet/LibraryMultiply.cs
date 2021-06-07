using MathNet.Numerics.LinearAlgebra;

namespace OOP_Lab_5.Core.Algorithms
{
    /// <summary>
    /// Multiplies matrixes using MathNet library algorithm.
    /// Implements IMultiply interface.
    /// </summary>
    public class LibraryMultiply : IMultiply
    {
        /// <summary>
        /// Gets new matrix that equals to multiplication of passed matrixes.
        /// </summary>
        /// <param name="left">Left matrix argument of matrix multiplication operation.</param>
        /// <param name="right">Right matrix argument of matrix multiplication operation.</param>
        /// <returns>New matrix that equals to multiplication of passed matrixes.</returns>
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
