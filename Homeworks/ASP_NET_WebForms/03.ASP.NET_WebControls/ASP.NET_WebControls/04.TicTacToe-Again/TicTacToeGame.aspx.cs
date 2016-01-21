using System;
using System.Web.UI.WebControls;
using System.Linq;

namespace TicTacToe_Again
{
    public partial class TicTacToeGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                foreach (ListItem item in this.gameBoard.Items)
                {
                    if (item.Text == string.Empty)
                    {
                        item.Attributes.Add("class", "closed");
                    }
                }
            }
        }

        protected void btnPlay_Click(object sender, EventArgs e)
        {
            ListItem selected = this.gameBoard.SelectedItem;

            if (!this.ProcessPlayerTurn(selected))
            {
                return;
            }

            var board = GetValuesAsStringBoardFormat();

            GameLogic game = new GameLogic();
            GameState state = game.GetResult(board);

            if (state == GameState.UserWins)
            {
                this.lblInfo.Visible = true;
                this.lblInfo.Text = "Congratulations! You won!";
                this.btnPlay.Visible = false;
                this.linkTryAgain.Visible = true;
                return;
            }

            this.ProcessBotAction();

            board = GetValuesAsStringBoardFormat();
            state = game.GetResult(board);

            if (state == GameState.ComputerWins)
            {
                this.lblInfo.Visible = true;
                this.lblInfo.Text = "Loser! You lose!";
                this.btnPlay.Visible = false;
                this.linkTryAgain.Visible = true;
                return;
            }
            else if (state == GameState.Draw)
            {
                this.lblInfo.Visible = true;
                this.lblInfo.Text = "Draw! You should try again!";
                this.btnPlay.Visible = false;
                this.linkTryAgain.Visible = true;
                return;
            }
        }

        private string GetValuesAsStringBoardFormat()
        {
            string board = string.Empty;
            for (int i = 0; i < this.gameBoard.Items.Count; i++)
            {
                string txt = this.gameBoard.Items[i].Text;
                board += txt == string.Empty ? " " : txt;
            }

            return board;
        }

        /// <summary>
        /// Process Bot command
        /// </summary>
        /// <returns>Returns false if it can not play.</returns>
        private bool ProcessBotAction()
        {
            TicTacToeBot bot = new TicTacToeBot(this.gameBoard);
            int botChoice = bot.PlayAtTile();

            if (botChoice < 0)
            {
                return false;
            }

            this.gameBoard.Items[botChoice].Attributes.Clear();
            this.gameBoard.Items[botChoice].Text = "O";
            this.gameBoard.Items[botChoice].Attributes.Add("class", "sky-color");

            return true;
        }

        /// <summary>
        /// Process command from player.
        /// </summary>
        /// <param name="selected">ListItem that should be selected from user.</param>
        /// <returns>Returns false if operation fails.</returns>
        private bool ProcessPlayerTurn(ListItem selected)
        {
            if (selected == null)
            {
                this.lblError.Visible = true;
                this.lblError.Text = "Please select a tile!";
                return false;
            }

            int index = int.Parse(selected.Value);

            if (this.gameBoard.Items[index].Text != string.Empty)
            {
                this.gameBoard.Items[index].Selected = false;
                this.lblError.Visible = true;
                this.lblError.Text = "Wrong Tile";
                return false;
            }

            this.lblError.Visible = false;
            this.gameBoard.Items[index].Attributes.Clear();
            this.gameBoard.Items[index].Text = "X";
            this.gameBoard.Items[index].Selected = false;
            this.gameBoard.Items[index].Attributes.Add("class", "joint-color");

            return true;
        }
    }
}