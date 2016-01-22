using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace UserProfile
{
    public partial class Friends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.gridFriends.DataSource = this.GetUsers();
            this.gridFriends.DataBind();
        }

        private ICollection<User> GetUsers()
        {
            return new List<User>()
            {
                new User("Milhouse", "Simpson", 3.112345,  2, 13, new DateTime(2003, 6, 18), "http://wiw.org/~jess/wp-content/uploads/2007/07/milhouse.gif"),
                new User("Maggie", "Simpson", 12.713345,  212, 5, new DateTime(2010, 1, 11), "http://www.gunaxin.com/wp-content/uploads/2010/03/Maggie_Simpson.png"),
                new User("Ralf", "Wiggum", 8.215345,  2, 13, new DateTime(2003,6,18), "http://www.polyvore.com/cgi/img-thing?.out=jpg&size=l&tid=5015297"),
                new User("Nelson", "Muntz", 5.042541,  12, 15, new DateTime(2000,7, 4), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Nelson_Muntz.png"),
                new User("Krusty", "Clown", 1.8225,  9, 34, new DateTime(1984,7,11), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Krusty_the_Clown.jpg"),
                new User("Abraham", "Simpson", 15.83261,  91, 93, new DateTime(1924,1,5), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Abraham_Simpson.gif"),
                new User("Ned", "Flanders", 18.9231,  0, 40, new DateTime(1970, 12, 1), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Ned_Flanders.png"),
                new User("Snowbal", "The cat", 12.8351,  54, 2, new DateTime(2005,3,22), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Snowball_II.gif"),
                new User("Waylon", "Smithers", 10.750,  41, 33, new DateTime(2081,5,1), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Waylon_Smithers.png"),
                new User("Todd", "Flanders", 9.16546,  166, 13, new DateTime(2005,9,28), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Todd_Flanders.png"),
                new User("Seymour", "Skinners", 6.5715,  15, 41, new DateTime(1983,6,19), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Seymour_Skinner.png"),
                new User("Sarah", "Wiggum", 6.84185,  7, 43, new DateTime(1978,9,4), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Sarah_Wiggum.png"),
                new User("Rod", "Flanders", 3.59451,  22, 6, new DateTime(2004,3,15), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Rod_Flanders.png"),
                new User("Mr.", "Chalmers", 16.6234,  312, 53, new DateTime(1966,4,22), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Mr_Chalmers.png"),
                new User("Milhouse", "Van Houten", 6.59843,  21, 13, new DateTime(2000,6,18), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Milhouse_van_Houten.png"),
                new User("Marge", "Simpson", 10.0064,  69, 39, new DateTime(1986,1,1), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Marge_Simpson.png"),
                new User("Luann", "Van Houten", 11.16846,  102, 13, new DateTime(2000,6,18), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Luann_van_Houten.png"),
                new User("Itchy", "The mouse", 13.54892,  52, 2, new DateTime(2005,3,22), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Itchy.gif"),
                new User("Clancy", "Wiggum", 6.1234,  159, 19, new DateTime(1993,12,12), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Clancy_Wiggum.png"),
                new User("Bart", "Simpson", 3.557709,  456, 13, new DateTime(2003,4,19), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Bart_Simpson.jpg"),
                new User("Homer", "Simpson", 9.892577,  215, 43, new DateTime(1979,11,6), "http://www.anvari.org/db/cols/The_Simpsons_Characters_Picture_Gallery/Homer_Simpson.png"),
            };
        }

        protected void OnSorting(object sender, GridViewSortEventArgs e)
        {
            this.gridFriends.DataSource = this.GetSortedUsers(e.SortExpression, e.SortDirection);
            this.gridFriends.DataBind();
        }

        private ICollection<User> GetSortedUsers(string field, SortDirection direction)
        {
            switch (field)
            {
                case "Age":
                    return direction == SortDirection.Ascending ?
                        this.GetUsers().OrderBy(e => e.Age).ToList() :
                        this.GetUsers().OrderByDescending(e => e.Age).ToList();
                case "Rating":
                    return direction == SortDirection.Ascending ?
                        this.GetUsers().OrderBy(e => e.Rating).ToList() :
                        this.GetUsers().OrderByDescending(e => e.Rating).ToList();
                default:
                    return direction == SortDirection.Ascending ?
                        this.GetUsers().OrderBy(e => e.FirstName).ToList() :
                        this.GetUsers().OrderByDescending(e => e.FirstName).ToList();
            }
        }

        protected void OnChangePageIndex(object sender, GridViewPageEventArgs e)
        {
            this.gridFriends.PageIndex = e.NewPageIndex;
            this.gridFriends.DataSource = this.GetUsers();
            this.gridFriends.DataBind();
        }
    }
}