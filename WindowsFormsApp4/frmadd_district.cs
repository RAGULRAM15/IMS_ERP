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
    public partial class frmadd_district : Form
    {
        public frmadd_district()
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
        private void frmadd_district_Load(object sender, EventArgs e)
        {
            this.Text = MODE;
            //this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            txt3.Text = frm_district.value2;
            txt1.Text = frm_district.value;
            txt2.Text = frm_district.value1;
            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
            // String str = "Select * from T_QUOTATION_ITEM";
            String SQLQuery = " SELECT STATE_ID, STATE FROM M_STATE WHERE ACTIVE =1 ";


            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand comm = new SqlCommand(SQLQuery, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = comm;
                conn.Open();
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);


                DataRow row = dt.NewRow();
                row[1] = "SELECT STATE";
                dt.Rows.InsertAt(row, 0);
                ////SqlDataReader dr = comm.ExecuteReader();
                //while (dr.Read())
                //{
                //    string item = dr[0].ToString();
                //      txtquotation.Items.Add(item);

                //dr.Close();
                //DataTable dt = ds.Tables[0];
                // txt2.DataSource = ds.Tables["DOWN"].DefaultView;
                txt2.DataSource = dt;
                txt2.DisplayMember = "STATE";
                txt2.ValueMember = "STATE_ID";
                //txt2.Tag = txt2.ValueMember.ToString();

            }
        }

        private void txt2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int item = txt2.SelectedIndex;
            txt2.Tag = item;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (txt1.Text != "" && txt2.Text != "" && txt3.Text=="")
            {
                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
                string qurey = "INSERT INTO [M_DISTRICT](DISTRICT,STATE_ID,ACTIVE) VALUES('" + txt1.Text + "'," + txt2.Tag + ",'" + "1" + "')";
                SqlConnection CONN = new SqlConnection(ConnString);
                CONN.Open();
                SqlCommand COMM = new SqlCommand(qurey, CONN);
                COMM.ExecuteNonQuery();
                CONN.Close();


                MessageBox.Show("SAVED SUCESSFULLY", "Message", MessageBoxButtons.OK);
               
            }
            else if (txt3.Text!="")
            {
                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
                string qurey = "UPDATE M_DISTRICT SET DISTRICT ='" + txt1.Text + "', STATE_ID =" + txt2.Tag + " WHERE DISTRICT_ID ="+txt3.Text+"";
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
            txt2.Text = "";
            txt3.Text = "";
            this.Close();
            frm_district frm_District = new frm_district();
            frm_District.MdiParent = frm_mid.ActiveForm;
            frm_District.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            this.Close(); 
            frm_district frm_District = new frm_district();
            frm_District.MdiParent = frm_mid.ActiveForm;
            frm_District.Show();
        }

        private void frmadd_district_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                txt1.Text = "";
                txt2.Text = "";
                txt3.Text = "";
                this.Close();
                frm_district frm_District = new frm_district();
                frm_District.MdiParent = frm_mid.ActiveForm;
                frm_District.Show();
            }
        }
    }
}
