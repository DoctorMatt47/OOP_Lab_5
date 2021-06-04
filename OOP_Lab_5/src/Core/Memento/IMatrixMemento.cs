using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_5.Core.Memento
{
    public interface IMatrixMemento
    {
        List<List<long>> Matrix { get; }
        int Count { get; }
    }
}
