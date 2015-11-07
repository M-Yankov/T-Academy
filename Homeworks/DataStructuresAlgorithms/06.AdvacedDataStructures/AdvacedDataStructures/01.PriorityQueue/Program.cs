namespace PriorityQueueTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implement a class PriorityQueue<T> based on the data structure "binary heap".
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            var queue = new PriorityQueue<int>();
            //// 8, 6, 7, 4, 5, 3, 2, 1
            queue.Enqueue(6);
            queue.Enqueue(5);
            queue.Enqueue(3);
            queue.Enqueue(1);
            queue.Enqueue(8);
            queue.Enqueue(7);
            queue.Enqueue(2);
            queue.Enqueue(4);

            //// a.DequeueAll().ToList().ForEach(x => Console.Write(x + " "));

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            //// Throws an exception - no elements;
            //// Console.WriteLine(a.Dequeue());
        }
    }
}
