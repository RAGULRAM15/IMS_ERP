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
    public partial class frm_state : Form
    {
        public frm_state()
        {
            InitializeComponent();
        }

        private void txt_add_Click(object sender, EventArgs e)
        {
            frmadd_state f4 = new frmadd_state();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "ADD STATE";
            f4.Show();
            this.Hide();
        }
        public static string value { get; set; }
        public static string value1 { get; set; }
        public static string value2 { get; set; }
        private void btn_edit_Click(object sender, EventArgs e)
        {

            frmadd_state f4 = new frmadd_state();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "EDIT STATE";
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

           // String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
            // String str = "Select * from T_QUOTATION_ITEM";
            String sqlquery = "DELETE FROM M_STATE WHERE STATE_ID = '" + txt3.Text + "'";
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

        private void txtstate_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.F2)
            //{
            //    frmf2 popup = new frmf2();
            //    string _query = "SELECT STATE_ID AS [ID], STATE,STATE_CODE, S.COUNTRY FROM [M_STATE] D INNER JOIN[dbo].[M_COUNTRY] S ON D.COUNTRY_ID = S.COUNTRY_ID WHERE D.ACTIVE = 1";
            //    //string _query = "SELECT STATE_ID AS [ID], STATE, STATE_CODE FROM M_STATE WHERE ACTIVE = 1";
            //    popup.ShowF2(_query, "State", ((TextBox)sender).Text, "State", sender);
            //}
        }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
        public void refresh()
        {
            
            String str = "SELECT  STATE_ID AS [ID], STATE, STATE_CODE FROM M_STATE WHERE ACTIVE = 1";

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
        private void dtgF4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            frmadd_state f4 = new frmadd_state();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "EDIT STATE";
            int rowIndex = dtgF4.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dtgF4.Rows[rowIndex];

             value2 = edit_row.Cells[0].Value.ToString();
            value = edit_row.Cells[1].Value.ToString();
            f4.Show();
            this.Hide();
        }

        private void frm_state_Load(object sender, EventArgs e)
        {
            //dtgF4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dtgF4.Width, dtgF4.Height, 20, 20));
            refresh();
        }

        private void txtstate_TextChanged(object sender, EventArgs e)
        {
            //String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
            String str = "SELECT  STATE_ID AS [ID], STATE, STATE_CODE FROM M_STATE WHERE ACTIVE = 1";

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
            dv.RowFilter = "STATE LIKE'" + txtstate.Text + "%'";
            dtgF4.DataSource = dv;
            
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

        private void dtgF4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_state_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
            }
        }

        private void dtgF4_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dtgF4.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
