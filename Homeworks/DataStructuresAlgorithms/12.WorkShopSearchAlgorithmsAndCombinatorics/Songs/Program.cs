namespace Songs
{
    using System;
    using System.Linq;

    public class Program
    {

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var arr1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var arr2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); ;
            var pesho = new int[n + 1];

            for (int i = 0; i < n; i++)
            {
                pesho[arr1[i]] = i;
            }

            for (int i = 0; i < n; i++)
            {
                arr2[i] = pesho[arr2[i]];
            }


            int inversions = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (arr2[i] > arr2[j])
                    {
                        inversions++;
                    }
                }
            }

            Console.WriteLine(CountInversions(arr2, 0, n));
            
        }

        private  static long CountInversions(int[] array, int left, int right)
        {
            if (left + 1 == right)
            {
                return 0;
            }

            int middle = (left + right) / 2;

            long inversions =  CountInversions(array, left, middle) + CountInversions(array, middle, right);

            int[] sorted = new int[right - left];
            int i = left;
            int j = middle;
            int k = 0;

            while (i < middle && j < right)
            {
                if (array[i] < array[j])
                {
                    sorted[k] = array[i];
                    i++;
                }
                else
                {
                    inversions += middle - i;

                    sorted[k] = array[j];
                    j++;
                }

                k++;
            }

            while (i < middle)
            {
                sorted[k] = array[i];
                i++;
                k++;
            }

            while (j < right)
            {
                sorted[k] = array[j];
                j++;
                k++; ;
            }

            for (int z = 0; z < sorted.Length; z++)
            {
                array[left + z] = sorted[z];
            }

            return inversions;
        }
    }
}
