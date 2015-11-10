namespace WordsVariations
{
    using System.Text;

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
