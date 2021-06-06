using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Core.Prototype;

namespace OOP_Lab_5.Facade
{
    public interface IMatrixFacade
    {
        Matrix Matrix { get; }

        void Transpose();

        long Determinant(IFindDeterminant det);

        int Rank(IFindRank rank);

        void Square(IMultiply mul);

        void Triangular(ITriangular triangular);

        void MultiplyOnScalar(long scalar);

        void SaveToDb(string id);

        void LoadFromDb(string id);

        void ChangeSize(int size);

        IPrototype Copy();

        void Paste(IPrototype matrix);

        void Undo();

        Matrix Add(Matrix other);

        Matrix Diff(Matrix other);

        Matrix Multiply(Matrix other, IMultiply mul);
    }
}
