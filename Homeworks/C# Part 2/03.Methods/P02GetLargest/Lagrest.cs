/*Problem 2. Get largest number

    Write a method GetMax() with two parameters that returns the larger of two integers.
    Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Lagrest
{
    static void Main()
    {
        Console.Write("First Num = ");
        int first = int.Parse(Console.ReadLine());
        Console.Write("Second Num = ");
        int second = int.Parse(Console.ReadLine());
        Console.Write("Third Num = ");
        int third = int.Parse(Console.ReadLine());
        int maxFS = GetMaX(first, second);
        int maxLast = GetMaX(maxFS, third);
        Console.WriteLine("Max num is {0}.", maxLast);
    }
    static int GetMaX(int a, int b)
    {
        return a > b ? a : b;
    }
}
