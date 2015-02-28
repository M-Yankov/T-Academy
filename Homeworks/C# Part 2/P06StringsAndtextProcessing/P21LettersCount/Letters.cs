/*Problem 21. Letters count

    Write a program that reads a string from the console and prints all different letters in the string along with information how many times each letter is found.
*/
using System;

class Letters
{
    static void Main()
    {
        Console.Write("Input text: ");
        string n = Console.ReadLine();
        int[] unicodeSymbols = new int[65536];
        int index;
        foreach (var ch in n)
        {
            index = Convert.ToInt32(ch);

            unicodeSymbols[index]++;
        }
        //foreach (var item in unicodeSymbols.Where(x => x != 0))
        //{

        //    Console.WriteLine("'{0}' apears {1} times", (char)item, item);
        //}
        for (int i = 0; i < unicodeSymbols.Length; i++)
        {
            if (unicodeSymbols[i] != 0)
            {
                Console.WriteLine("'{0}' - {1} times ", (char)i, unicodeSymbols[i]);
            }
        }
    }
}

