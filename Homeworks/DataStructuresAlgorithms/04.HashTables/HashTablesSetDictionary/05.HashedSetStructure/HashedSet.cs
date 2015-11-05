namespace HashedSetStructure
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using KeyValuePairStructure;

    public class HashedSet<T> : IEnumerable<T>
    {
        private const int InitialSize = 16;
        private HashTable<int, T> data;

        public HashedSet()
            : this(InitialSize)
        {
        }

        public HashedSet(uint size)
        {
            this.data = new HashTable<int, T>(size);
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            try
            {
                this.data.Add(item.GetHashCode(), item);
                this.Count++;
            }
            catch (Exception)
            {
            }
        }

        public void Remove(T item)
        {
            int countBefore = this.data.Count;
            this.data.Remove(item.GetHashCode());
            int differance = countBefore - this.data.Count;
            this.Count -= differance;
        }

        public T Find(T item)
        {
            return this.data.Find(item.GetHashCode());
        }

        public void Clear()
        {
            this.data.Clear();
            this.Count = this.data.Count;
        }

        public void Union(HashedSet<T> unionWith)
        {
            int countBefore = this.data.Count;

            foreach (var item in unionWith)
            {
                this.data.Add(item.GetHashCode(), item);
            }

            int differance = this.data.Count - countBefore;
            this.Count += differance;
        }

        public void Intersect(HashedSet<T> unionWith)
        {
            var result = new HashTable<int, T>();
            foreach (var item in unionWith)
            {
                try
                {
                    if (this.data.Find(item.GetHashCode()) != null)
                    {
                        result.Add(item.GetHashCode(), item);
                    }
                }
                catch (Exception)
                {
                }
            }

            this.data = result;
            this.Count = result.Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.data)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
