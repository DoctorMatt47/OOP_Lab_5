using NUnit.Framework;
using OOP_Lab_5.Core;
using System.Collections.Generic;

namespace OOP_Lab_5.Tests
{
    public class MatrixTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Matrix_ZeroMatrix()
        {
            var matrix = new Matrix(4);
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix.Count; j++)
                {
                    Assert.AreEqual(matrix[i, j], 0);
                }
            }
        }

        [Test]
        public void FindDeterminant_Det_EqualsZero()
        {
            var matrix = new Matrix(new List<List<int>>
            {
                new List<int>{1, 2, 3},
                new List<int>{2, 3, 4},
                new List<int>{3, 4, 5}
            });
            Assert.Zero(matrix.FindDeterminant());
        }

        [Test]
        public void FindDeterminant_Det_EqualsMinus20()
        {
            var matrix = new Matrix(new List<List<int>>
            {
                new List<int>{1, 1, 2},
                new List<int>{3, 5, 8},
                new List<int>{13, 21, 34}
            });
            Assert.Zero(matrix.FindDeterminant());
        }
    }
}