/*Problem 2. Compare arrays

    Write a program that reads two integer arrays from the console and compares them element by element.
 * 
 */
using System;

class Comparing
{
    static void Main()
    {
        string equal = " is equal to ";
        string notEqual = " is not equal ";
        Console.Write("Lenght of the arrays: ");
        int arrayLength1 = int.Parse(Console.ReadLine());
        double[] masiv1 = new double[arrayLength1];
        for (int i = 0; i < masiv1.Length; i++)
        {
            Console.Write("array1 [" + i + "]" + " = ");
            masiv1[i] = double.Parse(Console.ReadLine());
        }
        double[] masiv2 = new double[arrayLength1];
        for (int j = 0; j < masiv2.Length; j++)
        {
            Console.SetCursorPosition(18, j + 1);
            Console.Write("array2 [" + j + "]" + " = ");
            masiv2[j] = double.Parse(Console.ReadLine());
        }
        Console.WriteLine("\n\n");
        for (int z = 0; z < arrayLength1; z++)
        {
            if(masiv1[z] == masiv2[z])
            {
                Console.WriteLine("array1[" + z + "]" + equal + "array2[" + z + "]");
            }
            else
            {
                Console.WriteLine("array1[" + z + "]" + notEqual + "array2[" + z + "]");
            }
        }
    }
}
