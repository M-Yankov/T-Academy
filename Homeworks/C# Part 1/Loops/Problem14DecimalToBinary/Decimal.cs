/*Problem 14. Decimal to Binary Number

    Using loops write a program that converts an integer number to its binary representation.
    The input is entered as long. The output should be a variable of type string.
    Do not use the built-in .NET functionality.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Decimal
{
    static void Main()
    {
        Console.Write("Enter number: ");
        long input = long.Parse(Console.ReadLine());
        string output = "";
        for (int i = 0; true; i++) 
        {
            output += input % 2;
            input /= 2;
            if (input == 1)
            {
                output += input;
                break;
            }
        }
        //Console.WriteLine(output);
        string final = "";
        for (int z = 1; z <= output.Length ; z++)   // must reverse numbers in string
        {
            final += output.Substring(output.Length - z, 1);  // get last digit and adds in first postion in new string
        }
        Console.WriteLine("binary: " + final);
    }
}

