/*
 * Problem 1. Sum of 3 Numbers

    Write a program that reads 3 real numbers from the console and prints their sum.

 */

using System;
using System.Globalization;


class SumOfThree
{
    static void Main()
    {
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter c: ");
        double c = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, a + b + c);
        string gosho = new string('-', 30);
        Console.WriteLine(gosho);
        
    }
}

