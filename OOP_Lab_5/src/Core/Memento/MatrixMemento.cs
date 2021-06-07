using System.Collections.Generic;

namespace OOP_Lab_5.Core.Memento
{
    /// <summary>
    /// Represents matrix storage that can be used to restore matrix data.
    /// Implements IMatrixMemento interface.
    /// </summary>
    public class MatrixMemento : IMatrixMemento
    {
        /// <summary>
        /// Matrix elements.
        /// </summary>
        public List<List<long>> Matrix { get; private set; }

        /// <summary>
        /// Count of rows and columns.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Constructs MatrixMemento instance.
        /// </summary>
        /// <param name="matrix">Elements of matrix to be stored.</param>
        public MatrixMemento(List<List<long>> matrix)
        {
            Matrix = matrix;
            Count = matrix.Count;
        }
    }
}
