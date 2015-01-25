/*Problem 5. The Biggest of 3 Numbers

    Write a program that finds the biggest of three numbers.

 */
using System;
using System.Globalization;

class TheBiggest
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter value for a = ");
            double a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter value for b = ");
            double b = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter value for c = ");
            double c = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double temp;
            if (a > b)
            {
                temp = a;
            }
            else
            {
                temp = b;
            }
            if (temp > c)
            {
                Console.WriteLine("The biggest number from your numbers is: " + temp);
            }
            else
            {
                Console.WriteLine("The Biggest number from your numbers is " + c );
            }

        }
    }
}

