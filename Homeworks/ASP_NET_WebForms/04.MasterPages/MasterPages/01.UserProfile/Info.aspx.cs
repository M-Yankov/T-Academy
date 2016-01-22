using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserProfile
{
    public partial class Info : System.Web.UI.Page
    {
        protected ICollection<User> CurrentUser
        {
            get
            {
                return new List<User>
                {
                    new User("Ivan","Petrov",5.1, 15,22,new DateTime(1993, 5, 5), "https://svpow.files.wordpress.com/2011/02/homer-3.jpeg")
                };
            }
        }
        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.viewInfo.DataSource = this.CurrentUser;
            this.viewInfo.DataBind();
        }
    }
}