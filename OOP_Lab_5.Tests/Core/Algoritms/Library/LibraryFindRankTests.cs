using NUnit.Framework;
using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Algorithms;
using System.Collections.Generic;

namespace OOP_Lab_5.Tests.Core.Algoritms.Library
{
    public class LibraryFindRankTests
    {
        private IFindRank _algorithm;

        [SetUp]
        public void Setup()
        {
            _algorithm = new LibraryFindRank();
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
            matrix.FindRankAlgorithm = _algorithm;
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
            matrix.FindRankAlgorithm = _algorithm;
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
            matrix.FindRankAlgorithm = _algorithm;
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
            matrix.FindRankAlgorithm = _algorithm;
            Assert.AreEqual(matrix.FindRank(), 0);
        }
    }
}
