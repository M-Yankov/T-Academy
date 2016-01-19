namespace HelloWorldWebForms
{
    using System;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class HelloUser : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AddListItemToResult("Page_Load invoked");
            string location = Assembly.GetExecutingAssembly().Location;
            this.lbCurrentAssembly.Text = location;
            this.helloFromCSharpCode.Text = "Hello from C# code!";
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            this.AddListItemToResult("Page_PreInit invoked");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            this.AddListItemToResult("Page_Init invoked");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.AddListItemToResult("Page_PreRender invoked");
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            // It's happens on server restart, crash or shutdown
            // Response is unavailable at page unload
            // Response.Write("Page_Unload invoked" );
        }

        protected void ButtonOK_Init(object sender, EventArgs e)
        {
            this.AddListItemToResult("ButtonOK_Init invoked");
        }

        protected void ButtonOK_Load(object sender, EventArgs e)
        {
            this.AddListItemToResult("ButtonOK_Load invoked");
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            string name = string.Empty;
            if (string.IsNullOrEmpty(this.tbName.Text))
            {
                name = "undefined";
            }
            else
            {
                name = this.tbName.Text;
            }

            this.lbResult.Text = string.Format("Hello {0}!", name);
            this.AddListItemToResult("ButtonOK_Load invoked");
        }

        protected void ButtonOK_PreRender(object sender, EventArgs e)
        {
            this.AddListItemToResult("ButtonOK_PreRender invoked");
        }

        protected void ButtonOK_Unload(object sender, EventArgs e)
        {
            // Response is unavailable at control unload
            // Response.Write("ButtonOK_Unload invoked" );
        }

        private void AddListItemToResult(string text)
        {
            ListItem itemToAdd = new ListItem(text);
            itemToAdd.Attributes.Add("runat", "server");
            this.listPageEvents.Items.Add(itemToAdd);
        }
    }
}