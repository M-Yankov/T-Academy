/*Problem 9. Trapezoids

    Write an expression that calculates trapezoid's area by given sides a and b and height h.

 */
using System.Globalization;
using System;
using System.Text;



class Trapezoid
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.WriteLine("Trapezoid");
        Console.WriteLine("      a    ");
        Console.WriteLine("   ________ ");
        Console.WriteLine("  /|       \\ ");
        Console.WriteLine(" / |h       \\");
        Console.WriteLine("/__|_________\\");
        Console.WriteLine("       b       "); 
        Console.Write("Enter values. a = ");
        double a = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("b = ");
        double b = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("h = ");
        double h = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        double s = ((a + b) * h) / 2;
        Console.WriteLine("Area = {0}cm\u00B2", s);//Set your console to Lucida Consolas to see "cm²"


    }
}

