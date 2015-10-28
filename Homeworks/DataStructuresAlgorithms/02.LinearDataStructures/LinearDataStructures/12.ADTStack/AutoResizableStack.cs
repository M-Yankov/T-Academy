namespace AdtStack
{
    public class AutoResizableStack<T>
    {
        private T[] array;
        private int currentIndex;

        public AutoResizableStack() : this(4)
        {
        }

        public AutoResizableStack(int length)
        {
            this.array = new T[length];
            this.currentIndex = 0;
        }

        public int Count
        {
            get
            {
                return this.currentIndex;
            }
        }

        public int LongLength
        {
            get
            {
                return this.array.Length;
            }
        }
            
        public void Add(T item)
        {
            if (this.array.Length == this.currentIndex)
            {
                this.array = this.EnsureCapacity(this.array, this.array.Length * 2);
            }

            this.array[this.currentIndex] = item;
            this.currentIndex++;
        }

        private T[] EnsureCapacity(T[] oldArr, int newCapacity)
        {
            T[] result = new T[newCapacity];

            for (int i = 0; i < oldArr.Length; i++)
            {
                result[i] = oldArr[i];
            }

            return result;
        }
    }
}