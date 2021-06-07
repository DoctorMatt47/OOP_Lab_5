using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Core.Prototype;
using OOP_Lab_5.Facade;
using System.Diagnostics;

namespace OOP_Lab_5.Decorators
{
    /// <summary>
    /// Represents decorator for MatrixFacade class.
    /// Measures time of algorithms.
    /// Inherits MatrixFacadeDecorator class.
    /// Implements decorator pattern.
    /// </summary>
    public class TimeDecorator : MatrixFacadeDecorator
    {
        /// <summary>
        /// Time of last launched algorithm.
        /// </summary>
        public long Time { get; private set; }

        /// <summary>
        /// Constructs TimeDecorator instance.
        /// </summary>
        /// <param name="facade">MatrixFacade to be encapsulated</param>
        public TimeDecorator(IMatrixFacade facade) : base(facade) { }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls Transpose method of MatrixFacade instance.
        /// </summary>
        public override void Transpose()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.Transpose();
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls Determinant method of MatrixFacade instance.
        /// </summary>
        /// <param name="det">Passed algorithm for determinant find.</param>
        /// <returns>Matrix determinant.</returns>
        public override long Determinant(IFindDeterminant det)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var ret = _facade.Determinant(det);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            return ret;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls Rank method of MatrixFacade instance.
        /// </summary>
        /// <param name="rank">Passed algorithm for rank find.</param>
        /// <returns>Matrix rank</returns>
        public override int Rank(IFindRank rank)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var ret = _facade.Rank(rank);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            return ret;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls Square method of MatrixFacade instance.
        /// </summary>
        /// <param name="mul">Passed algorithm for matrix multiply.</param>
        public override void Square(IMultiply mul)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.Square(mul);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls Triangular method of MatrixFacade instance.
        /// </summary>
        /// <param name="triangular">Passed algorithm for matrix triangular.</param>
        public override void Triangular(ITriangular triangular)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.Triangular(triangular);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls MultiplyOnScalar method of MatrixFacade instance.
        /// </summary>
        /// <param name="scalar">Scalar</param>
        public override void MultiplyOnScalar(long scalar)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.MultiplyOnScalar(scalar);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls SaveToDb method of MatrixFacade instance.
        /// </summary>
        /// <param name="id">Id of record.</param>
        public override void SaveToDb(string id)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.SaveToDb(id);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;

        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls LoadFromDb method of MatrixFacade instance.
        /// </summary>
        /// <param name="id">Id of record.</param>
        public override void LoadFromDb(string id)
        {
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                _facade.LoadFromDb(id);
                stopwatch.Stop();
                Time = stopwatch.ElapsedMilliseconds;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls ChangeSize method of MatrixFacade instance.
        /// </summary>
        /// <param name="size">Size of matrix.</param>
        public override void ChangeSize(int size)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.ChangeSize(size);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls Copy method of MatrixFacade instance.
        /// </summary>
        /// <returns>Matrix copy.</returns>
        public override IPrototype Copy()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var ret = _facade.Copy();
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            return ret;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls Paste method of MatrixFacade instance.
        /// </summary>
        /// <param name="matrix">Matrix to be pasted.</param>
        public override void Paste(IPrototype matrix)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.Paste(matrix);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls Undo method of MatrixFacade instance.
        /// </summary>
        public override void Undo()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.Undo();
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls Add method of MatrixFacade instance.
        /// </summary>
        /// <param name="other">Other matrix to be added.</param>
        /// <returns>New matrix that equals to adddition of this and other matrixes.</returns>
        public override Matrix Add(Matrix other)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var ret = _facade.Add(other);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            return ret;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls Diff method of MatrixFacade instance.
        /// </summary>
        /// <param name="other">Other matrix to be subtracted from this.</param>
        /// <returns>New matrix that equals to substraction of this and other matrixes.</returns>
        public override Matrix Diff(Matrix other)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var ret = _facade.Diff(other);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            return ret;
        }

        /// <summary>
        /// Measures the time of the algorithm.
        /// Calls Multiply method of MatrixFacade instance.
        /// </summary>
        /// <param name="other">Other matrix to be multiplied to this.</param>
        /// <param name="mul">Passed algorithm for matrix multiply.</param>
        /// <returns>New matrix that equals to substraction of this and other matrixes.</returns>
        public override Matrix Multiply(Matrix other, IMultiply mul)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var ret = _facade.Multiply(other, mul);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            return ret;
        }
    }
}
