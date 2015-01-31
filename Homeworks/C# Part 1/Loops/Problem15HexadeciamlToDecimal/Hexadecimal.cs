/*
 * Problem 15. Hexadecimal to Decimal Number

    Using loops write a program that converts a hexadecimal integer number to its decimal form.
    The input is entered as string. The output should be a variable of type long.
    Do not use the built-in .NET functionality.                                                 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Hexadecimal
{
    static void Main()
    {
        
        // System.Console.CapsLock = true ; :v 
        string[] hex = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" }; //if you notice - index of  array represents number in decimal.
        Console.Write("Enter Hex number: ");
        string input = Console.ReadLine().ToUpper(); // if enter lowercase of letter - will not be a problem
        long finale = 0;
        string temp = "";
        for (int i = 0; i <= input.Length -1; i++)
        {
            temp = input[i].ToString();
            for (int z = 0; z <= hex.Length-1; z++)
			{   
			    if(temp == hex[z])
                {
                    finale += (long)((Math.Pow(16, input.Length-1-i)) * z);
                    break;
                }
			}
        }
        Console.WriteLine("Decimal: " + finale);
    }
}

