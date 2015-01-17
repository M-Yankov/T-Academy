/*
 * Problem 12. Extract Bit from Integer

    Write an expression that extracts from given integer n the value of given bit at index p.
 */
using System;


class ExactBit
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter index of bit: ");
        int p = int.Parse(Console.ReadLine());
        int mask = 1 << p;
        int temp = n & mask;
        int result = temp>> p;
        Console.WriteLine("You searched index of number {0} is: {1}", n, result);
        Console.WriteLine("Your number in bits: " + Convert.ToString(n,2).PadLeft(16 ,'0'));
    }
}

