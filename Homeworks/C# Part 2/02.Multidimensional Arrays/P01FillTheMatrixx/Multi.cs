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
            if (count % 2 != 0)
            {
                for (int z = 0; z < n; z++)
                {
                    multi[i, z] = ineer;
                    ineer++;
                }
                count++;
            }
            else
            {
                for (int p = n - 1; p >= 0; p--)
                {
                    multi[i, p] = ineer;
                    ineer++;
                }
                count++;
            }
        }
        Console.WriteLine("\n\nb)");
        Print(multi);
        Array.Clear(multi, 0, multi.Length);

        ineer = 1;  //  = 0
        int ime = 1;
        int nameCol = 1;
        int col = 0;
        int row = multi.GetLength(1) - ime;
        bool lastRow = true;
        bool lastCol = false;

        while (true)
        {
            if (lastRow)
            {
                row = multi.GetLength(1) - ime;
                if (row < 0)
                {
                    row = 0;
                    lastCol = true;
                }

            }
            if (lastCol)
            {
                col = nameCol;
            }
            if (row == 0 && col == n - 1)
            {
                multi[n - 1, 0] = n * n;//ineer + 3 ;
                break;
            }
            multi[col, row] = ineer;

            ineer++;


            if (row == n - 1)
            {
                ime++;
                col = 0;
                lastRow = true;
                //ineer += 3;

            }
            else if (col == n - 1)
            {
                nameCol++;
                row = 0;
                lastCol = true; // to repair code.
            }
            else
            {
                row++;
                col++;
                lastRow = false;
                lastCol = false; // new added 
            }
        }
        Console.WriteLine("\n\nc)");
        Print(multi);
        ineer = 1;
        row = 0;
        col = 0;
        int dokade = 0;
        bool exit = false;
        while (true)
        {
            for (int z = 0 + dokade; z < multi.GetLength(1) - dokade; z++)   // z < n - dokade
            {
                multi[col, z] = ineer;                    // |      /// array[ col , row ] ???
                if (ineer == n * n)
                {
                    exit = true;
                }
                ineer++;                                  // |
                row = z;                                  // V
            }
            if (exit)
            {
                break;
            }
            for (int c = 1 + dokade; c < multi.GetLength(0) - dokade; c++)  /// ------->
            {
                multi[c, row] = ineer;
                if (ineer == n * n)
                {
                    exit = true;
                }
                ineer++;
                col = c;
            }
            if (exit)
            {
                break;
            }
            for (int u = row - 1; u > -1 + dokade; u--)    // ^
            {                                               // |
                multi[col, u] = ineer;                      // |
                if (ineer == n * n)
                {
                    exit = true;
                }
                ineer++;                                    // |
                row = u;                                    // |
            }
            if (exit)
            {
                break;
            }
            dokade++;
            for (int le = col - 1 ; le > -1 + dokade; le--)     /// <-------   //// col - 1 - dokade
            {
                multi[le, row] = ineer;
                if (ineer == n * n)
                {
                    exit = true;
                }
                ineer++;
                col = le;
            }
            if (exit)
            {
                break;
            }
        }
        Console.WriteLine("\n\nd)");
        Print(multi);
        Console.WriteLine("\nI've made it!!!!");
    }
    static void Print(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int z = 0; z < array.GetLength(1); z++)
            {
                Console.Write("{0,3}", array[z, i]);
            }
            Console.WriteLine();
        }
    }
}

