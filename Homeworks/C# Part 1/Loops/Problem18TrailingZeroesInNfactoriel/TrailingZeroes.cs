/*Problem 18.* Trailing Zeroes in N!

    Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
    Your program should work well for very big numbers, e.g. n=100000.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class TrailingZeroes
{
    static void Main()
    {
        Console.Write("Factoriel of: ");            // If you enter a very big number like 100000 you must wait about 5 mins - to watch wat's going on console - make comment below part of the code to see workflow
        int n = int.Parse(Console.ReadLine());
        BigInteger factoriel = 1;
        for (int i = 1; i <= n; i++)
        {
            factoriel *= i;
            // Console.WriteLine(i); if (i == 100000) Console.WriteLine("First loop ends");
        }
       
        BigInteger reminder;
        int count = 0;
        for (int z = 0; true; z++)
        {
            reminder = factoriel % 10;
            factoriel /= 10;
            if (reminder == 0)
            {
                count++;
                // Console.WriteLine(count);
            }
            else
            {
                break;
            }
        }
        Console.WriteLine("Factoriel of {0} has {1} zeros in tail!",n,count);
    }
}

