/*Problem 1. Shapes

    Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
    Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure (heightwidth for rectangle and heightwidth/2 for triangle).
    Define class Square and suitable constructor so that at initialization height must be kept equal to width and implement the CalculateSurface() method.
    Write a program that tests the behaviour of the CalculateSurface() method for different shapes (Square, Rectangle, Triangle) stored in an array.
*/
namespace P01Shapes
{
    using System;
    using System.Text;
    class MainMethod
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Triangle triangle = new Triangle(5.6, 2.3);
            Rectengle rect = new Rectengle(5, 2);
            Square sqrt = new Square(2.5);
            Shape[] forms = new Shape[] { triangle, rect, sqrt };
            foreach (var shape in forms)
            {
                Console.WriteLine("{0} with has surface {1}cm\u00B2", shape.GetType().Name ,shape.CalculateSurface());
            }
        }
    }
}
