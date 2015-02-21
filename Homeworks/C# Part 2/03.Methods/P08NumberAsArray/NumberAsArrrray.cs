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
        string first = Console.ReadLine();  // 152
        Console.Write("Enter second num: ");
        string second = Console.ReadLine(); // 111
        int num = first.Length > second.Length ? first.Length : second.Length;
        int[] array1 = new int[num];
        int[] array2 = new int[num];
        Fill(array1, Convert.ToInt32(first));
        Fill(array2, Convert.ToInt32(second));
        Console.WriteLine("\nResult: ");
        var final = Calculate(array1, array2, num);
        Array.Reverse(final);
        foreach (var i in final)
        {

            Console.Write(i);
        }
        Console.WriteLine();

    }
    static void Fill(int[] arr, int num)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = num % 10;
            num = num / 10;
        }
    }
    static int[] Calculate(int[] a, int[] b, int num)
    {
        int naYm = 0;
        int[] result = new int[num];
        int sum = 0;
        for (int i = 0; i < num; i++)
        {
            sum = a[i] + b[i];
            if (sum > 9)
            {
                result[i] = (sum % 10) + naYm; // 15 % 10 = 5;
                naYm = 1; // 15 /10= 1 naYm is allays 1 ... 10,11,12,13,14,15,16,17,18 <-- that's all results from sum of two 0igits,
            }
            else
            {
                result[i] = sum + naYm;
                naYm = 0;
            }
        }
        if (naYm == 1)
        {
            int[] newArray = new int[result.Length + 1];
            Array.Copy(result, newArray, result.Length);
            newArray[newArray.Length - 1] = 1;
            return newArray;
        }
        else
        {

            return result;
        }
    } // Yes 
}
