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
    public partial class Frmadd_entry : Form
    {
        public Frmadd_entry()
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
        private void Frmadd_entry_Load(object sender, EventArgs e)
        {
            this.Text = MODE;
            //this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            txt1.Text = frm_entry.value;
        }

        private void btnok_Click(object sender, EventArgs e)
        {

            if (txt1.Text != "")
            {

                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
                string qurey = "INSERT INTO [M_ENTRY](ENTRY_NAME,ACTIVE) VALUES('" + txt1.Text + "'," + "1" + ")";
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
            txt1.Text = "";
            frm_entry frm_Entry = new frm_entry();
            frm_Entry.MdiParent = frm_mid.ActiveForm;
            frm_Entry.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            this.Close();
            frm_entry frm_Entry = new frm_entry();
            frm_Entry.MdiParent = frm_mid.ActiveForm;
            frm_Entry.Show();
        }

        private void Frmadd_entry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
                frm_entry frm_Entry = new frm_entry();
                frm_Entry.MdiParent = frm_mid.ActiveForm;
                frm_Entry.Show();
            }
        }
    }
}
