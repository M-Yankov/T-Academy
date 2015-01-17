/*Problem 7. Point in a Circle

    Write an expression that checks if given point (x, y) is inside a circle K({0, 0}, 2).
*/
using System.Globalization;
using System;



class PointCircle
{
    static void Main()
    {
        Console.WriteLine("We have a circle in coordinate system with radius of 2. and center {0:0}");
        Console.Write("x= ");
        //string x = Console.ReadLine();
        double x = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("y= ");
        double y = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        bool pointIn = (x * x + y * y <= 4) && (Math.Abs(y) < 2);
        Console.WriteLine(pointIn);

    }
}

