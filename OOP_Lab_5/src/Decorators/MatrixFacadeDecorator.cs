using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Core.Prototype;
using OOP_Lab_5.Facade;

namespace OOP_Lab_5.Decorators
{
    public class MatrixFacadeDecorator : IMatrixFacade
    {
        protected IMatrixFacade _facade;

        public Matrix Matrix 
        { 
            get
            {
                return _facade.Matrix;
            } 
        }

        public MatrixFacadeDecorator(IMatrixFacade facade)
        {
            _facade = facade;
        }

        public virtual void Transpose()
        {
            _facade.Transpose();
        }

        public virtual long Determinant(IFindDeterminant det)
        {
            return _facade.Determinant(det);
        }

        public virtual int Rank(IFindRank rank)
        {
            return _facade.Rank(rank);
        }

        public virtual void Square(IMultiply mul)
        {
            _facade.Square(mul);
        }

        public virtual void Triangular(ITriangular triangular)
        {
            _facade.Triangular(triangular);
        }

        public virtual void MultiplyOnScalar(long scalar)
        {
            _facade.MultiplyOnScalar(scalar);
        }

        public virtual void SaveToDb(string id)
        {
            _facade.SaveToDb(id);
        }

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

        public virtual void ChangeSize(int size)
        {
            _facade.ChangeSize(size);
        }

        public virtual IPrototype Copy()
        {
            return _facade.Copy();
        }

        public virtual void Paste(IPrototype matrix)
        {
            _facade.Paste(matrix);
        }

        public virtual void Undo()
        {
            _facade.Undo();
        }

        public virtual Matrix Add(Matrix other)
        {
            return _facade.Add(other);
        }

        public virtual Matrix Diff(Matrix other)
        {
            return _facade.Diff(other);
        }

        public virtual Matrix Multiply(Matrix other, IMultiply mul)
        {
            return _facade.Multiply(other, mul);
        }
    }
}
