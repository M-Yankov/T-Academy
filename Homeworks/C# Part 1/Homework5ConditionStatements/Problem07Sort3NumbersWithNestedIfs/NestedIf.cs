/*Problem 7. Sort 3 Numbers with Nested Ifs

    Write a program that enters 3 real numbers and prints them sorted in descending order.
        Use nested if statements.

Note: Don’t use arrays and the built-in sorting functionality.
 * 
 */
using System;
using System.Globalization;

class NestedIf
{
    static void Main()
    {
        Console.Write("Enter a = ");
        double a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter b = ");
        double b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter c = ");
        double c = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        if (a > b)
        {
            if (a > c)
            {
                Console.Write("{0} ", a);
                if (b > c)
                {
                    Console.WriteLine("{0} {1}", b, c);
                }
                else
                {
                    Console.WriteLine("{0} {1}", c, b);
                }
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", c, a, b);
            }
        }
        else
        {
            if (b > c)
            {
                Console.Write("{0} ", b);
                if (a > c)
                {
                    Console.WriteLine("{0} {1}", a, c);
                }
                else
                {
                    Console.WriteLine("{0} {1}", c, a);
                }
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", c, b, a);
            }
        }
    }
}
