using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace P08Event
{
    public delegate void ChangedEventHandler(object sender , EventArgs e);
    class TimerN
    {
        public event ChangedEventHandler MyEvent;
        protected virtual void OnChanged(EventArgs e)
        {
            if (MyEvent != null)
            {
                MyEvent(this, e);
            }
        }
        public void DayMethod(int time)
        {
            Console.WriteLine("This method shows day after {0} days: {1:dddd}", time, DateTime.Now.AddDays(time));
            OnChanged(EventArgs.Empty);
        }
        public void MonthMethod(int time)
        {
            Console.WriteLine("This method shows month after {0} mounts: {1:MMMM}", time, DateTime.Now.AddMonths(time));
            OnChanged(EventArgs.Empty);
        }
        public  void SecondsMethod(int time)
        {
            Console.WriteLine("This method shows second after {0} second: {1:ss}", time, DateTime.Now.AddSeconds(time));
            OnChanged(EventArgs.Empty);
        }
        public void MinutesMethod(int time)
        {
            Console.WriteLine("This method show minute after {0} minutes: {1:mm}", time, DateTime.Now.AddMinutes(time));
            OnChanged(EventArgs.Empty);
        }
    }
}
