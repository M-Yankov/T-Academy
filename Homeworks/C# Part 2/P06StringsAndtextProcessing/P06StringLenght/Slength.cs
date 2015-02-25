/*Problem 6. String length

    Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with *.
    Print the result string into the console.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Slength
{
    static void Main()
    {
        Console.Write("Already know what to do: ");
        string s = Console.ReadLine();
        if (s.Length < 20)
        {
            int longue = 20 - s.Length;
            s += new string('*', longue); // update git
            Console.WriteLine("\n{0}", s);
        }
        else
        {
            s = s.Substring(0, 20);
            Console.WriteLine("\n{0}", s);

        }
    }
}
