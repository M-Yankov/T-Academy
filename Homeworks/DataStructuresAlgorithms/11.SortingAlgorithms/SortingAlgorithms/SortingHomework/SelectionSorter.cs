namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return;
            }

            for (int i = 0; i < collection.Count - 1; i++)
            {
                T min = collection[i];
                int index = 0;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (min.CompareTo(collection[j]) > 0)
                    {
                        min = collection[j];
                        index = j;
                    }
                }

                if (min.CompareTo(collection[i]) != 0)
                {
                    T temp = collection[i];
                    collection[i] = collection[index];
                    collection[index] = temp;
                }
            }
        }
    }
}
