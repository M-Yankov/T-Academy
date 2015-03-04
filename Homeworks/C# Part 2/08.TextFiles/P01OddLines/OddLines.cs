/*Problem 1. Odd lines

    Write a program that reads a text file and prints on the console its odd lines.
*/
using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\input.txt");

        using (reader)
        {
            int counter = 0;
            string s = reader.ReadLine();
            while (s != null)
            {
                counter++;
                if (counter % 2 == 1)
                {
                    Console.WriteLine("{0} line: {1}", counter, s);
                
                }
                s = reader.ReadLine();
            }
        }
    }
}
