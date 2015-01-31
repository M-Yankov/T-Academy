/*Problem 8. Catalan Numbers

    In combinatorics, the Catalan numbers are calculated by the following formula: catalan-formula
    Write a program to calculate the nth Catalan number by given n (0 ≤ n ≤ 100).
 * 
 *  Shift + Del = Crtl + X ( But first combination cuts whore row without we select it.) :}
 * */


using System;
using System.Numerics;

class Catalan
{
    static void Main()
    {
        Console.Write("Enter value for n [0 to 100] = ");
        int numN = int.Parse(Console.ReadLine());
        if (numN >= 0 && numN <= 100)
        {
            BigInteger factoriel2xN = 1;
            BigInteger factorielNplus1 = 1;
            BigInteger factorielN = 1;
            for (int i = 1; i <= numN * 2; i++)
            {
                factoriel2xN *= i;
            }
            for (int k = 1; k <= numN + 1; k++)
            {
                factorielNplus1 *= k;
            }
            for (int j = 1; j <= numN; j++)
            {
                factorielN *= j;
            }
            BigInteger final = factoriel2xN / (factorielNplus1 * factorielN);
            Console.WriteLine("Catalan(n) = " + final);
        }
        else
        {
            Console.WriteLine("N must be in radius [1,100]!");
        }
    }
}

