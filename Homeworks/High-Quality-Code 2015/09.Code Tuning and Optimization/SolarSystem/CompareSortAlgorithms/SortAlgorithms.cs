namespace CompareSortAlgorithms
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class SortAlgorithms
    {
        internal static void InsertionSort<T>(T[] paramCollection)
        {
            dynamic[] collection = new dynamic[paramCollection.Length];
            Array.Copy(paramCollection, collection, collection.Length);

            Stopwatch timer = new Stopwatch();
            timer.Start();

            for (int i = 0; i < collection.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                if (collection[i] < collection[i - 1])
                {
                    int index = i;

                    while (collection[index] < collection[index - 1])
                    {
                        var valueToReplace = collection[index - 1];
                        collection[index - 1] = collection[index];
                        collection[index] = valueToReplace;
                        index--;

                        if (index == 0)
                        {
                            break;
                        }
                    }
                }
            }

            timer.Stop();
            // Console.WriteLine("{0} - time elapsed - {1}", string.Join(", ", collection), timer.Elapsed); // ensure that array is sorted.
             Console.WriteLine("Time elapsed - {0}", timer.Elapsed);            
        }

        internal static void SelectiionSort<T>(T[] paramCollection)
        {
            T[] collection = new T[paramCollection.Length];
            Array.Copy(paramCollection, collection, paramCollection.Length);
            Stopwatch timer = new Stopwatch();
            timer.Start();

            List<T> sortedValues = new List<T>();
            int index = 0;

            for (int i = 0; i < collection.Length; i++)
            {
                T currentElemenent = collection[i];
                T minValue = collection[i];
                for (int j = i + 1; j < collection.Length; j++)
                {
                    if ((dynamic)minValue > (dynamic)collection[j])
                    {
                        minValue = collection[j];
                        index = j;
                    }
                }

                if ((dynamic)currentElemenent > (dynamic)minValue)
                {
                    T valueToReplace = collection[i];
                    collection[i] = collection[index];
                    collection[index] = valueToReplace;
                }
            }

            timer.Stop();
            //Console.WriteLine("{0} - time elapsed - {1}", string.Join(", ", collection), timer.Elapsed);
            Console.WriteLine("Time elapsed - {0}", timer.Elapsed);            
        }

        internal static void QuickSort<T>(T[] collection, int startIndex, int endIndex) 
        {
            // {9 3 8 1 6 7 4};
            // {7 3 8 1 6 4 9};
            // {6 3 8 1 4 7 9};
            // {1 3 8 4 6 7 9};
            // {1 3 8 4 6 7 9};
            // {1 3 4 8 6 7 9};
            int indexOfPivot = endIndex;

            for (int i = startIndex; i < indexOfPivot;)
            {
                if ((indexOfPivot >=0 && indexOfPivot < collection.Length) && (dynamic)collection[i] > (dynamic)collection[indexOfPivot])
                {
                    dynamic valueToReplace = collection[i];
                    collection[i] = collection[indexOfPivot - 1];
                    collection[indexOfPivot - 1] = collection[indexOfPivot];
                    collection[indexOfPivot] = valueToReplace;
                    indexOfPivot--;
                }
                else
                {
                    i++;
                }
            }

            if (!IsArraySorted(collection, 0, indexOfPivot - 1))
            {
                QuickSort(collection, 0, indexOfPivot - 1);
            }

            if (!IsArraySorted(collection, indexOfPivot + 1, collection.Length - 1))
            {
                QuickSort(collection, indexOfPivot + 1, collection.Length - 1);
            }

            //if (IsArraySorted(collection, 0, collection.Length -1))
            //{
            //    Console.WriteLine("{0} - time elapsed - ", string.Join(", ", collection));
            //}
            //return collection;
            //return new dynamic[] { "nothing" };
        }

        private static bool IsArraySorted<T>(T[] collection, int startIndex, int endIndex)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                if ((dynamic)collection[i] > (dynamic)collection[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static void Main()
        {
            DecimalTesting.TestSortAlgorytmsWithDecimalValues();
            DoubleTesting.TestSortAlgorythsWithDoubleValus();
            FloatTesting.TestSortAlgorythmsWithFloatValues();
        }
    }
}
