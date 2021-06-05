using System.Linq;
using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Memento;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Data.Entities;
using OOP_Lab_5.Data;
using System.Data;

namespace OOP_Lab_5
{
    public class MatrixFacade
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

        public MatrixFacade(Matrix left)
        {
            _history = new MatrixHistory(left);
        }

        public void Transpose()
        {
            _history.Backup();
            Matrix = Matrix.Transpose();
        }

        public long Determinant(IFindDeterminant det)
        {
            Matrix.FindDeterminantAlgorithm = det;
            return Matrix.FindDeterminant();
        }

        public int Rank(IFindRank rank)
        {
            Matrix.FindRankAlgorithm = rank;
            return Matrix.FindRank();
        }

        public void Square(IMultiply mul)
        {
            _history.Backup();
            Matrix.MultiplyAlgorithm = mul;
            Matrix = Matrix.Square();
        }

        public void Triangular(ITriangular triangular)
        {
            _history.Backup();
            Matrix.TriangularAlgorithm = triangular;
            Matrix = Matrix.Triangular();
        }

        public void MultiplyOnScalar(long scalar)
        {
            _history.Backup();
            Matrix *= scalar;
        }

        public void SaveToDb(string id)
        {
            if (_db.Matrixes.Any(t => t.Id == id))
            {
                throw new DataException("Object with that id was not found");
            }
            var entity = new MatrixEntity(id, Matrix);
            _db.Matrixes.Add(entity);
            _db.SaveChanges();
        }

        public void LoadFromDb(string id)
        {
            var matrixEntity = _db.Matrixes.FirstOrDefault(t => t.Id == id);
            if (matrixEntity is null)
            {
                throw new DataException("Object with that id was not found");
            }
            Matrix = matrixEntity.ToMatrix();
        }

        public void Undo()
        {
            _history.Undo();
        }
    }
}
