using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Last
{
    class Program
    {
        static void OldMainMethod()
        {
            //StreamReader reader = new StreamReader("..\\..\\test.txt");
            //          Console.SetIn(reader);
            int mask = int.Parse(Console.ReadLine());
            string range = Convert.ToString(mask, 2);
            int perfectmask = 15; // (int)Math.Pow(2, range.Length) - 1;

            int numbers = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = 0; i < numbers; i++)
            {
                long num = long.Parse(Console.ReadLine());
                for (int j = 0; j < 31; j++)
                {
                    long temp = num >> j;
                    long check = temp & perfectmask;
                    string str1 = Convert.ToString(check, 2).PadLeft(4, '0');
                    string cmask = Convert.ToString(mask, 2).PadLeft(4, '0');
                    if (str1 == cmask)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}