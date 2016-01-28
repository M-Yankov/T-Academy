namespace SessionLife
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;

    public partial class Messages : Page
    {
        private const string Key = "Massages";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string message = this.tbMessage.Text;
            if (string.IsNullOrEmpty(message) || string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            IList<string> contents = this.Session[Key] as List<string>;
            if (contents == null)
            {
                contents = new List<string>();
            }

            contents.Add(message);
            this.Session[Key] = contents;

            this.outPut.Text = string.Empty;
            foreach (string content in contents)
            {
                this.outPut.Text += (this.Server.HtmlEncode(content) + "<br/>");
            }
        }
    }
}