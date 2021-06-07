using System.Linq;
using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Memento;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Data.Entities;
using OOP_Lab_5.Data;
using System.Data;
using OOP_Lab_5.Core.Prototype;

namespace OOP_Lab_5.Facade
{
    /// <summary>
    /// Represents main operation with matrix.
    /// Implements IMatrixFacade interface.
    /// Implements facade pattern.
    /// </summary>
    public class MatrixFacade : IMatrixFacade
    {
        /// <summary>
        /// Database connection.
        /// </summary>
        private readonly DatabaseContext _db = new DatabaseContext();
        
        /// <summary>
        /// History of operations.
        /// </summary>
        private MatrixHistory _history;

        /// <summary>
        /// Matrix getter and private setter.
        /// </summary>
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

        /// <summary>
        /// Constructs class instance.
        /// </summary>
        /// <param name="matrix">Matrix to be encapsulated.</param>
        public MatrixFacade(Matrix matrix)
        {
            _history = new MatrixHistory(matrix);
        }

        /// <summary>
        /// Transpose matrix.
        /// </summary>
        public virtual void Transpose()
        {
            _history.Backup();
            Matrix = Matrix.Transpose();
        }

        /// <summary>
        /// Gets matrix determinant using passed algorithm.
        /// </summary>
        /// <param name="det">Passed algorithm for determinant find</param>
        /// <returns>Matrix determinant.</returns>
        public virtual long Determinant(IFindDeterminant det)
        {
            Matrix.FindDeterminantAlgorithm = det;
            return Matrix.FindDeterminant();
        }

        /// <summary>
        /// Gets matrix rank using passed algorithm.
        /// </summary>
        /// <param name="rank">Passed algorithm for rank find.</param>
        /// <returns>Matrix rank</returns>
        public virtual int Rank(IFindRank rank)
        {
            Matrix.FindRankAlgorithm = rank;
            return Matrix.FindRank();
        }

        /// <summary>
        /// Square matrix using passed algorithm.
        /// </summary>
        /// <param name="mul">Passed algorithm for matrix multiply.</param>
        public virtual void Square(IMultiply mul)
        {
            _history.Backup();
            Matrix.MultiplyAlgorithm = mul;
            Matrix = Matrix.Square();
        }

        /// <summary>
        /// Triangular matrix using passed algorithm.
        /// </summary>
        /// <param name="triangular">Passed algorithm for matrix triangular.</param>
        public virtual void Triangular(ITriangular triangular)
        {
            _history.Backup();
            Matrix.TriangularAlgorithm = triangular;
            Matrix = Matrix.Triangular();
        }

        /// <summary>
        /// Multiply matrix on scalra using passed algorithm.
        /// </summary>
        /// <param name="scalar">Scalar</param>
        public virtual void MultiplyOnScalar(long scalar)
        {
            _history.Backup();
            Matrix *= scalar;
        }

        /// <summary>
        /// Saves matrix instance to database with passed id.
        /// If database consists of passed id, method will update record with that id.
        /// </summary>
        /// <param name="id">Id of record.</param>
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

        /// <summary>
        /// Loads matrix record from database with passed id.
        /// If database does not consist of passed id, method will throw exception.
        /// </summary>
        /// <param name="id">Id of record.</param>
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

        /// <summary>
        /// Changes size of matrix
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        public virtual void ChangeSize(int size)
        {
            _history.Backup();
            Matrix = Matrix.ChangeCount(size);
        }

        /// <summary>
        /// Copies matrix.
        /// </summary>
        /// <returns>Matrix copy.</returns>
        public virtual IPrototype Copy()
        {
            return Matrix.Clone();
        }

        /// <summary>
        /// Pastes matrix.
        /// </summary>
        /// <param name="matrix">Matrix to be pasted.</param>
        public virtual void Paste(IPrototype matrix)
        {
            _history.Backup();
            Matrix = (Matrix)matrix;
        }

        /// <summary>
        /// Undoes operations to last backup.
        /// </summary>
        public virtual void Undo()
        {
            _history.Undo();
        }

        /// <summary>
        /// Adds this matrix to other.
        /// </summary>
        /// <param name="other">Other matrix to be added.</param>
        /// <returns>New matrix that equals to adddition of this and other matrixes.</returns>
        public virtual Matrix Add(Matrix other)
        {
            return Matrix + other;
        }


        /// <summary>
        /// Subtracts other matrix from this.
        /// </summary>
        /// <param name="other">Other matrix to be subtracted from this.</param>
        /// <returns>New matrix that equals to substraction of this and other matrixes.</returns>
        public virtual Matrix Diff(Matrix other)
        {
            return Matrix - other;
        }

        /// <summary>
        /// Multiply other this to other using passed algorithm.
        /// </summary>
        /// <param name="other">Other matrix to be multiplied to this.</param>
        /// <param name="mul">Passed algorithm for matrix multiply.</param>
        /// <returns>New matrix that equals to substraction of this and other matrixes.</returns>
        public virtual Matrix Multiply(Matrix other, IMultiply mul)
        {
            Matrix.MultiplyAlgorithm = mul;
            other.MultiplyAlgorithm = mul;
            return Matrix * other;
        }
    }
}
