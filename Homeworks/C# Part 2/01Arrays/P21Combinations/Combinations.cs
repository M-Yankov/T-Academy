/*Problem 21.* Combinations of set

    Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N].
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Combinations
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine()); 
        int[] arr = new int[int.Parse(Console.ReadLine())];
        Combination(arr, n, 0, 0);

    }
    static void Combination(int[] arr, int n, int i, int next)
    {
        if (i == arr.Length)
        {
            Console.WriteLine(string.Join(", ", arr));
            return;
        }
        for (int j = next; j < n; j++)
        {
            arr[i] = j + 1;
            Combination(arr, n, i + 1, j + 1);
        }
    }
}

