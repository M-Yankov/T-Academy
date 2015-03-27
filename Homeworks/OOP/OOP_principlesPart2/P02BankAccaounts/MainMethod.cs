/*Problem 2. Bank accounts

    A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. Customers could be individuals or companies.
    All accounts have customer, balance and interest rate (monthly based).
        Deposit accounts are allowed to deposit and with draw money.
        Loan and mortgage accounts can only deposit money.
    All accounts can calculate their interest amount for a given period (in months). In the common case its is calculated as follows: number_of_months * interest_rate.
    Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
    Deposit accounts have no interest if their balance is positive and less  than 1000.
    Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
 * 
    Your task is to write a program to model the bank system by classes and interfaces.
    You should identify the classes, interfaces, base classes and abstract actions and implement the calculation of the interest functionality through overridden methods.
 * */
namespace P02BankAccaounts
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;
    class MainMethod
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("bg-BG");
            // for each account type - deposit , loan , mortgage  we will have two types of customers - individual and company
            Deposit depAcc1 = new Deposit("Strahil Voivoda", CustumerType.individual, 845.65M, 6);
            Deposit depAcc2 = new Deposit("Telerik ltd.", CustumerType.company, 9995.00M, 6);
            Loan loanAcc1 = new Loan("Bai Ganio", CustumerType.individual, -798.23554M, 18.6169);
            Loan loanAcc2 = new Loan("Fish House", CustumerType.company, -5420.00326M, 16.1);
            Mortgage mortAcc1 = new Mortgage("Kolio", CustumerType.individual, -30565.65488M, 21.55);
            Mortgage mortAcc2 = new Mortgage("MeatFactory", CustumerType.company, -20150.00012M, 19.60);

            Accaount[] accounts = new Accaount[] { depAcc1, depAcc2, loanAcc1, loanAcc2, mortAcc1, mortAcc2 };
            uint months = 5;
            foreach (var acc in accounts)
            {
                Console.WriteLine("{0} has interest amount {1:C2} for months {2} months", acc.PcustomerName, acc.CalculateInterestAmaount(months), months);
            }
            Console.WriteLine("\n\rEvery one of them will try to withdraw 50.5");

            double sum = 50.5;
            #region foeach
            foreach (var acc in accounts)
            {
                Console.WriteLine("{0} has balance before withdraw: {1:C2}" , acc.PcustomerName , acc.Pbalance );
                switch(acc.GetType().Name)
                {
                      
                    case "Deposit": 
                        Deposit temp = acc as Deposit;
                        try
                        {
                            temp.WithdrawMoney(sum);

                        }
                        catch (OperationCanceledException ex)  // catch(ArgumentException ) for not enough money
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Loan":
                        Loan temp1 = acc as Loan;
                        try
                        {
                           temp1.WithdrawMoney(sum);  // can't withdraw but just to show that is implemented

                        }
                        catch (OperationCanceledException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "Mortgage":
                        Mortgage temp2 = acc as Mortgage;
                        try
                        {
                        temp2.WithdrawMoney(sum); // can't withdraw but just to show that is implemented

                        }
                        catch (OperationCanceledException ex)
                        {
                            
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default: break;
                }
                Console.WriteLine("{0} has balance After withdraw: {1:C2}", acc.PcustomerName, acc.Pbalance);

            }
            #endregion


            double sum2 = 1560;
            Console.WriteLine("\n{0} and {1} will make deposits with {4:C2} \nThey have balances:\n {0}: {2:C2}\n {1}: {3:C2}" ,loanAcc1.PcustomerName , depAcc2.PcustomerName , loanAcc1.Pbalance , depAcc2.Pbalance , sum2 );
            loanAcc1.DepositMoney(sum2);
            depAcc2.DepositMoney(sum2);
            Console.WriteLine("After deposits:\n {0}: {2:C2}\n {1}: {3:C2}" ,loanAcc1.PcustomerName , depAcc2.PcustomerName , loanAcc1.Pbalance , depAcc2.Pbalance );

        }
    }
}
