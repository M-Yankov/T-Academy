namespace Permutations
{
    using System;

    /// <summary>
    /// Task 4. Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n. Example: 
    ///     ○ n=3 → {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2},{3, 2, 1}
    /// </summary>
    public class Permutation
    {
        public static void Main()
        {
            int length = 3;
            int startNum = 1;
            int endNum = 3;

            int[] arr = new int[length];
            GenerateCombinations(arr, 0, startNum, endNum);
        }

        private static void GenerateCombinations(int[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                if (!HasDuplicates(arr))
                {
                    Console.WriteLine("(" + string.Join(", ", arr) + ")");
                }
            }
            else
            {
                for (int i = 1; i <= endNum; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, index + 1, i, endNum);
                }
            }
        }

        private static bool HasDuplicates(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int k = i + 1; k < arr.Length; k++)
                {
                    if (arr[i] == arr[k])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
