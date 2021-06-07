namespace OOP_Lab_5.Core.Algorithms
{
    /// <summary>
    /// Interface of matrix FindDeterminant algorithm.
    /// Implements strategy pattern.
    /// </summary>
    public interface IFindDeterminant
    {
        /// <summary>
        /// Gets determinant of passed matrix.
        /// </summary>
        /// <param name="matrix">Matrix whose determinant will be found.</param>
        /// <returns>Determinant of passed matrix.</returns>
        long Execute(Matrix matrix);
    }
}
