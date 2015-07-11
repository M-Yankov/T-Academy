namespace MethodPrintStatistics
{
    using System;

    class Test
    {
        static void Main()
        {
            double[] studentMarks = { 3.25, 5.5, 6, 3.75, 4, 5, 6, 3.25, 2.25, 4.5 };
            Statistics stats = new Statistics();
            stats.PrintStatistics(studentMarks);
        }
    }
}
