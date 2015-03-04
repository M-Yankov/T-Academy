/*Problem 5. Maximal area sum

    Write a program that reads a text file containing a square matrix of numbers.
    Find an area of size 2 x 2 in the matrix, with a maximal sum of its elements.
        The first line in the input file contains the size of matrix N.
        Each of the next N lines contain N numbers separated by space.
        The output should be a single number in a separate text file.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


    class Sum
    {
        static void Main()
        {
            StreamReader reader = new StreamReader("..\\..\\input.txt");
            int n = int.Parse(reader.ReadLine());
            int[,] array = new int[n,n];
            for (int row = 0; row < n; row++)
            {
               int[] temp = reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
               for (int col = 0; col < temp.Length; col++)
               {
                   array[row, col] = temp[col];
               }
            }
            int sum = int.MinValue;
            for (int row = 0; row < array.GetLength(1) - 1 ; row++) // 2x 2                     4 5 6 4
            {
                for (int col = 0; col < array.GetLength(0) - 1; col++)
                {
                    int tempeseasd = array[row,col] + array[row + 1, col] + array[row , col +1] + array[row + 1, col +1];
                    if ( tempeseasd > sum)
                    {
                        sum = tempeseasd;
                    }
                }
            }

            Console.WriteLine(sum); 
            Console.ReadLine();
            // I don't have time but I know what to do...
        }
    }
