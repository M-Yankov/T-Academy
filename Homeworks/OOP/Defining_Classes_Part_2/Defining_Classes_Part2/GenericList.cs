/* Problem 5. Generic class

    Write a generic class GenericList<T> that keeps a list of elements of some parametric type T.
    Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor.
    Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, clearing the list, finding element by its value and ToString().
    Check all input parameters to avoid accessing elements at invalid positions.
 * Problem 6. Auto-grow

    Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it.

Problem 7. Min and Max

    Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>.
    You may need to add a generic constraints for the type T.

 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace Defining_Classes_Part2
{
    //it's cool using this time of comments or what ever are they , because can see text between <summary> tags is Main method, when call it. :)
    /// <summary>
    /// My generetic class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GenericList<T> where T : IComparable  , new()
    {
        
        const int constSize = 4; // 40696 
        private T[] elements;
        public GenericList(int size)
        {
            elements = new T[size];
        }
        public GenericList() : this(constSize)
        {

        }
        private int count = 0; // field <- This can be used for end of items in array. Not  array.Lenght

        public int Count   // generated with propf 
        {
            get { return this.count; }
            set { this.count = value; }
        }
        /// <summary>
        /// Add intem at the end of the list
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)  // adding element
        {
            if (this.count >= elements.Length)
            {
                
                int temp = elements.Length;
                Array.Resize<T>(ref elements, temp *2 );  // Problem 6 implemented
                
            }
            this.elements[count] = item;
            this.count++;
        }
        public T this[int index]   // accessing element by index
        {
            get
            {
                if (index >= elements.Length)
                {
                    throw new IndexOutOfRangeException("Index was not in range.");
                }
                
                return elements[index];
           }
        }
        /// <summary>
        /// Removing element by index
        /// </summary>
        public void RemoveAt(int index)  // removing element by index
        {
            
            for (int i = index; i < elements.Length - 1; i++)
            {
                elements[i] = elements[i + 1];
            }
            int newSize = elements.Length - 1;
            Array.Resize<T>(ref elements, newSize); // hmm it's cool    
            count--;
        }
        /// <summary>
        /// Inserting element at given position
        /// </summary>
        /// <param name="index"></param>
        public void InsertAt(int index , T item)
        {
            int newSize = elements.Length + 1;
            Array.Resize<T>(ref elements, newSize);
            for (int i = elements.Length - 1; i > index ; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }
            this.elements[index] = item;
            count++;
        }
        /// <summary>
        /// Clearing the list.
        /// </summary>
        public void Clear()
        {
            Array.Resize<T>(ref elements, 0);
            count = 0;
        }

        public void Show()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(elements[i]);
            }
        }
        /// <summary>
        /// Finding element at index by its value(First occurance). If not found returns -1. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Finding(T value) // I'am drunk
        {
            
            return Array.IndexOf<T>(elements, value);
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                if (i != count -1)
                {
                res.Append(elements[i] + ", ");
                    
                }
                else
                {
                    res.Append(elements[i]);
                }
            }
            return res.ToString();
        }
        /// <summary>
        /// Finds the min value item in Icomparable list.
        /// </summary>
        /// <returns></returns>
        public T Minimal()
        {

            if (count == 0)
            {
                throw new KeyNotFoundException("List.Count = 0. NO items!");
            }
            T temp = elements[0];
            for (int i = 0; i < count; i++)
            {
                if (elements[i].CompareTo(temp) < 0)
                {
                    temp = elements[i];
                }
            }
            return temp;
        }
        /// <summary>
        /// Returns the max value item of Icomparable list.
        /// </summary>
        /// <returns></returns>
        public T Maximal()
        {

            if (count == 0)
            {
                throw new KeyNotFoundException("List.Count = 0. NO items!");
            }
            T temp = elements[0];
            for (int i = 0; i < count; i++)
            {
                if (elements[i].CompareTo(temp) > 0)
                {
                    temp = elements[i];
                }
            }
            return temp;
        }

        

        
    }
}
