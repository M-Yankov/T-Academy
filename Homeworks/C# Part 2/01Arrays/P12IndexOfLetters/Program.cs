/*Problem 12. Index of letters

    Write a program that creates an array containing all letters from the alphabet (A-Z).
    Read a word from the console and print the index of each of its letters in the array.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P12IndexOfLetters
{
    class Program
    {
        static void Main()
        {
            
            //Console.WriteLine("\u005A"); --> hexadecima code of "Z" from ASCII
            //Console.WriteLine((char)65); --> decimal code of "A"  ASCII

            char[] letters = new char[26];  //---> from A to Z letters are 26 

            // I will use only uppercase
            for (int i = 0; i < 26; i++)   // fill the array
            {
                int temp = 65 + i;
                letters[i] = (char)temp;
            }
            Console.WriteLine(string.Join(", ", letters));
            Console.Write("Enter your word: ");
            string word = Console.ReadLine().ToUpper();
            
            for (int i = 0; i < word.Length; i++)
            {
                char temp = Convert.ToChar(word.Substring(i, 1));
                for (int j = 0; j < letters.Length; j++)
                {
                    if (temp == letters[j])
                    {
                        Console.WriteLine("{0} --> {1}", temp, j);
                        break;
                    }
                    if (j == letters.Length -1)
                    {
                        Console.WriteLine("{0} --> not in Array ", temp);
                    }

                }
                
            }

        }
    }
}
