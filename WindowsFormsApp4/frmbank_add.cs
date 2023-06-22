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
    public partial class frmbank_add : Form
    {
        public string MODE { get; internal set; }

        public frmbank_add()
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
        private void frmbank_add_Load(object sender, EventArgs e)
        {
            this.Text = MODE;
            //this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            txt1.Text = frm_bank.value;
            txt2.Text = frm_bank.value1;
            txt3.Text = frm_bank.value2;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (txt1.Text != "")
            {

                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
                string qurey = "INSERT INTO [M_BANK](BANK,ACCOUNT_NO,ACTIVE) VALUES('" + txt1.Text + "'," + txt2.Text + "," + "1" + ")";
                SqlConnection CONN = new SqlConnection(ConnString);
                CONN.Open();
                SqlCommand COMM = new SqlCommand(qurey, CONN);
                COMM.ExecuteNonQuery();
                CONN.Close();


                MessageBox.Show("SAVED SUCESSFULLY", "Message", MessageBoxButtons.OK);
                txt1.Text = "";
                txt2.Text = "";
                txt3.Text = "";
            }
            else if (txt3.Text != "")
            {

                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
                string qurey = "UPDATE [M_BANK] BANK='" + txt1.Text + "',ACCOUNT_NO =" + txt2.Text + " WHERE BANK = "+txt3.Text+"";
                SqlConnection CONN = new SqlConnection(ConnString);
                CONN.Open();
                SqlCommand COMM = new SqlCommand(qurey, CONN);
                COMM.ExecuteNonQuery();
                CONN.Close();


                MessageBox.Show("SAVED SUCESSFULLY", "Message", MessageBoxButtons.OK);
                txt1.Text = "";
                txt2.Text = "";
                txt3.Text = "";
            }
            else
            {
                MessageBox.Show("PLEASE ENTER THE VALUE", "MESSAGE", MessageBoxButtons.OK);
            }
            this.Close();
            frm_bank frm_District = new frm_bank();
            frm_District.MdiParent = frm_mid.ActiveForm;
            frm_District.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            this.Close();
            frm_bank frm_District = new frm_bank();
            frm_District.MdiParent = frm_mid.ActiveForm;
            frm_District.Show();
        }

        private void frmbank_add_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                txt1.Text = "";
                txt2.Text = "";
                txt3.Text = "";
                this.Close();
                frm_bank frm_District = new frm_bank();
                frm_District.MdiParent = frm_mid.ActiveForm;
                frm_District.Show();
            }
        }
    }
}
