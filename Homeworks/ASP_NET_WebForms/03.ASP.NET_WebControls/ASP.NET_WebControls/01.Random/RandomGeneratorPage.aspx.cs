namespace GetRandomNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class RandomGeneratorPage : Page
    {
        private Random randGenerator = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.errContainer.Visible = false;
        }

        public void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string first = this.tbMinNumber.Value;
            string second = this.tbMaxNumber.Value;
            if (this.HasWrongInput(first,  second))
            {
                AppendError(first, second);
                return;
            }

            this.result.InnerText = GetRandomNumberAsString(first, second);
        }

        protected void GenrateRandomNum_Click(object sender, EventArgs e)
        {
            string first = this.tbWebMinNumber.Text;
            string second = this.tbWebMaxNumber.Text;
            if (this.HasWrongInput(first, second))
            {
                AppendError(first, second);
                return;
            }

            this.lblWebResult.Text = GetRandomNumberAsString(first, second);
        }

        private void AppendError(string first, string second)
        {
            this.errContainer.Style.Add("color", "#fc0711");
            this.errContainer.Visible = true;
            this.errTitle.InnerText = "Invalid Numbers";
            this.errMessage.InnerText = string.Format("First Number should be lower than second. Yours: {0} and {1}", first, second);
        }

        private bool HasWrongInput(string firstNum, string secondNum)
        {
            int min;
            int max;
            if (!int.TryParse(firstNum, out min) || !int.TryParse(secondNum, out max))
            {
                return true;
            }

            if (min >= max)
            {
                return true;
            }

            return false;
        }

        private string GetRandomNumberAsString(string min, string max)
        {
            int minNum = int.Parse(min);
            int maxNum = int.Parse(max);

            return randGenerator.Next(minNum, maxNum) + string.Empty;
        }
    }
}