/*Problem 16. Date difference

    Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


class Daysbetween
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("bg-BG");
        Console.Write("Enter date in format(dd.MM.yyyy): ");
        DateTime first = new DateTime();
        first = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter second date in same format: ");
        DateTime second = new DateTime();
        second = DateTime.Parse(Console.ReadLine());
        string result = (second - first).ToString();
        string final = result.Substring(0, result.IndexOf("."));
        int a = int.Parse(final);
        Console.WriteLine("{0} days", a);
    }
}
