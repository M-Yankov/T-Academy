/*Problem 17. Date in Bulgarian

    Write a program that reads a date and time given in the format: 
 *  day.month.year hour:minute:second and prints the date and time after 6 hours and 30 minutes (in the same format) 
 *  along with the day of week in Bulgarian.
 */
using System;
using System.Globalization;
using System.Text;
using System.Threading;


class Bulgaristan
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("bg-BG");
        Console.WriteLine("Enter date in format: dd.mm.yyyy hh:mm.ss");
        DateTime bulgarian = DateTime.Parse(Console.ReadLine());
        bulgarian = bulgarian.AddHours(6);
        bulgarian = bulgarian.AddMinutes(30);
        Console.WriteLine("After 6 hours & 30 mins: ");
        Console.WriteLine("{0:dddd} , {1}", bulgarian, bulgarian.ToLongDateString());
    }
}
