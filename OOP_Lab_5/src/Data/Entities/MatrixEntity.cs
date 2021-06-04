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

        public void Stringify(Matrix matrix)
        {
            Count = matrix.Count;
            Matrix = "";
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    Matrix += matrix[i, j] + ' ';
                }
            }
        }
        public Matrix ToMatrix()
        {
            var matrix = new Matrix(Count);
            var matrixNumber = "";
            int k = 0;
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < Count; j++)
                {
                    while (Matrix[k] != ' ' && k < Matrix.Length)
                    {
                        matrixNumber += Matrix[k++];
                    }
                    matrix[i, j] = Convert.ToInt32(matrixNumber);
                }
            }
            return matrix;
        }
    }
}
