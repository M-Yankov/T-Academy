/*Problem 10. Fibonacci Numbers

    Write a program that reads a number n and prints on the console the first n members of the Fibonacci sequence (at a single line, separated by comma and space - ,) : 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, ….

Note: You may need to learn how to use loops.*/

using System;


class Fibonacci
{
    static void Main()
    {
        Console.Write("How many numbers wou want to see from Fibonacci sequence? ");
        int number = int.Parse(Console.ReadLine());
        int temp1 = 0;
        int temp2 = 0;
        int sum = 0;
        for (int i = 0; i <= number; i++ )
        {

            Console.Write(sum + ", ");
            temp2 = temp1;
            temp1 = sum;
            sum = temp1 + temp2;
            
            if (i == 0)
            {
                sum = 1;
            }
        }
    }
}

