namespace PositiveIntegerNumbers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 1. Write a program that reads from the console a sequence of positive integer numbers.
    ///     ○ The sequence ends when empty line is entered.
    ///     ○ Calculate and print the sum and average of the elements of the sequence.
    ///     ○ Keep the sequence in List<int>.
    /// </summary>
    public class StartUp
    {
        public static void Main()
        {
            string input = " ";
            long sum = 0;
            int current = 0;
            List<int> numbers = new List<int>();

            while (input != string.Empty)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out current))
                {
                    sum += current;
                    numbers.Add(current);
                    //// it can be done without using List<int>, just counter++;
                }
                else if (input != string.Empty)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }

            //// decimal for accuracy, float for speed.
            double average = (double)sum / (numbers.Count == 0 ? 1 : numbers.Count);
            Console.WriteLine("\nThe sum is {0}\nAverage is {1}", sum, average);
        }
    }
}