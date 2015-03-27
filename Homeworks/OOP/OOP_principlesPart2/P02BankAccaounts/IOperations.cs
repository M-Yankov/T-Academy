using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02BankAccaounts
{
    interface IOperations
    {
        void WithdrawMoney(double sum); // теглене

        
         void DepositMoney(double sum); // внасяне 
        
    }
}
