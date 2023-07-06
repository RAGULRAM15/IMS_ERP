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
    public partial class frm_invoice_Approval : Form
    {
        public frm_invoice_Approval()
        {
            InitializeComponent();
        }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
        public  int COMPANY_ID { get; set; }
        public int year_id { get; set; }
        private void frm_invoice_Approval_Load(object sender, EventArgs e)
        {
             COMPANY_ID = frm_mid.comp_id;
            year_id = frm_mid.year_id;
            from_date();
            // String str = "Select * from T_QUOTATION_ITEM";
            // String SQLQuery = "SELECT ROW_ID,ITEM_NAME,SIZE,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL FROM T_INVOICE_ITEM WHERE INVOICE_NO = '" + txtinvoice.Text + "'";
            String sqlquery = "SELECT INVOICE_NO,INVOICE_DATE,MC.CUSTOMER_NAME,NET_AMOUNT,TIA.CUSTOMER_ID,APPROVAL_CHECK  FROM T_INVOICE  AS TIA " +
                "INNER JOIN M_CUSTOMER AS MC ON TIA.CUSTOMER_ID = MC.CUSTOMER_ID " +
                "WHERE  TIA.COMPANY_ID=" + COMPANY_ID + " AND TIA.APPROVAL_CHECK = 1  order by INVOICE_NO desc";
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, ConnString);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds, "INVOICE");
            //  dtg_iapproval.DataSource = ds.Tables["ACTIVE"];
            dtg_iapproval.DataSource = ds.Tables["INVOICE"].DefaultView;
        }

        private void txt_add_Click(object sender, EventArgs e)
        {
            frm_approval newMDIChild = new frm_approval();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = frm_mid.ActiveForm;

            // Display the new form.
            newMDIChild.Show();
            this.Hide();
        }

        private void frm_invoice_Approval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
               
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            String sqlquery = "SELECT INVOICE_NO,INVOICE_DATE,MC.CUSTOMER_NAME,NET_AMOUNT,TIA.CUSTOMER_ID,APPROVAL_CHECK  FROM T_INVOICE_APPROVAL  AS TIA " +
                  "INNER JOIN M_CUSTOMER AS MC ON TIA.CUSTOMER_ID = MC.CUSTOMER_ID " +
                  "WHERE  TIA.COMPANY_ID=" + COMPANY_ID + " AND TIA.APPROVAL_CHECK = 1   order by INVOICE_NO desc";


            SqlConnection conn = new SqlConnection(ConnString);

            conn.Open();
            //SqlCommand comm = new SqlCommand(str, conn);
            //comm.Connection = conn;
            //comm.CommandText = str;
            SqlDataAdapter DA = new SqlDataAdapter(sqlquery, conn);
            DataSet DT = new DataSet();
            DA.Fill(DT);
            dtg_iapproval.DataSource = DT.Tables[0];
            conn.Close();
            string filter = txt_fillter.Text.Trim();
            DateTime startDate = txt_from.Value.Date;
            DateTime endDate = txt_to.Value.Date.AddDays(1).AddSeconds(-1);
            DataView dv = DT.Tables[0].DefaultView;
            StringBuilder filter_expression = new StringBuilder();

            filter_expression.Append("CUSTOMER_NAME LIKE'" + filter + "%'");


            if (startDate != DateTime.MinValue && endDate != DateTime.MaxValue)
            {
                if (filter_expression.Length > 0)
                {
                    filter_expression.Append(" AND ");
                }
                filter_expression.Append("INVOICE_DATE >= '" + startDate + "' AND INVOICE_DATE <= '" + endDate + "'");
            }
            if (filter_expression.Length > 0)
            {
                dv.RowFilter = filter_expression.ToString();
            }
            dtg_iapproval.DataSource = dv;
        }
        public void from_date()
        {
            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";

            String str = "SELECT FY_YEAR_ID, FROM_DATE, TO_DATE  FROM M_FY_YEAR where  FY_YEAR_ID =" + year_id + "";


            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(str, conn);
                //comm.Connection = conn;
                //comm.CommandText = str;
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    txt_from.Tag = dr[0].ToString();
                    txt_to.Tag = dr[0].ToString();
                    txt_from.Value = Convert.ToDateTime(dr[1].ToString());
                    txt_to.Value = Convert.ToDateTime(dr[2].ToString());


                }
            }
        }

        private void txt_fillter_Enter(object sender, EventArgs e)
        {
            if (txt_fillter.Text == "Customer Name")
            {
                txt_fillter.Text = "";
                txt_fillter.ForeColor = SystemColors.WindowText;
            }
        }

        private void txt_fillter_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txt_fillter.Text))
            {
                txt_fillter.Text = "Customer Name";
                txt_fillter.ForeColor = SystemColors.GrayText;
            }
        }

        private void dtg_iapproval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dtg_iapproval.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
