using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem12BitsExchange
{
    class BitsExchange
    {
        static void Main(string[] args)
        {
            int num = 180;
            Console.WriteLine("180 in bits " + Convert.ToString(num ,2 ));
            int mask = (1 << 3);           
            Console.WriteLine("MASK            "+Convert.ToString(mask,2));
            int gosho = mask & num;
            Console.WriteLine("Gosho         " + Convert.ToString(gosho,2));
            gosho >>= 3;
            Console.WriteLine("Gosho            " + Convert.ToString(gosho, 2));
            int finale = num ^ gosho;
            Console.WriteLine("Finale "+Convert.ToString(finale,2));
        }
    }
}
