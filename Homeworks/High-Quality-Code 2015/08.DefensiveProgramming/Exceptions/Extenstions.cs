namespace Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Extenstions
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            Validator.ValidateLessThanLength(arr.Length, startIndex, count);

            List<T> result = new List<T>();

            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEndingFromText(string str, int count)
        {
            Validator.ValidateLessThanLength(str.Length, 0, count);

            StringBuilder result = new StringBuilder();

            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckIsPrime(int number)
        {
            Validator.LessThanZero(number);

            bool isPrime = true;

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                }
            }

            return isPrime;
        }
    }
}
