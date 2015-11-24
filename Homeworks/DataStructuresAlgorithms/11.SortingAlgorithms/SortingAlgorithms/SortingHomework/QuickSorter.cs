namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return;
            }

            this.QuickSort(collection, 0, collection.Count);
        }

        private void QuickSort(IList<T> collection, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int indexOfPivot = this.FindPivot(collection, startIndex, endIndex);
                this.QuickSort(collection, startIndex, indexOfPivot);
                this.QuickSort(collection, indexOfPivot + 1, endIndex);
            }
        }

        private int FindPivot(IList<T> collection, int startIndex, int endIndex)
        {
            T pivot = collection[endIndex - 1];
            int index = startIndex;
            for (int i = startIndex; i < endIndex - 1; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    T temp = collection[i];
                    collection[i] = collection[index];
                    collection[index] = temp;
                    index++;
                }
            }

            T temp2 = collection[index];
            collection[index] = collection[endIndex - 1];
            collection[endIndex  - 1] = temp2;
            return index;
        }
    }
}
