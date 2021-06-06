using NUnit.Framework;
using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Algorithms;
using System.Collections.Generic;

namespace OOP_Lab_5.Tests.Core.Algoritms.Library
{
    public class LibraryMultiplyTests
    {
        private IMultiply _algorithm;

        [SetUp]
        public void Setup()
        {
            _algorithm = new LibraryMultiply();
        }

        [Test]
        public void Multiply_Matrix_EqualsMultipliedMatrixes1()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{5, 2, 4},
                new List<long>{5, 3, 7},
                new List<long>{1, 5, 2}
            });
            var matrix2 = new Matrix(new List<List<long>>
            {
                new List<long>{2, 5, 3},
                new List<long>{6, 5, 5},
                new List<long>{2, 5, 3}
            });
            var matrix3Check = new Matrix(new List<List<long>>
            {
                new List<long>{30, 55, 37},
                new List<long>{42, 75, 51},
                new List<long>{36, 40, 34}
            });
            matrix1.MultiplyAlgorithm = _algorithm;
            matrix2.MultiplyAlgorithm = _algorithm;
            var matrix3 = matrix1 * matrix2;
            for (int i = 0; i < matrix3.Count; i++)
            {
                for (int j = 0; j < matrix3.Count; j++)
                {
                    Assert.AreEqual(matrix3[i, j], matrix3Check[i, j]);
                }
            }
        }

        [Test]
        public void Multiply_Matrix_EqualsMultipliedMatrixes2()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{1, 1, 2},
                new List<long>{0, 0, 0},
                new List<long>{0, 4, 0}
            });
            var matrix2 = new Matrix(new List<List<long>>
            {
                new List<long>{2, 5, 3},
                new List<long>{6, 5, 5},
                new List<long>{2, 5, 3}
            });
            var matrix3Check = new Matrix(new List<List<long>>
            {
                new List<long>{12, 20, 14},
                new List<long>{0, 0, 0},
                new List<long>{24, 20, 20}
            });
            matrix1.MultiplyAlgorithm = _algorithm;
            matrix2.MultiplyAlgorithm = _algorithm;
            var matrix3 = matrix1 * matrix2;
            for (int i = 0; i < matrix3.Count; i++)
            {
                for (int j = 0; j < matrix3.Count; j++)
                {
                    Assert.AreEqual(matrix3[i, j], matrix3Check[i, j]);
                }
            }
        }

        [Test]
        public void Multiply_Matrix_EqualsMultipliedMatrixes3()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{1, 1, 2},
                new List<long>{0, 5, 6},
                new List<long>{0, 4, 0}
            });
            var matrix2 = new Matrix(new List<List<long>>
            {
                new List<long>{2, 2, 3},
                new List<long>{6, 0, 5},
                new List<long>{2, 0, 3}
            });
            var matrix3Check = new Matrix(new List<List<long>>
            {
                new List<long>{12, 2, 14},
                new List<long>{42, 0, 43},
                new List<long>{24, 0, 20}
            });
            matrix1.MultiplyAlgorithm = _algorithm;
            matrix2.MultiplyAlgorithm = _algorithm;
            var matrix3 = matrix1 * matrix2;
            for (int i = 0; i < matrix3.Count; i++)
            {
                for (int j = 0; j < matrix3.Count; j++)
                {
                    Assert.AreEqual(matrix3[i, j], matrix3Check[i, j]);
                }
            }
        }

        [Test]
        public void Multiply_Matrix_EqualsMultipliedMatrixes4()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{1, 2, 5, 8, 9, 0},
                new List<long>{0, 5, 6, 7, 12, 3},
                new List<long>{0, 4, 0, 4, 8, 5},
                new List<long>{2, 4, 2, 2, 15, 3},
                new List<long>{7, 1, 0, 2, 5, 0},
                new List<long>{8, 2, 5, 43, 12, 4},
            });
            var matrix2 = new Matrix(new List<List<long>>
            {
                new List<long>{3, 2, 5, 8, 9, 0},
                new List<long>{0, 7, 6, 7, 12, 3},
                new List<long>{0, 4, 2, 4, 8, 5},
                new List<long>{2, 4, 2, 4, 15, 3},
                new List<long>{7, 1, 0, 2, 7, 0},
                new List<long>{8, 2, 5, 43, 12, 6},
            });
            var matrix3Check = new Matrix(new List<List<long>>
            {
                new List<long>{82, 77, 43, 92, 256, 55},
                new List<long>{122, 105, 71, 240, 333, 84},
                new List<long>{104, 62, 57, 275, 224, 54},
                new List<long>{139, 69, 57, 219, 253, 46},
                new List<long>{60, 34, 45, 81, 140, 9},
                new List<long>{226, 242, 168, 466, 913, 184}
            });
            matrix1.MultiplyAlgorithm = _algorithm;
            matrix2.MultiplyAlgorithm = _algorithm;
            var matrix3 = matrix1 * matrix2;
            for (int i = 0; i < matrix3.Count; i++)
            {
                for (int j = 0; j < matrix3.Count; j++)
                {
                    Assert.AreEqual(matrix3[i, j], matrix3Check[i, j]);
                }
            }
        }
    }
}
