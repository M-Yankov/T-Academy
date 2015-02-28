/*Problem 24. Order words

    Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P24OrderWords
{
    class Ordering
    {
        static void Main(string[] args)
        {
            Console.Write("Input text: ");
            string n = Console.ReadLine();
            List<string> words = new List<string>();
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
                    words.Add(key);
                
                
                key = "";
                i++;
            } // word counter is ready ...
            Console.WriteLine("Ordered words below:");
            foreach (var word in words.OrderBy(x => x))
            {
                Console.WriteLine(word);   
            }
        }
    }
}
