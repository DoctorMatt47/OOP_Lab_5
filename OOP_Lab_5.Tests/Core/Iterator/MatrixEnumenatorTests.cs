using NUnit.Framework;
using OOP_Lab_5.Core;
using System.Collections.Generic;

namespace OOP_Lab_5.Tests.Core.Algoritms.Iterator
{
    public class MatrixEnumenatorTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Current_CurrentReturn_EqualsElement1()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{0, 1, 0},
                new List<long>{0, 0, 0},
                new List<long>{0, 0, 0}
            });
            var iterator = matrix1.GetEnumerator();
            iterator.MoveNext();
            iterator.MoveNext();
            var one = (long)iterator.Current;
            Assert.AreEqual(one, 1);
        }

        [Test]
        public void Foreach_isFinded_True()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{0, 0, 0},
                new List<long>{0, 0, 0},
                new List<long>{0, 1, 0}
            });
            bool isFinded = false;
            foreach (var elem in matrix1)
            {
                if ((long)elem == 1)
                    isFinded = true;
            }
            Assert.IsTrue(isFinded);
        }

        [Test]
        public void Foreach_isFinded_False()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{0, 0, 0},
                new List<long>{0, 0, 0},
                new List<long>{0, 1, 0}
            });
            bool isFinded = false;
            foreach (var elem in matrix1)
            {
                if ((long)elem == 2)
                    isFinded = true;
            }
            Assert.IsFalse(isFinded);
        }
    }
}
