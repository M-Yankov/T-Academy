namespace KeyValuePairStructure
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const uint InitialCapacity = 16;
        private LinkedList<KeyValuePair<K, T>>[] data;

        public HashTable()
            : this(InitialCapacity)
        {
        }

        public HashTable(uint size)
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[size];
        }

        public int Count { get; private set; }

        public ICollection<K> Keys
        {
            get
            {
                ICollection<K> result = new List<K>();
                for (int i = 0; i < this.data.Length; i++)
                {
                    if (this.data[i] != null)
                    {
                        this.data[i].ToList().ForEach(pair => result.Add(pair.Key));
                    }
                }

                return result;
            }
        }

        public KeyValuePair<K, T> this[K keyIndex]
        {
            get
            {
                int index = this.GetHashCodeOfKey(keyIndex) % this.data.Length;
                index *= index < 0 ? -1 : 1;

                if (this.data[index] == null)
                {
                    throw new NullReferenceException("This key does not exist in the hashTable");
                }

                return this.data[index].Where(pair => pair.Key == (dynamic)keyIndex).FirstOrDefault();
            }
        }

        public void Add(K key, T value)
        {
            KeyValuePair<K, T> thePair = new KeyValuePair<K, T>(key, value);

            int indexInData = this.GetHashCodeOfKey(thePair.Key) % this.data.Length;
            indexInData *= indexInData < 0 ? -1 : 1;

            if (this.Keys.Contains(key))
            {
                throw new ArgumentException("This key already exist!");
            }

            if (this.data[indexInData] == null)
            {
                this.data[indexInData] = new LinkedList<KeyValuePair<K, T>>();
            }

            this.data[indexInData].AddLast(thePair);
            this.Count++;

            if (this.Count >= (0.75 * this.data.Length))
            {
                this.data = this.Resize();
            }
        }

        /// <summary>
        /// From task description ○ Find(key)->value;
        /// </summary>
        /// <param name="key">Key value.</param>
        /// <returns>Returns the value from pair that contains Key value instead of whole pair.</returns>
        public T Find(K key)
        {
            int indexInData = this.GetHashCodeOfKey(key) % this.data.Length;
            indexInData *= indexInData < 0 ? -1 : 1;
            if (this.data[indexInData] == null)
            {
                //// better throw instead return (default)T
                throw new ArgumentException("This key cannot be found");
            }

            if (!this.data[indexInData].Any(pair => pair.Key == (dynamic)key))
            {
                throw new ArgumentException("This key cannot be found");
            }

            return this.data[indexInData].Where(pair => pair.Key == (dynamic)key).FirstOrDefault().Value;
        }

        public void Clear()
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i] != null)
                {
                    this.data[i] = null;
                }

                this.Count = 0;
            }
        }

        public void Remove(K key)
        {
            if (this.Count == 0)
            {
                return;
            }

            int indexInData = this.GetHashCodeOfKey(key) % this.data.Length;
            indexInData *= indexInData < 0 ? -1 : 1;
            var a = this.data[indexInData].Where(pair => pair.Key == (dynamic)key).FirstOrDefault();
            this.data[indexInData].Remove(a);
            this.Count--;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            for (int i = 0; i < this.data.Length; i++)
            {
                if (this.data[i] != null)
                {
                    var list = this.data[i].ToList();
                    foreach (var item in list)
                    {
                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private LinkedList<KeyValuePair<K, T>>[] Resize()
        {
            LinkedList<KeyValuePair<K, T>>[] newGenericArray = new LinkedList<KeyValuePair<K, T>>[this.data.Length * 2];
            for (int i = 0; i < this.data.Length; i++)
            {
                //// TODO: Foreach not null values;
                if (this.data[i] != null)
                {
                    var listOfPairs = this.data[i].ToList();

                    for (int k = 0; k < listOfPairs.Count; k++)
                    {
                        int index2 = this.GetHashCodeOfKey(listOfPairs[k].Key) % newGenericArray.Length;
                        index2 *= index2 < 0 ? -1 : 1;

                        if (newGenericArray[index2] == null)
                        {
                            newGenericArray[index2] = new LinkedList<KeyValuePair<K, T>>();
                        }

                        newGenericArray[index2].AddLast(listOfPairs[k]);
                    }
                }
            }

            return newGenericArray;
        }

        private int GetHashCodeOfKey(K key)
        {
            long hash = (7 * key.GetHashCode()) << 13;
            hash >>= 17;
            hash ^= 13 / hash;
            int len = Math.Min(10, hash.ToString().Length);
            return int.Parse(hash.ToString().Substring(0, len));
        }
    }
}
