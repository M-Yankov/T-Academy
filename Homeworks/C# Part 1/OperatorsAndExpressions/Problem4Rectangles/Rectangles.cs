/*
 * Problem 4. Rectangles

    Write an expression that calculates rectangle’s perimeter and area by given width and height.
*/

using System;
using System.Globalization;
using System.Text;

class Rectangles
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        double sideA;
        double sideB;
        Console.Write("Enter value for a: ");
        sideA = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter value for b: ");
        sideB = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        double sum = sideA * 2 + sideB * 2;
        double area = sideA * sideB;
        Console.WriteLine("Rectangle with {0}cm and {1}cm has: {2}cm perimeter and {3}cm\u00B2 area.", sideA, sideB, Math.Round(sum, 2), Math.Round(area, 2));
    }
}

