using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exp3
{
    public partial class Form2 : Form
    {
        public static int num1;
        public static int num2;
        public static int res;
        public int ch;

        public Form2()
        {
            InitializeComponent();
            resultBox.Clear();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            resultBox.Clear();

        }



        private void one_Click(object sender, EventArgs e)
        {

            resultBox.Text += "1";

        }

        private void two_Click(object sender, EventArgs e)
        {
            resultBox.Text += "2";
        }

        private void three_Click(object sender, EventArgs e)
        {
            resultBox.Text += "3";
        }

        private void four_Click(object sender, EventArgs e)
        {
            resultBox.Text += "4";
        }

        private void five_Click(object sender, EventArgs e)
        {
            resultBox.Text += "5";
        }

        private void six_Click(object sender, EventArgs e)
        {
            resultBox.Text += "6";
        }

        private void seven_Click(object sender, EventArgs e)
        {
            resultBox.Text += "7";
        }

        private void eight_Click(object sender, EventArgs e)
        {
            resultBox.Text += "8";
        }

        private void nine_Click(object sender, EventArgs e)
        {
            resultBox.Text += "9";
        }

        private void zero_Click(object sender, EventArgs e)
        {
            resultBox.Text += "0";
        }
        private void add_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToInt32(resultBox.Text);

            resultBox.Clear();
            ch = 1;
        }

        private void sub_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToInt32(resultBox.Text);

            resultBox.Clear();
            ch = 2;
        }

        private void mul_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToInt32(resultBox.Text);

            resultBox.Clear();
            ch = 3;
        }

        private void result_Click(object sender, EventArgs e)
        {
            num2 = Convert.ToInt32(resultBox.Text);
            if (ch == 1)
            {
                num2 = Convert.ToInt32(resultBox.Text);
                res = num1 + num2;

                                  resultBox.Text =Convert.ToString(res);
                num1 = res;

            }
            else if (ch == 2)
            {

                num2 = Convert.ToInt32(resultBox.Text);
                res = num1 - num2;

                                      resultBox.Text = Convert.ToString(res);
                num1 = res;

            }
            else
            {
                num2 = Convert.ToInt32(resultBox.Text);
                res = num1 * num2;

                resultBox.Text = Convert.ToString(res);
                num1 = res;

            }

        }

    }

}
