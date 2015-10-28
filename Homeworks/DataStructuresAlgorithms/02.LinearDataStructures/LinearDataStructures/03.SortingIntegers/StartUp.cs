namespace SortingIntegers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 3. Write a program that reads a sequence of integers (List<int>) ending with an empty line
    /// and sorts them in an increasing order. 
    /// </summary>
    public class StartUp
    {
        public static void Main()
        {
            string input = " ";
            int current = 0;
            List<int> numbers = new List<int>();

            while (input != string.Empty)
            {
                input = Console.ReadLine();
                if (int.TryParse(input, out current))
                {
                    numbers.Add(current);
                }
                else if (input != string.Empty)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }

            numbers.Sort((a, b) => a.CompareTo(b));
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
