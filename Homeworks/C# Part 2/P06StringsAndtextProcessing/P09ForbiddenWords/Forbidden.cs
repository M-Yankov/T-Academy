/*Problem 9. Forbidden words

    We are given a string containing a list of forbidden words and a text containing some of these words.
    Write a program that replaces the forbidden words with asterisks.

Example text: Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.

Forbidden words: PHP, CLR, Microsoft

The expected result: ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.
 */
using System;
using System.Text;  // For string builder


class Forbidden
{
    static void Main()
    {
        Console.Write("Input your text here: ");  // Case sensitive
        string n = Console.ReadLine();
        StringBuilder something = new StringBuilder();
        something.Append(n);
        Console.Write("Forbidden words separated by space: ");
        string[] forbiddenWords = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            if (something.ToString().Contains(forbiddenWords[i]))
            {
                something.Replace(forbiddenWords[i], new string('*', forbiddenWords[i].Length));
            }
        }
        Console.WriteLine(something);
    }
}
