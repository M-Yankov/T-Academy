/*Problem 4. Compare text files

    Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different.
    Assume the files have equal number of lines.
*/
using System;
using System.IO;


class Program
{
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\document1.txt");
        StreamReader reader2 = new StreamReader("..\\..\\file1.txt");
        string text1 = reader.ReadLine();
        string text2 = reader2.ReadLine() ;
        int equal = 0;
        int diff = 0;

        while (text2 != null && text1 != null )
        {
            if (text1 == text2)
            {
                equal++;
            }
            else
            {
                diff++;
            }
            text1 = reader.ReadLine();
            text2 = reader2.ReadLine();
        }
        Console.WriteLine("Equal Lines - {0}\nDifferent lines - {1}", equal , diff);
    }
}
