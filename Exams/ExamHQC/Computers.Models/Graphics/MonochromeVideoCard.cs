namespace Computers.Models.Graphics
{
    using System;

    public class MonochromeVideoCard : IDrawable
    {
        public void Draw(string textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(textMessage);
            Console.ResetColor();
        }
    }
}
