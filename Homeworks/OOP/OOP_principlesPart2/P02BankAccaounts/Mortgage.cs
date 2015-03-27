
namespace P02BankAccaounts
{
    using System;
    class Mortgage : Accaount, IOperations
    {
        public Mortgage(string namecustomer, CustumerType typeCustomer, decimal balanceAcc, double intertestRateAcc)
        {
            this.Pbalance = balanceAcc;
            this.Pcustomer = typeCustomer;
            this.PcustomerName = namecustomer;
            this.PinterestRate = intertestRateAcc;
        }


        public void WithdrawMoney(double sum)
        {
            throw new OperationCanceledException("Operation not allowed!");
        }

        public void DepositMoney(double sum)
        {
            this.Pbalance = this.Pbalance + (decimal)sum;
        }

        public override double CalculateInterestAmaount(uint mounts)
        {
            if (this.Pcustomer == CustumerType.company)
            {
                if (mounts <= 12)
                {
                    return mounts * (this.PinterestRate / 2);
                }
                else
                {
                    return 12 * (this.PinterestRate / 2) + ((mounts - 12) * this.PinterestRate);
                }
            }
            else
            {
                if (mounts <= 6)
                {
                    return 0;
                }
                else
                {
                    return (mounts - 6) * this.PinterestRate;
                }
            }
        }
    }
}
