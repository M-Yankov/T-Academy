using System;
namespace Strategy
{
    public class ColorMixer: IConsoleWriter
    {
        public void Write(string text)
        {
            ConsoleColor[] colorsForConsole = new ConsoleColor[]
            {
                ConsoleColor.White,
                ConsoleColor.Gray,
                ConsoleColor.DarkGray,
                ConsoleColor.DarkYellow,
                ConsoleColor.Yellow,
                ConsoleColor.Red,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkMagenta,
                ConsoleColor.Magenta,
                ConsoleColor.Blue,
                ConsoleColor.Cyan,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkGreen,
                ConsoleColor.Green
            };

            for (int i = 0, colorIndex = 0; i < text.Length; i++, colorIndex++)
            {
                if (colorIndex >= colorsForConsole.Length)
                {
                    colorIndex = 0;
                }

                Console.ForegroundColor = colorsForConsole[colorIndex];
                Console.Write(text[i]);
            }

            Console.ResetColor();
            Console.Write("\n");
        }
    }
}
