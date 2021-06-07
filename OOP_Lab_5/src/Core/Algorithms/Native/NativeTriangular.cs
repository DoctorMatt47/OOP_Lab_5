namespace OOP_Lab_5.Core.Algorithms
{
    /// <summary>
    /// Triangulars matrix using native algorithm.
    /// Implements ITriangular interface.
    /// </summary>
    public class NativeTriangular : ITriangular
    {
        /// <summary>
        /// Gets new triangular matrix of passed matrix.
        /// </summary>
        /// <param name="matrix">Matrix that will be triangulared</param>
        /// <returns>New triangular matrix of passed matrix.</returns>
        public Matrix Execute(Matrix matrix)
        {
            var rank = matrix.Count;

            var triangular = new Matrix(matrix);

            for (int row = 0; row < rank; row++)
            {
                if (triangular[row, row] != 0)
                {
                    for (int col = 0; col < triangular.Count; col++)
                    {
                        if (col != row)
                        {
                            double mult =
                               (double)triangular[col, row] /
                                        triangular[row, row];

                            for (int i = 0; i < rank; i++)

                                triangular[col, i] -= (int)mult
                                         * triangular[row, i];
                        }
                    }
                }
                else
                {
                    bool reduce = true;

                    for (int i = row + 1; i < triangular.Count; i++)
                    {
                        if (triangular[i, row] != 0)
                        {
                            for (int j = 0; j < rank; j++)
                            {
                                long temp = triangular[row, j];
                                triangular[row, j] = triangular[i, j];
                                triangular[i, j] = temp;
                            }
                            reduce = false;
                            break;
                        }
                    }

                    if (reduce)
                    {
                        rank--;
                        for (int i = 0; i < triangular.Count; i++)
                            triangular[i, row] = triangular[i, rank];
                    }
                    row--;
                }
            }
            return triangular;
        }
    }
}
