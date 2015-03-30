
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
