namespace LongestSequence
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 4. Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
    ///     ○ Write a program to test whether the method works correctly. 
    ///     Note: See 04.TestLongeesSequence project thate are some tests.
    /// </summary>
    public class LongestSequence
    {
        public static List<int> FindLongestSequnceOfEqualNumbers(IList<int> numbers)
        {
            int startIndex = 0;
            int endIndex = 0;
            int counter = 1;
            int maxLength = 1;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                    //// if you change it to >= will results last longest sequence
                    if (counter > maxLength) 
                    {
                        maxLength = counter;
                        endIndex = i + 1;
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            startIndex = endIndex - (maxLength - 1);
            List<int> result = new List<int>();

            for (int i = startIndex; i <= endIndex; i++)
            {
                result.Add(numbers[i]);
            }

            return result;
        }
    }
}
