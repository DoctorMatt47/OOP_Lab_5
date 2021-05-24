using System;
using System.Collections.Generic;

namespace OOP_Lab_5.Core
{
    public class Matrix
    {
        private List<List<int>> _matrix;
        public int Count { get; }

        public Matrix(List<List<int>> matrix)
        {
            if (matrix.Count > 0 && matrix.Count != matrix[0].Count)
                throw new ArgumentException();

            _matrix = matrix;
            Count = matrix.Count;
        }

        public Matrix(int count)
        {
            if (count < 0)
                throw new ArgumentException();

            Count = count;
            _matrix = new List<List<int>>(count);
            for (int i = 0; i < count; i++)
            {
                _matrix.Add(new List<int>(count));
                for (int j = 0; j < count; j++)
                {
                    _matrix[i].Add(0);
                }
            }
        }  

        public int this [int i, int j]
        {
            get
            {
                return _matrix[i][j];
            }
            set
            {
                _matrix[i][j] = value;
            }
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (left.Count != right.Count)
                throw new ArgumentException();

            Matrix retMatrix = new Matrix(left.Count);
            for (int i = 0; i < retMatrix.Count; i++)
            {
                for (int j = 0; j < retMatrix.Count; j++)
                {
                    retMatrix[i, j] = left[i, j] + right[i, j];
                }
            }
            return retMatrix;
        }

        public static Matrix operator -(Matrix matrix)
        {
            Matrix retMatrix = new Matrix(matrix.Count);
            for (int i = 0; i < retMatrix.Count; i++)
            {
                for (int j = 0; j < retMatrix.Count; j++)
                {
                    retMatrix[i, j] = -matrix[i, j];
                }
            }
            return retMatrix;
        }

        public static Matrix operator -(Matrix left, Matrix right)
        {
            return left + (-right);
        }

        public static Matrix operator *(Matrix left, Matrix right)
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

        public int FindDeterminant()
        {
            var det = 0;
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    var k = j + i < Count ? j + i : i + j - Count;
                    det += _matrix[j][k];
                }
                
            }
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    var k = Count - i - j - 1 >= 0 ? Count - i - j - 1 : 2 * Count - i - j - 1;
                    det -= _matrix[k][j];
                }
            }
            return det;
        }

    }
}
