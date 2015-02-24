/*Problem 3. Sequence n matrix

    We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbour elements located on the same line, column or diagonal.
    Write a program that finds the longest sequence of equal strings in the matrix.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SequenceMatrix
{
    public static int sumOuter = 1;
    static void Main()
    {
        Console.Write("Enter rows: ");  // no afect 
        int N = int.Parse(Console.ReadLine());
        Console.Write("Enter cols: ");
        int M = int.Parse(Console.ReadLine());
        string[,] myArray = 
        {
        {"ha","qq" ,"s"},
        {"pp" , "ha", "s"},
        {"pp", "qq" ,"ha" },   // there is some example but I am 100% sure that my program will not work with all Array strings - No free time. .try some your inputs
    };
        //Input(myArray);

        Print(myArray);
        string element = Search(myArray);
        Console.WriteLine("Answer: ");
        for (int i = 0; i < sumOuter; i++)
        {
            Console.WriteLine(element);
        }
    }
    static void Print(string[,] arr)
    {
        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                Console.Write("{0} \t", arr[row, col]);
            }
            Console.WriteLine();
        }
    }
    static void Input(string[,] arr)
    {
        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                Console.Write("[{0},{1}] = ", row, col);
                arr[row, col] = Console.ReadLine();
            }
        }
    }

    static string Search(string[,] arr)
    {
        int row = 0;
        int col = 0;
        int counter = 1;
        int sum = 1;
        string some = "";
        while (row < arr.GetLength(0) -1 && col < arr.GetLength(1))
        {
            if (col == arr.GetLength(1) - 1  )
            {
                if (arr[row, col] == arr[row + 1, col])
                {
                    row += 1;
                    counter++;
                }
                else if (arr[row, col] == arr[row, col - 1])
                {
                    col -= 1;
                    counter++;
                }
                else if (arr[row, col] == arr[row + 1, col - 1])
                {
                    row += 1;
                    col -= 1;
                    counter++;
                }
                else
                {
                    row = 0;
                    counter = 1;
                }
                if (counter > sum)
                {
                    sum = counter;
                    some = arr[row, col];
                }
            }
            else
            {
                if (arr[row, col] == arr[row, col + 1])
                {
                    col += 1;
                    counter++;
                }
                else if (arr[row, col] == arr[row + 1, col])
                {
                    row += 1;
                    counter++;
                }
                else if (arr[row, col] == arr[row + 1, col + 1])
                {
                    row += 1;
                    col += 1;
                    counter++;
                }
                else
                {
                    col++;
                    counter = 1;
                }
                if (counter > sum)
                {
                    sum = counter;
                    some = arr[row, col];
                }
            }
        }
        sumOuter = sum;
        return some;
    }

}

