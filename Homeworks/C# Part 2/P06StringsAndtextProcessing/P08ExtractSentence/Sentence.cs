/*Problem 8. Extract sentences

    Write a program that extracts from a given text all sentences containing given word.

Example:

The word is: in

The text is: We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

The expected result is: We are living in a yellow submarine. We will move out of it in 5 days.

Consider that the sentences are separated by . and the words – by non-letter symbols.
 */
using System;


class Sentence
{
    static void Main()
    {
        Console.Write("Input text here: ");
        string[] sentences = Console.ReadLine().Split(new string[] {". "} , StringSplitOptions.RemoveEmptyEntries);
        
        Console.Write("Hint: surround text with spaces to find exact. Word: ");
        string word = Console.ReadLine();
        foreach (var w in sentences)
        {
            if(w.Contains(word))
            {
                Console.WriteLine("--> {0}", w);
            }
        }
    }
}
