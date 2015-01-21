/*Problem 9. Sum of n Numbers

    Write a program that enters a number n and after that enters more n numbers and calculates and prints their sum. Note: You may need to use a for-loop.
*/

using System;
using System.Globalization;

class SumNumbers
{
    static void Main()
    {
        Console.Write("How many numbers want to sum? ");
        double number = double.Parse(Console.ReadLine());
        double sum = 0;
        for (int i = 1; i <= number; i++)//This is loop 
        {
            Console.Write("Enter value for " + i + " number: " );
            sum += double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); //adding entered number to 'sum'
            
        }
        Console.WriteLine("Sum of these " + number + " numbers = " + sum);
    }
}

