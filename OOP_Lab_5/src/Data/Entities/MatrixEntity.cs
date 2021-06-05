using Microsoft.EntityFrameworkCore;
using OOP_Lab_5.Core;
using System;

namespace OOP_Lab_5.Data.Entities
{
    public class MatrixEntity : BaseEntity<string>
    {
        public override string Id { get; set; }
        public string Matrix { get; set; }
        public int Count { get; set; }

        public MatrixEntity() { }

        public MatrixEntity(string id, Matrix matrix)
        {
            Id = id;
            Stringify(matrix);
        }

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
