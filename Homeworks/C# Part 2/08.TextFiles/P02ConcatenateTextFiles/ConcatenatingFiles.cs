/*Problem 2. Concatenate text files

    Write a program that concatenates two text files into another text file.
*/
using System;
using System.IO;
using System.Text;

class ConcatenatingFiles
{
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\file1.txt");
        string text1 = reader.ReadToEnd();
        StringBuilder result = new StringBuilder();
        result.Append(text1);
        reader = new StreamReader("..\\..\\document2.txt");
        result.AppendLine();
        result.Append(reader.ReadToEnd());
        StreamWriter write = new StreamWriter("..\\..\\final.txt");
        using (write)
        {
            write.WriteLine(result.ToString());

        }
        Console.WriteLine("Your file is ready\nSerch in your source code directory");

    }
}
