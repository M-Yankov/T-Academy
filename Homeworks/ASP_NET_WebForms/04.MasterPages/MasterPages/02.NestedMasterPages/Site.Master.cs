using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NestedMasterPages
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string lang = this.Session["lang"] as string;
                if (lang != null)
                {
                    for (int i = 0; i < this.ddLang.Items.Count; i++)
                    {
                        if (this.ddLang.Items[i].Value == lang)
                        {
                            this.ddLang.Items[i].Selected = true;
                        }
                        else
                        {
                            this.ddLang.Items[i].Selected = false;
                        }
                    }
                }
            }
        }

        protected void ChangeLang(object sender, EventArgs e)
        {
            // Validations
            string url = (sender as DropDownList).SelectedItem.Value;
            this.Session.Add("lang", url);
            string lang = url.Substring(1, url.LastIndexOf("/") - 1);

            this.Response.Redirect(url);
        }
    }
}