namespace WordsVariations
{
    using System.Text;

    /// <summary>
    /// Task 5. Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations V k n). 
    ///     ○ Example: n=3, k=2, set = {hi, a, b} → (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
    /// </summary>
    public class Words
    {
        private static int k = 2;
        private static int n = 3;
        private static int[] arr;
        private static string[] words;

        public static void Main()
        {
            arr = new int[n];
            words = new string[] { "hi", "a", "b" };
            GenerateVariationsNoReps(0);
        }

        private static void GenerateVariationsNoReps(int index)
        {
            if (index >= k)
            {
                PrintWords(arr);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    arr[index] = i;
                    GenerateVariationsNoReps(index + 1);
                }
            }
        }

        private static void PrintWords(int[] indexes)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < n - 1; i++)
            {
                result.Append(words[indexes[i]] + " ");
            }

            result.AppendLine();
            System.Console.WriteLine("({0})", result.ToString().Trim());
        }
    }
}
