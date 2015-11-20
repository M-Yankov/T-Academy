namespace BullsAndCows.Models
{
    using System;
    using System.Linq;

    public enum GameState
    {
        WaitingForOpponent = 0,
        RedPlayerTurn = 1,
        BluePlayerTurn = 2,
        Finished = 4
    }
}
