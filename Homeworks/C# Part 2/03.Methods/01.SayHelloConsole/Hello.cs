/*Homework: Methods
Problem 1. Say Hello

    Write a method that asks the user for his name and prints “Hello, <name>”
    Write a program to test this method.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Hello
{
    static void Main()
    {
        Console.Write("Enter Your name: ");
        string text = Console.ReadLine();
        while (text.Length < 3)
        {
            Console.Write("Try again: ");
            text = Console.ReadLine();
        }
        string result = Name(text);
        Console.WriteLine(result);
    }
    static string Name(string s)
    {
        s = "Hello " + s + "!";
        return s;
        //Console.WriteLine("Hello" + s); there are several method
    }
}
