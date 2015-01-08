using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.AgeAfter10Years
{
    class Program
    {
        static void Main(string[] args)
        {
            string input ;
            Console.WriteLine("Enter your date of Birth in format: dd.mm.yyyy\nExample: 01.01.2013");
            input = Console.ReadLine();//If you enter unreal date , the program will stop.
            DateTime Birthday = Convert.ToDateTime(input);
            Console.WriteLine("Your Birthday is on: {0}-{1}-{2}", Birthday.Day , Birthday.Month , Birthday.Year);
            DateTime Now = DateTime.Now;
            
            int age =  Now.Year - Birthday.Year;
            if (Now.Month - Birthday.Month != 0) //This condition checks if your Birthday is past or not.
            {
                if (Now.Month - Birthday.Month > 0)
                {
                    Console.WriteLine("Your age is: " + age);
                    age = age + 10;
                    Console.WriteLine("After 10 years you will be on: " + age);
                }
                else
                {
                    age = age - 1;
                    Console.WriteLine("Your age is: " + age);
                    age = age + 10;
                    Console.WriteLine("After 10 years you will be on: " + age);
                }
            }
            else
            {
                if (Now.Day - Birthday.Day >= 0)
                {
                    Console.WriteLine("Your age is: " + age);
                    age = age + 10;
                    Console.WriteLine("After 10 years you will be on: " + age);

                }
                else
                {
                    age = age - 1;
                    Console.WriteLine("Your age is: " + age);
                    age = age + 10;
                    Console.WriteLine("After 10 years you will be on: " + age);
                }
            }
        }
    }
}
