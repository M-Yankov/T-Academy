namespace BullsAndCows.UsersService.Models
{
    public class DetailUserModel
    {
        public string Id { get; set; }

        public int Losses { get; set; }

        public int Rank { get; set; }

        public string Username { get; set; }

        public int Wins { get; set; }
    }
}
