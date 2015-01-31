/*Problem 7. Calculate N! / (K! * (N-K)!)

    In combinatorics, the number of ways to choose k different members out of a group of n different elements (also known as the number of combinations) 
 *  is calculated by the following formula: formula For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
    Your task is to write a program that calculates n! / (k! * (n-k)!) for given n and k (1 < k < n < 100). Try to use only two loops.

 */
using System;
using System.Numerics;                      // WE must add this to use Bignteger for big calculations with big numbers

class Formula
{
    static void Main()
    {
        Console.Write("Enter value for n [1 to 99] = ");
        int numN = int.Parse(Console.ReadLine());
        Console.Write("Enter value for k (k to 99] = ");
        int numK = int.Parse(Console.ReadLine());
        BigInteger facktorielN = 1;             //There are the varaiables of Big Integer
        BigInteger facktorielK = 1;
        BigInteger fackNminusK = 1;
        if (numK < numN && numN > 0 && numN < 100 && numK > 0 && numK < 100)
        {
            for (int i = 1, j = 1; i <= numN; i++, j++)
            {
                facktorielN *= i;
                if (j <= numK)
                {
                    facktorielK *= j;
                }
            }
            for (int j = 1; j <= numN - numK; j++)
            {
                fackNminusK *= j;
            }
        }
        else
        {
            Console.WriteLine("\"n\" must be greater than \"k\"--or numbers must be lower that 100!");
            return;
        }
        BigInteger final = (facktorielN / (facktorielK * fackNminusK));
        Console.WriteLine("N! / (K! * (N-K)!) = " + final);
    }
}

