using System;
using System.Collections;
using System.Collections.Generic;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Core.Iterators;
using OOP_Lab_5.Core.Memento;
using OOP_Lab_5.Core.Prototype;

namespace OOP_Lab_5.Core
{
    /// <summary>
    /// Represents square matrix and basic operations with it.
    /// </summary>
    public class Matrix : IEnumerable, IPrototype
    {
        /// <summary>
        /// 2d square list, consists of matrix elements.
        /// </summary>
        private List<List<long>> _matrix;

        /// <summary>
        /// Count of rows and columns in matrix.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Find determinant algorithm.
        /// Used in FindDeterminant method.
        /// Implements strategy pattern.
        /// </summary>
        public IFindDeterminant FindDeterminantAlgorithm { private get; set; }

        /// <summary>
        /// Find rank algorithm.
        /// Used in FindRank method.
        /// Implements strategy pattern.
        /// </summary>
        public IFindRank FindRankAlgorithm { private get; set; }

        /// <summary>
        /// Triangular algorithm.
        /// Used in Triangular method.
        /// Implements strategy pattern.
        /// </summary>
        public ITriangular TriangularAlgorithm { private get; set; }

        /// <summary>
        /// Triangular algorithm.
        /// Used in overloaded multiply operator and in Square method.
        /// Implements strategy pattern.
        /// </summary>
        public IMultiply MultiplyAlgorithm { private get; set; }

        /// <summary>
        /// Constructs Matrix with passed 2d array.
        /// </summary>
        /// <param name="matrix">2d square array used to initialize matrix.</param>
        public Matrix(long[,] matrix)
        {
            if (matrix.Length > 0 && matrix.GetLength(0) == matrix.GetLength(1))
                throw new ArgumentException();

            Count = matrix.Length;
            _matrix = new List<List<long>>(Count);
            for (int i = 0; i < Count; i++)
            {
                _matrix.Add(new List<long>(Count));
                for (int j = 0; j < Count; j++)
                {
                    _matrix[i].Add(matrix[i, j]);
                }
            }
        }

        /// <summary>
        /// Constructs Matrix with passed 2d list.
        /// </summary>
        /// <param name="matrix">2d square list used to initialize matrix.</param>
        public Matrix(List<List<long>> matrix)
        {
            if (matrix.Count > 0 && matrix.Count != matrix[0].Count)
                throw new ArgumentException("Matrix is not square");

            _matrix = matrix;
            Count = matrix.Count;
        }

        /// <summary>
        /// Constructs square zero matrix with passed count of rows and columns.
        /// </summary>
        /// <param name="count">Count of rows and columns to initialize matrix.</param>
        public Matrix(int count)
        {
            if (count < 0)
                throw new ArgumentException("Count must not be negative");

            Count = count;
            _matrix = new List<List<long>>(Count);
            for (int i = 0; i < Count; i++)
            {
                _matrix.Add(new List<long>(Count));
                for (int j = 0; j < Count; j++)
                {
                    _matrix[i].Add(0);
                }
            }
        }

        /// <summary>
        /// Constructs matrix that equals to passed.
        /// </summary>
        /// <param name="other">Other matrix, values of it are used to initialize this matrix.</param>
        public Matrix(Matrix other)
        {
            Count = other.Count;

            _matrix = new List<List<long>>(Count);
            for (int i = 0; i < Count; i++)
            {
                _matrix.Add(new List<long>(Count));
                for (int j = 0; j < Count; j++)
                {
                    _matrix[i].Add(other[i, j]);
                }
            }
        }

        /// <summary>
        /// Overloaded unary subtraction operator.
        /// Gets new matrix that equals to passed matrix multiplied by -1.
        /// </summary>
        /// <param name="matrix">Matrix argument that will be multiplied by -1.</param>
        /// <returns>New matrix that equals to passed matrix multiplied by -1.</returns>
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

        /// <summary>
        /// Overloaded binary addition operator.
        /// Gets new matrix that equals to addition of passed matrixes.
        /// </summary>
        /// <param name="left">Left matrix argument of matrix addition operation.</param>
        /// <param name="right">Right matrix argument of matrix addition operation.</param>
        /// <returns>New matrix that equals to addition of passed matrixes.</returns>
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

        /// <summary>
        /// Overloaded binary subtraction operator.
        /// Gets new matrix that equals to subtraction of passed matrixes.
        /// </summary>
        /// <param name="left">Left matrix argument of matrix subtraction operation.</param>
        /// <param name="right">Right matrix argument of matrix subtraction operation.</param>
        /// <returns>New matrix that equals to subtraction of passed matrixes.</returns>
        public static Matrix operator -(Matrix left, Matrix right)
        {
            return left + (-right);
        }

