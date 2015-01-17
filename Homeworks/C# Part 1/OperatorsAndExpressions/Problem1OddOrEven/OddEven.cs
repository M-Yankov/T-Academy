/*Problem 1. Odd or Even Integers

    Write an expression that checks if given integer is odd or even.

 * */

using System;



class Program
{
    static void Main()
    {
        for (int i = -3; i <= 12; i++)//I use loop to show numbers from -3 to 12 and what type is it (odd/even)
        {
            Console.Write(i);
            if (i % 2 == 0)
            {
                Console.WriteLine("\tIs even");
            }
            else
            {
                Console.WriteLine("\tIs odd");
            }
        }
    }
}

