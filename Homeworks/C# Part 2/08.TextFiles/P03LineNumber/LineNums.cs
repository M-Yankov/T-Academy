/*Problem 3. Line numbers

    Write a program that reads a text file and inserts line numbers in front of each of its lines.
    The result should be written to another text file.
*/
using System;
using System.IO;

class LineNums
{
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\inputfile.txt");
        StreamWriter writer = new StreamWriter("..\\..\\output.txt");
        string txt = reader.ReadLine();
        int counter = 0;
        using (writer)
        {
            while (txt != null)
            {
                counter++;
                txt = String.Format("{0}.{1}", counter, txt);
                writer.WriteLine(txt);
                //writer.Dispose();
                txt = reader.ReadLine();
            }
        }
        Console.WriteLine("Your file is ready.");
    }
}
