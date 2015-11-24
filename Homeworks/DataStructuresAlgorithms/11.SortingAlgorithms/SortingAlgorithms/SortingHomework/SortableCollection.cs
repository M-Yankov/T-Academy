namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int start = 0, end = this.items.Count - 1; start < end; start++, end--)
            {
                if (item.CompareTo(this.items[start]) == 0)
                {
                    return true;
                }

                if (item.CompareTo(this.items[end]) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            return this.BinarySearch(item, 0, this.items.Count);
        }

        public void Shuffle()
        {
            if (this.items.Count <= 1)
            {
                return;
            }

            int start = 0;
            int end = this.items.Count - 1;
            int middle = this.items.Count / 2;

            while (end > 0 && middle < this.items.Count)
            {
                if (middle == end)
                {
                    this.Swap(start, middle);
                }
                else if (start == end)
                {
                    this.Swap(start, end);
                }
                else
                {
                    this.Swap(start, end);
                    this.Swap(start, middle);
                }

                start++;
                middle++;
                end--;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private bool BinarySearch(T item, int start, int end)
        {
            int middle = (start + end) / 2;
            int compared = item.CompareTo(this.items[middle]);

            if (compared == 0)
            {
                return true;
            }
            else if (start == end)
            {
                return false;
            }
            else if (compared < 0)
            {
                return this.BinarySearch(item, start, middle);
            }
            else
            {
                return this.BinarySearch(item, middle + 1, end);
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || this.items.Count <= firstIndex ||
                secondIndex < 0 || this.items.Count <= secondIndex)
            {
                throw new IndexOutOfRangeException();
            }

            T temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }
    }
}
