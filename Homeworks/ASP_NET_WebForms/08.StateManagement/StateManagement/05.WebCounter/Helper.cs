namespace WebCounter
{
    using System;
    using System.Drawing;

    public class Helper
    {
        public string ConvertNumberToImageBits(int value)
        {
            Bitmap generatedImage = new Bitmap(200, 200);
            Graphics gr = Graphics.FromImage(generatedImage);
            Font font = new Font("Consolas", 15, FontStyle.Regular);
            gr.DrawString("Visitors:", font, Brushes.DarkOrange, new PointF(70, 70));
            Font fon2t = new Font("Consolas", 32, FontStyle.Regular);
            gr.DrawString(value.ToString(), fon2t, Brushes.DarkGray, new PointF(90, 90));
            ImageConverter conv = new ImageConverter();
            byte[] imageBytes = (byte[])conv.ConvertTo(generatedImage, typeof(byte[]));
            string bytesAsString = Convert.ToBase64String(imageBytes);
            string imageSrc = string.Format("data:image/png;base64,{0}", bytesAsString);
            return imageSrc;
        }
    }
}