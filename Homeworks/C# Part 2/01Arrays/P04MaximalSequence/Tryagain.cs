/*Problem 4. Maximal sequence

    Write a program that finds the maximal sequence of equal elements in an array.
 */

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;


class LetsTryAgain 
{
    static void Main()
    {
        Console.Write("Array Lenght: ");
        int range = int.Parse(Console.ReadLine());
        int[] myArray = new int[range];
        int?[] final = new int?[range];  // This is array with null values 
       // int?[] nullable = new int?[2]; 
        for (int i = 0; i < range; i++)
        {
            Console.Write("Enter " + i + " index: ");
            myArray[i] = int.Parse(Console.ReadLine());
        }
        int temp = 0;
        for (int j  = 0; j  < myArray.Length -1 ; j ++)
        {
            if(myArray[j] == myArray[j + 1])
            {
                final[temp] = myArray[j];
                final[temp + 1] = myArray[j + 1];
                temp++;
            }
            else
            {
                temp = 0;
            }
        }
        //string finres = string.Join(", ", final);
        
        foreach (var s in final)
        {
            
            if(s != null)
            Console.Write(s + ", ");
        }
        //Console.WriteLine(finres);   ///               string[] numberStrigs = Console.REadLine().Split(' ');
        Console.WriteLine();
        // int[] numbres = Console.ReadLine().split(' ').Select(int.parse).ToArray();
        
    }
}