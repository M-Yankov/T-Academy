namespace NumberOccurance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Task 7. Write a program that finds in given array of integers (all belonging to the range [0..1000]) 
    /// how many times each of them occurs.
    ///     ○ Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2} 
    ///         ■ 2 → 2 times
    ///         ■ 3 → 4 times
    ///         ■ 4 → 3 times
    /// </summary>
    public class NumberOccurance
    {
        private const int MinValue = 0;
        private const int MaxValue = 1000;
        private static readonly string ErrorMessage = string.Format("Must be in range [{0}...{1}]", MinValue, MaxValue);

        public static void Main()
        {
            var numbers = new List<int> { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            IDictionary<int, int> numbersOcurances = CheckNumberOccurance(numbers);
            foreach (KeyValuePair<int, int> numberWithOccueance in numbersOcurances.OrderBy(x => x.Key))
            {
                Console.WriteLine("\t■ {0} → {1} times", numberWithOccueance.Key, numberWithOccueance.Value);
            }
        }

        public static IDictionary<int, int> CheckNumberOccurance(IList<int> numbers)
        {
            IDictionary<int, int> result = new Dictionary<int, int>();
            foreach (int number in numbers)
            {
                if (number < MinValue || MaxValue < number)
                {
                    throw new ArgumentOutOfRangeException("number", number, ErrorMessage);
                }

                try
                {
                    result[number]++;
                }
                catch (KeyNotFoundException)
                {
                    result[number] = 1;
                }

                /* Why the code above will be faster? I think the ContainsKey() checks each element in the collection
                 * to verify the result if not found makes "n" operations. Instead I use the index [] witch is constant complexity.
                 * But the whole complexity of the Method is O(n) - checks each number in the input collection.
                if (result.ContainsKey(number))
                {
                    result[number]++;
                }
                else
                {
                    result[number] = 1;
                }*/
            }

            return result;
        }
    }
}