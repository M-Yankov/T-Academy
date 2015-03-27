namespace P02BankAccaounts
{
    abstract class Accaount
    {
        private CustumerType custtype;
        private string customerName;
        private decimal balance;
        private double interestRate;

        public CustumerType Pcustomer
        {
            get
            {
                return this.custtype;
            }
            set
            {
                this.custtype = value;
            }
        }

        public string PcustomerName
        {
            get
            {
                return this.customerName;
            }
            set
            {
                this.customerName = value;
            }
        }

        public decimal Pbalance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public double PinterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                this.interestRate = value;
            }
        }
        /// <summary>
        /// Calculate Interest amount for first n mounts.
        /// </summary>
        /// <param name="mounts"></param>
        /// <returns></returns>
       public virtual double CalculateInterestAmaount(uint mounts)
        {
            return this.PinterestRate * mounts;
        }
    }
}
