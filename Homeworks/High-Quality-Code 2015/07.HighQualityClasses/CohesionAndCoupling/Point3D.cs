namespace CohesionAndCoupling
{
    using System;

    public class Point3D : Point
    {
        public Point3D(double x, double y, double z)
            : base(x, y)
        {
            this.Z = z;
        }

        public double Z { get; set; }
    }
}
