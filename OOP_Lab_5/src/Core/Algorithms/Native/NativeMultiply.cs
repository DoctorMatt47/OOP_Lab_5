using System;

namespace OOP_Lab_5.Core.Algorithms
{
    /// <summary>
    /// Multiplies matrixes using native algorithm.
    /// Implements IMultiply interface.
    /// </summary>
    public class NativeMultiply : IMultiply
    {
        /// <summary>
        /// Gets new matrix that equals to multiplication of passed matrixes.
        /// </summary>
        /// <param name="left">Left matrix argument of matrix multiplication operation.</param>
        /// <param name="right">Right matrix argument of matrix multiplication operation.</param>
        /// <returns>New matrix that equals to multiplication of passed matrixes.</returns>
        public Matrix Execute(Matrix left, Matrix right)
        {
            if (left.Count != right.Count)
                throw new ArgumentException();

            Matrix retMatrix = new Matrix(left.Count);
            for (int i = 0; i < retMatrix.Count; i++)
            {
                for (int j = 0; j < retMatrix.Count; j++)
                {
                    for (int k = 0; k < retMatrix.Count; k++)
                    {
                        retMatrix[i, j] += left[i, k] * right[k, j];
                    }
                }
            }
            return retMatrix;
        }
    }
}
