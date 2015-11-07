namespace PriorityQueueTask
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private const string EmptyQueueErrorMessage = "The priority queue is empty!";
        private Heap<T> heap;

        public PriorityQueue()
        {
            this.heap = new Heap<T>();
        }

        public int Count { get; set; }

        public void Enqueue(T item)
        {
            this.heap.Add(item);
            this.Count++;
        }

        public T Dequeue()
        {
            this.heap.HeapSort();
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EmptyQueueErrorMessage);
            }

            this.Count--;
            return this.heap.Max();
        }

        public void Sort()
        {
            this.heap.HeapSort();
        }

        public void Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException(EmptyQueueErrorMessage);
            }

            //// TODO: return peek value;
        }

        public IEnumerable<T> DequeueAll()
        {
            var result = new List<T>();

            while (this.Count != 0)
            {
                result.Add(this.Dequeue());
            }

            return result;
        }
    }
}
