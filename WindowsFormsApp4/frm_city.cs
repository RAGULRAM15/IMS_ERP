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
    public partial class frm_city : Form
    {
        public frm_city()
        {
            InitializeComponent();
        }

        private void dtgF4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmadd_city f4 = new frmadd_city();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "EDIT CITY";
            int rowIndex = dtgF4.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dtgF4.Rows[rowIndex];

            value2 = edit_row.Cells[0].Value.ToString();
            value1 = edit_row.Cells[2].Value.ToString();
            value = edit_row.Cells[1].Value.ToString();
            f4.Show();
            this.Hide();
        }

        private void txtcity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmf2 popup = new frmf2();
                //string _query = "SELECT CITY_ID AS [ID], CITY, CITY_CODE FROM M_CITY WHERE ACTIVE = 1";
                string _query = "SELECT CITY_ID AS [ID], CITY, S.DISTRICT FROM [M_CITY] D INNER JOIN[dbo].[M_DISTRICT] S ON D.DISTRICT_ID = S.DISTRICT_ID  WHERE D.ACTIVE = 1 ORDER BY[CITY_ID]";
                //string _query=" SELECT DISTRICT_ID AS[ID], DISTRICT, S.STATE FROM[M_DISTRICT] DINNER JOIN[dbo].[M_STATE] S ON D.STATE_ID = S.STATE_ID WHERE D.ACTIVE = 1";
                popup.ShowF2(_query, "City", ((TextBox)sender).Text, "City", sender);
            }
        }
        public static string value { get; set; }
        public static string value1 { get; set; }
        public static string value2 { get; set; }


        private void txt_add_Click(object sender, EventArgs e)
        {
            frmadd_city f4 = new frmadd_city();
            f4.MdiParent = frm_mid.ActiveForm;

            f4.Show();
            this.Hide();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            frmadd_city f4 = new frmadd_city();
            f4.MdiParent = frm_mid.ActiveForm;

            int rowIndex = dtgF4.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dtgF4.Rows[rowIndex];

             value2 = edit_row.Cells[0].Value.ToString();
            value1 = edit_row.Cells[2].Value.ToString();
            value = edit_row.Cells[1].Value.ToString();
            f4.Show();
            this.Hide();
        }

        private void txt_delete_Click(object sender, EventArgs e)
        {
            int rowIndex = dtgF4.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dtgF4.Rows[rowIndex];

            txt3.Text = edit_row.Cells[0].Value.ToString();

            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
            // String str = "Select * from T_QUOTATION_ITEM";
            String sqlquery = "DELETE FROM M_CITY WHERE CITY_ID = '" + txt3.Text + "'";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(sqlquery, conn))
                {
                    comm.ExecuteNonQuery();
                }
                conn.Close();

            }
            refresh();
        }

        private void txt_refresh_Click(object sender, EventArgs e)
        {
            refresh();
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
        private void frm_city_Load(object sender, EventArgs e)
        {
            //dtgF4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dtgF4.Width, dtgF4.Height, 20, 20));
            refresh();
        }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
        public void refresh()
        {
          
            String str = "SELECT CITY_ID AS [ID], CITY, CITY_CODE FROM M_CITY WHERE ACTIVE = 1";

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                //SqlCommand comm = new SqlCommand(str, conn);
                //comm.Connection = conn;
                //comm.CommandText = str;
                SqlDataAdapter DA = new SqlDataAdapter(str, conn);
                DataSet DT = new DataSet();
                DA.Fill(DT);
                dtgF4.DataSource = DT.Tables[0];
                conn.Close();
            }
        }

        private void txtcity_TextChanged(object sender, EventArgs e)
        {
            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
            String str = "SELECT CITY_ID AS [ID], CITY, CITY_CODE FROM M_CITY WHERE ACTIVE = 1";

            SqlConnection conn = new SqlConnection(ConnString);
            
                conn.Open();
                //SqlCommand comm = new SqlCommand(str, conn);
                //comm.Connection = conn;
                //comm.CommandText = str;
                SqlDataAdapter DA = new SqlDataAdapter(str, conn);
                DataSet DT = new DataSet();
                DA.Fill(DT);
                dtgF4.DataSource = DT.Tables[0];
                conn.Close();
            
            DataView dv =DT.Tables[0].DefaultView;
            dv.RowFilter = "CITY LIKE '" + txtcity.Text + "%'";
            dtgF4.DataSource = dv;
        }

        private void frm_city_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
            }
        }
    }
}
