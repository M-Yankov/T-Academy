namespace Computers.Models.Composite
{
    using System;
    using System.Linq;

    public abstract class BaseHardDrive
    {
        public abstract int Capacity { get; }

        public abstract void SaveData(int address, string newData);
        
        public abstract string LoadData(int address);
    }
}