using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StudentsAndCourses
{
    public partial class RegisterStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitStudent_Click(object sender, EventArgs e)
        {
            this.panelResult.Controls.Add(this.CreateControl("h2",
                this.tbFirstName.Text + " " + this.tbLastName.Text));

            this.panelResult.Controls.Add(this.CreateControl("strong",
                "Faculty №: " + this.tbFaculty.Text));

            this.panelResult.Controls.Add(this.CreateControl("br"));

            this.panelResult.Controls.Add(this.CreateControl("em",
                "University: " + this.listUni.SelectedItem.Text));

            this.panelResult.Controls.Add(this.CreateControl("br"));

            this.panelResult.Controls.Add(this.CreateControl("em",
                "Specialty: " + this.listSpec.SelectedItem.Text));

            this.panelResult.Controls.Add(this.CreateControl("div", "Courses: "));

            var itemsAsString = string.Empty;

            foreach (ListItem item in this.listCourses.Items)
            {
                // StringBulder instead
                if (item.Selected)
                {
                    itemsAsString += "<li>" + item.Text + "</li>";
                }
            }

            this.panelResult.Controls.Add(this.CreateControl("ul", itemsAsString));
        }

        private Control CreateControl(string tagName, string innerText = " ")
        {
            string openTag = "<" + tagName + ">";
            string closeTag = "</" + tagName + ">";
            return new LiteralControl(openTag + innerText + closeTag);
        }
    }
}