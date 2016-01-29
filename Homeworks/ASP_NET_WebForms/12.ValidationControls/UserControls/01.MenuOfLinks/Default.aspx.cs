using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuOfLinks
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<Link> links = new List<Link>()
            {
                new Link() {Title = "Google", Url ="www.google.com" },
                new Link() {Title = "Telerik", Url ="www.telerik.com" },
                new Link() {Title = "Sport", Url ="www.Sportal.bg" },
                new Link() {Title = "Facebook", Url ="www.facebook.com" },
                new Link() {Title = "Youtube", Url ="www.youtube.com" },
            };

            this.linkMenu.DataSouce = links;
            this.linkMenu.DataBind();
        }
    }
}