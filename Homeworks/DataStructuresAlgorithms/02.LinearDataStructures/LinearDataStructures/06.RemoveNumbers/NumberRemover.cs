namespace RemoveNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Task 6. Write a program that removes from given sequence all numbers that occur odd number of times.
    /// </summary>
    public class NumberRemover
    {
        public static void Main()
        {
            List<int> theExample = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            IEnumerable<KeyValuePair<int, int>> result = RemoveNumbersWithOddOcurance(theExample);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{ ");
            foreach (KeyValuePair<int, int> numberWithOccurance in result)
            {
                for (int i = 0; i < numberWithOccurance.Value; i++)
                {
                    stringBuilder.Append(numberWithOccurance.Key + ", ");
                }
            }

            stringBuilder.Append("}");
            stringBuilder.Remove(stringBuilder.Length - 3, 1);
            Console.WriteLine(stringBuilder.ToString());
        }

        private static IEnumerable<KeyValuePair<int, int>> RemoveNumbersWithOddOcurance(IList<int> numbers)
        {
            IDictionary<int, int> numberOccurance = new Dictionary<int, int>();

            foreach (int number in numbers)
            {
                if (numberOccurance.ContainsKey(number))
                {
                    numberOccurance[number]++;
                }
                else
                {
                    numberOccurance[number] = 1;
                }
            }

            return numberOccurance.Where(num => num.Value % 2 == 0);
        }
    }
}
