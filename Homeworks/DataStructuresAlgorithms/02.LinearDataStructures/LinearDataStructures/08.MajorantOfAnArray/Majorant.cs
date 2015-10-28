namespace MajorantOfAnArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NumberOccurance;

    /// <summary>
    /// Task 8. *The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
    ///     ○ Write a program to find the majorant of given array (if exists).
    ///     ○ Example: 
    ///         ■ {2, 2, 3, 3, 2, 3, 4, 3, 3} → 3
    /// </summary>
    public class Majorant
    {
        public static void Main()
        {
            var numbers = new List<int> { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            var mostOccuranceNumbers = GetMostOccurance(numbers);
            Console.WriteLine(string.Join(", ", mostOccuranceNumbers));
        }

        private static ICollection<int> GetMostOccurance(IList<int> numbers)
        {
            //// reuse the method from previous task
            var numbersOccurances = NumberOccurance.CheckNumberOccurance(numbers);

            int occursAtLeast = (numbers.Count / 2) + 1;

            return numbersOccurances.Where(x => x.Value >= occursAtLeast).Select(x => x.Key).ToList();
        }
    }
}