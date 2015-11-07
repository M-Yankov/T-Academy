namespace PriorityQueueTask
{
    using System;

    /// <summary>
    /// Heap implementation help links {[https://en.wikipedia.org/wiki/Heap_%28data_structure%29], [https://en.wikipedia.org/wiki/Heapsort]}
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Heap<T> where T : IComparable<T>
    {
        private T[] heapElements;

        public Heap()
        {
            this.heapElements = new T[16];
            this.ThreeQuarters = this.heapElements.Length * 0.75;
        }

        public int Count { get; set; }

        private int Index { get; set; }

        private double ThreeQuarters { get; set; }

        internal void Add(T item)
        {
            if (this.Count >= this.ThreeQuarters)
            {
                this.Resize();
            }

            this.heapElements[this.Index] = item;
            this.Count++;
            this.OrderElements(this.Index);

            this.Index++;
        }

        /// <summary>
        /// This is the priority.
        /// </summary>
        /// <returns></returns>
        internal T Max()
        {
            this.Index--;
            T result = this.heapElements[this.Index];
            this.heapElements[this.Index] = default(T);
            this.Count--;
            return result;
        }

        internal void HeapSort()
        {
            if (this.CheckIfSorted())
            {
                return;
            }

            int end = this.Index - 1;
            while (end > 0)
            {
                this.Swap(end, 0);
                end--;
                this.SiftDown(this.heapElements, 0, end);
            }
        }

        private void SiftDown(T[] element, int startIndex, int endIndex)
        {
            int rootIndex = startIndex;
            while ((rootIndex * 2) + 1 <= endIndex)
            {
                int childIndex = (rootIndex * 2) + 1;
                int swap = rootIndex;

                if (element[swap].CompareTo(element[childIndex]) == -1)
                {
                    swap = childIndex;
                }

                if (childIndex + 1 <= endIndex && element[swap].CompareTo(element[childIndex + 1]) == -1)
                {
                    swap = childIndex + 1;
                }

                if (swap == rootIndex)
                {
                    return;
                }
                else
                {
                    this.Swap(rootIndex, swap);
                    rootIndex = swap;
                }
            }
        }

        private bool CheckIfSorted()
        {
            for (int i = 0; i < this.Index - 1; i++)
            {
                if (this.heapElements[i].CompareTo(this.heapElements[i + 1]) != -1)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// AKA. Heapify.
        /// </summary>
        /// <param name="index"></param>
        private void OrderElements(int index)
        {
            while (index > 0)
            {
                int comparedValue = this.heapElements[index].CompareTo(this.heapElements[(index - 1) / 2]);
                if (comparedValue > 0)
                {
                    this.Swap((index - 1) / 2, index);
                }

                index = (index - 1) / 2;
            }
        }

        private void Swap(int parentIndex, int childIndex)
        {
            T valueToSwap = this.heapElements[parentIndex];
            this.heapElements[parentIndex] = this.heapElements[childIndex];
            this.heapElements[childIndex] = valueToSwap;
        }

        private void Resize()
        {
            T[] newHeap = new T[this.heapElements.Length * 2];
            for (int i = 0; i < this.heapElements.Length; i++)
            {
                newHeap[i] = this.heapElements[i];
            }

            this.heapElements = newHeap;
        }
    }
}
