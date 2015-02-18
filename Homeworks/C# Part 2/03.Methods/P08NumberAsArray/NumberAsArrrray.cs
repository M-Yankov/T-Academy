/*Problem 8. Number as array

    Write a method that adds two positive integer numbers represented as arrays of digits (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
    Each of the numbers that will be added could have up to 10 000 digits.
0*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NumberAsArrrray
{
    static void Main()
    {
        Console.Write("Enter fitst num: ");
        string first = Console.ReadLine();
        Console.Write("Enter second num: ");
        string second = Console.ReadLine();
        int num = first.Length > second.Length ? first.Length : second.Length;
        int[] array1 = new int[num];
        int[] array2 = new int[num];
    }
    static void Fill(int[] arr , int num)
    {
        for (int i = arr.Length -1; i >= 0; i--)
        {
            arr[i] = num % 10;
            num = num / 10;
        }
    }
    static void Calculate(int[] a , int[] b ,)
}
