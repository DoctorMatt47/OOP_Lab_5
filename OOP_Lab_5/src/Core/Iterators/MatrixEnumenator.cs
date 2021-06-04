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
        private int _i = -1;
        private int _j = -1;

        public object Current
        {
            get
            {
                if (_j == -1 || _i == -1)
                    throw new InvalidOperationException();
                return _matrix[_i, _j];
            }
            set
            {
                if (_j == -1 || _i == -1)
                    throw new InvalidOperationException();
                _matrix[_i, _j] = (long)value;
            }
        }

        public MatrixEnumenator(Matrix matrix) => _matrix = matrix;

        public bool MoveNext() 
        {
            _i = _i < _matrix.Count - 1 ? _i++ : 0;
            _j = _j < _matrix.Count - 1 ? _j++ : -1;
            if (_j == -1)
                return false;
            return true;
        }

        public void Reset()
        {
            _i = -1;
            _j = -1;
        }
    }
}
