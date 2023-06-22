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
    public partial class frmadd_city : Form
    {
        public frmadd_city()
        {
            InitializeComponent();
        }
        public void clear()
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text ="";

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
        private void frmadd_city_Load(object sender, EventArgs e)
        {
            //this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            txt1.Text = frm_city.value;
            txt2.Text = frm_city.value1;
            txt3.Text = frm_city.value2;
            this.Text = MODE;
            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            // String str = "Select * from T_QUOTATION_ITEM";
            String SQLQuery = " SELECT DISTRICT_ID, DISTRICT FROM M_DISTRICT WHERE ACTIVE =1 ";


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
                row[1] = "SELECT DISTRICT";
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
                txt2.DisplayMember = "DISTRICT";
                txt2.ValueMember = "DISTRICT_ID";
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

                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
                string qurey = "INSERT INTO [M_CITY](CITY,DISTRICT_ID,ACTIVE) VALUES('" + txt1.Text + "'," + txt2.Tag + "," + "1" + ")";
                SqlConnection CONN = new SqlConnection(ConnString);
                CONN.Open();
                SqlCommand COMM = new SqlCommand(qurey, CONN);
                COMM.ExecuteNonQuery();
                CONN.Close();
                MessageBox.Show("SAVED SUCESSFULLY", "Message", MessageBoxButtons.OK);


            }
            else if (txt3.Text != "")
            {
                MessageBox.Show("SAVED SUCESSFULLY", "Message", MessageBoxButtons.OK);
                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
                string qurey = "UPDATE [M_CITY] SET CITY='" + txt1.Text + "',DISTRICT_ID=" + txt2.Tag + " WHERE CITY_ID=" + txt3.Text + "";
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

            clear();
            this.Close();
            frm_city _City = new frm_city();
            _City.MdiParent = frm_mid.ActiveForm;
            _City.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            clear();
            this.Close();
            frm_city _City = new frm_city();
            _City.MdiParent = frm_mid.ActiveForm;
            _City.Show();
        }

        private void frmadd_city_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
                frm_city _City = new frm_city();
                _City.MdiParent = frm_mid.ActiveForm;
                _City.Show();
            }
        }
    }
}
