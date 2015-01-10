using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintLongSequnce
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int x = 2; x <= 1001; x++)
            {
                if (x % 2 != 0)//Devide 'x' by 2. if returns different than 0, Prints 'x' with minus, else print 'x' 
                {

                    Console.WriteLine(-x);
                }
                else
                {
                    Console.WriteLine(x);
                }
            }
        }
    }
}
