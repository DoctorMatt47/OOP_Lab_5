using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_5.Core.Iterators
{
    public class MatrixEnumenator : IEnumerator
    {
        private Matrix _matrix;
        private int _column = -1;
        private int _row = -1;

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

        public MatrixEnumenator(Matrix matrix) => _matrix = matrix;

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

        public void Reset()
        {
            _column = -1;
            _row = -1;
        }
    }
}
