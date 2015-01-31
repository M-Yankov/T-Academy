/*Problem 17.* Calculate GCD

    Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
    Use the Euclidean algorithm (find it in Internet).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class GCD
{
    static void Main()
    {
        Console.Write("Enter a = ");
        int numA = int.Parse(Console.ReadLine());
        Console.Write("Enter b = ");
        int numB = int.Parse(Console.ReadLine());
        int exchange ;
        int reminder ;
        if (numA < numB)
        {
            exchange = numB;
            numB = numA;
            numA = exchange;
        }
        if (numA == numB)
        {
            Console.WriteLine("{0} = {1}", numA, numB);
            return;
        }
        int numAcopy = numA;
        int numBcopy = numB;
        for (int i = 0; true ; i++)
        {
            reminder = numAcopy % numBcopy;
            if (reminder == 0)
            {
                Console.WriteLine("GCD = " + numBcopy);
                break;
            }
            if (reminder == 1)
            {
                Console.WriteLine("GCD = " + reminder);
                break;
            }

            numAcopy = numBcopy;
            numBcopy = reminder;

        }
        // Source http://www.math.rutgers.edu/~greenfie/gs2004/euclid.html
    }
}
