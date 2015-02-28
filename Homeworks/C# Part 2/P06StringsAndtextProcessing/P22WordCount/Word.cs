/*     

Problem 22. Words count

    Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.

*/
using System;
using System.Collections.Generic;
using System.Linq;


class Word
{
    static void Main()
    {
        Console.Write("Input text: ");
        string n = Console.ReadLine();
        Dictionary<string, int> words = new Dictionary<string, int>();
        string key = "";
        int i = 0;
        while (i < n.Length)
        {

            while (Char.IsLetter(n[i]))
            {
                key += n[i];
                if (i == n.Length - 1)
                {
                    
                    break;
                }
                i++;
            }
            if (words.ContainsKey(key))
            {
                words[key]++;
            }
            else
            {
                words.Add(key, 1);

            }
            key = "";
            i++;
        } // word counter is ready ...
        Console.WriteLine("Your words below");
        foreach (var item in words)
        {
            Console.WriteLine("{0} apears {1} times", item.Key, item.Value);
        }
    }
}
