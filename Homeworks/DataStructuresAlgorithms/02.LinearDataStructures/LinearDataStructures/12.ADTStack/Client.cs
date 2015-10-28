namespace AdtStack
{
    using System;

    /// <summary>
    /// Task 12. Implement the ADT stack as auto-resizable array.
    ///     ○ Resize the capacity on demand (when no space is available to add / insert a new element).
    /// </summary>
    public class Client
    {
        public static void Main()
        {
            int a = 2;
            Console.WriteLine(a.GetHashCode());
            AutoResizableStack<int> theStack = new AutoResizableStack<int>();
            theStack.Add(1);
            theStack.Add(2);
            theStack.Add(3);
            theStack.Add(55);
            theStack.Add(55);

            Console.WriteLine("Count of elements {0}", theStack.Count);
            Console.WriteLine("Full length {0}", theStack.LongLength);
        }
    }
}
