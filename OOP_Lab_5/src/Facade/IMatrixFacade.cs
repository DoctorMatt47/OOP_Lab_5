using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Core.Prototype;

namespace OOP_Lab_5.Facade
{
    /// <summary>
    /// Represents main operation with matrix.
    /// It used like main interface of matrix operations.
    /// Implements facade pattern.
    /// </summary>
    public interface IMatrixFacade
    {
        /// <summary>
        /// Encapsulated matrix instance.
        /// </summary>
        Matrix Matrix { get; }

        /// <summary>
        /// Transpose matrix.
        /// </summary>
        void Transpose();

        /// <summary>
        /// Gets matrix determinant using passed algorithm.
        /// </summary>
        /// <param name="det">Passed algorithm for determinant find.</param>
        /// <returns>Matrix determinant.</returns>
        long Determinant(IFindDeterminant det);

        /// <summary>
        /// Gets matrix rank using passed algorithm.
        /// </summary>
        /// <param name="rank">Passed algorithm for rank find.</param>
        /// <returns>Matrix rank</returns>
        int Rank(IFindRank rank);

        /// <summary>
        /// Square matrix using passed algorithm.
        /// </summary>
        /// <param name="mul">Passed algorithm for matrix multiply.</param>
        void Square(IMultiply mul);

        /// <summary>
        /// Triangular matrix using passed algorithm.
        /// </summary>
        /// <param name="triangular">Passed algorithm for matrix triangular.</param>
        void Triangular(ITriangular triangular);

        /// <summary>
        /// Multiply matrix on scalra using passed algorithm.
        /// </summary>
        /// <param name="scalar">Scalar</param>
        void MultiplyOnScalar(long scalar);

        /// <summary>
        /// Saves matrix instance to database with passed id.
        /// If database consists of passed id, method will update record with that id.
        /// </summary>
        /// <param name="id">Id of record.</param>
        void SaveToDb(string id);

        /// <summary>
        /// Loads matrix record from database with passed id.
        /// If database does not consist of passed id, method will throw exception.
        /// </summary>
        /// <param name="id">Id of record.</param>
        void LoadFromDb(string id);

        /// <summary>
        /// Changes size of matrix
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        void ChangeSize(int size);

        /// <summary>
        /// Copies matrix.
        /// </summary>
        /// <returns>Matrix copy.</returns>
        IPrototype Copy();

        /// <summary>
        /// Pastes matrix.
        /// </summary>
        /// <param name="matrix">Matrix to be pasted.</param>
        void Paste(IPrototype matrix);

        /// <summary>
        /// Undoes operations to last backup.
        /// </summary>
        void Undo();

        /// <summary>
        /// Adds this matrix to other.
        /// </summary>
        /// <param name="other">Other matrix to be added.</param>
        /// <returns>New matrix that equals to adddition of this and other matrixes.</returns>
        Matrix Add(Matrix other);

        /// <summary>
        /// Subtracts other matrix from this.
        /// </summary>
        /// <param name="other">Other matrix to be subtracted from this.</param>
        /// <returns>New matrix that equals to substraction of this and other matrixes.</returns>
        Matrix Diff(Matrix other);

        /// <summary>
        /// Multiply other this to other using passed algorithm.
        /// </summary>
        /// <param name="other">Other matrix to be multiplied to this.</param>
        /// <param name="mul">Passed algorithm for matrix multiply.</param>
        /// <returns>New matrix that equals to substraction of this and other matrixes.</returns>
        Matrix Multiply(Matrix other, IMultiply mul);
    }
}
