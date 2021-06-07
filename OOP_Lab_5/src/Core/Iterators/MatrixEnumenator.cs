using System;
using System.Collections;

namespace OOP_Lab_5.Core.Iterators
{
    /// <summary>
    /// Represents matrix iterator.
    /// Provides access to matrix elements.
    /// Implements IEnumerator interface.
    /// Implements iterator pattern.
    /// </summary>
    public class MatrixEnumenator : IEnumerator
    {
        /// <summary>
        /// Encapsulated matrix instance.
        /// </summary>
        private Matrix _matrix;

        /// <summary>
        /// Column iterator.
        /// </summary>
        private int _column = -1;

        /// <summary>
        /// Row iterator.
        /// </summary>
        private int _row = -1;

        /// <summary>
        /// Provides access to element with _row and _column indexes.
        /// </summary>
        public object Current
        {
            get
            {
                if (_row == -1 || _column == -1)
                    throw new InvalidOperationException();
                return _matrix[_row, _column];
            }
            set
            {
                if (_row == -1 || _column == -1)
                    throw new InvalidOperationException();
                _matrix[_row, _column] = (long)value;
            }
        }

        /// <summary>
        /// Constructs MatrixEnumenator instance.
        /// </summary>
        /// <param name="matrix">Matrix to be encapsulated.</param>
        public MatrixEnumenator(Matrix matrix) => _matrix = matrix;

        /// <summary>
        /// Moves iterator to next position.
        /// </summary>
        /// <returns>False if collection is ended, true if is not</returns>
        public bool MoveNext() 
        {
            if (_column == -1 && _row == -1)
            {
                _column = 0;
                _row = 0;
            }
            else if (_column < _matrix.Count - 1)
            {
                _column++;
            }
            else if (_column == _matrix.Count - 1 && _row != _matrix.Count - 1)
            {
                _column = 0;
                _row++;
            }
            else if (_column == _matrix.Count - 1 && _row == _matrix.Count - 1)
            {
                _column = -1;
                _row = -1;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Moves iterator to begin.
        /// </summary>
        public void Reset()
        {
            _column = -1;
            _row = -1;
        }
    }
}
