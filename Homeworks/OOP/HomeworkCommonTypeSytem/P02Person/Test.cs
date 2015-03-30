/*Problem 4. Person class

    Create a class Person with two fields – name and age. Age can be left unspecified (may contain null value. Override ToString() to display the information of a person and if age is not specified – to say so.
    Write a program to test this functionality.
*/
namespace P02Person
{
    using System;
    class Test
    {
        static void Main()
        {
            Person gosho = new Person("Georgi", 22);
            Person toshoAgeLess = new Person("Toshko");
            Console.WriteLine(gosho);
            Console.WriteLine(toshoAgeLess);
            toshoAgeLess.Page = 20;
            // Don't do this.
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Bad practice: {0} = {1}" ,gosho.Pname ,toshoAgeLess.Pname);
            Console.ResetColor();
            gosho = toshoAgeLess;
            gosho.Page = 19;
            Console.WriteLine(gosho);
            Console.WriteLine(toshoAgeLess);
        }
    }
}
