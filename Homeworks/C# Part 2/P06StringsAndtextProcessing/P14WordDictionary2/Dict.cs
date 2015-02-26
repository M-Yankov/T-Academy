/*Problem 14. Word dictionary

    A dictionary is stored as a sequence of text lines containing words and their explanations.
    Write a program that enters a word and translates it by using the dictionary.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Dict
{


    static void Main()
    {
        Dictionary<string, string> words = new Dictionary<string, string>();

        words.Add("C#", "a Object orient programing language");
        words.Add("C++", "a program language parent of C#");
        words.Add(".NET", "platform for applications from Microsoft");
        words.Add("CLR", "managed execution enviroment for .NET");
        words.Add("namespace", "hieracal organization of classes");
        words.Add("class", "using for make an objects");
        words.Add("method", "make a operations or calculations with some data. Can return a values");
        words.Add("pesho", "the talisman of Telerik Akademy");
        Search(words);
        string answer = "y";
        while (answer == "y")
        {
            Console.Write("Do you want to add something? (y/n) ");

            answer = Console.ReadLine();
            if (answer == "y")                       // you can add something and then search it by key
            {
                Console.Write("key = ");
                string keyUser = Console.ReadLine().Trim();
                Console.Write("value = ");
                string valueUser = Console.ReadLine().Trim();
                words.Add(keyUser, valueUser);
                Search(words);
            }
            else
            {
                break;
            }
        }

    }
    static void Search(Dictionary<string, string> words)
    {
        Console.Write("Search for key in Dictionary: ");
        string key = Console.ReadLine().Trim();
        if (words.ContainsKey(key))
        {
            Console.WriteLine("{0} - {1}", key, words[key]);
        }
        else
        {
            Console.WriteLine("No such thing");
            Console.ReadLine();
            Console.Clear();
            words.Clear();
            Main();
        }
    }
}
