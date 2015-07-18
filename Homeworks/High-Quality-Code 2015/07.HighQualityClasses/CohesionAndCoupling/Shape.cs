namespace CohesionAndCoupling
{
    using System;

    public static class Shape
    {
        public static double Width { get; set; }

        public static double Height { get; set; }

        public static double Depth { get; set; }

        public static double CalculateDistance2D(Point2D firstPoint, Point2D secondPoint)
        {
            double diferenceX = Math.Pow(secondPoint.X - firstPoint.X, 2);
            double diferenceY = Math.Pow(secondPoint.Y - firstPoint.Y, 2);

            double distance = Math.Sqrt(diferenceX + diferenceY);
            return distance;
        }

        public static double CalculateDistance3D(Point3D firstPoint, Point3D secondPoint)
        {
            double diferenceX = Math.Pow(secondPoint.X - firstPoint.X, 2);
            double diferenceY = Math.Pow(secondPoint.Y - firstPoint.Y, 2);
            double diferenceZ = Math.Pow(secondPoint.Z - firstPoint.Z, 2);

            double distance = Math.Sqrt(diferenceX + diferenceY + diferenceZ);
            return distance;
        }

        public static double CalculateVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }

        public static double CalculateDiagonalXYZ()
        {
            double distance = CalculateDistance3D(new Point3D(0, 0, 0), new Point3D(Width, Height, Depth));
            return distance;
        }

        public static double CalculateDiagonalXY()
        {
            double distance = CalculateDistance2D(new Point2D(0, 0), new Point2D(Width, Height));
            return distance;
        }

        public static double CalculateDiagonalXZ()
        {
            double distance = CalculateDistance2D(new Point2D(0, 0), new Point2D(Width, Depth));
            return distance;
        }

        public static double CalculateDiagonalYZ()
        {
            double distance = CalculateDistance2D(new Point2D(0, 0), new Point2D(Height, Depth));
            return distance;
        }
    }
}