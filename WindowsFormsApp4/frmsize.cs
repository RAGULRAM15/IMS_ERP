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
    public partial class frmsize : Form
    {
        public frmsize()
        {
            InitializeComponent();
        }

        private void dgv_item_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmadd_size f4 = new frmadd_size();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "EDIT SIZE";
            int rowIndex = dgv_item.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dgv_item.Rows[rowIndex];
            value1 = edit_row.Cells[0].Value.ToString();
            value = edit_row.Cells[1].Value.ToString();
            //value1 = edit_row.Cells[2].Value.ToString();
            f4.Show();
            this.Hide();
        }

        private void txt_add_Click(object sender, EventArgs e)
        {
            frmadd_size f4 = new frmadd_size();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "ADD SIZE";
            f4.Show();
            this.Hide();
        }
        public static string value { get; set; }
        public static string value1 { get; set; }
        private void btn_edit_Click(object sender, EventArgs e)
        {
            frmadd_size f4 = new frmadd_size();
            f4.MdiParent = frm_mid.ActiveForm;
            f4.MODE = "EDIT SIZE";
            int rowIndex = dgv_item.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dgv_item.Rows[rowIndex];
            value1 = edit_row.Cells[0].Value.ToString();
            value = edit_row.Cells[1].Value.ToString();
            //value1 = edit_row.Cells[2].Value.ToString();
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
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
        private void txt_delete_Click(object sender, EventArgs e)
        {
            int rowIndex = dgv_item.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dgv_item.Rows[rowIndex];

            txt3.Text = edit_row.Cells[0].Value.ToString();

            //String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            // String str = "Select * from T_QUOTATION_ITEM";
            String sqlquery = "DELETE FROM M_SIZE WHERE SIZE_ID = '" + txt3.Text + "'";
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

        private void frmsize_Load(object sender, EventArgs e)
        {
            //dgv_item.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgv_item.Width, dgv_item.Height, 20, 20));
            refresh();
        }

        private void txt_item_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.F2)
            //{
            //    frmf5 popup = new frmf5();
            //    string _query = "SELECT SIZE_ID AS [ID], SIZE_NAME FROM M_SIZE WHERE ACTIVE = 1";
            //    popup.ShowF2(_query, "SIZE_NAME", ((TextBox)sender).Text, "SIZE_NAME", sender);


            //}
        }
        public void refresh()
        {
           
            String str = "SELECT SIZE_ID AS [ID], SIZE_NAME FROM M_SIZE WHERE ACTIVE = 1";

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

        private void txt_item_TextChanged(object sender, EventArgs e)
        {
           // String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            String str = "SELECT SIZE_ID AS [ID], SIZE_NAME FROM M_SIZE WHERE ACTIVE = 1";

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
             dv.RowFilter = "SIZE_NAME LIKE'" + txt_item.Text + "%'";
            dgv_item.DataSource = dv;
        }

        private void frmsize_KeyDown(object sender, KeyEventArgs e)
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
