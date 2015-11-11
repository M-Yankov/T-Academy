namespace PermutationsWithRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PermutationWithRepetitions
    {
        public static void Main(string[] args)
        {
            var numbers = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            Array.Sort(numbers);
            int countOfPermutations = 0;
            PermutationRepetition(numbers, 0, numbers.Length, ref countOfPermutations);
            Console.WriteLine("countOfPermutations: {0}", countOfPermutations);
            Console.WriteLine("length of array: {0}", numbers.Length);
        }

        private static void PermutationRepetition(int[] arr, int start, int n, ref int count)
        {
            count++;
            PrintArray(arr);
            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermutationRepetition(arr, left + 1, n, ref count);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[n - 1] = firstElement;
            }
        }

        private static void Swap(ref int p1, ref int p2)
        {
            var temp = p1;
            p1 = p2;
            p2 = temp;
        }

        private static void PrintArray(int[] arr)
        {
            string numbers = string.Join(", ", arr);
            Console.WriteLine("{{ {0} }}", numbers);
        }
    }
}
