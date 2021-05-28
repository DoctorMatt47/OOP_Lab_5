using System;

namespace OOP_Lab_5.Core.Algorithms
{
    public class NativeMultiply : IMultiply
    {
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
