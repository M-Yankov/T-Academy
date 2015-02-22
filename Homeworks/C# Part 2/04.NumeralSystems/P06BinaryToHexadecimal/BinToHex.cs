/*Problem 6. Binary to hexadecimal

    Write a program to convert binary numbers to hexadecimal numbers (directly).
*/
using System;

namespace P06BinaryToHex
{

    public class BinToHex
    {
        public static void Main()
        {
            Console.Write("Enter binary number: ");
            string text = Console.ReadLine();
            ConvertToDec(text);
        }
        static void ConvertToDec(string str)
        {
            long output = 0;
            long temp;
            for (int i = 0; i < str.Length; i++)
            {
                temp = long.Parse(str[i].ToString());
                output += (long)((Math.Pow(2, (str.Length - i - 1))) * temp);
            }
            ConvertToHex(output);
        }
        static void ConvertToHex(long number)
        {
            string[] hex = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" }; // index of elements represent their value in decimal

            long temp = 0;
            string final = "";
            for (int i = 0; true; i++) // This can be replaced with while 
            {
                if (number < 16)
                {
                    for (int y = 0; y <= hex.Length - 1; y++)
                    {
                        if (number == y)
                        {
                            final += hex[y];
                            break;
                        }
                    }
                    break;
                }
                temp = number % 16;
                number /= 16;
                for (int z = 0; z <= hex.Length - 1; z++)
                {
                    if (temp == z)
                    {
                        final += hex[z];
                        break;
                    }
                }
            }
            //Console.WriteLine("final: " + final); //great it works
            string lastReallyFinal = "";

            for (int z = 1; z <= final.Length; z++) // must reverse ememelnts in string
            {
                lastReallyFinal += final.Substring(final.Length - z, 1); // get last digit and adds in first postion in new string
            }
            Console.WriteLine("{0}", lastReallyFinal);
        }
    }

}
