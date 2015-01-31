/*
 * Problem 9. Matrix of Numbers

    Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20) and prints a matrix like in the examples below. Use two nested loops.
 * 
 */

using System;


class Matrix
{
    static void Main()
    {
        Console.Title = "Matrix";
        Console.Write("Enter value for n [1 to 20] = "); // if you enter number > 10 resize your console window width <-->
        int numN = int.Parse(Console.ReadLine());
        if (numN >= 1 && numN <= 20)
        {
            int colprint = 1;
            for (int i = 0; i <= numN - 1; i++)
            {
                for (int col = i; col <= numN - 1 + i; col++) // Two nested loops
                {
                    Console.Write(col + 1 + "\t");
                }
                Console.WriteLine();
                colprint += 2;
                Console.SetCursorPosition(0, colprint);
            }
        }
        else
        {
            Console.WriteLine("N must be in diapason 1 to 20 !!!!");
            return;
        }
    }
}

