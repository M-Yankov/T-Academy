namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(File.GetFileExtension("example"));
            Console.WriteLine(File.GetFileExtension("example.pdf"));
            Console.WriteLine(File.GetFileExtension("example.new.pdf"));

            Console.WriteLine(File.GetFileNameWithoutExtension("example"));
            Console.WriteLine(File.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(File.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                              Shape.CalculateDistance2D(new Point2D(1, -2), new Point2D(3, 4)));

            Console.WriteLine("Distance in the 3D space = {0:f2}",
                              Shape.CalculateDistance3D(new Point3D(5, 2, -1), new Point3D(3, -6, 4)));

            Shape.Width = 3;
            Shape.Height = 4;
            Shape.Depth = 5;

            Console.WriteLine("Volume = {0:f2}", Shape.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", Shape.CalculateDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", Shape.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", Shape.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", Shape.CalculateDiagonalYZ());
        }
    }
}