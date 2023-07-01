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
    public partial class frm_item : Form
    {
        public frm_item()
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
        private void frm_item_Load(object sender, EventArgs e)
        {
            //dgv_item.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgv_item.Width, dgv_item.Height, 20, 20));
            refresh();
        }

        private void txt_item_TextChanged(object sender, EventArgs e)
        {
            //String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            String str = "SELECT ITEM_ID AS [ID], ITEM_NAME, HSN_CODE FROM M_ITEM WHERE ACTIVE = 1";

            SqlConnection conn = new SqlConnection(ConnString);
            
                conn.Open();
                //SqlCommand comm = new SqlCommand(str, conn);
                //comm.Connection = conn;
                //comm.CommandText = str;
                SqlDataAdapter DA = new SqlDataAdapter(str, conn);
                DataSet DT = new DataSet();
                DA.Fill(DT);
                dgv_item.DataSource = DT.Tables[0];
                conn.Close();
            DataView dv = DT.Tables[0].DefaultView;
            dv.RowFilter="ITEM_NAME LIKE'"+txt_item.Text+"%'";
        }

        private void txt_item_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F2)
            //{
            //    frmf5 popup = new frmf5();
            //    string _query = "SELECT ITEM_ID AS [ID], ITEM_NAME, HSN_CODE FROM M_ITEM WHERE ACTIVE = 1";
            //    popup.ShowF2(_query, "ITEM_NAME", ((TextBox)sender).Text, "ITEM_NAME", sender);


            //}
        }

        private void txt_add_Click(object sender, EventArgs e)
        {
            frmadd_item f4 = new frmadd_item();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "ADD ITEM";

            f4.Show();
            this.Hide();
        }
        public static string value { get; set; }
        public static string value1 { get; set; }
        private void txt_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
        public void refresh()
        {
           
            String str = "SELECT ITEM_ID AS [ID], ITEM_NAME, HSN_CODE FROM M_ITEM WHERE ACTIVE = 1";

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                //SqlCommand comm = new SqlCommand(str, conn);
                //comm.Connection = conn;
                //comm.CommandText = str;
                SqlDataAdapter DA = new SqlDataAdapter(str, conn);
                DataSet DT = new DataSet();
                DA.Fill(DT);
                dgv_item.DataSource = DT.Tables[0];
                conn.Close();
            }
        }
        private void txt_delete_Click(object sender, EventArgs e)
        {
            int rowIndex = dgv_item.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dgv_item.Rows[rowIndex];

            txt3.Text = edit_row.Cells[0].Value.ToString();

            //String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            // String str = "Select * from T_QUOTATION_ITEM";
            String sqlquery = "DELETE FROM M_ITEM WHERE ITEM_ID = '" + txt3.Text + "'";
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

        private void txt3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            frmadd_item f4 = new frmadd_item();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "EDIT ITEM";
            int rowIndex = dgv_item.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dgv_item.Rows[rowIndex];

             value1 = edit_row.Cells[0].Value.ToString();
            value = edit_row.Cells[1].Value.ToString();
            f4.edit_frm();
            f4.Show();
            this.Hide();
        }

        private void dgv_item_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmadd_item f4 = new frmadd_item();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "EDIT ITEM";
            int rowIndex = dgv_item.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dgv_item.Rows[rowIndex];

            // value = edit_row.Cells[0].Value.ToString();
            value = edit_row.Cells[1].Value.ToString();
            f4.edit_frm();
            f4.Show();
            this.Hide();
        }

        private void dgv_item_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
            }
        }

        private void dgv_item_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dgv_item.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
