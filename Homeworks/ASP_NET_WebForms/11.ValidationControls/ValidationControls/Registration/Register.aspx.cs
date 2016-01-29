using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registration
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                if (this.radMale.Checked)
                {
                    this.chkCars.Visible = true;
                    this.chkCoffes.Visible = false;
                }

                if (this.radFemale.Checked)
                {
                    this.chkCars.Visible = false;
                    this.chkCoffes.Visible = true;
                }
            }
        }
    }
}