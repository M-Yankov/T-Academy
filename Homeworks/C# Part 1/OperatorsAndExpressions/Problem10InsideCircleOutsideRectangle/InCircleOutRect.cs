/*Problem 10. Point Inside a Circle & Outside of a Rectangle

    Write an expression that checks for given point (x, y) if it is within the circle K({1, 1}, 1.5) and out of the rectangle R(top=1, left=-1, width=6, height=2).
*/

using System.Globalization;
using System;


class InCircleOutRect
{
    static void Main(string[] args)
    {

        Console.WriteLine("Point in Circle and out of Rectangle");
        Console.Write("x = ");
        double x = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("y = ");
        double y = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        bool inCircleOutRect = ((x - 1) * (x - 1)) + ((y - 1) * (y - 1)) <= 1.5 * 1.5 && y > 1;
        Console.WriteLine(inCircleOutRect);


    }
}

