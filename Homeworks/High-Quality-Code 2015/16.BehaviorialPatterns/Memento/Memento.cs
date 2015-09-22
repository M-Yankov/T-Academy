namespace Memento
{
    using System;

    internal class Memento
    {
        public Memento(int mainLevel, int subLevel, MarioStates conditionOfMario, int livesCount, int score, int coins)
        {
            this.Level = mainLevel;
            this.SubLevel = subLevel;
            this.State = conditionOfMario;
            this.Lives = livesCount;
            this.Score = score;
            this.Coins = coins;
        }

        public int Level { get; set; }

        public int SubLevel { get; set; }

        // It can be a separate class
        public MarioStates State { get; set; }

        public int Lives { get; set; }

        public int Score { get; set; }

        public int Coins { get; set; }
    }
}
