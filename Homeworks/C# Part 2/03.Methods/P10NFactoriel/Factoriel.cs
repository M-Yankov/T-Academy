/*Problem 10. N Factorial

    Write a program to calculate n! for each n in the range [1..100].

Hint: Implement first a method that multiplies a number represented as array of digits by given integer number.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Factoriel
    {
        static void Main()
        {
            Console.Write("Enter n! for n = ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Method(number)); ;
           
        }
        static int Method(int a)
        {
            int[] arr = new int[a];
            for (int i = 0; i < a; i++)
            {
                arr[i] = i+1;
            }
            return Factoreiee(arr);
            
        }
        static int Factoreiee(int[] arr)
        {
            int proizvedenie = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                proizvedenie *= arr[i];
            }
            return proizvedenie;
        }
    }