        /// <summary>
        /// Overloaded multiplication operator. 
        /// Gets new matrix that equals to multiplication of passed matrixes.
        /// Uses strategy pattern and MultiplyAlgorithm variable.
        /// If MultiplyAlgorithm variable was not initialized or is null,
        /// it will be assigned with NativeMultiply instance.
        /// </summary>
        /// <param name="left">Left matrix argument of matrix multiplication operation.</param>
        /// <param name="right">Right matrix argument of matrix multiplication operation.</param>
        /// <returns>New matrix that equals to multiplication of passed matrixes.</returns>
        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (left.MultiplyAlgorithm is null)
                left.MultiplyAlgorithm = new NativeMultiply();
            return left.MultiplyAlgorithm.Execute(left, right);
        }

        /// <summary>
        /// Overloaded multiplication operator. 
        /// Gets new matrix that equals to passed matrix multiplicated by passed scalar value.
        /// </summary>
        /// <param name="left">Left matrix argument of matrix multiplication on scalar operation.</param>
        /// <param name="right">Scalar value.</param>
        /// <returns>New matrix that equals to passed matrix multiplicated by passed scalar value.</returns>
        public static Matrix operator *(Matrix left, long right)
        {
            var retMatrix = new Matrix(left.Count);
            for (int i = 0; i < left.Count; i++)
            {
                for (int j = 0; j < left.Count; j++)
                {
                    retMatrix[i, j] = left[i, j] * right;
                }
            }
            return retMatrix;
        }

        /// <summary>
        /// Overloaded multiplication operator. 
        /// Gets new matrix that equals to passed matrix multiplicated by passed scalar value.
        /// </summary>
        /// <param name="left">Scalar value.</param>
        /// <param name="right">Left matrix argument of matrix multiplication on scalar operation.</param>
        /// <returns>New matrix that equals to passed matrix multiplicated by passed scalar value.</returns>
        public static Matrix operator *(long left, Matrix right)
        {
            return right * left;
        }

        /// <summary>
        /// Overloaded indexer operator.
        /// Gets access to element of matrix with indexes i and j.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public long this[int i, int j]
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

