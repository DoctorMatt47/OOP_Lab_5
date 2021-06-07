using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Core.Prototype;
using OOP_Lab_5.Facade;

namespace OOP_Lab_5.Decorators
{
    /// <summary>
    /// Represents base decorator for MatrixFacade class.
    /// Implements decorator pattern.
    /// </summary>
    public class MatrixFacadeDecorator : IMatrixFacade
    {
        /// <summary>
        /// Encapsulated MatrixFacade instance.
        /// </summary>
        protected IMatrixFacade _facade;

        /// <summary>
        /// Matrix getter.
        /// </summary>
        public Matrix Matrix 
        { 
            get
            {
                return _facade.Matrix;
            } 
        }

        /// <summary>
        /// Constructs MatrixFacadeDecorator instance.
        /// </summary>
        /// <param name="facade">MatrixFacade to be encapsulated</param>
        public MatrixFacadeDecorator(IMatrixFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Calls Transpose method of MatrixFacade instance.
        /// </summary>
        public virtual void Transpose()
        {
            _facade.Transpose();
        }

        /// <summary>
        /// Calls Determinant method of MatrixFacade instance.
        /// </summary>
        /// <param name="det">Passed algorithm for determinant find.</param>
        /// <returns>Matrix determinant.</returns>
        public virtual long Determinant(IFindDeterminant det)
        {
            return _facade.Determinant(det);
        }

        /// <summary>
        /// Calls Rank method of MatrixFacade instance.
        /// </summary>
        /// <param name="rank">Passed algorithm for rank find.</param>
        /// <returns>Matrix rank</returns>
        public virtual int Rank(IFindRank rank)
        {
            return _facade.Rank(rank);
        }

        /// <summary>
        /// Calls Square method of MatrixFacade instance.
        /// </summary>
        /// <param name="mul">Passed algorithm for matrix multiply.</param>
        public virtual void Square(IMultiply mul)
        {
            _facade.Square(mul);
        }

        /// <summary>
        /// Calls Triangular method of MatrixFacade instance.
        /// </summary>
        /// <param name="triangular">Passed algorithm for matrix triangular.</param>
        public virtual void Triangular(ITriangular triangular)
        {
            _facade.Triangular(triangular);
        }

        /// <summary>
        /// Calls MultiplyOnScalar method of MatrixFacade instance.
        /// </summary>
        /// <param name="scalar">Scalar</param>
        public virtual void MultiplyOnScalar(long scalar)
        {
            _facade.MultiplyOnScalar(scalar);
        }

        /// <summary>
        /// Calls SaveToDb method of MatrixFacade instance.
        /// </summary>
        /// <param name="id">Id of record.</param>
        public virtual void SaveToDb(string id)
        {
            _facade.SaveToDb(id);
        }

        /// <summary>
        /// Calls LoadFromDb method of MatrixFacade instance.
        /// </summary>
        /// <param name="id">Id of record.</param>
        public virtual void LoadFromDb(string id)
        {
            try
            {
                _facade.LoadFromDb(id);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Calls ChangeSize method of MatrixFacade instance.
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        public virtual void ChangeSize(int size)
        {
            _facade.ChangeSize(size);
        }

        /// <summary>
        /// Calls Copy method of MatrixFacade instance.
        /// </summary>
        /// <returns>Matrix copy.</returns>
        public virtual IPrototype Copy()
        {
            return _facade.Copy();
        }

        /// <summary>
        /// Calls Paste method of MatrixFacade instance.
        /// </summary>
        /// <param name="matrix">Matrix to be pasted.</param>
        public virtual void Paste(IPrototype matrix)
        {
            _facade.Paste(matrix);
        }

        /// <summary>
        /// Calls Undo method of MatrixFacade instance.
        /// </summary>
        public virtual void Undo()
        {
            _facade.Undo();
        }

        /// <summary>
        /// Calls Add method of MatrixFacade instance.
        /// </summary>
        /// <param name="other">Other matrix to be added.</param>
        /// <returns>New matrix that equals to adddition of this and other matrixes.</returns>
        public virtual Matrix Add(Matrix other)
        {
            return _facade.Add(other);
        }

        /// <summary>
        /// Calls Diff method of MatrixFacade instance.
        /// </summary>
        /// <param name="other">Other matrix to be subtracted from this.</param>
        /// <returns>New matrix that equals to substraction of this and other matrixes.</returns>
        public virtual Matrix Diff(Matrix other)
        {
            return _facade.Diff(other);
        }

        /// <summary>
        /// Calls Multiply method of MatrixFacade instance.
        /// </summary>
        /// <param name="other">Other matrix to be multiplied to this.</param>
        /// <param name="mul">Passed algorithm for matrix multiply.</param>
        /// <returns>New matrix that equals to substraction of this and other matrixes.</returns>
        public virtual Matrix Multiply(Matrix other, IMultiply mul)
        {
            return _facade.Multiply(other, mul);
        }
    }
}
