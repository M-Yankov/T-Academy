/*Problem 7. Encode/decode

    Write a program that encodes and decodes a string using given encryption key (cipher).
    The key consists of a sequence of characters.
    The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class EncodingDecoding
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string input = Console.ReadLine();
        Console.Write("Enter key(cipher): ");
        string cipher = Console.ReadLine();
        List<string> result = new List<string>();
        for (int i = 0, j = 0; i < input.Length; i++, j++) // This must be in method
        {

            if (j >= cipher.Length)
            {
                j = 0;
            }
            result.Add((input[i] ^ cipher[j]).ToString("X"));//.ToString()); // "X"
        }
        Console.WriteLine(string.Join("", result));
        Console.Write("To decode enter the same key: ");
        cipher = Console.ReadLine();
        StringBuilder final = new StringBuilder();
        for (int i = 0, k = 0; i < result.Count; i++, k++)
        {
            int a = Converting(result[i]);
            if (k >= cipher.Length)
            {
                k = 0;
            }
            int temp = a ^ cipher[k];
            final.Append(Convert.ToChar(temp));

        }
        Console.WriteLine(string.Join("", final)); // Yeah
    }
    static int Converting(string str)
    {
        string[] hex = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" }; //if you notice - index of array represents number in decimal.
        //Console.Write("Enter Hex number: ");
        string input = str.ToUpper(); // if enter lowercase of letter - will not be a problem
        int finale = 0;
        string temp = "";
        for (int i = 0; i <= input.Length - 1; i++)
        {
            temp = input[i].ToString();
            for (int z = 0; z <= hex.Length - 1; z++)
            {
                if (temp == hex[z])
                {
                    finale += (int)((Math.Pow(16, input.Length - 1 - i)) * z);
                    break;
                }
            }
        }
        return finale;
    }
}
