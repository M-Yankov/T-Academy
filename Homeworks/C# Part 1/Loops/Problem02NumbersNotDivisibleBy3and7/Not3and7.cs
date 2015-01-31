/*
 * Problem 2. Numbers Not Divisible by 3 and 7

    Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n not divisible by 3 and 7, on a single line, separated by a space.

 */

using System;


class Not3and7
{
    static void Main()
    {
        Console.Write("Enter int number: ");
        uint lenght = 0;
        try
        {
            lenght = uint.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Bad input!");
            return;
        }
        for (int i = 1; i <= lenght; i++)
        {
            if (i % 3 == 0 || i % 7 == 0)
            {
                continue;
            }
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}

