using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuOfLinks
{
    public partial class MenuLinks : System.Web.UI.UserControl
    {
        private string font;
        private Color color;

        public string Font
        {
            get { return font; }
            set { font = value; }
        }

        public Color Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public object DataSouce { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected override void OnDataBinding(EventArgs e)
        {
            this.dataList.DataSource = this.DataSouce;
            this.dataList.DataBind();
            base.OnDataBinding(e);
        }
    }
}