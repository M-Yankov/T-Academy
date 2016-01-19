using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class TextToImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ConvertImage(object sender, EventArgs e)
        {
            string text = this.textToBeConvrted.Text;
            string url = string.Format("/{0}.png", text);
            this.Response.Redirect(url);
        }
    }
}