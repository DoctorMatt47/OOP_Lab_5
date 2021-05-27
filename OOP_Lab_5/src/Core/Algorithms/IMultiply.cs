using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_5.Core.Algorithms
{
    public interface IMultiply
    {
        Matrix Execute(Matrix left, Matrix right);
    }
}
