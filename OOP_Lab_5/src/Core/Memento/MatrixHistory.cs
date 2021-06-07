using System.Collections.Generic;

namespace OOP_Lab_5.Core.Memento
{
    /// <summary>
    /// Represents storage of matrixes that can be used to restore and backup matrixes.
    /// Implements memento pattern.
    /// </summary>
    public class MatrixHistory
    {
        /// <summary>
        /// History of matrix changes.
        /// </summary>
        private Stack<IMatrixMemento> _history = new Stack<IMatrixMemento>();
        
        /// <summary>
        /// Encapsulated matrix.
        /// </summary>
        public Matrix Matrix { get; set; }

        /// <summary>
        /// Constructs MatrixHistory instance.
        /// </summary>
        /// <param name="matrix">Matrix to be encapsulated</param>
        public MatrixHistory(Matrix matrix)
        {
            Matrix = matrix;
        }

        /// <summary>
        /// Backups matrix data to the storage.
        /// </summary>
        public void Backup()
        {
            _history.Push(Matrix.Save());
        }

        /// <summary>
        /// Restore matrix data, undoes to the last backup.
        /// </summary>
        public void Undo()
        {
            if (_history.Count == 0)
                return;

            Matrix.Restore(_history.Pop());
        }
    }
}
