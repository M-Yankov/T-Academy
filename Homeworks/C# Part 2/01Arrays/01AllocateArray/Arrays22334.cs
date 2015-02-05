/*
 * Problem 1. Allocate array

    Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5.
    Print the obtained array on the console.

 */

using System;


    class Arrays22334
    {
        static void Main()
        {
            int[] mArray = new int[20];
            for (int i = 0; i < mArray.Length; i++)
            {
                mArray[i] = i * 5;
            }
            for (int j = 0; j < mArray.Length; j++)
            {
                Console.WriteLine(j + " --> " + mArray[j]); //elements's indexes multiplied by 5.
            }
        }
    }
