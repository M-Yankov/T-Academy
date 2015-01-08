using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.PrintSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //Print First 10 numbers of Sequesce 2,-3,4,-5,6,-7...
            
            for (int x = 2; x <= 11; x++)
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
