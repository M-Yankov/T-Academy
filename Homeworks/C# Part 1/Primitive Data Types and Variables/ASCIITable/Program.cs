/*
 * Problem 14.* Print the ASCII Table

    Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints 
 *  the entire ASCII table of characters on the console (characters from 0 to 255).

Note: Some characters have a special purpose and will not be displayed as expected. You may skip them or display them differently.*/

using System;


namespace ASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To see specific symbols, manage your console from Properties\\Font\nand set \"Lucida Console\"");
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine((char)169);
            Console.WriteLine((char)170);

            for (char c = (char)0; c <= (char)255; ++c)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("To see specific symbols, manage your console from Properties\\Font\nand set \"Lucida Console\"");

        }
    }
}
