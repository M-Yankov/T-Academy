using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04
{
    class Program
    {
        static void OldMMain()
        {
            int inputN = int.Parse(Console.ReadLine()); //10
            int inputD = int.Parse(Console.ReadLine());
            int mid = inputN - inputD;

            int something = (inputN * 2) - 1;
            if (inputD > inputN)
            {

            }
            for (int i = 0; i < inputN; i++)
            {
                Console.Write(new string('#', i));
                Console.Write("\\");

                if (i < (inputN - 1) - inputD)  // to try inputD -1
                {
                    Console.Write(new string(' ', inputD)); // must repair
                    Console.Write("\\");
                    Console.Write(new string('.', mid));
                    Console.Write("/");
                    Console.Write(new string(' ', inputD));
                    mid -= 2;
                }
                else
                {

                    Console.Write(new string(' ', something));

                }
                something -= 2;

                Console.Write("/");
                Console.Write(new string('#', i));
                Console.WriteLine();

            }
            Console.Write(new string('#', inputN));
            Console.Write("X");
            Console.Write(new string('#', inputN));
            Console.WriteLine();
            something = 1;
            mid += 2;
            for (int j = inputN - 1; j >= 0; j--)
            {
                Console.Write(new string('#', j));
                Console.Write("/");
                if (j > (inputN - 2) - inputD)
                {
                    Console.Write(new string(' ', something));

                    something += 2;
                }
                else
                {
                    Console.Write(new string(' ', inputD)); // must repair
                    Console.Write("/");
                    Console.Write(new string('.', mid));
                    Console.Write("\\");
                    Console.Write(new string(' ', inputD));
                    mid += 2;
                }

                Console.Write("\\");
                Console.Write(new string('#', j));

                Console.WriteLine();
            }


        }
    }
}