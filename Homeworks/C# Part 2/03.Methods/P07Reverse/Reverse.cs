/*Problem 7. Reverse number

    Write a method that reverses the digits of given decimal number.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Reverse
{
    static void Main()
    {
        Console.Write("Do same bla bla bla: ");
        string text = Console.ReadLine();
        string final = Reverseeed(text); // the two method are same 
        Console.WriteLine(final);
        Console.WriteLine("Same as:");
        Second(text);  // -||-||-||
    }
    static string Reverseeed(string str) // must have different name of class . Just for sure. 
    {
        string result = "";
        for (int i = str.Length -1; i >= 0 ; i--)
        {
            result += str[i];
        }
        return result;
    }
    static void Second(string s)
    {
        var compare = s.Reverse();
        foreach (var i in compare)
        {
            Console.Write(i);
        }
        Console.WriteLine();
    }
}

