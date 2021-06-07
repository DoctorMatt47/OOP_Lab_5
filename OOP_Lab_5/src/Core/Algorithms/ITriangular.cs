namespace OOP_Lab_5.Core.Algorithms
{
    /// <summary>
    /// Interface of matrix Triangular algorihm.
    /// Implements strategy pattern.
    /// </summary>
    public interface ITriangular
    {
        /// <summary>
        /// Gets new triangular matrix of passed matrix.
        /// </summary>
        /// <param name="matrix">Matrix that will be triangulared</param>
        /// <returns>New triangular matrix of passed matrix.</returns>
        Matrix Execute(Matrix matrix);
    }
}
