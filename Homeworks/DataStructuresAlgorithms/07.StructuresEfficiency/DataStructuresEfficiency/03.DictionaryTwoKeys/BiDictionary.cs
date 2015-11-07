namespace DictionaryTwoKeys
{
    using System;
    using System.Collections.Generic;

    public class BiDictionary<Key, Key2, TValue> where TValue : IComparable
    {
        private Dictionary<Key, TValue> dickData;
        private Dictionary<Key2, TValue> secondData;

        public BiDictionary()
        {
            this.dickData = new Dictionary<Key, TValue>();
            this.secondData = new Dictionary<Key2, TValue>();
        }

        public TValue this[Key firstKey]
        {
            get
            {
                try
                {
                    TValue value = this.dickData[firstKey];
                    return value;
                }
                catch (Exception ex)
                {
                    throw new KeyNotFoundException("Key not found!", ex);
                }
            }
        }

        public TValue this[Key2 secondKey]
        {
            get
            {
                try
                {
                    TValue value = this.secondData[secondKey];
                    return value;
                }
                catch (Exception ex)
                {
                    throw new KeyNotFoundException("Key not found!", ex);
                }
            }
        }

        public TValue this[Key firstKey, Key2 secondKey]
        {
            get
            {
                try
                {
                    TValue value = this[firstKey];
                    return value;
                }
                catch (Exception ex)
                {
                    try
                    {
                        TValue value = this[secondKey];
                        return value;
                    }
                    catch (Exception)
                    {
                        throw new KeyNotFoundException("Second key not found.", ex);
                    }
                }
            }
        }

        public void Add(Key key, TValue data)
        {
            if (this.dickData.ContainsKey(key))
            {
                throw new InvalidOperationException("Key Already exist");
            }

            this.dickData.Add(key, data);
        }

        public void Add(Key2 key, TValue data)
        {
            if (this.secondData.ContainsKey(key))
            {
                throw new InvalidOperationException("Key Already exist");
            }

            this.secondData.Add(key, data);
        }

        public void Add(Key firstKey, Key2 secondKey, TValue data)
        {
            if (this.secondData.ContainsKey(secondKey) || this.dickData.ContainsKey(firstKey))
            {
                throw new InvalidOperationException("Key Already exist");
            }

            this.dickData.Add(firstKey, data);
            this.secondData.Add(secondKey, data);
        }
    }
}
