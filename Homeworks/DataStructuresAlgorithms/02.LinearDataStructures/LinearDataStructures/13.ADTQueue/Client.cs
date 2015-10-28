namespace AdtQueue
{
    using System;

    /// <summary>
    /// Task 13. Implement the ADT queue as dynamic linked list.
    ///     ○ Use generics (LinkedQueue<T>) to allow storing different data types in the queue.
    /// </summary>
    public class Client
    {
        public static void Main()
        {
            DinamicQueue<string> dimQueue = new DinamicQueue<string>(3);

            dimQueue.Add("Ivan");
            dimQueue.Add("Petar");
            dimQueue.Add("Iordan");
        }
    }
}
