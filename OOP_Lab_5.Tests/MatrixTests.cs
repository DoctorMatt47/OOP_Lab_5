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
            var matrix = new Matrix(new List<List<long>>
            {
                new List<long>{1, 2, 3},
                new List<long>{2, 3, 4},
                new List<long>{3, 4, 5}
            });
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
            Assert.AreEqual(matrix.FindDeterminant(), 11);
        }

        [Test]
        public void Transpose_Matrix_EqualsTransposeMatrix()
        {
            var matrix = new Matrix(new List<List<long>>
            {
                new List<long>{1, 1, 2},
                new List<long>{3, 5, 8},
                new List<long>{13, 21, 24}
            });
            var matrixT = matrix.Transpose();
            for (int i = 0; i < matrix.Count; i++)
            {
                for (int j = 0; j < matrix.Count; j++)
                {
                    Assert.AreEqual(matrix[i, j], matrixT[j, i]);
                }
            }
        }

        [Test]
        public void FindRank_Rank_Equals3()
        {
            var matrix = new Matrix(new List<List<long>>
            {
                new List<long>{1, 2, 3},
                new List<long>{3, 1, 2},
                new List<long>{2, 3, 1}
            });
            Assert.AreEqual(matrix.FindRank(), 3);
        }

        [Test]
        public void FindRank_Rank_Equals2()
        {
            var matrix = new Matrix(new List<List<long>>
            {
                new List<long>{1, 2, 2, 3},
                new List<long>{3, 4, 4, 5},
                new List<long>{5, 6, 6, 7},
                new List<long>{0, 0, 0, 0}
            });
            Assert.AreEqual(matrix.FindRank(), 2);
        }

        [Test]
        public void FindRank_Rank_Equals1()
        {
            var matrix = new Matrix(new List<List<long>>
            {
                new List<long>{1, 2, 3, 4},
                new List<long>{2, 4, 6, 8},
                new List<long>{0, 0, 0, 0},
                new List<long>{0, 0, 0, 0}
            });
            Assert.AreEqual(matrix.FindRank(), 1);
        }

        [Test]
        public void FindRank_Rank_Equals0()
        {
            var matrix = new Matrix(new List<List<long>>
            {
                new List<long>{0, 0, 0},
                new List<long>{0, 0, 0},
                new List<long>{0, 0, 0}
            });
            Assert.AreEqual(matrix.FindRank(), 0);
        }
    }
}