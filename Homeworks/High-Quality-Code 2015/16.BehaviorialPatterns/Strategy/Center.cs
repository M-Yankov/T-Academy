namespace Strategy
{
    using System;

    public class Center : IConsoleWriter
    {
        public void Write(string text)
        {
            Console.Title = "You are using Center Writer";

            if (text.Contains("\n"))
            {
                string[] separatedByNewLine = text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in separatedByNewLine)
                {
                    int centerX = (int)((Console.WindowWidth / 2) - (word.Length / 2));
                    int currentRow = Console.CursorTop;
                    Console.SetCursorPosition(centerX, currentRow);
                    Console.WriteLine(word);
                }
            }
            else
            {
                int centerX = (int)((Console.WindowWidth / 2) - (text.Length / 2));
                int currentRow = Console.CursorTop;
                Console.SetCursorPosition(centerX, currentRow);
                Console.WriteLine(text);
            }
        }
    }
}
