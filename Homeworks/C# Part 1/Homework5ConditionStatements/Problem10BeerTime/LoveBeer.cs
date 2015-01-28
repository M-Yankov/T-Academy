/*Problem 10.* Beer Time

    A beer time is after 1:00 PM and before 3:00 AM.
    Write a program that enters a time in format “hh:mm tt” (an hour in range [01...12], a minute in range [00…59] and AM / PM designator)
 * and prints beer time or non-beer time according to the definition above or invalid time if the time cannot be parsed. Note: You may need to learn how to parse dates and times.

 * */
using System;
using System.Globalization;

    class LoveBeer //and wiskey too 
    {
        static void Main()
        {
            Console.Write("Enter some time in format hh:mm:ss AM/PM \n(Example: 2:00:40 AM): " );
            string input = Console.ReadLine();
            DateTime beer;
            try
            {
                beer = Convert.ToDateTime(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Bad input!");
                return;
            }
            if (beer.Hour >= 13 || beer.Hour < 3)
            {
                Console.WriteLine("It's Beer Time *** :)");
            }
            else
            {
                Console.WriteLine("Non beer time :( /n Maybe it's rakia time.");
            }
            //Console.WriteLine(beer.ToString("h:mm:ss tt" ,CultureInfo.CreateSpecificCulture("en-US"))); 
            //Console.WriteLine(beer);

        }
    }

