namespace WordCombinations
{
    /// <summary>
    /// Task 6. Write a program for generating and printing all subsets of k strings from given set of strings. 
    ///     ○  Example: s = {test, rock, fun}, k=2 → (test rock), (test fun), (rock fun)
    /// </summary>
    public class CombinationOfWords
    {
        private static int k = 2;
        private static int[] arr;
        private static string[] words;

        public static void Main()
        {
            words = new string[] { "test", "rock", "fun", "pesho", "gosho" };
            arr = new int[words.Length];
            Comb(0, 0);
        }

        private static void Comb(int index, int start)
        {
            if (index >= k)
            {
                PrintWords(arr);
            }
            else
            {
                for (int i = start; i < arr.Length; i++)
                {
                    arr[index] = i;
                    Comb(index + 1, i + 1);
                }
            }
        }

        private static void PrintWords(int[] arr)
        {
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            for (int i = 0; i < k; i++)
            {
                result.Append(words[arr[i]] + " ");
            }

            System.Console.WriteLine(result.ToString());
        }
    }
}
