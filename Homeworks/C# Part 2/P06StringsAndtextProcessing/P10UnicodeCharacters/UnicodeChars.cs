/**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class UnicodeChars
    {
        static void Main()
        {
            Console.Write("Input text: ");
            string input = Console.ReadLine(); // работи и с кирилица , поне при мен
            for (int i = 0; i < input.Length; i++)
            {
                int mamkatiiformatirane = input[i];
                Console.Write("\\u{0:X4}" , mamkatiiformatirane);
            }
            Console.WriteLine();
        }
    }
