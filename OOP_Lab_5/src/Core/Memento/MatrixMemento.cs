using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_5.Core.Memento
{
    public class MatrixMemento : IMatrixMemento
    {
        public List<List<int>> Matrix { get; private set; }
        public int Count { get; private set; }

        public MatrixMemento(List<List<int>> matrix)
        {
            Matrix = matrix;
            Count = matrix.Count;
        }
    }
}
