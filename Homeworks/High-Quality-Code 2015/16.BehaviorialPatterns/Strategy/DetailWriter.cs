namespace Strategy
{
    using System;

    public class DetailWriter : IConsoleWriter
    {
        public void Write(string text)
        {
            string pcName = Environment.UserName;
            DateTime date = DateTime.Now;
            string str = Environment.OSVersion.VersionString;
            
            string fullMessage = string.Format("{0} said: \"{1}\" \t on {2:dd:MM:yyyy HH:mm:ss}", pcName, text, date);
            Console.WriteLine(fullMessage);
            Console.WriteLine(str);
        }
    }
}
