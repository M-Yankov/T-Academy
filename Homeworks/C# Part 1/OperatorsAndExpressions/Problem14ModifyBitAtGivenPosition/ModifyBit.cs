/*Problem 14. Modify a Bit at Given Position

    We are given an integer number n, a bit value v (v=0 or 1) and a position p.
    Write a sequence of operators (a few lines of C# code) that modifies n to hold the value v at the position p from the binary representation of n while preserving all other bits in n.
*/

using System;


class ModifyBit
{
    static void Main()
    {
        int mask;
        Console.Write("Enter a integer number: ");
        int number = int.Parse(Console.ReadLine());
        Console.Write("Enter a position(index): ");
        int positon = int.Parse(Console.ReadLine());
        Console.Write("Enter a value (0 or 1): ");
        int value = int.Parse(Console.ReadLine());
        int final;
        if (value != 0 && value != 1)
            
        {
            Console.WriteLine("Bad input!");
            return;//exiting from program
        }
        
        if (value == 0)
        {
            value = 1;
            mask = value << positon;
            mask = ~mask;
            final = number & mask;
        }
        else
        {
            mask = value << positon;
            final = number | mask;
        }
        
        Console.WriteLine("Your number in bits: " + Convert.ToString(number, 2).PadLeft(16, '0'));
        //Console.WriteLine(Convert.ToString(mask, 2));
        Console.WriteLine("Your number in bits after exchange: "+ Convert.ToString(final,2));
        Console.WriteLine("Your final result: "+final);

    }
}

