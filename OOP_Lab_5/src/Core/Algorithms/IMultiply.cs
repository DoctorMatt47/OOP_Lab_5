namespace OOP_Lab_5.Core.Algorithms
{
    /// <summary>
    /// Interface of matrix Multiply algorithm.
    /// Implements strategy pattern.
    /// </summary>
    public interface IMultiply
    {
        /// <summary>
        /// Gets new matrix that equals to multiplication of passed matrixes.
        /// </summary>
        /// <param name="left">Left matrix argument of matrix multiplication operation.</param>
        /// <param name="right">Right matrix argument of matrix multiplication operation.</param>
        /// <returns>New matrix that equals to multiplication of passed matrixes.</returns>
        Matrix Execute(Matrix left, Matrix right);
    }
}
