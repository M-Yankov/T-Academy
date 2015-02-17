using System;
using System.Collections.Generic;
using System.Linq;


namespace P02MaxicalSum
{
    class Sum
    {
        static void Main()
        {
            Console.Write("Enter rows: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Enter cols: ");
            int M = int.Parse(Console.ReadLine());
            int[,] myArray = new int[N, M];
            if(!Check(N,N))
            {
                Console.WriteLine("Bad input! cow & row must >= 3");
                return;
            }
            Assign(myArray);
            Console.WriteLine("Your array: ");
            Print(myArray);
            Console.WriteLine("\nMax Sum 3x3 is:\n");
            MaxSum(myArray);
        }
        public static void Print(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int z = 0; z < arr.GetLength(1); z++)
                {
                    Console.Write("{0,2}", arr[i, z]);
                }
                Console.WriteLine();
            }
        } // I use methods
        public static void Assign(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int z = 0; z < arr.GetLength(1); z++)
                {
                    Console.Write("[{0},{1}] = ", i, z);
                    arr[i, z] = int.Parse(Console.ReadLine());
                }
            }
        } // and I am happy
        public static bool Check(int a, int b)
        {
            if(a < 3 || b < 3)
            {
                return false;
            }
            else 
            {
                return true;
            }
        } // because It's easy
        public static void MaxSum(int[,] arr)
        {
            int sum = int.MinValue;
            int temp;
            int row = 0;
            int col = 0;
            for (int i = 0; i < arr.GetLength(0) -2; i++)
            {
                for (int z = 0; z < arr.GetLength(1) -2; z++)
                {
                    temp =  arr[i, z] + arr[i + 1, z] + arr[i + 2, z]+
                            arr[i, z+1] + arr [i+1 , z+1] + arr[i+2 , z+1]+
                            arr[i, z+2] + arr[i+1 , z+2] + arr[i+2, z+2];
                    if (temp > sum)
                    {
                        sum = temp;
                        row = i;
                        col = z;
                    }
                }
            }
            for (int r = row; r <= row + 2; r++)
            {
                for (int c = col; c <= col +2; c++)
                {
                    Console.Write("{0,2}", arr[r,c]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Sum: {0}",sum);
        } // cheers :)
    }
}
