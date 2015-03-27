
namespace P02BankAccaounts
{
    using System;
    class Deposit : Accaount, IOperations
    {

        public Deposit(string nameCustomer, CustumerType typeCustomer, decimal balcanceAccount, double interestrateAcc)
        {
            this.Pbalance = balcanceAccount;
            this.Pcustomer = typeCustomer;
            this.PcustomerName = nameCustomer;
            this.PinterestRate = interestrateAcc;
        }


        public override double CalculateInterestAmaount(uint mounts)
        {
            if (this.Pbalance > 0 && this.Pbalance < 1000)
            {
                return 0;
            }
            else
            {
                return mounts * this.PinterestRate;

            }
        }



        public void WithdrawMoney(double sum)
        {
            if (this.Pbalance - (decimal)sum < 0)
            {
                throw new ArgumentException("Not enogh money!");
            }
            this.Pbalance = this.Pbalance - (decimal)sum - 1; // shall we get taxes for operation . - yes :D  tax is 1 form the current currency.
        }

        public void DepositMoney(double sum)
        {
            this.Pbalance = this.Pbalance + (decimal)sum;
        }
    }

}
