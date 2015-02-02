using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            //StreamReader reader = new StreamReader("..\\..\\input.txt");
            //Console.SetIn(reader);
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            //Console.Write("N1: ");
            int n1 = int.Parse(Console.ReadLine());
            //Console.Write("N2: ");
            int n2 = int.Parse(Console.ReadLine());
            //Console.Write("N3: ");
            int n3 = int.Parse(Console.ReadLine());
            //Console.Write("N4: ");
            int n4 = int.Parse(Console.ReadLine());
            //Console.Write("N5: ");
            int n5 = int.Parse(Console.ReadLine());  //to change n to N
            //Console.Write("Amount: ");
            double A = double.Parse(Console.ReadLine());
            //Console.Write("Price: ");
            double P = double.Parse(Console.ReadLine());
            double total = n1 * 0.05 + n2 * 0.1 + n3 * 0.2 + n4 * 0.5 + n5 * 1;
            double charge = 0;
            double left = 0;
            if (A >= P)
            {

                charge = A - P;
                left = Math.Abs(total - charge);
                if (total - charge < 0)
                {
                    Console.WriteLine("No {0:0.00}", left);
                }
                else
                {
                    Console.WriteLine("Yes {0:0.00}", left);
                }
            }
            else if (A < P)
            {
                charge = P - A;
                Console.WriteLine("More {0:0.00}", charge);
            }


        }
    }
}
