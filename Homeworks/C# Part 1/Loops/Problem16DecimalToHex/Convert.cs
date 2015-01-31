/*
 * Problem 16. Decimal to Hexadecimal Number

    Using loops write a program that converts an integer number to its hexadecimal representation.
    The input is entered as long. The output should be a variable of type string.
    Do not use the built-in .NET functionality.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Convert
{
    static void Main()
    {
        string[] hex = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" }; // index of elements represent their value in decimal
        Console.Write("Enter decimal number: ");
        long number = long.Parse(Console.ReadLine());
        long temp = 0;
        string final = "";
        for (int i = 0; true; i++) 
        {
            temp = number % 16;
            number /= 16;
            for (int z = 0; z <= hex.Length - 1; z++)
            {
                if (temp == z)
                {
                    final += hex[z];
                    break;
                }
            }
            if (number < 16)
            {
                for (int y = 0; y <= hex.Length - 1; y++)
                {
                    if (number == y)
                    {
                        final += hex[y];
                        break;
                    }
                }
                break;
            }
        }
        //Console.WriteLine("final: " + final); //great it works
        string lastReallyFinal = "";
        for (int z = 1; z <= final.Length; z++)   // must reverse ememelnts in string
        {
            lastReallyFinal += final.Substring(final.Length - z, 1);  // get last digit and adds in first postion in new string
        }
        Console.WriteLine("Hex: " + lastReallyFinal);
    }
}

