namespace OOP_Lab_5.Core.Algorithms
{
    /// <summary>
    /// Interface of matrix FindRank algorithm.
    /// Implements strategy pattern.
    /// </summary>
    public interface IFindRank
    {
        /// <summary>
        /// Gets rank of passed matrix.
        /// </summary>
        /// <param name="matrix">Matrix whose rank will be found.</param>
        /// <returns>Rank of passed matrix.</returns>
        int Execute(Matrix matrix);
    }
}
