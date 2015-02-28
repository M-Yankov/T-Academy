/*
Problem 23. Series of letters

    Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.
*/
using System;
using System.Text;


class Series
{
    static void Main()
    {
        Console.Write("Input text: ");
        string text = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < text.Length - 1; i++)
        {
            if (text[i] != text[i+1])
            {
                result.Append(text[i]);
            }
        }
        result.Append(text[text.Length - 1]);
        Console.WriteLine(string.Join("",result));
    }
}
