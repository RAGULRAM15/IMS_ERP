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
    public partial class frm_addcountry : Form
    {
        public frm_addcountry()
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
        private void frm_addcountry_Load(object sender, EventArgs e)
        {
            //btnok.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnok.Width, btnok.Height, 20, 20));
           // btnclose.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnclose.Width, btnclose.Height, 20, 20));
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            //txtcountry.BorderStyle = BorderStyle.None;
            //txtcode.BorderStyle = BorderStyle.None;
            this.Text = MODE;
            txt3.Text = frm_country.value2;
            txtcountry.Text = frm_country.value;
            txtcode.Text = frm_country.value1;
        }

        private void btnok_Click(object sender, EventArgs e)
        {

            if (txtcode.Text != "" && txtcountry.Text != "" && txt3.Text=="")
            {
                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
                string qurey = "INSERT INTO [dbo].[M_COUNTRY](COUNTRY,COUNTRY_CODE,ACTIVE) VALUES('" + txtcountry.Text + "','" + txtcode.Text + "'," + "1" + ")";
                SqlConnection CONN = new SqlConnection(ConnString);
                CONN.Open();
                SqlCommand COMM = new SqlCommand(qurey, CONN);
                COMM.ExecuteNonQuery();
                CONN.Close();
                MessageBox.Show("SAVED SUCESSFULLY", "Message", MessageBoxButtons.OK);

               
            }
            else if (txt3.Text != "")
            {
                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
                string qurey = "UPDATE M_COUNTRY  SET COUNTRY ='" + txtcountry.Text + "', COUNTRY_CODE ='" + txtcode.Text + "'WHERE COUNTRY_ID="+txt3.Text+"";
                SqlConnection CONN = new SqlConnection(ConnString);
                CONN.Open();
                SqlCommand COMM = new SqlCommand(qurey, CONN);
                COMM.ExecuteNonQuery();
                CONN.Close();
                MessageBox.Show("SAVED SUCESSFULLY", "Message", MessageBoxButtons.OK);

               
            }
            else  
            {
                MessageBox.Show("PLEASE ENTER THE VALUE", "MESSAGE", MessageBoxButtons.OK);
            }
            txtcode.Text = "";
            txtcountry.Text = "";
            txt3.Text = "";
            frm_country _Country = new frm_country();
            _Country.Show();
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            txtcode.Text = "";
            txtcountry.Text = "";
            txt3.Text = "";
            frm_country _Country = new frm_country();
            _Country.Show();
            this.Close();
        }

        private void frm_addcountry_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid);
        }

        private void frm_addcountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
            }
        }
    }
}
