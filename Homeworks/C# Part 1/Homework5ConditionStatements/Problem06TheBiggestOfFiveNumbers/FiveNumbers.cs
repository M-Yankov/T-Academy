/*Problem 6. The Biggest of Five Numbers

    Write a program that finds the biggest of five numbers by using only five if statements.
*/

using System;
using System.Globalization;

class FiveNumbers
{
    static void Main()
    {
        Console.Write("Enter First num: ");
        double one = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter Second num: ");
        double two = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter Third num: ");
        double three = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter Fourth num: ");
        double four = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        Console.Write("Enter Fifth num: ");
        double five = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        double final = 0;
        if (one >= two && one >= three && one >= four && one >= five) // first if statement
        {
            final = one;
        }
        if (two >= one && two >= three && two >= four && two >= five) // second if statement
        {
            final = two;
        }
        if (three >= one && three >= two && three >= four && three >= five) // third if statement
        {
            final = three;
        }
        if (four >= one && four >= two && four >= three && four >= five) //fourth if statement
        {
            final = four;
        }
        if (five >= one && five >= two && five >= three && five >= four) // fifth statement
        {
            final = five;
        }
        Console.WriteLine("{0} is the biggest number.", final);
    }
}
