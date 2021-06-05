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
        public Matrix Matrix { get; set; }

        public MatrixHistory(Matrix matrix)
        {
            Matrix = matrix;
        }

        public void Backup()
        {
            _history.Push(Matrix.Save());
        }

        public void Undo()
        {
            if (_history.Count == 0)
                return;

            Matrix.Restore(_history.Pop());
        }
    }
}
