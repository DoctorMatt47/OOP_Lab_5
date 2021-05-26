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
            _matrix = new List<List<int>>(Count);
            for (int i = 0; i < Count; i++)
            {
                _matrix.Add(new List<int>(Count));
                for (int j = 0; j < Count; j++)
                {
                    _matrix[i].Add(0);
                }
            }
        }

        public Matrix(Matrix other)
        {
            Count = other.Count;

            _matrix = new List<List<int>>(Count);
            for (int i = 0; i < Count; i++)
            {
                _matrix.Add(new List<int>(Count));
                for (int j = 0; j < Count; j++)
                {
                    _matrix[i].Add(other[i, j]);
                }
            }
        }

        private Matrix TriangularCore(out int rank)
        {
            rank = Count;

            var matrix = new Matrix(this);

            for (int row = 0; row < rank; row++)
            {
                if (matrix[row, row] != 0)
                {
                    for (int col = 0; col < Count; col++)
                    {
                        if (col != row)
                        {
                            double mult =
                               (double)matrix[col, row] /
                                        matrix[row, row];

                            for (int i = 0; i < rank; i++)

                                matrix[col, i] -= (int)mult
                                         * matrix[row, i];
                        }
                    }
                }
                else
                {
                    bool reduce = true;

                    for (int i = row + 1; i < Count; i++)
                    {
                        if (matrix[i, row] != 0)
                        {
                            for (int j = 0; j < rank; j++)
                            {
                                int temp = matrix[row, j];
                                matrix[row, j] = matrix[i, j];
                                matrix[i, j] = temp;
                            }
                            reduce = false;
                            break;
                        }
                    }

                    if (reduce)
                    {
                        rank--;
                        for (int i = 0; i < Count; i++)
                            matrix[i, row] = matrix[i, rank];
                    }
                    row--;
                }
            }
            return matrix;
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
                var mul = 1;
                for (int j = 0; j < Count; j++)
                {
                    var k = j + i < Count ? j + i : i + j - Count;
                    mul *= _matrix[j][k];
                }
                det += mul;
            }
            for (int i = 0; i < Count; i++)
            {
                var mul = 1;
                for (int j = 0; j < Count; j++)
                {
                    var k = Count - i - j - 1 >= 0 ? Count - i - j - 1 : 2 * Count - i - j - 1;
                    mul*= _matrix[k][j];
                }
                det -= mul;
            }
            return det;
        }

        public int FindRank()
        {
            int rank;
            TriangularCore(out rank);
            return rank;
        }

        public Matrix Transpose()
        {
            if (Count < 2) return this;

            var retMatrix = new Matrix(this);
            for (int i = 0; i < Count; i++)
            {
                for (int j = i + 1; j < Count; j++)
                {
                    (retMatrix[i, j], retMatrix[j, i]) = (retMatrix[j, i], retMatrix[i, j]);
                }
            }
            return retMatrix;
        }

        public Matrix Triangular()
        {
            int rank;
            return TriangularCore(out rank);
        }

    }
}
