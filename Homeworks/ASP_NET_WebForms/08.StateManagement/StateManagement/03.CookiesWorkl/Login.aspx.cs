namespace CookiesWorkl
{
    using System;
    using System.Web;
    using System.Web.UI;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string username = this.tbUserName.Text;
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrWhiteSpace(username))
            {
                return;
            }

            HttpCookie authCookie = new HttpCookie(CookieKeyProvider.Key, this.tbUserName.Text);
            authCookie.Expires = DateTime.Now.AddMinutes(1);
            this.Response.Cookies.Add(authCookie);
            this.Response.Redirect("Profile.aspx");
        }
    }
}