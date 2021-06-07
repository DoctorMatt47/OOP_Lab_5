using Microsoft.EntityFrameworkCore;
using OOP_Lab_5.Core;
using System;

namespace OOP_Lab_5.Data.Entities
{
    /// <summary>
    /// Represents matrix entity for database storage.
    /// Inherits BaseEntity class.
    /// </summary>
    public class MatrixEntity : BaseEntity<string>
    {
        /// <summary>
        /// Id of this instance.
        /// </summary>
        public override string Id { get; set; }

        /// <summary>
        /// Matrix, which stored in string.
        /// </summary>
        public string Matrix { get; set; }

        /// <summary>
        /// Count of rows and columns.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MatrixEntity() { }

        /// <summary>
        /// Constructs entity of passed matrix.
        /// </summary>
        /// <param name="id">Id to be stored.</param>
        /// <param name="matrix">Matrix, to be transformed to string.</param>
        public MatrixEntity(string id, Matrix matrix)
        {
            Id = id;
            Stringify(matrix);
        }

        /// <summary>
        /// Transforms matrix to string.
        /// </summary>
        /// <param name="matrix">Matrix to be transformed to string</param>
        public void Stringify(Matrix matrix)
        {
            Count = matrix.Count;
            Matrix = "";
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    Matrix += matrix[i, j] + " ";
                }
            }
        }

        /// <summary>
        /// Gets Matrix instance, based on this.
        /// </summary>
        /// <returns>New matrix, based on this.</returns>
        public Matrix ToMatrix()
        {
            var matrix = new Matrix(Count);           
            int k = 0;
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    var matrixNumber = "";
                    while (Matrix[k] != ' ' && k < Matrix.Length)
                    {
                        matrixNumber += Matrix[k++];
                    }
                    k++;
                    matrix[i, j] = Convert.ToInt64(matrixNumber);
                }
            }
            return matrix;
        }
    }
}
