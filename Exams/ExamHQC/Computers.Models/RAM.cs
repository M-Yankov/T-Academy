namespace Computers.Models
{
    public class RAM
    {
        private int value;

        public RAM(int amontRamInGB)
        {
            this.Amount = amontRamInGB;
        }

        public int Amount { get; set; }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}