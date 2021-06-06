using NUnit.Framework;
using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Algorithms;
using System.Collections.Generic;

namespace OOP_Lab_5.Tests.Core.Algoritms.Library
{
    public class LibraryFindDeterminantTests
    {
        private IFindDeterminant _algorithm;

        [SetUp]
        public void Setup()
        {
            _algorithm = new LibraryFindDeterminant();
        }

        [Test]
        public void FindDeterminant_Det_EqualsZero()
        {
            var matrix = new Matrix(new List<List<long>>
            {
                new List<long>{1, 2, 3},
                new List<long>{2, 3, 4},
                new List<long>{3, 4, 5}
            });
            matrix.FindDeterminantAlgorithm = _algorithm;
            Assert.Zero(matrix.FindDeterminant());
        }

        [Test]
        public void FindDeterminant_Det_EqualsMinus20()
        {
            var matrix = new Matrix(new List<List<long>>
            {
                new List<long>{1, 1, 2},
                new List<long>{3, 5, 8},
                new List<long>{13, 21, 24}
            });
            matrix.FindDeterminantAlgorithm = _algorithm;
            Assert.AreEqual(matrix.FindDeterminant(), -20);
        }

        [Test]
        public void FindDeterminant_Det_Equals11()
        {
            var matrix = new Matrix(new List<List<long>>
            {
                new List<long>{-5, -4, -3},
                new List<long>{6, 7, 8},
                new List<long>{2, 1, -1}
            });
            matrix.FindDeterminantAlgorithm = _algorithm;
            Assert.AreEqual(matrix.FindDeterminant(), 11);
        }
    }
}
