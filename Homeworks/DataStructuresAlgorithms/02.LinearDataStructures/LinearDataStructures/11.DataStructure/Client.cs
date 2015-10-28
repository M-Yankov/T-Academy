namespace DataStructure
{
    using System;

    /// <summary>
    /// Task 11. Implement the data structure linked list.
    ///     ○ Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>). 
    ///     ○ Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).
    /// </summary>
    public class Client
    {
        public static void Main()
        {
            LinkedList<int> numbers = new LinkedList<int>();
            var theFirst = new ListItem<int>(2);
            var theNext = new ListItem<int>(595);
            theFirst.NextItem = theNext;
            numbers.FirstItem = theFirst;

            Console.WriteLine("First item in the list: {0}", numbers.FirstItem.Value);
            Console.WriteLine("Next item: {0}", theFirst.NextItem.Value);
        }
    }
}
