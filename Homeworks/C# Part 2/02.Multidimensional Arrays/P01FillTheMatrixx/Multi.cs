/*Problem 1. Fill the matrix

    Write a program that fills and prints a matrix of size (n, n) as shown below:
 * n = 4
    a)  1, 5, 9,  13    b)  1, 8, 9,  16    C)  7, 11, 14, 16   d)* 1, 12, 11, 10
 *      2, 6, 10, 14        2, 7 ,10, 15        4, 8,  12, 15       2, 13, 16,  9
 *      3, 7, 11, 15        3, 6, 11, 14        2, 5,  9,  13       3, 14, 15,  8
 *      4, 8, 12, 16        4, 5, 12, 13        1, 3 , 6,  10       4,  5,  6,  7
 *      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Multi
{
    static void Main()
    {
        Console.Write("Enter length for matrix[N , N] = ");
        int n = int.Parse(Console.ReadLine()); //4   
        int[,] multi = new int[n, n]; //4,4 {red, kolona}
        int ineer = 1;
        for (int i = 0; i < n; i++)
        {
            for (int z = 0; z < n; z++)
            { 
                multi[i, z] = ineer;
                ineer++;
            }
        }
        Console.WriteLine("\n\na)");
        Print(multi);
        ineer = 1;
        int count = 1;
        for (int i = 0; i < n; i++)
        {
            if(count % 2 != 0)
            {
                for (int z = 0; z < n; z++)
                {
                    multi[i,z] = ineer;
                    ineer++;
                }
                count++;
            }
            else
            {
                for (int p = n-1; p >= 0; p--)
                {
                    multi[i,p] = ineer;
                    ineer++;
                }
                count++;
            }
        }
        Console.WriteLine("\n\nb)");
        Print(multi);

    }
    static void Print(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int z = 0; z < array.GetLength(1); z++)
            {
                Console.Write("{0,3}" ,array[z, i]);
            }
            Console.WriteLine();
        }
    }
}

