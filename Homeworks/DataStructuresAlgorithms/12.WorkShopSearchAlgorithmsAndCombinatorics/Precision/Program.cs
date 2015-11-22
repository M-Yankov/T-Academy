namespace Precision
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static int Devide(string fraction, int a, int b)
        {
            a *= 10;
            int i;
            for (i = 0; i < fraction.Length; i++)
            {
                int digit = a / b;
                if (digit != fraction[i] - '0')
                {
                    break;
                }

                a = a % b * 10;
            }

            return i;
        }

        static bool PoGolqmo(string fraction, int a, int b)
        {
            a *= 10;
            int i;
            for (i = 0; i < fraction.Length; i++)
            {
                int digit = a / b;
                if (digit < fraction[i] - '0')
                {
                    return false ;
                }
                else if (digit > fraction[i] - '0')
                {
                    return true;
                }

                a = a % b * 10;
            }
        }



        public static void Main()
        {
            int bestnom = 0;
            int bestDen = 1;
            int precision = 1;

            int maxDenominator = int.Parse(Console.ReadLine());
            var fraction = Console.ReadLine().Split('.')[1];
            for (int den = 1; den <= maxDenominator; den++)
            {
                int left = 0;
                int righht = den;
                while (left < righht)
                {
                    int middle = (left + righht) / 2;
                    if (PoGolqmo(fraction, middle, den))
                    {
                        righht = middle;
                    }
                    else
                    {
                        left = middle + 1;
                    }
                }
                int cur = Devide(fraction, left, den);
                if (cur > precision)
                {
                    bestDen = den;
                    bestnom = left  1;
                    precision = cur;
                }
            }
            Console.WriteLine("{0}/{1}", bestnom, bestDen);
            Console.WriteLine(precision + 1);
        }
    }
}
