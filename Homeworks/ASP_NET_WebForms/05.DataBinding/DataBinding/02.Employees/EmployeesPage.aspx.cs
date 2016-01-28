using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employees
{
    public partial class EmployeesPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnPageIndexChange(object sender, GridViewPageEventArgs e)
        {
            this.gridEmployees.PageIndex = e.NewPageIndex;
            this.label.Text = this.gridEmployees.PageCount + string.Empty;
        }
    }
}