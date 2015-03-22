
namespace P07DelegateTimer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using P08Event;

    class Program
    {
        static void Main(string[] args)
        {
            TimerN nowaTimer = new TimerN();
            MyClass someExample = new MyClass(nowaTimer);
            nowaTimer.DayMethod(6);
            nowaTimer.MinutesMethod(7);
            nowaTimer.MonthMethod(1);
            nowaTimer.SecondsMethod(2);
        }
    }
    class MyClass
    {
        private TimerN hurryUp;
        public MyClass(TimerN time)
        {
            this.hurryUp = time;
            this.hurryUp.MyEvent += new ChangedEventHandler(SomethingChanged); // hard with this events....
        }
        private void SomethingChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Time changed!");
        }
    }
}
