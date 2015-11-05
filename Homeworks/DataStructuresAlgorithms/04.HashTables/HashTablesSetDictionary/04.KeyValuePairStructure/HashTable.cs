namespace KeyValuePairStructure
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class HashTable<K, T> // TODO: :IEnumerable<T>
    {
        private LinkedList<KeyValuePair<K, T>>[] data;
        private const uint InitialCapacity = 16;

        public HashTable()
            : this(InitialCapacity)
        {
        }

        public HashTable(uint size)
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[size];
        }

        public int Count { get; private set; }

        public T Find(K key)
        {
            int indexInData = GetHashCodeOfKey(key) % this.data.Length;
            Console.WriteLine("key {0} has code {1}", key.ToString(), GetHashCodeOfKey(key));
            indexInData *= indexInData < 0 ? -1 : 1;
            return this.data[indexInData].Where(pair => pair.Key == (dynamic)key).FirstOrDefault().Value;
        }

        public void Add(K key, T value)
        {
            KeyValuePair<K, T> thePair = new KeyValuePair<K, T>(key, value);

            int indexInData = GetHashCodeOfKey(thePair.Key) % this.data.Length;
            indexInData *= indexInData < 0 ? -1 : 1;

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

        private LinkedList<KeyValuePair<K, T>>[] Resize()
        {
            LinkedList<KeyValuePair<K, T>>[] newGenericArray = new LinkedList<KeyValuePair<K, T>>[this.data.Length * 2];
            Console.WriteLine("new size {0}", newGenericArray.Length);
            for (int i = 0; i < this.data.Length; i++)
            {
                //// TODO: Foreach not null values;
                if (this.data[i] != null)
                {
                    var listOfPairs = this.data[i].ToList();

                    for (int k = 0; k < listOfPairs.Count; k++)
                    {
                        int index2 = GetHashCodeOfKey(listOfPairs[k].Key) % newGenericArray.Length;
                        index2 *= index2 < 0 ? -1 : 1;

                        if (newGenericArray[index2] == null)
                        {
                            newGenericArray[index2] = new LinkedList<KeyValuePair<K, T>>();
                        }

                        newGenericArray[index2].AddLast(listOfPairs[k]);
                    }
                }
            }
            Console.WriteLine("end transfer");
            return newGenericArray;
        }

        private int GetHashCodeOfKey(K key)
        {
            long hash = 7 * key.GetHashCode() << 13;
            hash >>= 17;
            hash ^= 13 / hash;
            int len = Math.Min(10, hash.ToString().Length);
            return int.Parse(hash.ToString().Substring(0, len));


            //// After All Bullshits below finally good hash
            switch (hash % 3)
            {
                case 0:
                    hash ^= 31;
                    break;
                case 1:
                    hash ^= 29;
                    break;
                case 2:
                    hash ^= 13;
                    break;
                case -1:
                    hash ^= 23;
                    break;
                case -2:
                    hash ^= 7;
                    break;
            }

            string resultToString = hash.ToString();
            int lengthOfMaxINt = int.MaxValue.ToString().Length; //// 10
            int counter = 0;
            while (resultToString.Length >= lengthOfMaxINt)
            {
                if (counter % 2 == 0)
                {
                    resultToString = resultToString.Substring(1);
                }
                else
                {
                    int length = 5;
                    string number = resultToString.Substring(resultToString.Length / 2 - length / 2, length);
                    resultToString = ((double.Parse(number) * Math.PI) + string.Empty);
                    resultToString = resultToString.Substring(resultToString.IndexOf(".") + 1);
                }

                counter++;
            }

            int result = int.Parse(resultToString);
            //if (resultToString.Length >= lengthOfMaxINt)
            //{
            //    result = int.Parse(resultToString.Substring(resultToString.Length / 2));
            //}
            //else
            //{
            //    result = (int)hash;
            //}

            return result;
        }
    }
}
