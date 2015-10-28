namespace AdtQueue
{
    using System;
    using System.Collections.Generic;

    public class DinamicQueue<T>
    {
        private T[] elements;
        private int currentIndex = 0;

        public DinamicQueue() : this(4)
        {
        }

        public DinamicQueue(int size)
        {
            this.elements = new T[size];
        }

        public void Add(T item)
        {
            if (this.currentIndex > this.elements.Length)
            {
                throw new NotImplementedException("The Student is too lazy to write self increasing size method. Sorry!");
            }

            this.elements[this.currentIndex] = item;
            this.currentIndex++;
        }
    }
}