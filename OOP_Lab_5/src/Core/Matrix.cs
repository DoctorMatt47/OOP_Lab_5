using System;
using System.Collections;
using System.Collections.Generic;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Core.Iterators;
using OOP_Lab_5.Core.Memento;
using OOP_Lab_5.Core.Prototype;

namespace OOP_Lab_5.Core
{
    public class Matrix : IEnumerable, IPrototype
    {
        private List<List<int>> _matrix;
        public int Count { get; private set; }
        public IFindDeterminant FindDeterminantAlgorithm { private get; set; }
        public IFindRank FindRankAlgorithm { private get; set; }
        public ITriangular TriangularAlgorithm { private get; set; }
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
                throw new ArgumentException("Matrix is not square");

            _matrix = matrix;
            Count = matrix.Count;
        }

        public Matrix(int count)
        {
            if (count < 0)
                throw new ArgumentException("Count must not be negative");

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
                throw new ArgumentException("Matrix is not square");

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
            if (left.MultiplyAlgorithm is null)
                left.MultiplyAlgorithm = new NativeMultiply();
            return left.MultiplyAlgorithm.Execute(left, right);
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
            if (FindDeterminantAlgorithm is null)
                FindDeterminantAlgorithm = new NativeFindDeterminant();
            return FindDeterminantAlgorithm.Execute(this);
        }

        public int FindRank()
        {
            if (FindRankAlgorithm is null)
                FindRankAlgorithm = new NativeFindRank();
            return FindRankAlgorithm.Execute(this);
        }

        public Matrix Triangular()
        {
            if (TriangularAlgorithm is null)
                TriangularAlgorithm = new NativeTriangular();

            return TriangularAlgorithm.Execute(this);
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

        public Matrix Square()
        {
            return this * this;
        }

        public IPrototype Clone()
        {
            return new Matrix(this);
        }

        public IEnumerator GetEnumerator()
        {
            return new MatrixEnumenator(this);
        }

        public IMatrixMemento Save()
        {
            return new MatrixMemento(_matrix);
        }

        public void Restore(IMatrixMemento memento)
        {
            if (memento is not MatrixMemento)
            {
                throw new Exception("Unknown memento class " +
                    memento.ToString());
            }
            _matrix = memento.Matrix;
            Count = memento.Count;
        }
    }
}
