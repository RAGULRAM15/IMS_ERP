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
    public partial class frm_invoice_report : Form
    {
        public frm_invoice_report()
        {
            InitializeComponent();
        }

        private void frm_invoice_report_Load(object sender, EventArgs e)
        {
            txt_company.Tag = frm_mid. comp_id;
            company_name();
            from_date();
            year_id = frm_mid.year_id;
            //DROP();
            from_date();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        public void from_date()
        {


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
                dr.Close();
                conn.Close();
            }
        }
       
        public void company_name()
        {

            //// String str = "Select * from T_QUOTATION_ITEM";
            String SQLQuery = " SELECT  COMPANY_NAME FROM M_COMPANY WHERE COMPANY_ID =" + txt_company.Tag + " ";
            try
            {
                SqlConnection conn = new SqlConnection(ConnString);
                conn.Open();
                SqlCommand comm = new SqlCommand(SQLQuery, conn);

                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    string item = dr[0].ToString();
                    txt_company.Text = item;



                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static int year_id { get; set; }
        private void frm_qut_report_Load(object sender, EventArgs e)
        {

        }
        public void DROP()
        {
            //String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
            //// String str = "Select * from T_QUOTATION_ITEM";
            //String SQLQuery = " SELECT COMPANY_ID, COMPANY_NAME FROM M_COMPANY WHERE ACTIVE =1 ";
            //try
            //{
            //    using (SqlConnection conn = new SqlConnection(ConnString))
            //    {
            //        SqlCommand comm = new SqlCommand(SQLQuery, conn);
            //        SqlDataAdapter da = new SqlDataAdapter();
            //        da.SelectCommand = comm;
            //        conn.Open();
            //        DataTable dt = new DataTable();
            //        DataSet ds = new DataSet();
            //        da.Fill(dt);
            //        DataRow row = dt.NewRow();
            //        row[1] = "";
            //        dt.Rows.InsertAt(row, 0);
            //        //SqlDataReader dr = comm.ExecuteReader();
            //        //while (dr.Read())
            //        //{
            //        //    string item = dr[0].ToString();
            //        //      txtquotation.Items.Add(item);

            //        //dr.Close();
            //        //DataTable dt = ds.Tables[0];
            //        txt_company.DataSource = dt;
            //        txt_company.DisplayMember = "COMPANY_NAME";
            //        txt_company.ValueMember = "COMPANY_ID";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void txt_customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (txt_customer.Text == "")
                {
                    frmf2 popup = new frmf2();
                    string _query = "SELECT CUSTOMER_ID AS [ID], CUSTOMER_NAME, C.CITY FROM M_CUSTOMER CU INNER JOIN M_CITY C ON C.CITY_ID = CU.CITY_ID WHERE CU.ACTIVE = 1";
                    popup.ShowF2(_query, "CUSTOMER_NAME", ((TextBox)sender).Text, "CUSTOMER_NAME", sender);
                }

                //}
                //}

            }
        }

        private void txt_company_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int item = txt_company.SelectedIndex;
            //txt_company.Tag = item;
        }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
        private void btn_gridview_Click(object sender, EventArgs e)
        {
            dtg_inv_report.Visible = true;
            txt_total.Visible = true;
            if (txt_customer.Text != "")
            {
                
                String str = "SELECT INVOICE_ID , INVOICE_NO,INVOICE_DATE,CUSTOMER_NAME,NET_AMOUNT FROM T_INVOICE" +
                    "   INNER JOIN [M_CUSTOMER] ON [T_INVOICE].CUSTOMER_ID = [M_CUSTOMER].CUSTOMER_ID" +
                    " WHERE T_INVOICE.CUSTOMER_ID=" + txt_customer.Tag + " AND T_INVOICE.COMPANY_ID =" + txt_company.Tag + "" +
                    "ORDER BY INVOICE_ID";


                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    //SqlCommand comm = new SqlCommand(str, conn);
                    //comm.Connection = conn;
                    //comm.CommandText = str;
                    SqlDataAdapter DA = new SqlDataAdapter(str, conn);
                    DataSet DT = new DataSet();
                    DA.Fill(DT);
                    dtg_inv_report.DataSource = DT.Tables[0];
                    conn.Close();
                    DateTime startDate = txt_from.Value.Date;
                    DateTime endDate = txt_to.Value.Date.AddDays(1).AddSeconds(-1);
                    DataView dv = DT.Tables[0].DefaultView;
                    dv.RowFilter = "INVOICE_DATE >= '" + startDate + "' AND INVOICE_DATE <= '" + endDate + "'";
                    dtg_inv_report.DataSource = dv;
                }
            }
            else
            {
                if (txt_customer.Text == "")
                {
                    
                    String str = "SELECT INVOICE_ID , INVOICE_NO,INVOICE_DATE,CUSTOMER_NAME,NET_AMOUNT FROM T_INVOICE" +
                        "   INNER JOIN [M_CUSTOMER] ON [T_INVOICE].CUSTOMER_ID = [M_CUSTOMER].CUSTOMER_ID" +
                        " WHERE COMPANY_ID=" + txt_company.Tag + "" +
                        "ORDER BY INVOICE_ID";


                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        conn.Open();
                        //SqlCommand comm = new SqlCommand(str, conn);
                        //comm.Connection = conn;
                        //comm.CommandText = str;
                        SqlDataAdapter DA = new SqlDataAdapter(str, conn);
                        DataSet DT = new DataSet();
                        DA.Fill(DT);
                        dtg_inv_report.DataSource = DT.Tables[0];
                        conn.Close();
                        DateTime startDate = txt_from.Value.Date;
                        DateTime endDate = txt_to.Value.Date.AddDays(1).AddSeconds(-1);
                        DataView dv = DT.Tables[0].DefaultView;
                        dv.RowFilter = "INVOICE_DATE >= '" + startDate + "' AND INVOICE_DATE <= '" + endDate + "'";
                        dtg_inv_report.DataSource = dv;
                    }
                }
            }
            TOTAL();

        }
        public void TOTAL()
        {
            Decimal sum = 0;
            int i;


            for (i = 0; i < dtg_inv_report.Rows.Count; i++)
            {
                sum += Decimal.Parse(dtg_inv_report.Rows[i].Cells["NET_AMOUNT"].Value.ToString());

            }

            txt_total.Text = sum.ToString();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            //txt_company.Text = "";
            txt_customer.Text = "";
            dtg_inv_report.DataSource = null;
            dtg_inv_report.Rows.Clear();
            txt_total.Text = "";
            dtg_inv_report.Visible = false;
            txt_total.Visible = false;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            txt_customer.Text = "";
            dtg_inv_report.DataSource = null;
            dtg_inv_report.Rows.Clear();
            txt_total.Text = "";
            dtg_inv_report.Visible = false;
            txt_total.Visible = false;
            this.Close();
        }
        private int numberOfItemsPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string curdhead = "STAG EXPORTS";
            e.Graphics.DrawString(curdhead, new System.Drawing.Font("Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 350, 10);
            string l2 = "---------------------------------";
            e.Graphics.DrawString(l2, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 320, 20);
            string curdhead2 = "INVOICE SUMMARY REPORT";
            e.Graphics.DrawString(curdhead2, new System.Drawing.Font("Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 300, 30);
            string l3 = "------------------------------------------------";
            e.Graphics.DrawString(l3, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 290, 40);

            string curdhead3 = "(" + txt_from.Text + ")-(" + txt_to.Text + ")";
            e.Graphics.DrawString(curdhead3, new System.Drawing.Font("Segoe UI Emoji", 14, FontStyle.Bold), Brushes.Black, 292, 50);
            if (txt_customer.Text != "")
            {
                string curdhead4 = "CUSTOMER : " + txt_customer.Text + "";
                e.Graphics.DrawString(curdhead4, new System.Drawing.Font("Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 500, 100);
            }
            string curdhead5 = "COMPANY : " + txt_company.Text + "";
            e.Graphics.DrawString(curdhead5, new System.Drawing.Font("Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 100);





            string l1 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(l1, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 120);

            string g1 = "INVOICE_NO ";
            e.Graphics.DrawString(g1, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 20, 140);

            string g2 = "INVOICE_DATE";
            e.Graphics.DrawString(g2, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 200, 140);

            string g3 = "CUSTOMER_NAME";
            e.Graphics.DrawString(g3, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 450, 140);

            string g4 = "AMOUNT";
            e.Graphics.DrawString(g4, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 690, 140);

            //string g5 = "STATUS";
            //e.Graphics.DrawString(g5, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 690, 140);

            string l8 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(l8, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 160);

            int height = 165;
            for (int l = numberOfItemsPrintedSoFar; l < dtg_inv_report.Rows.Count; l++)
            {
                numberOfItemsPerPage = numberOfItemsPerPage + 1;
                if (numberOfItemsPerPage <= 50)
                {
                    numberOfItemsPrintedSoFar++;

                    if (numberOfItemsPrintedSoFar <= dtg_inv_report.Rows.Count)
                    {

                        height += dtg_inv_report.Rows[0].Height;
                        e.Graphics.DrawString(dtg_inv_report.Rows[l].Cells["INVOICE_NO"].FormattedValue.ToString(), dtg_inv_report.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(40, height, dtg_inv_report.Columns[0].Width = 200, dtg_inv_report.Rows[0].Height));
                        e.Graphics.DrawString(dtg_inv_report.Rows[l].Cells["INVOICE_DATE"].FormattedValue.ToString(), dtg_inv_report.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(220, height, dtg_inv_report.Columns[0].Width = 200, dtg_inv_report.Rows[0].Height));
                        e.Graphics.DrawString(dtg_inv_report.Rows[l].Cells["CUSTOMER_NAME"].FormattedValue.ToString(), dtg_inv_report.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(425, height, dtg_inv_report.Columns[0].Width = 200, dtg_inv_report.Rows[0].Height));
                        e.Graphics.DrawString(dtg_inv_report.Rows[l].Cells["NET_AMOUNT"].FormattedValue.ToString(), dtg_inv_report.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(700, height, dtg_inv_report.Columns[0].Width = 200, dtg_inv_report.Rows[0].Height));

                        // e.Graphics.DrawString(dtg_qut_report.Rows[l].Cells["STATUS"].FormattedValue.ToString(), dtg_qut_report.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(700, height, dtg_qut_report.Columns[0].Width = 200, dtg_qut.Rows[0].Height));
                        //string S4 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                        //e.Graphics.DrawString(S4, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, numberOfItemsPrintedSoFar);

                        //S4 = height + Convert.ToInt32(S4).ToString();

                    }
                    else
                    {


                        e.HasMorePages = false;
                    }
                    if (numberOfItemsPrintedSoFar >= dtg_inv_report.Rows.Count)

                    {
                        //int lastRowIndex = dtg_inv.Rows.Count - 1;
                        //int lastRowHeight = dtg_inv.Rows[lastRowIndex].GetPreferredHeight(lastRowIndex, DataGridViewAutoSizeRowMode.AllCells, true);
                        //float lastlLineY = e.MarginBounds.Bottom - lastRowHeight;
                        string S4 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                        e.Graphics.DrawString(S4, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, height + 22);
                        e.Graphics.DrawString("TOTAL : ", dtg_inv_report.Font = new Font(" Segoe UI Emoji", 10, FontStyle.Bold), Brushes.Black, dtg_inv_report.Columns[0].Width = 10, height + 44);


                        double sum = 0;
                        int value = 0;
                        for (int i = 0; i < dtg_inv_report.Rows.Count; i++)
                        {
                            sum += Convert.ToDouble(dtg_inv_report.Rows[i].Cells["NET_AMOUNT"].Value.ToString());
                            
                        }
                        value = Convert.ToInt32(dtg_inv_report.Rows.Count.ToString());
                        e.Graphics.DrawString(value.ToString(), dtg_inv_report.Font = new Font(" Segoe UI Emoji", 10, FontStyle.Bold), Brushes.Black, dtg_inv_report.Columns[0].Width = 80, height + 44);
                        e.Graphics.DrawString(sum.ToString(), dtg_inv_report.Font = new Font(" Segoe UI Emoji", 10, FontStyle.Bold), Brushes.Black, dtg_inv_report.Columns[0].Width = 700, height + 44);

                        string S5 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                        e.Graphics.DrawString(S5, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, height + 66);


                    }
                }
                else
                {

                    numberOfItemsPerPage = 0;
                    e.HasMorePages = true;
                    return;

                }

            }
            numberOfItemsPerPage = 0;
            numberOfItemsPrintedSoFar = 0;

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (txt_customer.Text != "")
            {
               
                String str = "SELECT INVOICE_ID , INVOICE_NO,INVOICE_DATE,CUSTOMER_NAME,NET_AMOUNT FROM T_INVOICE" +
                    "   INNER JOIN [M_CUSTOMER] ON [T_INVOICE].CUSTOMER_ID = [M_CUSTOMER].CUSTOMER_ID" +
                    " WHERE T_INVOICE.CUSTOMER_ID =" + txt_customer.Tag + " AND T_INVOICE.COMPANY_ID ="+txt_company.Tag+"" +
                    "ORDER BY INVOICE_ID";


                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    conn.Open();
                    //SqlCommand comm = new SqlCommand(str, conn);
                    //comm.Connection = conn;
                    //comm.CommandText = str;
                    SqlDataAdapter DA = new SqlDataAdapter(str, conn);
                    DataSet DT = new DataSet();
                    DA.Fill(DT);
                    dtg_inv_report.DataSource = DT.Tables[0];
                    conn.Close();
                    DateTime startDate = txt_from.Value.Date;
                    DateTime endDate = txt_to.Value.Date.AddDays(1).AddSeconds(-1);
                    DataView dv = DT.Tables[0].DefaultView;
                    dv.RowFilter = "INVOICE_DATE >= '" + startDate + "' AND INVOICE_DATE <= '" + endDate + "'";
                    dtg_inv_report.DataSource = dv;
                    printPreviewDialog.ShowDialog();
                }
            }
            else
            {
                if (txt_customer.Text == "")
                {
                   
                    String str = "SELECT INVOICE_ID ,INVOICE_NO,INVOICE_DATE,CUSTOMER_NAME,NET_AMOUNT FROM T_INVOICE" +
                        "   INNER JOIN [M_CUSTOMER] ON [T_INVOICE].CUSTOMER_ID = [M_CUSTOMER].CUSTOMER_ID" +
                        " WHERE COMPANY_ID=" + txt_company.Tag + "" +
                        "ORDER BY INVOICE_ID";


                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        conn.Open();
                        //SqlCommand comm = new SqlCommand(str, conn);
                        //comm.Connection = conn;
                        //comm.CommandText = str;
                        SqlDataAdapter DA = new SqlDataAdapter(str, conn);
                        DataSet DT = new DataSet();
                        DA.Fill(DT);
                        dtg_inv_report.DataSource = DT.Tables[0];
                        conn.Close();
                        DateTime startDate = txt_from.Value.Date;
                        DateTime endDate = txt_to.Value.Date.AddDays(1).AddSeconds(-1);
                        DataView dv = DT.Tables[0].DefaultView;
                        dv.RowFilter = "INVOICE_DATE >= '" + startDate + "' AND INVOICE_DATE <= '" + endDate + "'";
                        dtg_inv_report.DataSource = dv;
                        printPreviewDialog.ShowDialog();
                    }
                }
            }
            //System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();
            //PrintDialog1.AllowSomePages = true;
            //PrintDialog1.ShowHelp = true;
            //PrintDialog1.Document = printDocument;
            //DialogResult result = PrintDialog1.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    printDocument.Print();
            //}
        }

        private void printDocument_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void frm_invoice_report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                txt_customer.Text = "";
                dtg_inv_report.DataSource = null;
                dtg_inv_report.Rows.Clear();
                txt_total.Text = "";
                dtg_inv_report.Visible = false;
                txt_total.Visible = false;
                this.Close();
            }
        }

        private void dtg_inv_report_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dtg_inv_report.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
