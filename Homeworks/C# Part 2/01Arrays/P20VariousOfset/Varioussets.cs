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


        Various(0, array,k,n);
        
    }
    static void Various(int index, int[] result, int k, int n)
    {
        if (index == k)
        {
            for (int i = 0; i < k; i++)
                Console.Write("{0,3}", result[i]);
            Console.WriteLine();
            return;
        }
        for (int i = 0; i < n; i++)
        {
            result[index] = i + 1;
            Various(index + 1,result , k , n );
        }
    }
}

