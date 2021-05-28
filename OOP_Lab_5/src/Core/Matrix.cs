using System;
using System.Collections;
using System.Collections.Generic;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Core.Iterators;

namespace OOP_Lab_5.Core
{
    public class Matrix : IEnumerable
    {
        private List<List<int>> _matrix;

        public int Count { get; }

        public IFindDeterminant FindDeterminantAlgorithm { private get; set; }

        public IFindRank FindRankAlgorithm { private get; set; }

        public IMultiply MultiplyAlgorithm { private get; set; }

        public Matrix(int[,] matrix)
        {
            if (matrix.Length > 0 && matrix.GetLength(0) == matrix.GetLength(1))
                throw new ArgumentException();

            Count = matrix.Length;
            _matrix = new List<List<int>>(Count);
            for (int i = 0; i < Count; i++)
            {
                _matrix.Add(new List<int>(Count));
                for (int j = 0; j < Count; j++)
                {
                    _matrix[i].Add(matrix[i, j]);
                }
            }
        }

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

        public int this[int i, int j]
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

        public List<List<int>> GetList() => new List<List<int>>(_matrix);

        public int[,] GetArray()
        {
            var array = new int[Count, Count];
            for (int i = 0; i < Count; i++)
            {
                _matrix.Add(new List<int>(Count));
                for (int j = 0; j < Count; j++)
                {
                    array[i, j] = this[i, j];
                }
            }
            return array;
        }

        public int FindDeterminant()
        {
            if (FindDeterminantAlgorithm == null)
                FindDeterminantAlgorithm = new MyFindDeterminant();
            return FindDeterminantAlgorithm.Execute(this);
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

        public Matrix Square()
        {
            return this * this;
        }

        public IEnumerator GetEnumerator()
        {
            return new MatrixEnumenator(this);
        }
    }
}
