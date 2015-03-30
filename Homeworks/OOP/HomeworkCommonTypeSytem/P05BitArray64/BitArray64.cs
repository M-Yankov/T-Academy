
namespace P05BitArray64
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    class BitArray64 : IEnumerable<int>
    {
        private ulong[] my64BitArray;

        private uint size;


        public BitArray64(uint size)  // Constructor
        {
            my64BitArray = new ulong[size];
            this.Lenght = size;
        }
        public uint Lenght
        {
            get { return this.size; }
            set { this.size = value; }
        }
        public ulong[] PmyArray
        {
            get { return this.my64BitArray; }
            set { this.my64BitArray = value; }
        }

        public ulong this[int index]
        {
            get
            {
                if (index >= my64BitArray.Length || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid Index!");
                }
                return this.my64BitArray[index];
            }
            set
            {
                if (index >= my64BitArray.Length || index < 0)
                {
                    throw new IndexOutOfRangeException("Invalid Index!");
                }
                this.my64BitArray[index] = value;
            }
        }

        public static bool operator ==(BitArray64 a, BitArray64 b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(BitArray64 a, BitArray64 b)
        {
            return !a.Equals(b);
        }
        public override bool Equals(object obj)
        {
            BitArray64 arr = obj as BitArray64;
            if (arr.Lenght != this.Lenght)
            {
                return false;
            }
            for (int i = 0; i < arr.Lenght; i++)
            {
                if (arr[i] != this[i])
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode()
        {
            int num = 3456612;
            int res = this.my64BitArray.Length;
            for (int i = 0; i < res; i++)
            {
                num = num ^ (int)this.my64BitArray[i];
            }
            return (~num) * -1;
        }
        public override string ToString()
        {
            return string.Join(",", this.PmyArray);
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < my64BitArray.Length; i++)
            {
                yield return (int)my64BitArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
