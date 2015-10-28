namespace DataStructure
{
    public class LinkedList<T>
    {
        private ListItem<T> firstItem;

        public LinkedList()
        {
            this.firstItem = new ListItem<T>();
        }

        public ListItem<T> FirstItem
        {
            get
            {
                return this.firstItem;
            }

            set
            {
                this.firstItem = value;
            }
        }
    }
}