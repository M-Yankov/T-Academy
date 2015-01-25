/*
 * Problem 1. Exchange If Greater

    Write an if-statement that takes two double variables a and b and exchanges their values if the first one is greater than the second one. As a result print the values a and b, separated by a space.

 */

using System;
using System.Globalization;

class Greater
{
    static void Main()
    {
        
        Console.Write("Enter first number: a = ");
        double first = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter Second number: b = ");
        double second = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        double temp;
        if (first > second) // If true they will be exchanged
        {
            temp = first;
            first = second;
            second = temp;
        }
        Console.WriteLine("Your numbers: {0} {1} ", first, second);
        
    }
}

