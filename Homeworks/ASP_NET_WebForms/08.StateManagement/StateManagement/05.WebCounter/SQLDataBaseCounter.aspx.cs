using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCounter
{
    public partial class SQLDataBaseCounter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbCounterContex ctx = new DbCounterContex();
            COunter counter = ctx.Counters.FirstOrDefault();
            if (counter == null)
            {
                ctx.Counters.Add(new COunter() { Value = 0 });
                ctx.SaveChanges();
            }

            counter.Value++;
            ctx.SaveChangesAsync();

            string imageSrc = new Helper().ConvertNumberToImageBits(counter.Value);
            this.image.ImageUrl = imageSrc;
        }
    }
}