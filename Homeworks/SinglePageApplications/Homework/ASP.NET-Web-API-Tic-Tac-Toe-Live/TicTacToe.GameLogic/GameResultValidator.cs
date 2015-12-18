using System.Collections.Generic;
namespace TicTacToe.GameLogic
{
    public class GameResultValidator : IGameResultValidator
    {
        private IList<int>[] indexes;

        public GameResultValidator()
        {
            this.indexes = new List<int>[8];
            this.PopulateData();
        }

        /// <summary>
        /// All 8 directions
        /// </summary>
        private void PopulateData()
        {
            this.indexes[0] = new List<int>() { 0, 1, 2 };
            this.indexes[1] = new List<int>() { 3, 4, 5 };
            this.indexes[2] = new List<int>() { 6, 7, 8 };
            this.indexes[3] = new List<int>() { 0, 4, 8 };
            this.indexes[4] = new List<int>() { 2, 4, 6 };
            this.indexes[5] = new List<int>() { 0, 3, 6 };
            this.indexes[6] = new List<int>() { 1, 4, 7 };
            this.indexes[7] = new List<int>() { 2, 5, 8 };
        }

        // │ O │ - │ X │ 
        // │ O │ - │ X │
        // │ - │ - │ X │
        public GameResult GetResult(string board)
        {
            // check all combinations: diagonal, horizontal, vertical
            for (int i = 0; i < this.indexes.Length; i++)
            {
                int index1 = this.indexes[i][0];
                int index2 = this.indexes[i][1];
                int index3 = this.indexes[i][2];

                string line = board[index1] + string.Empty + board[index2] + string.Empty + board[index3];

                /// formula  a == b and a == c then b = c
                if (line[0] == line[1] && line[0] == line[2] && line[1] != '-' && line[2] != '-' && line[0] != '-')
                {
                    /// We have a winner 
                    if (line[0] + string.Empty == "X")
                    {
                        return GameResult.WonByX;
                    }
                    else
                    {
                        return GameResult.WonByO;
                    }
                }
            }

            // Check if it's draw
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == '-')
                {
                    break;
                }

                if (i == board.Length - 1)
                {
                    return GameResult.Draw;
                }
            }

            return GameResult.NotFinished;
        }
    }
}
