namespace Computers.Models.Composite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RaidDrives : BaseHardDrive
    {
        private const string ErrorMessage = "No hard drive in the RAID array!";
        private IList<BaseHardDrive> drivesInRaid;

        public RaidDrives(IList<BaseHardDrive> hardDrives)
        {
            this.drivesInRaid = hardDrives;
        }

        public override int Capacity
        {
            get
            {
                if (this.drivesInRaid.Count != 0)
                {
                    return this.drivesInRaid.First().Capacity;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override void SaveData(int addr, string newData)
        {
            foreach (var drive in this.drivesInRaid)
            {
                drive.SaveData(addr, newData);
            }
        }

        public override string LoadData(int address)
        {
            if (!this.drivesInRaid.Any())
            {
                throw new OutOfMemoryException(ErrorMessage);
            }

            return this.drivesInRaid.First().LoadData(address);
        }
    }
}