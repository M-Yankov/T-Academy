/*Problem 4. Number Comparer

    Write a program that gets two numbers from the console and prints the greater of them.
    Try to implement this without if statements.

 */
using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.Write("a = ");
        double numberA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("b = ");
        double numberB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        double greater = numberA > numberB ? numberA : numberB;
        Console.WriteLine("The greater from {0} and {1} is: {2}", numberA, numberB, greater);
    }
}
