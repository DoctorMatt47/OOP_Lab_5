using OOP_Lab_5.Core;
using OOP_Lab_5.Core.Algorithms;
using OOP_Lab_5.Core.Prototype;
using OOP_Lab_5.Facade;
using System.Diagnostics;

namespace OOP_Lab_5.Decorators
{
    public class TimeDecorator : MatrixFacadeDecorator
    {
        public long Time { get; private set; }

        public TimeDecorator(IMatrixFacade facade) : base(facade) { }

        public override void Transpose()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.Transpose();
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        public override long Determinant(IFindDeterminant det)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var ret = _facade.Determinant(det);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            return ret;
        }

        public override int Rank(IFindRank rank)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var ret = _facade.Rank(rank);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            return ret;
        }

        public override void Square(IMultiply mul)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.Square(mul);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        public override void Triangular(ITriangular triangular)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.Triangular(triangular);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        public override void MultiplyOnScalar(long scalar)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.MultiplyOnScalar(scalar);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        public override void SaveToDb(string id)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.SaveToDb(id);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;

        }

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

        public override void ChangeSize(int size)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.ChangeSize(size);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        public override IPrototype Copy()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var ret = _facade.Copy();
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            return ret;
        }

        public override void Paste(IPrototype matrix)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.Paste(matrix);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        public override void Undo()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            _facade.Undo();
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
        }

        public override Matrix Add(Matrix other)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var ret = _facade.Add(other);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            return ret;
        }

        public override Matrix Diff(Matrix other)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var ret = _facade.Diff(other);
            stopwatch.Stop();
            Time = stopwatch.ElapsedMilliseconds;
            return ret;
        }

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
