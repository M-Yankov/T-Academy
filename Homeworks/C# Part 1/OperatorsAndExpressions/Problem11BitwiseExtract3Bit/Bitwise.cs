/*Problem 11. Bitwise: Extract Bit #3

    Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer.
    The bits are counted from right to left, starting from bit #0.
    The result of the expression should be either 1 or 0.
*/
using System;


class Bitwise
{
    static void Main()
    {
        Console.Write("Enter number of type int: ");
        int a = int.Parse(Console.ReadLine());
        int mask = 1 << 3; //this is bitwise operators
        int result = a & mask;
        int bit = result >> 3;
        Console.WriteLine("The third bit of {0} is: {1}", a, bit);
        Console.WriteLine("Your number in bits: " + Convert.ToString(a, 2).PadLeft(32,'0'));



    }
}

