
/*Problem 2. Reverse string

    Write a program that reads a string, reverses it and prints the result at the console.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Reversing
{
    static void Main()
    {
        Console.Write("enter some text: ");
        string s = Console.ReadLine();
        Console.WriteLine("Reversed: {0}", Reverse(s));
    }
    public static string Reverse(string s) //  20 mins thinking how to do it. finally copy paste from stackoverflow.com
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
