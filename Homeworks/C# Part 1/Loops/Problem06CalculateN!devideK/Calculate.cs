/*
 * Problem 6. Calculate N! / K!

    Write a program that calculates n! / k! for given n and k (1 < k < n < 100).
    Use only one loop.

 */

using System;


    class Calculate
    {
        static void Main()
        {
            int k = 0;
            int n = 0;
            Console.Write("Enter value for n [1 to 99] = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Enter value for k [k to 99] = ");
            k = int.Parse(Console.ReadLine());
            int facktorielN = 1;
            int facktorielK = 1;
            if (k < n && n > 0 && n < 100 && k > 0 && k < 100)
            {
                for (int i = 1, j = 1; i <= n; i++, j++) // <---- One looop
                {
                    facktorielN *= i;
                    if (j <= k)
                    {
                        facktorielK *= j;    
                    }
                }
            }
            else
            {
                Console.WriteLine("\"n\" must be greater than \"k\" or numbers must be lower that 100!");
                return;
            }
            double sum = 0;
            sum = facktorielN / facktorielK;
            Console.WriteLine("n! / k! = " + sum);
        }
    }

