/*Problem 19.* Permutations of set

    Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N].
 * Permutation are calculated like factoriel Example: 3! = 1.2.3 = 6 So wehave 6 sets
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Permutations
{
    static void Main()
    {
        Console.Write("Enter array lenght: ");
        int input = int.Parse(Console.ReadLine());

        int[] gosho = new int[input];
        for (int i = 0; i < input; i++)
        {
            gosho[i] = i + 1;
            Console.WriteLine(string.Join(", ", gosho));
        }
    }
}

