using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EscapingTask
{
    public partial class EscapeHTML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TransferText_Click(object sender, EventArgs e)
        {
            string text = this.tbTextToEscape.Text;
            this.litResult.Text = text;
            this.tbResult.Text = text;
            this.lblResult.Text = Server.HtmlEncode(text);
        }
    }
}