using System;
using System.Collections.Generic;
namespace Memento
{
    internal class Game
    {
        public Game()
            :this(1,1,MarioStates.Small,0,0,3)
        {

        }

        public Game(int level, int subLevel, MarioStates playerstate, int coins, int points, int lives)
        {
            this.Level = level;
            this.SubLevel = subLevel;
            this.State = playerstate;
            this.Coins = coins;
            this.Lives = lives;
            this.Score = points;
        }

        public int Level { get; set; }

        public int SubLevel { get; set; }

        // It can be a separate class
        public MarioStates State { get; set; }

        public int Lives { get; set; }

        public int Score { get; set; }

        public int Coins { get; set; }

        public IList<string> EnemyCreatures { get; set; }

        public Memento Save()
        {
            return new Memento(this.Level, this.SubLevel, this.State, this.Lives, this.Score, this.Coins);
        }

        public void Restore(Memento memo)
        {
            this.Level = memo.Level;
            this.SubLevel = memo.SubLevel;
            this.State = memo.State;
            this.Lives = memo.Lives;
            this.Score = memo.Score;
            this.Coins = memo.Coins;
        }

        public void Start()
        {
            LoadLevel();
        }

        public void GameOver()
        {
            this.Level = 1;
            this.SubLevel = 1;
            this.State = MarioStates.Small;
            this.Lives = 3;
            this.Score = 0;
            this.Coins = 0;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*** Game Over ***");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void LoadLevel()
        {
            Console.WriteLine(string.Format(
                @"Loading level: {0}-{1}     Coins X {3}    Score - {4}     ☺ X {2}
                    O
                   /|\   X {2}
                   / \", this.Level, this.SubLevel, this.Lives, this.Coins, this.Score));
        }
    }
}
