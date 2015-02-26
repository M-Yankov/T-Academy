/*Problem 15. Replace tags

    Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].
*/
using System;
using System.Text;


class ReplaceTa
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string n = Console.ReadLine();
        StringBuilder text = new StringBuilder();
        text.Append(n);
        text.Replace("<a href=\"", "[URL=");
        text.Replace("\">" , "]");
        text.Replace("</a>" , "[/URL]");
        Console.WriteLine(text);
    }
}