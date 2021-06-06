using System.Linq;
using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Memento;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Data.Entities;
using OOP_Lab_5.Data;
using System.Data;
using OOP_Lab_5.Core.Prototype;
using OOP_Lab_5.Facade;

namespace OOP_Lab_5.Facade
{
    public class MatrixFacade : IMatrixFacade
    {
        private readonly DatabaseContext _db = new DatabaseContext();
        private MatrixHistory _history;

        public Matrix Matrix
        {
            get 
            {
                return _history.Matrix;
            }
            private set
            {
                _history.Matrix = value;
            }
        }

        public MatrixFacade(Matrix matrix)
        {
            _history = new MatrixHistory(matrix);
        }

        public virtual void Transpose()
        {
            _history.Backup();
            Matrix = Matrix.Transpose();
        }

        public virtual long Determinant(IFindDeterminant det)
        {
            Matrix.FindDeterminantAlgorithm = det;
            return Matrix.FindDeterminant();
        }

        public virtual int Rank(IFindRank rank)
        {
            Matrix.FindRankAlgorithm = rank;
            return Matrix.FindRank();
        }

        public virtual void Square(IMultiply mul)
        {
            _history.Backup();
            Matrix.MultiplyAlgorithm = mul;
            Matrix = Matrix.Square();
        }

        public virtual void Triangular(ITriangular triangular)
        {
            _history.Backup();
            Matrix.TriangularAlgorithm = triangular;
            Matrix = Matrix.Triangular();
        }

        public virtual void MultiplyOnScalar(long scalar)
        {
            _history.Backup();
            Matrix *= scalar;
        }

        public virtual void SaveToDb(string id)
        {
            var oldEntity = _db.Matrixes.FirstOrDefault(t => t.Id == id);
            if (oldEntity is not null)
            {
                oldEntity.Id = id;
                oldEntity.Stringify(Matrix);
            }
            else
            {
                var newEntity = new MatrixEntity(id, Matrix);
                _db.Matrixes.Add(newEntity);
            }
            _db.SaveChanges();
        }

        public virtual void LoadFromDb(string id)
        {
            var matrixEntity = _db.Matrixes.FirstOrDefault(t => t.Id == id);
            if (matrixEntity is null)
            {
                throw new DataException("Object with that id was not found");
            }
            if (Matrix.Count == matrixEntity.Count)
            {
                _history.Backup();
                Matrix = matrixEntity.ToMatrix();
            }
        }

        public virtual void ChangeSize(int size)
        {
            _history.Backup();
            Matrix = Matrix.ChangeCount(size);
        }

        public virtual IPrototype Copy()
        {
            return Matrix.Clone();
        }

        public virtual void Paste(IPrototype matrix)
        {
            _history.Backup();
            Matrix = (Matrix)matrix;
        }

        public virtual void Undo()
        {
            _history.Undo();
        }

        public virtual Matrix Add(Matrix other)
        {
            return Matrix + other;
        }

        public virtual Matrix Diff(Matrix other)
        {
            return Matrix - other;
        }

        public virtual Matrix Multiply(Matrix other, IMultiply mul)
        {
            Matrix.MultiplyAlgorithm = mul;
            other.MultiplyAlgorithm = mul;
            return Matrix * other;
        }
    }
}
