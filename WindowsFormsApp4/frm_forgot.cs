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

namespace IMS
{
    public partial class frm_forgot : Form
    {
        public frm_forgot()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void clear()
        {
            txt_confirmpassword.Text = "";
            txt_newpassword.Text = "";
            txt_oldpassword.Text = "";
            txt_username.Text = "";
        }
       
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
        private void btnlogin_Click(object sender, EventArgs e)
        {
            CHECK();
            if (txt_newpassword.Text == txt_confirmpassword.Text)
            {
                if (txt_oldpassword.Text == lbl_check.Text)
                {

                    String Query;

                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {

                        //comm.Connection = conn;

                        Query = @"UPDATE [M_USER_MANAGEMENT] SET  PASSWORD ='" + txt_confirmpassword.Text + "'  WHERE USER_NAME='" + txt_username.Text.ToUpper().Trim() + "' AND PASSWORD ='" + txt_oldpassword.Text.Trim() + "'";


                        conn.Open();
                        SqlCommand comm = new SqlCommand(Query, conn);
                        comm.ExecuteNonQuery();

                        conn.Close();
                        MessageBox.Show("PASSWORD SUCCESSFULLY GENERATED");
                        clear();
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Old PASSWORD NOT MATCH ");
                }
            }
            else
            {
                MessageBox.Show("CONFIRM PASSWORD NOT A SAME ");
            }
        }
        public void CHECK()
        {
            String Query;

            using (SqlConnection conn = new SqlConnection(ConnString))
            {

                //comm.Connection = conn;

                Query = @"SELECT  PASSWORD FROM M_USER_MANAGEMENT WHERE USER_NAME='" + txt_username.Text.ToUpper().Trim() + "' ";


                conn.Open();
                SqlCommand comm = new SqlCommand(Query, conn);
               SqlDataReader DR= comm.ExecuteReader();
                while (DR.Read())
                {
                    lbl_check.Text = DR["PASSWORD"].ToString();
                }
                DR.Close();

                conn.Close();
            }

        }

        private void frm_forgot_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void frm_forgot_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.X && e.Alt)
            {
                clear();
                this.Close();
            }
        }
    }
}
