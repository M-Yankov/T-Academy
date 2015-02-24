/*Problem 5. Workdays

    Write a method that calculates the number of workdays between today and given date, passed as parameter.
    Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.
*/


using System;
using System.Collections;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

class Working
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        DateTime[] workOnWeekend = new DateTime[] { new DateTime(2015, 3, 21), new DateTime(2015, 9, 12), new DateTime(2015, 12, 12) };
        DateTime[] holidays =  { new DateTime(2015, 3, 2),  new DateTime(2015, 3, 3), new DateTime(2015, 4, 10), new DateTime(2015, 4, 13), new DateTime(2015, 5, 1), new DateTime(2015, 5, 6), new DateTime(2015, 9, 21), new DateTime(2015, 9, 22), new DateTime(2015, 12, 24), new DateTime(2015, 12, 25), new DateTime(2015, 12, 31) };
        //holidays[0] = Convert.ToDateTime("3/2/2015");
        DateTime today = new DateTime(DateTime.Now.Year , DateTime.Now.Month , DateTime.Now.Day , 00, 00, 00); // gets current dates 
        
        //DateTime nextday = DateTime.Now;
        int counter = 0;
        while (today.Year != 2016) //!= new DateTime(2016, 1, 1))
        {
            if (today.ToString("ddd") != "Sat" && today.ToString("ddd") != "Sun")
            {
                if (!holidays.Contains(today))
                {

                    counter++;
                }
            }
            if (workOnWeekend.Contains(today))
            {
                counter++;
            }
            today = today.AddDays(1);

        }
        
        Console.WriteLine("Work days till end of year - {0}", counter);         // почивнидни.com   <- не знам защо този домайн е на кирилица но работи. от там съм взел информацията
        /* Mart  = 20
         * April = 20
         * May = 20
         * June = 22;
         * July = 23   -> 109
         * August = 21  -> 130
         * Sep = 21    -> 151
         * October = 22  -> 173
         * November = 21; -> 194
         * Dec  = 21  -> 215
        */
    }
}
