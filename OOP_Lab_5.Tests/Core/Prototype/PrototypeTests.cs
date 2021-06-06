using NUnit.Framework;
using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Prototype;
using OOP_Lab_5.Core.Algorithms;
using System.Collections.Generic;

namespace OOP_Lab_5.Tests.Core.Algoritms.Prototypes
{
    public class PrototypeTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Clone_EqualsReturn_True()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{5, 2, 4},
                new List<long>{5, 3, 7},
                new List<long>{1, 5, 2}
            });
            var matrix2 = matrix1.Clone();
            Assert.IsTrue(matrix1.Equals((Matrix)matrix2));
        }
    }
}
