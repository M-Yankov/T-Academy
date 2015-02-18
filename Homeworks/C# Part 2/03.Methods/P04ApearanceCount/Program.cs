/*Problem 4. Appearance count

    Write a method that counts how many times given number appears in given array.
    Write a test program to check if the method is workings correctly.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        Console.Write("Enter elements: ");
        int[] myArray = Console.ReadLine().Split(new string[] { " ", ",", ", " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
        //int[] myArrat = { 8, 1, 9, 6, 7, 8, 7, 4, 8, 5, 4, 3, 7, 7, 4, 8, 2, 8, 8, 9, 2, 6, 9, 3, 7, 7, 3, 4, 8, 6, 5, 4, 9, 7, 6, 6, 6, 8, 5, 5, 5 };
        Console.Write("Enter num 1 - 10: ");
        Array.Sort(myArray);
        int k = int.Parse(Console.ReadLine());
        int result = Number(myArray, k);
        Console.WriteLine("{0} appears {1} times",k,result);
    }
    static int Number(int[] a , int k)
    {
        return a.Count(x => x == k);
    }
}
