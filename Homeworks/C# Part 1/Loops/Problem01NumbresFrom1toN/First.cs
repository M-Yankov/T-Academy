/*
 * Problem 1. Numbers from 1 to N

    Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n, on a single line, separated by a space.

 */
using System;


class First
{
    static void Main()
    {
        Console.Write("Enter int number: ");
        uint lenght = 0;
        try                                             // If input is ok this will compile 
        {
            lenght = uint.Parse(Console.ReadLine());
        }
        catch (Exception)                               // else this
        {
            Console.WriteLine("Bad input!");
            return;
        }
        for (int i = 1; i <= lenght; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}

