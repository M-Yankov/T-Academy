using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireMatrix
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            if(input%2 != 0)
            {
                input--;
            }
            //for (int i = 4; i < 77; i++)
            //{
            //    if(i % 4 == 0)
            //    {
            //        Console.Write("{0} ", i);
            //    }
            //}
            int firelength = (input / 2);  // + (input / 4); next part of flame
            int mid = 0;
            #region FirstPartOf flame
            for (int i = 0; i < firelength; i++)
            {
                for (int j = 0; j < (input / 2) - (i + 1); j++) 
                {
                    Console.Write(".");
                }
                Console.Write("#");
                Console.Write(new string('.', mid));
                if(mid != (input-2))
                {
                    mid += 2;

                }
                
                
                Console.Write("#");
                for (int z = 0; z < (input / 2) - (i + 1); z++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
            }
            #endregion
            #region Part2 flame
            for (int part2 = 0; part2 < input / 4; part2++)
            {
                //if (input % 2 != 0 && mid == input - 1)
                //{
                //    mid-=2;
                //}
                for (int j = 0; j < part2; j++)
                {
                    Console.Write(".");
                }
                Console.Write("#");
                Console.Write(new string('.', mid));
                mid -= 2;
                Console.Write("#");
                for (int z = 0; z < part2; z++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
            }
            #endregion
            
            Console.WriteLine(new string('-', input));
            int torchL = input/2;
            int torchR = input/2;
            for (int rowtourch = 0; rowtourch < input/2; rowtourch++)
            {
                for (int j = 0; j < rowtourch; j++)
                {
                    Console.Write(".");
                }
                Console.Write(new string('\\',torchL));
                torchL--;
                Console.Write(new string('/', torchR));
                torchR--;
                for (int j = 0; j < rowtourch; j++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
            }
        }
    }
}
