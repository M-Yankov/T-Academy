namespace CSharpExam1.MyOldSolutions
{

    using System;
    using System.Collections;
    using System.Linq;

    class ThreeNumbers
    {
        static void OldSolution()
        {
            long a = long.Parse(Console.ReadLine());
            long b = long.Parse(Console.ReadLine());
            long c = long.Parse(Console.ReadLine());
            long smallest;
            long bigest;
            double sum = (a + b + c) / 3.00;
            if (a > b)
            {
                if (a > c) // bigest
                {
                    bigest = a;
                }
                else
                {
                    bigest = c;
                }


            }
            else
            {
                //biggest
                if (b > c)
                {
                    bigest = b;
                }
                else
                {
                    bigest = c;
                }

            }

            // Smallese
            if (a < b)
            {
                if (a < c)
                {
                    smallest = a;
                }
                else
                {
                    smallest = c;
                }
            }
            else
            {
                if (b < c)
                {
                    smallest = b;
                }
                else
                {
                    smallest = c;
                }
            }
            Console.WriteLine(bigest);
            Console.WriteLine(smallest);
            Console.WriteLine("{0:0.00} ", sum); 
        }
    }
}
