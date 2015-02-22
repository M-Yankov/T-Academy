/*Problem 1. Decimal to binary

    Write a program to convert decimal numbers to their binary representation.
*/

using System;

namespace P01DecimalToBinary
{

    public class DecToBin
    {
        public static void Main()
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
            for (int z = 1; z <= output.Length; z++) // must reverse numbers in string
            {
                final += output.Substring(output.Length - z, 1); // get last digit and adds in first postion in new string
            }
            Console.WriteLine("binary: " + final);
        }
    }
}