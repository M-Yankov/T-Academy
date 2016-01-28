namespace WebCounter
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Web.UI;

    public partial class PageArticle : Page
    {
        private const string Key = "Counter";
        private const int InitialValue = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            object counter = this.Application[Key];
            if (counter == null)
            {
                this.Application[Key] = InitialValue;
            }

            int pageCount = int.Parse(this.Application[Key].ToString()) + 1;
            this.Application[Key] = pageCount;

            string bytesAsString = new Helper().ConvertNumberToImageBits(pageCount);
            //string imageSrc = string.Format("data:image/gif;base64,{0}", imageBase64);
           
            
            this.image.ImageUrl = bytesAsString;

            //generatedImage.Save(this.Response.OutputStream, ImageFormat.Png);
        }
    }
}