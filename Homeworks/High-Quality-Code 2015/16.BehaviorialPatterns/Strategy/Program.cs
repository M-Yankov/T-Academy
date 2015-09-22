namespace Strategy
{
    using System;

    public class Program
    {
        static void Main()
        {
            IConsoleWriter writeWithDetails = new DetailWriter();
            IConsoleWriter center = new Center();
            IConsoleWriter color = new ColorMixer();

            writeWithDetails.Write("Pesho");
            
            center.Write("Pesho is on the center");
            center.Write("and waits for a beer...");
            center.Write("Many\nwords\nseparated with\n new line symbol\nto\ntesting it's visualization");

            color.Write("Color mixer is fun, but it's not random ;)");
        }
    }
}
