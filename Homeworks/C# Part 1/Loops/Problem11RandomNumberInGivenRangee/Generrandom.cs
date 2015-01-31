/*
 * Problem 11. Random Numbers in Given Range

    Write a program that enters 3 integers n, min and max (min != max) and prints n random numbers in the range [min...max].

 */

using System;



class Generrandom //<-- avoid name this class 'Random' -  causes problems. Like lose 1 hour for serching where is the problem when .next didn't pop-up. 
{
    static void Main()
    {
        Console.Write("Enter numers count: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter min number: ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("Enter max number: ");
        int max = int.Parse(Console.ReadLine());
        Random generator = new Random();
        if (min < max)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(generator.Next(min, max) + " ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Bad input! max shoud be greater than min");
        }

        
    }
}

