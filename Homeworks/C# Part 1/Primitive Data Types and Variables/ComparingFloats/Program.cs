/*Problem 13.* Comparing Floats

    Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001.

Note: Two floating-point numbers a and b cannot be compared directly by a == b because of the nature of the floating-point arithmetic.
 * Therefore, we assume two numbers are equal if they are more closely to each other than a fixed constant eps.
 * 
 */

using System;


namespace ComparingFloats
{
    class Program
    {
        static void Main(string[] args)
        {
            const double eps = 0.00001;
            double a = 5.3f;
            double b = 6.01f;
            double bigger = a > b ? a : b;
            double smaller = a < b ? a : b;
            Console.Write("Are these numbers  5.3 and 6.01 equal? ");
            if ((bigger - smaller) > eps)
            {
                Console.WriteLine("\t\tfalse");
            }
            a = 5.0000001f;
            b = 5.0000003f;
            bigger = a > b ? a : b;
            smaller = a < b ? a : b;
            Console.Write("Are these numbers  5.0000001 and 5.0000003 equal ? ");
            if ((bigger - smaller) > eps)
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine("true");

            }

            a = 5.00000005f;
            b = 5.00000001f;
            bigger = a > b ? a : b;
            smaller = a < b ? a : b;
            Console.Write("Are these numbers  5.00000005 and 5.00000001 equal ? ");
            if ((bigger - smaller) > eps)
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine("true");

            }
            a = -0.0000007f;
            b = 0.00000007f;
            bigger = a > b ? a : b;
            smaller = a < b ? a : b;
            Console.Write("Are these numbers -0.0000007 and 0.00000007 equal ? ");
            if ((bigger - smaller) > eps)
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine("true");
            }
            a = -4.999999;
            b = -4.999998;

            bigger = a > b ? a : b;
            smaller = a < b ? a : b;
            Console.Write("Are these numbers -4.999999 and -4.999998 equal ? ");
            if ((bigger - smaller) != eps) // the result is not equal to eps
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine("true");
            }
            a = 4.999999f;
            b = 4.999998f;
            bigger = a > b ? a : b;
            smaller = a < b ? a : b;
            Console.Write("Are these numbers 4.999999 and 4.999998 equal ? ");
            if ((bigger - smaller) != eps) 
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine("true");
            }


        }
    }
}
