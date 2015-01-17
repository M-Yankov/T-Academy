/*Problem 13. Check a Bit at Given Position

    Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right) in given integer number n, has value of 1.

 */

using System;


class CheckBit
{
    static void Main()
    {
        Console.Write("Enter a number of type integer : ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter index of bit: ");
        int p = int.Parse(Console.ReadLine());
        int mask = 1 << p;
        int temp = n & mask;
        int result = temp >> p;
        bool answer = (result == 1);
        Console.WriteLine("Is {0}-th bit from {1} == 1? -{2}", p, n, answer);
        Console.WriteLine("Your number in bits: " + Convert.ToString(n, 2).PadLeft(16, '0'));

    }
}

