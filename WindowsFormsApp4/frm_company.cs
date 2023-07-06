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
    public partial class frm_company : Form
    {
        public frm_company()
        {
            InitializeComponent();
        }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
        public static string value1 { get; set; }
        public static string value2 { get; set; }
        private void btn_add_Click(object sender, EventArgs e)
        {
            frmadd_company newMDIChild = new frmadd_company();
            newMDIChild.MdiParent = frm_mid.ActiveForm;
            newMDIChild.MODE = "ADD COMPANY";
            newMDIChild.Show();

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
        private void btn_edit_Click(object sender, EventArgs e)
        {

            frmupdate_company detialform = new frmupdate_company();
            detialform.MdiParent = frm_mid.ActiveForm;
            detialform.MODE = "EDIT COMPANY";
            int rowIndex = dtgF4.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dtgF4.Rows[rowIndex];
            value1 = edit_row.Cells["COMPANY_NAME"].Value.ToString();
            value2 = edit_row.Cells["ID"].Value.ToString();
            //value2 = edit_row.Cells["CUSTOMER_NAME"].Value.ToString();
            detialform.edit_frm();

            detialform.Show();
            this.Hide();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int rowIndex = dtgF4.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dtgF4.Rows[rowIndex];
            value1 = edit_row.Cells["COMPANY_NAME"].Value.ToString();
            txt1.Text = value1;

            
            // String str = "Select * from T_QUOTATION_ITEM";
            String SQLQuery = "DELETE FROM M_COMPANY WHERE COMPANY_NAME = '" + txt1.Text + "'";
            //String sqlquery = "DELETE FROM T_QUOTATION WHERE QUOTATION_NO = '" + txtquotation.Text + "'";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(SQLQuery, conn))
                {
                    comm.ExecuteNonQuery();
                }
                conn.Close();
            }
            refresh();
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            frmadd_company detialform = new frmadd_company();
            detialform.MdiParent = frm_mid.ActiveForm;

            int rowIndex = dtgF4.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dtgF4.Rows[rowIndex];
            value1 = edit_row.Cells["COMPANY_NAME"].Value.ToString();
            //value2 = edit_row.Cells["CUSTOMER_NAME"].Value.ToString();
            detialform.view_form();
            detialform.Show();
            this.Hide();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void txtcompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmf2 popup = new frmf2();
                String qurey = "SELECT COMPANY_ID AS [ID],COMPANY_NAME,GST_NO FROM M_COMPANY WHERE ACTIVE =1";
                popup.ShowF2(qurey, "COMPANY_NAME", ((TextBox)sender).Text, "COMPANY_NAME", sender);
            }
        }

        private void dtgF4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            frmupdate_company detialform = new frmupdate_company();
            detialform.MdiParent = frm_mid.ActiveForm;
            detialform.MODE = "EDIT COMPANY";
            int rowIndex = dtgF4.CurrentCell.RowIndex;
            DataGridViewRow edit_row = dtgF4.Rows[rowIndex];
            value1 = edit_row.Cells["COMPANY_NAME"].Value.ToString();
            value2 = edit_row.Cells["ID"].Value.ToString();
            //value2 = edit_row.Cells["CUSTOMER_NAME"].Value.ToString();
            detialform.edit_frm();

            detialform.Show();
            this.Hide();
        }
        public void refresh()
        {
           
            String str = "SELECT COMPANY_ID AS [ID],COMPANY_NAME,GSTIN FROM M_COMPANY" +
                " WHERE ACTIVE =1";

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
       
        private void frm_company_Load(object sender, EventArgs e)
        {
            //dtgF4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dtgF4.Width, dtgF4.Height, 20, 20));
            refresh();
        }

        private void txtcompany_TextChanged(object sender, EventArgs e)
        {

            
            String str = "SELECT COMPANY_ID AS [ID],COMPANY_NAME,GST_NO FROM M_COMPANY WHERE ACTIVE =1";

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
            dv.RowFilter = "COMPANY_NAME LIKE'" + txtcompany.Text + "%'";
            dtgF4.DataSource = dv;
        }

        private void frm_company_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
            }
        }
    }
}
