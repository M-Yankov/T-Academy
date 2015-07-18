namespace QualityMethods
{
    using System;

    public class Point
    {
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double Y { get; set; }

        public double X { get; set; }
    }
}
