using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TicTacToe_Again
{
    public class TicTacToeBot
    {
        private ListItemCollection tiles;

        public TicTacToeBot(ListBox gameBoard)
        {
            this.tiles = gameBoard.Items;
        }

        /// <summary>
        /// Makes decision where to play.
        /// </summary>
        /// <returns>Index of tile to play.</returns>
        public int PlayAtTile()
        {
            IList<int> freeTiles = this.GetFreeTiles(this.tiles);
            if (freeTiles.Count == 0)
            {
                return -1;
            }

            if (freeTiles.Count == 1)
            {
                return freeTiles[0];
            }

            Random generator = new Random();
            int generatedIndex = generator.Next(0, freeTiles.Count);
            return freeTiles[generatedIndex];
        }

        private IList<int> GetFreeTiles(ListItemCollection items)
        {
            List<int> freeTiles = new List<int>();
            foreach (ListItem item in items)
            {
                if (item.Text == string.Empty)
                {
                    int index = int.Parse(item.Value);
                    freeTiles.Add(index);
                }
            }

            return freeTiles;
        }
    }
}