namespace Assertion
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class AssertionsHomework
    {
        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr.Length != 0, "Empty Collection is not allowed!", "Count less than zero!", arr);
            Debug.Assert(arr.Length != 1, "Only one element can't be sorted!", "Why do you want to sort 1 item?", arr);

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr.Length > 1, "Put more elements to collection", "Can't be zero or one");
            Debug.Assert(0 <= startIndex && startIndex <= arr.Length - 1, "Invalid index", "Index OutOfRange exception will receive.", startIndex);
            Debug.Assert(0 <= endIndex && endIndex <= arr.Length - 1, "Invalid index", "Index OutOfRange exception will receive.", endIndex);
            Debug.Assert(startIndex <= endIndex, "Start index must be greater than endIndex");

            int minElementIndex = startIndex;

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            T oldX = x;
            x = y;
            y = oldX;
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr.Length > 1, "Put more elements to collection", "Can't be zero or one");
            Debug.Assert(value != null, "Value can't be null", "Try to pass a number.", value);
            Debug.Assert(0 <= startIndex && startIndex <= arr.Length - 1, "Invalid index", "Index OutOfRange exception will receive.", startIndex);
            Debug.Assert(0 <= endIndex && endIndex <= arr.Length - 1, "Invalid index", "Index OutOfRange exception will receive.", endIndex);
            Debug.Assert(startIndex <= endIndex, "Start index must be greater than endIndex");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;

                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        private static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            int minElement = arr.Min();
            int maxelement = arr.Max();

            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);

            Debug.Assert(minElement == arr[0], "Selection Sort doesn't work!", "Minimal value is not sorted.");
            Debug.Assert(maxelement == arr[arr.Length - 1], "Selection Sort doesn't work!", "Can't sort maximal element!");
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            //// SelectionSort(new int[0]); // Test sorting empty array
            //// SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(BinarySearch(arr, -1000));
            Console.WriteLine(BinarySearch(arr, 0));
            Console.WriteLine(BinarySearch(arr, 17));
            Console.WriteLine(BinarySearch(arr, 10));
            Console.WriteLine(BinarySearch(arr, 1000));
        }
    }
}
