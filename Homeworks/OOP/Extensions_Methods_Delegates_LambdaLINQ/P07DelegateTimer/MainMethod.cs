
namespace P07DelegateTimer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;


    public delegate void MyDelegate(int time);
    class Program
    {
        static void Main(string[] args)
        {
            int mytime = 6; 
            MyDelegate del = DayMethod;
            del += MonthMethod;
            del += SecondsMethod;
            del += MinutesMethod;
            //del += Console.Clear;

            while (true)
            {
                 
                Thread.Sleep(1050);
                del(mytime);
            }
        }
        public static void DayMethod(int time)
        {
            Console.WriteLine("This method shows day after {0} days: {1:dddd}",time, DateTime.Now.AddDays(time));
        }
        public static void MonthMethod(int time)
        {
            Console.WriteLine("This method shows month after {0} mounts: {1:MMMM}", time, DateTime.Now.AddMonths(time));
        }
        public static void SecondsMethod(int time)
        {
            Console.WriteLine("This method shows second after {0} second: {1:ss}",time, DateTime.Now.AddSeconds(time));
        }
        public static void MinutesMethod(int time)
        {
            Console.WriteLine("This method show minute after {0} minutes: {1:mm}",time, DateTime.Now.AddMinutes(time));
        }

    }
}
