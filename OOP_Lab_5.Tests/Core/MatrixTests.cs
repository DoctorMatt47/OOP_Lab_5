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
        public void Transpose_Matrix_EqualsTransposeMatrix1()
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
        public void Transpose_Matrix_EqualsTransposeMatrix2()
        {
            var matrix = new Matrix(new List<List<long>>
            {
                new List<long>{1, 1, 2, 12},
                new List<long>{3, 5, 8, 75},
                new List<long>{13, 21, 24, 4},
                new List<long>{10, 22, 4, 3}
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
        public void MultiplyOnScalar_Matrix_EqualsMatrixMultipliedBy2()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{5, 2, 4},
                new List<long>{5, 3, 7},
                new List<long>{1, 5, 2}
            });
            var matrix2 = matrix1 * 2;
            for (int i = 0; i < matrix2.Count; i++)
            {
                for (int j = 0; j < matrix2.Count; j++)
                {
                    Assert.AreEqual(matrix2[i, j], matrix1[i, j] * 2);
                }
            }
        }

        [Test]
        public void MultiplyOnScalar_Matrix_EqualsMatrixMultipliedBy5()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{5, 0, 3, 4},
                new List<long>{24, 1, 5, 3},
                new List<long>{0, 5, 5, 7},
                new List<long>{3, 3, 0, 8}
            });
            var matrix2 = matrix1 * 5;
            for (int i = 0; i < matrix2.Count; i++)
            {
                for (int j = 0; j < matrix2.Count; j++)
                {
                    Assert.AreEqual(matrix2[i, j], matrix1[i, j] * 5);
                }
            }
        }

        [Test]
        public void Addition_Matrix_EqualsAddedMatrixes1()
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
                new List<long>{7, 7, 7},
                new List<long>{11, 8, 12},
                new List<long>{3, 10, 5}
            });
            var matrix3 = matrix1 + matrix2;
            for (int i = 0; i < matrix3.Count; i++)
            {
                for (int j = 0; j < matrix3.Count; j++)
                {
                    Assert.AreEqual(matrix3[i, j], matrix3Check[i, j]);
                }
            }
        }

        [Test]
        public void Addition_Matrix_EqualsAddedMatrixes2()
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
                new List<long>{4, 4, 10, 16, 18, 0},
                new List<long>{0, 12, 12, 14, 24, 6},
                new List<long>{0, 8, 2, 8, 16, 10},
                new List<long>{4, 8, 4, 6, 30, 6},
                new List<long>{14, 2, 0, 4, 12, 0},
                new List<long>{16, 4, 10, 86, 24, 10,}
            });
            var matrix3 = matrix1 + matrix2;
            for (int i = 0; i < matrix3.Count; i++)
            {
                for (int j = 0; j < matrix3.Count; j++)
                {
                    Assert.AreEqual(matrix3[i, j], matrix3Check[i, j]);
                }
            }
        }

        [Test]
        public void Difference_Matrix_EqualsDifferencedMatrixes1()
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
                new List<long>{3, -3, 1},
                new List<long>{-1, -2, 2},
                new List<long>{-1, 0, -1}
            });
            var matrix3 = matrix1 - matrix2;
            for (int i = 0; i < matrix3.Count; i++)
            {
                for (int j = 0; j < matrix3.Count; j++)
                {
                    Assert.AreEqual(matrix3[i, j], matrix3Check[i, j]);
                }
            }
        }

        [Test]
        public void Difference_Matrix_EqualsDifferencedMatrixes2()
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
                new List<long> { -2, 0, 0, 0, 0, 0 },
                new List<long> { 0, -2, 0, 0, 0, 0 },
                new List<long> { 0, 0, -2, 0, 0, 0 },
                new List<long> { 0, 0, 0, -2, 0, 0 },
                new List<long> { 0, 0, 0, 0, -2, 0 },
                new List<long> { 0, 0, 0, 0, 0, -2 }
            });
            var matrix3 = matrix1 - matrix2;
            for (int i = 0; i < matrix3.Count; i++)
            {
                for (int j = 0; j < matrix3.Count; j++)
                {
                    Assert.AreEqual(matrix3[i, j], matrix3Check[i, j]);
                }
            }
        }

        [Test]
        public void Equals_Matrix_True()
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
                new List<long>{1, 2, 5, 8, 9, 0},
                new List<long>{0, 5, 6, 7, 12, 3},
                new List<long>{0, 4, 0, 4, 8, 5},
                new List<long>{2, 4, 2, 2, 15, 3},
                new List<long>{7, 1, 0, 2, 5, 0},
                new List<long>{8, 2, 5, 43, 12, 4},
            });
            Assert.IsTrue(matrix1.Equals(matrix2));
        }

        [Test]
        public void Equals_Matrix_False()
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
                new List<long>{1, 2, 5, 8, 9, 0},
                new List<long>{0, 5, 6, 7, 12, 3},
                new List<long>{0, 4, 0, 4, 8, 5},
                new List<long>{2, 4, 2, 2, 15, 3},
                new List<long>{7, 1, 0, 2, 5, 2},
                new List<long>{8, 2, 5, 43, 12, 4},
            });
            Assert.IsFalse(matrix1.Equals(matrix2));
        }
    }
}