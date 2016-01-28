using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Request.Params["id"];
        }
    }
}