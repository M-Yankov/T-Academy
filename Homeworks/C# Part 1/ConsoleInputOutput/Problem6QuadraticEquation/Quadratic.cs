/*Problem 6. Quadratic Equation

    Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0 and solves it (prints its real roots).
 * 
 */
using System;
using System.Globalization;
using System.Text;


class Quadratic
{
    static void Main(string[] args)
    {
        Console.WriteLine("To see spec. symbols - set console font to Lucida Concolas and restart. ");
        Console.OutputEncoding = Encoding.Unicode;
        Console.WriteLine("ax\u00B2 + bx + c = 0");
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        double discriminant = (b * b) - (4 * a * c);
        double root1;
        double root2;
        if (discriminant > 0)
        {
            root1 = ((-b) + Math.Sqrt(discriminant)) / (2 * a);
            root2 = ((-b) - Math.Sqrt(discriminant)) / (2 * a);
            Console.WriteLine("Root 1 = {0} \nRoot 2 = {1}", root1, root2);
        }
        else if (discriminant == 0)
        {
            root1 = -b / (2 * a);
            root2 = root1;
            Console.WriteLine("Root 1 = Root 2 = {0}", root1);

        }
        else
        {
            Console.WriteLine("There are no real roots!");
        }
    }
}