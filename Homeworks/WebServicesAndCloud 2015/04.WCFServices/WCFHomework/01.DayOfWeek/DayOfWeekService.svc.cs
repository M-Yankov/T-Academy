namespace DayOfWeek
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Task 1. Create a simple WCF service. It should have a method that accepts a DateTime parameter and returns the day of week (in Bulgarian) as string.
    ///     ○ Test it with the integrated WCF client.
    /// </summary>
    public class DayOfWeekService : IDayOfWeekService
    {
        private SortedList<Enum, string> days;

        public DayOfWeekService()
        {
            this.days = new SortedList<Enum, string>()
            {
               { DayOfWeek.Monday, "Понеделник" },
               { DayOfWeek.Tuesday, "Вторник" },
               { DayOfWeek.Wednesday, "Сряда" },
               { DayOfWeek.Thursday, "Четвъртък" },
               { DayOfWeek.Friday, "Петък" },
               { DayOfWeek.Saturday, "Събота" },
               { DayOfWeek.Sunday, "Неделя" } 
            };
        }

        public string DayOfWeekInBulgarian(DateTime date)
        {
            return this.days[date.DayOfWeek];
        }
    }
}
