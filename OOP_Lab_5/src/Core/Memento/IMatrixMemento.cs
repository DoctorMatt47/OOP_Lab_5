using System.Collections.Generic;

namespace OOP_Lab_5.Core.Memento
{
    /// <summary>
    /// Represents interface for matrix storage that can be used to restore matrix data.
    /// Implements memento pattern.
    /// </summary>
    public interface IMatrixMemento
    {
        /// <summary>
        /// Matrix elements.
        /// </summary>
        List<List<long>> Matrix { get; }

        /// <summary>
        /// Count of rows and columns.
        /// </summary>
        int Count { get; }
    }
}
