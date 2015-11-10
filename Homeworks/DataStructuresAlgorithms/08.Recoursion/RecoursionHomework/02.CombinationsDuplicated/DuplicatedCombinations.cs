namespace CombinationsDuplicated
{
    using System;

    /// <summary>
    /// Task 2. Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set. Example: 
    ///     ○     n=3, k=2 → (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
    /// </summary>
    public class DuplicatedCombinations
    {
        public static void Main(string[] args)
        {
            /*
            for (int i = 1; i <= 3; i++)
            {
                for (int k = i; k <= 3; k++)
                {
                    for (int z = k; z <= 3; z++)
                    {
                    Console.WriteLine("{0} {1} {2}", i, k, z);

                    }
                }
            }
            */

            int length = 2;
            int startNum = 1;
            int endNum = 3;

            int[] arr = new int[length];
            GenerateCombinations(arr, 0, startNum, endNum);
        }

        private static void GenerateCombinations(int[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                // A combination was found --> print it
                Console.WriteLine("(" + string.Join(", ", arr) + ")");
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, index + 1, i, endNum);
                }
            }
        }

        private static void SimulateNestedLoops(int index, int[] vector)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine("[{0}]", string.Join("] [", vector));
                return;
            }

            for (int i = 1; i <= vector.Length; i++)
            {
                vector[index] = i;
                SimulateNestedLoops(index + 1, vector);
            }
        }

        private static void Combination(int[] arr, int n, int i, int next)
        {
            if (i >= arr.Length)
            {
                Console.WriteLine(string.Join(", ", arr));
                return;
            }

            for (int j = next; j < n; j++)
            {
                arr[i] = j + 1;
                Combination(arr, n, i + 1, j + 1);
            }
        }

        private static void Various(int index, int[] result, int k, int n)
        {
            if (index == k)
            {
                for (int i = 0; i < k; i++)
                {
                    Console.Write("{0,3}", result[i]);
                }

                Console.WriteLine();
                return;
            }

            for (int i = 0; i < n; i++)
            {
                result[index] = i + 1;
                Various(index + 1, result, k, n);
            }
        }
    }
}
