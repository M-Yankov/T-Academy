namespace WebCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Calculator : System.Web.UI.Page
    {
        private const int MAX_LENGTH_INPUT = 13;
        private const string OPERATION = "command";
        private const string FIRST_NUMBER = "firstNumber";
        private const string SECOND_NUMBER = "secondNumber";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddToInput(object sender, EventArgs e)
        {
            if (this.tbInput.Text.Length > MAX_LENGTH_INPUT)
            {
                return;
            }

            this.tbInput.Text += (sender as Button).Text;
        }

        protected void ClearInput(object sender, EventArgs e)
        {
            this.tbInput.Text = string.Empty;
            this.ViewState[FIRST_NUMBER] = null;
            this.ViewState[OPERATION] = null;
            this.lblSign.Text = string.Empty;
            this.lblFirstNum.Text = string.Empty;
        }

        protected void ProcessCommand(object sender, CommandEventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbInput.Text) ||
                string.IsNullOrWhiteSpace(this.tbInput.Text))
            {
                return;
            }

            object c = this.ViewState[OPERATION];
            if (c != null)
            {
                // Damn
                Operation operaton = (Operation)Enum.Parse(typeof(Operation), c.ToString());
                decimal firstNum = decimal.Parse(this.ViewState[FIRST_NUMBER].ToString());
                decimal secondNum = decimal.Parse(this.tbInput.Text);

                this.tbInput.Text = this.CalculateNumbers(firstNum, secondNum, operaton);
                
            }

            Operation op = (Operation)Enum.Parse(typeof(Operation), e.CommandName);
            switch (op)
            {
                case Operation.Addition:
                    this.lblSign.Text = "+";
                    break;
                case Operation.Division:
                    this.lblSign.Text = "/";
                    break;
                case Operation.Multiplication:
                    this.lblSign.Text = "X";
                    break;
                case Operation.Square:
                    this.lblSign.Text = "√";
                    break;
                case Operation.Subtraction:
                    this.lblSign.Text = "-";
                    break;
                default:
                    return;
            }

            this.ViewState[FIRST_NUMBER] = this.tbInput.Text;
            this.lblFirstNum.Text = this.tbInput.Text;
            this.tbInput.Text = string.Empty;
            this.ViewState[OPERATION] = e.CommandName;
        }

        protected void CalculateOnClick(object sender, EventArgs e)
        {
            object c = this.ViewState[OPERATION];
            if (c == null)
            {
                return;
            }

            Operation operaton = (Operation)Enum.Parse(typeof(Operation), c.ToString());
            decimal firstNum = decimal.Parse(this.ViewState[FIRST_NUMBER].ToString());
            decimal secondNum = decimal.Parse(this.tbInput.Text);

            this.tbInput.Text = this.CalculateNumbers(firstNum, secondNum, operaton);

            this.ViewState[FIRST_NUMBER] = null;
            this.ViewState[OPERATION] = null;
            this.lblSign.Text = string.Empty;
            this.lblFirstNum.Text = string.Empty;
        }
        protected void CalculateSquare(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbInput.Text) ||
                string.IsNullOrWhiteSpace(this.tbInput.Text))
            {
                return;
            }

            double num = double.Parse(this.tbInput.Text);
            double result = Math.Sqrt(num);

            this.ViewState[FIRST_NUMBER] = null;
            this.ViewState[OPERATION] = null;

            this.tbInput.Text = result + string.Empty;
            this.lblFirstNum.Text = string.Empty;
            this.lblSign.Text = string.Empty;
        }

        private string CalculateNumbers(decimal first, decimal second, Operation operaton)
        {
            switch (operaton)
            {
                case Operation.Addition:
                    return (first + second) + string.Empty;
                case Operation.Division:
                    if (first == 0)
                    {
                        return "0";
                    }
                    else
                    {
                        return (first / second) + string.Empty;
                    }

                case Operation.Multiplication:
                    return (first * second) + string.Empty;
                case Operation.Subtraction:
                    return (first - second) + string.Empty;
                default:
                    return string.Empty;
            }
        }
    }
}