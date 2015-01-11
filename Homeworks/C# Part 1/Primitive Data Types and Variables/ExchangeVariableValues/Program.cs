/*Problem 9. Exchange Variable Values

    Declare two integer variables a and b and assign them with 5 and 10 and after that exchange their values by using some programming logic.
    Print the variable values before and after the exchange.
*/

using System;

namespace ExchangeVariableValues
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            Console.WriteLine("a = {0} \nb = {1}",a ,b);
            
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After exchange...\na = {0} \nb = {1}",a,b);
        }
    }
}
