using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_5.Core.Memento
{
    public class MatrixHistory
    {
        private Stack<IMatrixMemento> _history = new Stack<IMatrixMemento>();
        private Matrix _matrix = null;

        public MatrixHistory(Matrix matrix)
        {
            _matrix = matrix;
        }

        public void Backup()
        {
            _history.Push(_matrix.Save());
        }

        public void Undo()
        {
            if (_history.Count == 0)
                return;

            _history.Pop();
        }
    }
}
