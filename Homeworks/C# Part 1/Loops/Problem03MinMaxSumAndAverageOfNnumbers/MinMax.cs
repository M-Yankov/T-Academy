/*Problem 3. Min, Max, Sum and Average of N Numbers

    Write a program that reads from the console a sequence of n integer numbers and returns the minimal, the maximal number, the sum and the average of 
 *  all numbers (displayed with 2 digits after the decimal point).
    The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
   

 * 
 */
using System;


class MinMax
{
    static void Main()
    {
        
        Console.Write("Enter numbers count: ");
        uint count = 0;
        try                                             //<---------- I think this is the best method to avoid break program from input console
        {
            count = uint.Parse(Console.ReadLine());
        }
        catch (Exception)
        {
            Console.WriteLine("Bad Input!");
            return;
        }
        int[] numbers = new int[count];             // Initializing array from type 'int' with lenght = count
        for (int i = 0; i <= count -1; i++)         // assuming numbers to element in array
        {
            Console.Write((i +1)+ " number = ");
            numbers[i] = int.Parse(Console.ReadLine());
        }
        int minValue = numbers[0];
        int maxValue = numbers[0];
        double sum = 0;
        foreach (int i in numbers)
        {
            if (i < minValue)
            {
                minValue = i;
            }
            if (i > maxValue)
            {
                maxValue = i;
            }
            sum += i;
        }
        double avg = sum / count;
        
        Console.WriteLine("Min: " + minValue);
        Console.WriteLine("Max: " + maxValue);
        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Avg: {0:0.00}", avg );
    }
}

