using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01.SayHello
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (txtBox1.Text.Length == 0)
            {
                MessageBox.Show("Enter some text!","Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBox1.Focus();
                richTextBox1.Clear();
            }
            else
            {
                string text = txtBox1.Text;
                richTextBox1.Text = Concatenation(text);

            }

        }
        private string Concatenation(string str)
        {
            str = "Hello " + str + "!" ;  
            return str;
        }
    }
}
