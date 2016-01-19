using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class Summator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CalculateInputs(object sender, EventArgs e)
        {
            try
            {
                decimal firstNumber = decimal.Parse(this.tbFirstNumber.Text);
                decimal secondNumber = decimal.Parse(this.tbSecondNumber.Text);
                this.ResultContainer.CssClass = "has-success";

                decimal result = (firstNumber + secondNumber);
                this.tbResult.Text = result.ToString();
            }
            catch (FormatException ex)
            {
                this.ResultContainer.CssClass = "has-error";
                this.tbResult.Text = "Invalid input!";
            }
        }
    }
}