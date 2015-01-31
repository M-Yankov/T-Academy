/*
    Problem 5. Calculate 1 + 1!/X + 2!/X^2 + … + N!/X^N

    Write a program that, for a given two integer numbers n and x, calculates the sum S = 1 + 1!/x + 2!/x^2 + … + n!/x^n.  <--- there was a litle syntaxis error (2!/x2) must be (2!/x^2)
    Use only one loop. Print the result with 5 digits after the decimal point.

*/

using System;

    class CalculateFormula
    {
        static void Main()
        {
            Console.Write("Enter value for N = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter value for X = ");
            int x = int.Parse(Console.ReadLine());
            double sum = 1;
            int facktoriel = 1;
            for (int i = 1; i <= n ; i++)                   // One adn only loop
            {
                facktoriel *= i;
               sum +=  (facktoriel / Math.Pow(x,i)); 
            }
            Console.WriteLine("facktoriel = {0:0.00000}",sum);  // 5 digits after decimal point
            
        }
    }

