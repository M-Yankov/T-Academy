namespace DataStructure
{
    using System;

    public class ListItem<T>
    {
        private T value;
        private ListItem<T> nextItem;

        public ListItem()
        {
            this.value = default(T);
        }

        public ListItem(T inputValue)
        {
            this.value = inputValue;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
        }

        public ListItem<T> NextItem 
        {
            get
            {
                return this.nextItem;
            }

            set
            {
                this.nextItem = value;
            }
        }
    }
}
