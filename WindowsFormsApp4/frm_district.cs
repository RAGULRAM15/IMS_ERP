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
    public partial class frm_district : Form
    {
        public frm_district()
        {
            InitializeComponent();
        }

        private void txt_add_Click(object sender, EventArgs e)
        {
            frmadd_district f4 = new frmadd_district();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "ADD DISTRICT";
            f4.Show();
            this.Hide();
        }
        public static string value { get; set; }
        public static string value1 { get; set; }
        public static string value2 { get; set; }
        private void btn_edit_Click(object sender, EventArgs e)
        {
            frmadd_district f4 = new frmadd_district();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "EDIT DISTRICT";
            int rowIndex = dtgF4.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dtgF4.Rows[rowIndex];

             value2 = edit_row.Cells[0].Value.ToString();
            value = edit_row.Cells[1].Value.ToString();
            f4.Show();
            this.Hide();
        }

        private void txt_delete_Click(object sender, EventArgs e)
        {
            int rowIndex = dtgF4.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dtgF4.Rows[rowIndex];

            txt3.Text = edit_row.Cells[0].Value.ToString();

            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            // String str = "Select * from T_QUOTATION_ITEM";
            String sqlquery = "DELETE FROM M_DISTRICT WHERE DISTRICT_ID = '" + txt3.Text + "'";
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
        public void refresh()
        {
            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            String str = "SELECT DISTRICT_ID AS [ID], DISTRICT, DISTRICT_CODE FROM M_DISTRICT WHERE ACTIVE = 1";

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

        private void txt_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void txtdistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmf2 popup = new frmf2();
                // string _query = "SELECT DISTRICT_ID AS [ID], DISTRICT, DISTRICT_CODE FROM M_DISTRICT WHERE ACTIVE = 1";
                string _query = "SELECT DISTRICT_ID AS [ID], DISTRICT, S.STATE FROM [M_DISTRICT] D INNER JOIN[dbo].[M_STATE] S ON D.STATE_ID = S.STATE_ID WHERE D.ACTIVE = 1";
                popup.ShowF2(_query, "District", ((TextBox)sender).Text, "District", sender);
            }
        }

        private void dtgF4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmadd_district f4 = new frmadd_district();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "EDIT DISTRICT";
            int rowIndex = dtgF4.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dtgF4.Rows[rowIndex];

             value2 = edit_row.Cells[0].Value.ToString();
            value = edit_row.Cells[1].Value.ToString();
            f4.Show();
            this.Hide();
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
        private void frm_district_Load(object sender, EventArgs e)
        {
            //dtgF4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dtgF4.Width, dtgF4.Height, 20, 20));
            refresh();
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdistrict_TextChanged(object sender, EventArgs e)
        {
            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            String str = "SELECT DISTRICT_ID AS [ID], DISTRICT, DISTRICT_CODE FROM M_DISTRICT WHERE ACTIVE = 1";

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

            DataView dv = DT.Tables[0].DefaultView;
            dv.RowFilter = "DISTRICT LIKE '" + txtdistrict.Text + "%'";
            dtgF4.DataSource = dv;
        }

        private void frm_district_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
            }
        }
    }
}
