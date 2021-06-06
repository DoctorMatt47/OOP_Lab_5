using NUnit.Framework;
using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Memento;
using System.Collections.Generic;

namespace OOP_Lab_5.Tests.Core.Memento
{
    public class MementoTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Restore_Matrix_EqualsToItself()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{0, 1, 0},
                new List<long>{0, 2, 4},
                new List<long>{0, 3, 0}
            });
            var matrixCheck = new Matrix(new List<List<long>>
            {
                new List<long>{0, 1, 0},
                new List<long>{0, 2, 4},
                new List<long>{0, 3, 0}
            });
            var memento = matrix1.Save();
            matrix1[0, 0] = 1;
            matrix1.Restore(memento);
            Assert.AreEqual(matrix1, matrixCheck);
        }

        [Test]
        public void MatrixHistory_Matrix_EqualsToItself()
        {
            var matrix1 = new Matrix(new List<List<long>>
            {
                new List<long>{0, 3, 0},
                new List<long>{0, 2, 0},
                new List<long>{0, 1, 0}
            });
            var matrixCheck = new Matrix(new List<List<long>>
            {
                new List<long>{0, 3, 0},
                new List<long>{0, 2, 0},
                new List<long>{0, 1, 0}
            });
            var history = new MatrixHistory(matrix1);
            history.Backup();
            history.Matrix[0, 0] = 1;
            history.Backup();
            history.Matrix[0, 0] = 2;
            history.Undo();
            history.Undo();
            Assert.AreEqual(history.Matrix, matrixCheck);
        }
    }
}
