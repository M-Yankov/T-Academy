/*Problem 20.* Variations of set

    Write a program that reads two numbers N and K and generates all the variations of K elements from the set [1..N].
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Varioussets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] array = new int[k];
        for (int i = 1; i <= n; i++)
        {
            array[0] = i;
            for (int j = 1; j <= n; j++)
            {
                array[1] = j;
                Console.WriteLine(string.Join(", ", array));   // two variations
            }
        }
    }
}

