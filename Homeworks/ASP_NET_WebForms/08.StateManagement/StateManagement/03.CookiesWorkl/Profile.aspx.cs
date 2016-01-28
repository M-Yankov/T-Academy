namespace CookiesWorkl
{
    using System;
    using System.Web;
    using System.Web.UI;

    public partial class Profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = this.Request.Cookies[CookieKeyProvider.Key];
            if (cookie == null)
            {
                this.Response.Redirect("Login.aspx");
            }

            this.lblUserName.Text = "Welcome <b>" + cookie.Value + "</b>";
        }
    }
}