/*
 * Problem 11. Bank Account Data

    A bank account has a holder name (first name, middle name and last name), available amount of money (balance), bank name, IBAN, 3 credit card numbers associated with the account.
    Declare the variables needed to keep the information for a single bank account using the appropriate data types and descriptive names.
 * */

using System;

namespace BankAccountData
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstname = "Petkan";
            string middleName = "Todorov";
            string Lastname = "Atanasov";
            double balance = 57005698.456;
            string bankName = "FiBank";
            string IBan = "BG99FINV915048723636";
            long cardNumber1Visa = 4176488224335666;
            long cardNumber2Visa = 4176444857899100;
            long cardNumber3Maestro = 6095564245461763;
            Console.WriteLine("***Account Data***\nFull name: {0} {1} {2} \nBalance: {3} \nBank: {4} \nIBAN: {5} \nCard Numbers: \nVisa: \t {6} \nVisa: \t {7} \nMaestro: {8}"
                ,firstname,middleName,Lastname,balance,bankName,IBan,cardNumber1Visa,cardNumber2Visa,cardNumber3Maestro);
           

        }
    }
}
