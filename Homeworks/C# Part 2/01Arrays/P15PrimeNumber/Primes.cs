/*Problem 15. Prime numbers

    Write a program that finds all prime numbers in the range [1...10 000 000]. Use the Sieve of Eratosthenes algorithm.

 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Primes
{
    static void Main()
    {
        List<int> aLLnumber = new List<int>();
        for (int i = 2; i < 10000000; i++) // 000
        {
            aLLnumber.Add(i);
        }
        for (int dev = 0; dev < aLLnumber.Count; dev++)
        {

            for (int rem = 0; rem < aLLnumber.Count; rem++)
            {
                if ((aLLnumber[rem] > aLLnumber[dev]) && (aLLnumber[rem] % aLLnumber[dev] == 0))
                {
                    
                    aLLnumber[rem] = -1;
                    //aLLnumber.RemoveAt(rem);
                }
            }
        }
        /*
        Console.WriteLine(string.Join(", ", aLLnumber)); // fack shit don't use this 
        */
        foreach (int num in aLLnumber)
        {
            if(num > 0)
            {

            Console.WriteLine(num + " ");
            }
        }
        // it's litle slow
    }
}

