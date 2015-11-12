namespace Divisors
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DivisorsSolution
    {
        private static long numberValue = long.MinValue;
        private static long minDevisors = long.MaxValue;

        public static void Main()
        {
            int lengthOfNumbers = int.Parse(Console.ReadLine());
            long[] inputNumbers = new long[lengthOfNumbers];
            for (int i = 0; i < lengthOfNumbers; i++)
            {
                inputNumbers[i] = long.Parse(Console.ReadLine());
            }

            Perm(inputNumbers, 0);
            Console.WriteLine(numberValue);
        }

        private static void Perm(long[] arr, int k)
        {
            if (k >= arr.Length)
            {
                long number = long.Parse(string.Join(string.Empty, arr));
                long devisors = GetCountOfDevisors(number);

                if (minDevisors > devisors)
                {
                    minDevisors = devisors;
                    numberValue = number;
                }
                else if (minDevisors == devisors && numberValue > number)
                {
                    //// ToDo try write code with opened eyes.
                    numberValue = number;
                }
            }
            else
            {
                Perm(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(arr, k, i);
                    Perm(arr, k + 1);
                    Swap(arr, k, i);
                }
            }
        }

        private static void Swap(long[] array, int firstNumberIndex, int secondNumberIndex)
        {
            long temp = array[firstNumberIndex];
            array[firstNumberIndex] = array[secondNumberIndex];
            array[secondNumberIndex] = temp;
        }

        private static int GetCountOfDevisors(long number)
        {
            //// Optimize?
            int countOfDivisors = 1;
            for (int i = 1; i < (number / 2) + 1; i++)
            { 
                if (number % i == 0)
                {
                    countOfDivisors++;
                }

                if (countOfDivisors > minDevisors)
                {
                    break;
                }
            }

            return countOfDivisors;
        }
    }
}
