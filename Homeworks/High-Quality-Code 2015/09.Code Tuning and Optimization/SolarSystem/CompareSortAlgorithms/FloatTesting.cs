namespace CompareSortAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class FloatTesting
    {
        internal static void TestSortAlgorythmsWithFloatValues()
        {
            Random generetor = new Random();
            int arrayLength = 100;
            float[] randomCollection = new float[arrayLength];
            byte sign = 1;

            for (int i = 0; i < arrayLength; i++)
            {
                if (i % 2 == 0)
                {
                    randomCollection[i] = (float)(generetor.NextDouble() * 9123936931.002374589478 * -sign);
                }
                else
                {
                    randomCollection[i] = (float)(generetor.NextDouble() * 9123936931.002374589478 * sign);
                }
            }

            float[] sorted = new float[arrayLength];
            float[] reversed = new float[sorted.Length];

            Array.Copy(randomCollection, sorted, randomCollection.Length);
            Array.Sort(sorted);
            Array.Copy(sorted, reversed, sorted.Length);
            Array.Reverse(reversed);

            Console.WriteLine("Float sorting\n\tInsertion sort:");
            Console.Write("\t\tRandom values - ");
            SortAlgorithms.InsertionSort(randomCollection);
            Console.Write("\t\tSorted values - ");
            SortAlgorithms.InsertionSort(sorted);
            Console.Write("\t\tReversed values - ");
            SortAlgorithms.InsertionSort(reversed);

            // Console.WriteLine(string.Join(", ", collection)); uncomment this line to be sure that the array is not sorted. just sorts it's copy. 
            Console.WriteLine("\tSelection sort:");
            Console.Write("\t\tRandom values - ");
            SortAlgorithms.SelectiionSort(randomCollection);
            Console.Write("\t\tSorted values - ");
            SortAlgorithms.SelectiionSort(sorted);
            Console.Write("\t\tReversed values - ");
            SortAlgorithms.SelectiionSort(reversed);

            // After quick sort the array is sorted and you can't use it as random mixed values. 
            Console.WriteLine("\tQuick Sort: ");
            Stopwatch timer = new Stopwatch();
            timer.Start();
            SortAlgorithms.QuickSort(randomCollection, 0, randomCollection.Length - 1);
            timer.Stop();
            //Console.WriteLine("{0} - time elapsed {1} - ", string.Join(", ", secondRandomCollection), timer.Elapsed);
            Console.WriteLine("\t\tRandom values - Time elapsed - {0}", timer.Elapsed);

            timer.Restart();
            SortAlgorithms.QuickSort(sorted, 0, randomCollection.Length - 1);
            timer.Stop();
            Console.WriteLine("\t\tSorted values - Time elapsed - {0}", timer.Elapsed);

            timer.Restart();
            SortAlgorithms.QuickSort(reversed, 0, randomCollection.Length - 1);
            timer.Stop();
            Console.WriteLine("\t\tReversed values - Time elapsed - {0}", timer.Elapsed);

        }
    }
}
