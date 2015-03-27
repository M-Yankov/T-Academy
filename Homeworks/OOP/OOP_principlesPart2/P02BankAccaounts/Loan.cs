
namespace P02BankAccaounts
{
    using System;
    class Loan : Accaount , IOperations
    {
        public Loan(string nameCustomer , CustumerType typeCustomer , decimal balanceAccount , double interestRateAcc)
        {
            this.Pbalance = balanceAccount;
            this.Pcustomer = typeCustomer;
            this.PcustomerName = nameCustomer;
            this.PinterestRate = interestRateAcc;
        }

        public override double CalculateInterestAmaount(uint mounts)
        {
            if (this.Pcustomer == CustumerType.individual)
            {
                if (mounts <= 3)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterestAmaount(mounts - 3);
                }
               
            }
            else
            {
                if (mounts <= 2)
                {
                    return 0;
                }
                else
                {
                    return base.CalculateInterestAmaount(mounts - 2);
                }
            }
        }

        public void WithdrawMoney(double sum)
        {
            throw new OperationCanceledException("Opperation not allowed!");
        }

        public void DepositMoney(double sum)
        {
            this.Pbalance = this.Pbalance + (decimal)sum;
        }
    }
}
