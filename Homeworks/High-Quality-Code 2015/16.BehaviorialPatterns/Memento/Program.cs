namespace Memento
{
    using System;

    class Program
    {
        static void Main()
        {
            Memory memory = new Memory();
            // Starting a new game

            Game superMario = new Game();
            superMario.Start();
            // playing, playing, jumping, falling, going underground, growing, fighting, killing e.t.c...
            superMario.Coins = 89;
            superMario.Level = 3;
            superMario.SubLevel = 4;
            superMario.Lives = 7;
            superMario.Score = 65340;
            superMario.State = MarioStates.BigAndArmed;
            Console.WriteLine("Playing 3 hours...");

            // Player saves it's good condition.
            memory.Save = superMario.Save();
            superMario.Start();

            // Suddenly Mario dies, killed by Big F***ing Monster
            superMario.GameOver();
            Console.WriteLine("Start from began after dead...");
            superMario.Start();

            // Player: "WtF Wtf, all my lives are gone, coins, aaaah :@ ;("
            // "Don't worry" - said the Game, "I have save for you"
            superMario.Restore(memory.Save);
            Console.WriteLine("Restore save...");
            superMario.Start();
        }
    }
}
