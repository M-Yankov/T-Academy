/*Problem 8. Prime Number Check

    Write an expression that checks if given positive integer number n (n = 100) is prime (i.e. it is divisible without remainder only to itself and 1).
 * 
 */
using System;


class PrimeNumber
{
    static void Main()
    {
        bool isPrime = false;
        for (int x = 3; x <= 100; x++) //I use this loop to show number from 3 to 100.
        {
            Console.Write(x);
            for (int i = 2; i <= x / i; i++) //And this inner loop to check number is prime or no. Logic here is if number is big like 79 ,                                              
            {                               // when it's devided by 2  = 39 It's normal that can't divide 79 on number bigger than 39. So I check smaller numbers
                if (x % i == 0)
                {
                    isPrime = false; break; //break will cause exit from loop. 
                }
                else
                {
                    isPrime = true;
                }
            }
            Console.WriteLine("\t" + isPrime);
        }
    }
}

