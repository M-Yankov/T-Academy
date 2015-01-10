using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReformatCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, I am horribly formatted program"); 
            Console.WriteLine("Numbers and squares:");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + " --> " + i * i);
            }
        }
    }
}
