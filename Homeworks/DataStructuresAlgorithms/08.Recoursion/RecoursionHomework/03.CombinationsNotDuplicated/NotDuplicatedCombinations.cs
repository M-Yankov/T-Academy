namespace CombinationsNotDuplicated
{
    using System;

    /// <summary>
    /// Task 3. Modify the previous program to skip duplicates: 
    ///     ○ n=4, k=2 → (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
    /// </summary>
    public class NotDuplicatedCombinations
    {
        public static void Main()
        {
            int length = 2;
            int startNum = 1;
            int endNum = 4;

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
                    GenerateCombinations(arr, index + 1, i + 1, endNum);
                }
            }
        }
    }
}
