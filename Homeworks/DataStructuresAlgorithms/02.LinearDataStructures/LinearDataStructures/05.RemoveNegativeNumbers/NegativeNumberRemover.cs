namespace RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task.5 Write a program that removes from given sequence all negative numbers.
    /// </summary>
    public class NegativeNumberRemover
    {
        private const int NumbersToGenerate = 50;
        private const int MinRange = -100;
        private const int MaxRange = 100;
        private static readonly Random Generator = new Random();

        public static void Main()
        {
            List<int> randomNumbers = new List<int>();
            for (int i = 0; i < NumbersToGenerate; i++)
            {
                int numberToAdd = Generator.Next(MinRange, MaxRange);
                randomNumbers.Add(numberToAdd);
            }

            IList<int> result = RemoveNegativeNumber(randomNumbers);
            Console.WriteLine(string.Join(", ", result));
        }

        private static IList<int> RemoveNegativeNumber(IList<int> numbers)
        {
            IList<int> result = new List<int>();

            //// I don't use remove because it will make more operation to remove an element
            //// So the complexity of algorithm is O(n)
            foreach (int number in numbers)
            {
                if (number >= 0)
                {
                    result.Add(number);
                }
            }

            return result;
        }
    }
}
