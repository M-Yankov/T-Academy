/*Problem 11. Adding polynomials

    Write a method that adds two polynomials.
    Represent them as arrays of their coefficients.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

class Polinom
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.Write("Enter first coeficient: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter second coeficient: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Enter third coeficient: ");
        int c = int.Parse(Console.ReadLine());
        Poly(a, b, c);
    }
    static void Poly(int a, int b, int c)
    {
        int[] arr = { a, b, c };
        Console.WriteLine("{0}X\u00B2 + {1}X + {2} = 0",a,b,c);
    }
}

