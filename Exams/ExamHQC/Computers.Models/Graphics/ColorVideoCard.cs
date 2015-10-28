namespace Computers.Models.Graphics
{
    using System;

    public class ColorVideoCard : IDrawable
    {
        public void Draw(string textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(textMessage);
            Console.ResetColor();
        }
    }
}
