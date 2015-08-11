namespace CompareSortAlgorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class DecimalTesting
    {

        internal static void TestSortAlgorytmsWithDecimalValues()
        {
            Random generetor = new Random();
            int arrayLength = 100;
            decimal[] randomCollection = new decimal[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                randomCollection[i] = Convert.ToDecimal(generetor.NextDouble() * 25523431.00002132426547);
            }

            decimal[] sorted = new decimal[arrayLength];
            decimal[] reversed = new decimal[sorted.Length];

            Array.Copy(randomCollection, sorted, randomCollection.Length);
            Array.Sort(sorted);
            Array.Copy(sorted, reversed, sorted.Length);
            Array.Reverse(reversed);

            Console.WriteLine("Decimal sorting\n\tInsertion sort:");
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
            //Console.WriteLine("{0} - time elapsed {1} - ", string.Join(", ", randomCollection), timer.Elapsed);
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
