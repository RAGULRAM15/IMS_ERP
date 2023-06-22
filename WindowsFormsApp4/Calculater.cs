using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    public partial class Calculater : Form
    {
        public Calculater()
        {
            InitializeComponent();
        }

        Double resultvalue = 0;
        String oprationperformed = "";
        bool isoprationperformed = false;
       




        private void Button_click(object sender, EventArgs e)
        {
           
        }


        private void oprater_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultvalue != 0)
            {
                txtequal.PerformClick();
                oprationperformed = button.Text;
                lbltxt.Text = resultvalue + " " + oprationperformed;
                isoprationperformed = true;
            }
            else
            {
                oprationperformed = button.Text;
                resultvalue = double.Parse(txtbox.Text);
                lbltxt.Text = resultvalue + " " + oprationperformed;
                isoprationperformed = true;
            }
        }


        private void txtclear_Click(object sender, EventArgs e)
        {
           

        }
                 
        private void txtequal_Click(object sender, EventArgs e)
        {
           
        }

        private void Calculater_Load(object sender, EventArgs e)
        {

        }

        private void txtequal_Click_1(object sender, EventArgs e)
        {
            switch (oprationperformed)
            {
                case "+":
                    txtbox.Text = (resultvalue + double.Parse(txtbox.Text)).ToString();
                    break;

                case "-":
                    txtbox.Text = (resultvalue - double.Parse(txtbox.Text)).ToString();
                    break;
                case "*":
                    txtbox.Text = (resultvalue * double.Parse(txtbox.Text)).ToString();
                    break;
                case "/":
                    txtbox.Text = (resultvalue / double.Parse(txtbox.Text)).ToString();
                    break;
                default:
                    MessageBox.Show("condition is invalid");
                    break;


            }
            resultvalue = double.Parse(txtbox.Text);
            lbltxt.Text = "";
        }

        private void txtclear_Click_1(object sender, EventArgs e)
        {
            lbltxt.Text = "";
            txtbox.Clear();
            txtbox.Text += "0";
            resultvalue = 0;
        }

        private void txt0_Click(object sender, EventArgs e)
        {
            if ((txtbox.Text == "0") || (isoprationperformed))
            {
                txtbox.Clear();
            }
            isoprationperformed = false;
            Button button = (Button)sender;
            //if (button.Text == ".")
            //{
            //    if (txtbox.Text.Contains("."))
            //    {
            //        txtbox.Text += button.Text;
            //    }
            //}
            //else
            //{
            txtbox.Text += button.Text;
            //}
        }

        private void txt5_Click(object sender, EventArgs e)
        {

        }

        private void txtsub_Click(object sender, EventArgs e)
        {

        }
    }
}
