/*Problem 5. Hexadecimal to binary

    Write a program to convert hexadecimal numbers to binary numbers (directly).
*/
using System;

namespace P05hexadecimal
{


    public class hexadecimal
    {
        public static void Main()
        {
            Console.Write("Enter Hex number: ");
            string input = Console.ReadLine().ToUpper();
            ConvertToDec(input);
        }
        static void ConvertToDec(string input)
        {
            string[] hex = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" }; //if you notice - index of array represents number in decimal.
            // if enter lowercase of letter - will not be a problem
            long finale = 0;
            string temp = "";
            for (int i = 0; i <= input.Length - 1; i++)
            {
                temp = input[i].ToString();
                for (int z = 0; z <= hex.Length - 1; z++)
                {
                    if (temp == hex[z])
                    {
                        finale += (long)((Math.Pow(16, input.Length - 1 - i)) * z);
                        break;
                    }
                }
            }
            Console.WriteLine(ConverToBin(finale));
        }
        static long ConverToBin(long input)
        {

            string output = "";
            for (int i = 0; true; i++)
            {
                output += input % 2;
                input /= 2;
                if (input == 1)
                {
                    output += input;
                    break;
                }
            }
            //Console.WriteLine(output);
            string final = "";
            for (int z = 1; z <= output.Length; z++) // must reverse numbers in string
            {
                final += output.Substring(output.Length - z, 1); // get last digit and adds in first postion in new string
            }
            return Convert.ToInt64(final);
        }
    }

}
