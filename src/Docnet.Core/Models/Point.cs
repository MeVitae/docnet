using System;
using Docnet.Core.Validation;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local
namespace Docnet.Core.Models
{
    public struct Point : IEquatable<Point>
    {
        public int X { get; }

        public int Y { get; }

        public Point(int x, int y)
        {
            Validator.CheckNotLessThanZero(x, nameof(x));
            Validator.CheckNotLessThanZero(y, nameof(y));

            X = x;
            Y = y;
        }

        public Point((int, int) coords)
        {
            var (x, y) = coords;

            X = x;
            Y = y;
        }

        public static bool operator ==(Point obj1, Point obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Point obj1, Point obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(Point other)
        {
            return X == other.X &&
                   Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
            {
                return false;
            }

            var box = (Point)obj;

            return Equals(box);
        }

        public override int GetHashCode()
        {
            var hashCode = 13;
            hashCode = hashCode * 7 + X.GetHashCode();
            hashCode = hashCode * 7 + Y.GetHashCode();
            return hashCode;
        }
    }

    public struct PdfPoint : IEquatable<PdfPoint>
    {
        public double X { get; }

        public double Y { get; }

        public PdfPoint(double x, double y)
        {
            /*Validator.CheckNotLessThanZero(left, nameof(left));
            Validator.CheckNotLessThanZero(bottom, nameof(bottom));*/

            X = x;
            Y = y;
        }

        public PdfPoint((double, double) coords)
        {
            var (x, y) = coords;

            X = x;
            Y = y;
        }

        public static bool operator ==(PdfPoint obj1, PdfPoint obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(PdfPoint obj1, PdfPoint obj2)
        {
            return !(obj1 == obj2);
        }

        public bool Equals(PdfPoint other)
        {
            return X == other.X &&
                   Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PdfPoint))
            {
                return false;
            }

            var box = (PdfPoint)obj;

            return Equals(box);
        }

        public override int GetHashCode()
        {
            var hashCode = 13;
            hashCode = hashCode * 7 + X.GetHashCode();
            hashCode = hashCode * 7 + Y.GetHashCode();
            return hashCode;
        }
    }
}