        /// <summary>
        /// Overrided equals method.
        /// Checks, if this and passed object are equals.
        /// </summary>
        /// <param name="otherObject">Passed object will be checked, if it equals to this object.</param>
        /// <returns>True if this and passed object are equals, false if not.</returns>
        public override bool Equals(object otherObject)
        {
            if (otherObject is Matrix other)
            {
                if (Count != other.Count)
                    return false;

                for (int i = 0; i < Count; i++)
                {
                    for (int j = 0; j < Count; j++)
                    {
                        if (this[i, j] != other[i, j])
                            return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Overrided GetHashCode method.
        /// <exception cref="System.NotImplementedException">This method is not implemented</exception>
        /// </summary>
        /// <returns>Hash code of this object</returns>
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets 2d list with matrix elements.
        /// </summary>
        /// <returns>2d list with matrix elements</returns>
        public List<List<long>> GetList() => new List<List<long>>(_matrix);

        /// <summary>
        /// Gets 2d array with matrix elements.
        /// </summary>
        /// <returns>2d array with matrix elements.</returns>
        public long[,] GetArray()
        {
            var array = new long[Count, Count];
            for (int i = 0; i < Count; i++)
            {
                _matrix.Add(new List<long>(Count));
                for (int j = 0; j < Count; j++)
                {
                    array[i, j] = this[i, j];
                }
            }
            return array;
        }

        /// <summary>
        /// Finds determinant of this matrix.
        /// Uses strategy pattern and FindDeterminantAlgorithm variable.
        /// If FindDeterminantAlgorithm variable was not initialized or is null,
        /// it will be assigned with NativeFindDeterminant instance.
        /// </summary>
        /// <returns>Return determinant of matrix</returns>
        /// <example>
        /// <code>
        /// var matrix = new Matrix(...);
        /// matrix.FindDeterminantAlgorithm = new LibraryFindDeterminant();
        /// var det = matrix.FindDeterminant();
        /// </code>
        /// </example>
        public long FindDeterminant()
        {
            if (FindDeterminantAlgorithm is null)
                FindDeterminantAlgorithm = new NativeFindDeterminant();
            return FindDeterminantAlgorithm.Execute(this);
        }

        /// <summary>
        /// Finds determinant of this matrix.
        /// Uses strategy pattern and FindRankAlgorithm variable.
        /// If FindRankAlgorithm variable was not initialized or is null,
        /// it will be assigned with NativeFindRank instance.
        /// </summary>
        /// <returns>Return rank of matrix</returns>
        /// <example>
        /// <code>
        /// var matrix = new Matrix(...);
        /// matrix.FindRankAlgorithm = new LibraryFindRank();
        /// var rank = matrix.FindRank();
        /// </code>
        /// </example>
        public int FindRank()
        {
            if (FindRankAlgorithm is null)
                FindRankAlgorithm = new NativeFindRank();
            return FindRankAlgorithm.Execute(this);
        }

        /// <summary>
        /// Gets new matrix with changed count of rows and columns.
        /// </summary>
        /// <param name="count">Count of rows and columns in new matrix.</param>
        /// <returns>New matrix with changed count of rows and columns.</returns>
        public Matrix ChangeCount(int count)
        {
            var matrix = new Matrix(count);
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    matrix[i, j] = i < Count && j < Count ? this[i, j] : 0;
                }
            }
            return matrix;
        }

        /// <summary>
        /// Gets new triangular matrix of this.
        /// Uses strategy pattern and TriangularAlgorithm variable.
        /// If TriangularAlgorithm variable was not initialized or is null,
        /// it will be assigned with NativeTriangular instance.
        /// </summary>
        /// <returns>New triangular matrix based on this.</returns>
        /// <example>
        /// <code>
        /// var matrix = new Matrix(...);
        /// matrix.TriangularAlgorithm = new LibraryTriangular();
        /// var triangularMatrix = matrix.FindTriangular();
        /// </code>
        /// </example>
        public Matrix Triangular()
        {
            if (TriangularAlgorithm is null)
                TriangularAlgorithm = new NativeTriangular();

            return TriangularAlgorithm.Execute(this);
        }

        /// <summary>
        /// Gets new transposed matrix of this.
        /// </summary>
        /// <returns>New transposed matrix of this.</returns>
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

        /// <summary>
        /// Gets new matrix that equals to this powered by two.
        /// Uses strategy pattern and MultiplyAlgorithm variable.
        /// If MultiplyAlgorithm variable was not initialized or is null,
        /// it will be assigned with NativeMultiply instance.
        /// </summary>
        /// <returns>New matrix that equals to this powered by two.</returns>
        /// <example>
        /// <code>
        /// var matrix = new Matrix(...);
        /// matrix.MultiplyAlgorithm = new LibraryMultiply();
        /// var squareMatrix = matrix.Square();
        /// </code>
        /// </example>
        public Matrix Square()
        {
            return this * this;
        }

        /// <summary>
        /// Gets prototype of this matrix.
        /// Uses prototype pattern.
        /// </summary>
        /// <returns>Prototype of this matrix.</returns>
        /// <example>
        /// <code>
        /// var matrix = new Matrix(...);
        /// var prototype = matrix.Clone();
        /// var matrixCloned = (Matrix)prototype;
        /// </code>
        /// </example>
        public IPrototype Clone()
        {
            return new Matrix(this);
        }

        /// <summary>
        /// Gets enumenator of this matrix.
        /// It allows to use foreach loop with instances of this class.
        /// Uses iterator pattern.
        /// </summary>
        /// <returns>Enumenator of this matrix.</returns>
        /// <example>
        /// <code>
        /// var matrix = new Matrix(...);
        /// foreach (element in matrix)
        /// {
        /// ...
        /// }
        /// </code>
        /// </example>
        public IEnumerator GetEnumerator()
        {
            return new MatrixEnumenator(this);
        }

        /// <summary>
        /// Gets memento of this matrix.
        /// Uses memento pattern.
        /// </summary>
        /// <returns>Memento of this matrix.</returns>
        /// <example>
        /// <code>
        /// var matrix = new Matrix(...);
        /// var matrixMemento = matrix.Save();
        /// ...
        /// matrix.Restore(matrixMemento);
        /// </code>
        /// </example>
        public IMatrixMemento Save()
        {
            var newMatrix = Clone();
            return new MatrixMemento(((Matrix)newMatrix)._matrix);
        }

        /// <summary>
        /// Restores this matrix, using memento pattern.
        /// </summary>
        /// <param name="memento">Memento instance to restore matrix.</param>
        /// <example>
        /// <code>
        /// var matrix = new Matrix(...);
        /// var matrixMemento = matrix.Save();
        /// ...
        /// matrix.Restore(matrixMemento);
        /// </code>
        /// </example>
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
