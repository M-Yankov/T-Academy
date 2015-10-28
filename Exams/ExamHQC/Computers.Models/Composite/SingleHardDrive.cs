namespace Computers.Models.Composite
{
    using System;
    using System.Collections.Generic;

    public class SingleHardDrive : BaseHardDrive
    {
        private Dictionary<int, string> data;
        private int capacity;

        public SingleHardDrive(int capacity)
        {
            this.capacity = capacity;
            this.data = new Dictionary<int, string>(capacity);
        }

        public override int Capacity
        {
            get
            {
                return this.Capacity;
            }
        }

        public override void SaveData(int address, string newData)
        {
            this.data[address] = newData;
        }

        public override string LoadData(int address)
        {
            return this.data[address];
        }
    }
}
