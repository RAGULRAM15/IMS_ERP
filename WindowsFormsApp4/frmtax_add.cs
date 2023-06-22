using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace IMS
{
    public partial class frmtax_add : Form
    {
        public frmtax_add()
        {
            InitializeComponent();
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (int nTop,
         int nLeft,
         int nRight,
         int nBottum,
         int nWidthEllipse,
         int nHeightEllipse
        );
        public string MODE { get; set; }
        private void frmtax_add_Load(object sender, EventArgs e)
        {
            this.Text = MODE;
            //btnok.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnok.Width, btnok.Height, 20, 20));
            // btnclose.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnclose.Width, btnclose.Height, 20, 20));
            //this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            txt3.Text = frmtax.value2;
            txt1.Text = frmtax.value;
            txt2.Text = frmtax.value1;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            this.Close();
            frmtax frm_District = new frmtax();
            frm_District.MdiParent = frm_mid.ActiveForm;
            frm_District.Show();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (txt1.Text != "" && txt2.Text != ""&&txt3.Text=="")
            {

                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
                string qurey = "INSERT INTO [M_TAX](TAX,PERCENTAGE,ACTIVE,CREATED_ON) VALUES('" + txt1.Text + "'," + txt2.Text + "," + "1" + "," + "GETDATE()" + ")";
                SqlConnection CONN = new SqlConnection(ConnString);
                CONN.Open();
                SqlCommand COMM = new SqlCommand(qurey, CONN);
                COMM.ExecuteNonQuery();
                CONN.Close();


                MessageBox.Show("SAVED SUCESSFULLY", "Message", MessageBoxButtons.OK);
                txt1.Text = "";
                txt2.Text = "";
            }
            if (txt3.Text != "")
            {
                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
                string qurey = "UPDATE M_TAX SET TAX='" + txt1.Text + "',PERCENTAGE = " + txt2.Text + " WHERE TAX_ID =" + txt3.Text + "";
                SqlConnection CONN = new SqlConnection(ConnString);
                SqlCommand COMM = new SqlCommand(qurey, CONN);
                CONN.Open();
                COMM.ExecuteNonQuery();
                CONN.Close();
                MessageBox.Show("SAVED SUCESSFULLY", "Message", MessageBoxButtons.OK);
                txt1.Text = "";
                txt2.Text = "";
            }
            else
            {
                MessageBox.Show("PLEASE ENTER THE VALUE", "MESSAGE", MessageBoxButtons.OK);
            }
            this.Close();
            frmtax frm_District = new frmtax();
            frm_District.MdiParent = frm_mid.ActiveForm;
            frm_District.Show();
        }

        private void frmtax_add_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
                frmtax frm_District = new frmtax();
                frm_District.MdiParent = frm_mid.ActiveForm;
                frm_District.Show();
            }

        }
    }
}
