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
    public partial class frm_invoice_list : Form
    {
        public frm_invoice_list()
        {
            InitializeComponent();
        }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
        public static int comp_id { get; set; }
        public static int year_id { get; set; }
        public static string user_name { get; set; }
        public static string CUSTOMER { get; set; }
        private void frm_invoice_main_Load(object sender, EventArgs e)
        {
            comp_id = frm_mid.comp_id;
            year_id = frm_mid.year_id;
            user_name = frm_mid.User_name;
            this.KeyPreview = true;
            from_date();
            name();
            this.Font = null;
            //to_date();
            //dtg_qut.ColumnHeadersHeight = 25;
            //dtg_qut.RowTemplate.Height = 25;
            //foreach (DataGridView ROW in dtg_qut.Rows)
            //{
            //    ROW.Height = dtg_qut.RowTemplate.Height;
            //}
            //dtg_qut.RowHeadersWidth = 100;
            //dtg_inv.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dtg_inv.Width, dtg_inv.Height, 60, 70));
            String str = "SELECT INVOICE_ID , INVOICE_NO,INVOICE_DATE,[M_CUSTOMER].CUSTOMER_NAME,NET_AMOUNT,STATUS FROM T_INVOICE" +
                " INNER JOIN[M_CUSTOMER] ON[T_INVOICE].CUSTOMER_ID = [M_CUSTOMER].CUSTOMER_ID" +
                
                 " WHERE [T_INVOICE].COMPANY_ID =" + comp_id + "" +
                 " order by INVOICE_ID desc";

            SqlConnection conn = new SqlConnection(ConnString);
            
                conn.Open();
                //SqlCommand comm = new SqlCommand(str, conn);
                //comm.Connection = conn;
                //comm.CommandText = str;
                SqlDataAdapter DA = new SqlDataAdapter(str, conn);
                DataSet DT = new DataSet();
                DA.Fill(DT);
                dtg_inv.DataSource = DT.Tables[0];
                conn.Close();
            
            DateTime startDate = txt_from.Value.Date;
            DateTime endDate = txt_to.Value.Date.AddDays(1).AddSeconds(-1);
            DataView dv = DT.Tables[0].DefaultView;
            dv.RowFilter = "INVOICE_DATE >= '" + startDate + "' AND INVOICE_DATE <= '" + endDate + "'";
            dtg_inv.DataSource = dv;
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
        public static int camp_id { get; set; }
       
        public static string NAME_ID { get; set; }
        public static string STATUS { get; set; }
       

        private void btn_add_Click(object sender, EventArgs e)
        {
            frm_invoice newMDIChild = new frm_invoice();
            newMDIChild.mode = "ADD";
            newMDIChild.MdiParent = frm_mid.ActiveForm;
            newMDIChild.Show();

            this.Hide();
        }
        public static string value1 { get; set; }
        public static string value2 { get; set; }
        public string value3 { get; set; }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dtg_inv.Rows.Count != 0)
            {
               
                int rowIndex = dtg_inv.CurrentCell.RowIndex;
                DataGridViewRow edit_row = dtg_inv.Rows[rowIndex];
                value1 = edit_row.Cells["INVOICE_NO"].Value.ToString();
               // value2 = edit_row.Cells["INVOICE_ID"].Value.ToString();
                STATUS = edit_row.Cells["STATUS"].Value.ToString();
                String sqlquery = "SELECT APPROVAL_CHECK FROM T_INVOICE" +

              " WHERE INVOICE_NO = '" + value1 + "'";
                //try
                //{
                using (SqlConnection conn1 = new SqlConnection(ConnString))
                {

                    SqlCommand comm1 = new SqlCommand(sqlquery, conn1);
                    conn1.Open();
                    SqlDataReader dr2 = comm1.ExecuteReader();
                    SqlDataAdapter dr3 = new SqlDataAdapter(comm1);
                    while (dr2.Read())
                    {
                        value3 = dr2["APPROVAL_CHECK"].ToString();

                    }
                    dr2.Close();
                    conn1.Close();
                }

                if (STATUS == "ACTIVE")
                {
                    if (value3 != true.ToString())
                    {


                        frm_invoice detialform = new frm_invoice();
                        detialform.mode = "EDIT INVOICE";
                        detialform.MdiParent = frm_mid.ActiveForm;

                        //value2 = edit_row.Cells["CUSTOMER_NAME"].Value.ToString();
                        detialform.edit_form();
                        detialform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("INVOICE ALREADY APPROVED...\nPLEASE CHECK THE APPROVAL LIST ", "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("LIST IS CANCELED...\nPLEASE CHECK THE LIST ", "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("PLEASE ADD LIST", "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
            }


        }

        private void dtg_qut_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //    frmQouation detialform = new frmQouation();
            //    detialform.MdiParent = frm_mid.ActiveForm;

            //    int rowIndex = dtg_qut.CurrentCell.RowIndex;
            //    DataGridViewRow edit_row = dtg_qut.Rows[rowIndex];
            //    value1 = edit_row.Cells["QUOTATION_NO"].Value.ToString();
            //    //value2 = edit_row.Cells["CUSTOMER_NAME"].Value.ToString();
            //    detialform.edit_form();

            //    detialform.Show();
            //    this.Hide();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dtg_inv.Rows.Count != 0)
            {
                int rowIndex = dtg_inv.CurrentCell.RowIndex;
                DataGridViewRow edit_row = dtg_inv.Rows[rowIndex];
                value1 = edit_row.Cells["INVOICE_NO"].Value.ToString();
                STATUS = edit_row.Cells["STATUS"].Value.ToString();

                if (STATUS == "ACTIVE")
                {
                    frm_invoice detialform = new frm_invoice();
                    detialform.mode = "INVOICE DELETE";
                    detialform.MdiParent = frm_mid.ActiveForm;

                    

                    //value2 = edit_row.Cells[0].Value.ToString();
                    //value2 = edit_row.Cells["CUSTOMER_NAME"].Value.ToString();
                    detialform.DELETE_form();
                    detialform.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("SORRY,LIST IS ALREADY CANCELED...\nPLEASE CHECK THE LIST ", "INVENTRY MANAGEMENT", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("PLEASE ADD LIST", "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
            }
            //int rowIndex = dtg_qut.CurrentCell.RowIndex;
            //DataGridViewRow edit_row = dtg_qut.Rows[rowIndex];
            //value1 = edit_row.Cells[0].Value.ToString();
            //txtquotation.Text = value1;

            //String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            //// String str = "Select * from T_QUOTATION_ITEM";
            //String SQLQuery = "DELETE FROM T_QUOTATION_ITEM WHERE QUOTATION_ID = '" + txtquotation.Text + "'";
            //String sqlquery = "DELETE FROM T_QUOTATION WHERE QUOTATION_ID = '" + txtquotation.Text + "'";
            //using (SqlConnection conn = new SqlConnection(ConnString))
            //{
            //    conn.Open();
            //    using (SqlCommand comm = new SqlCommand(sqlquery, conn))
            //    {
            //        comm.ExecuteNonQuery();
            //    }
            //    conn.Close();
            //}



            //try
            //{

            //    using (SqlConnection conn = new SqlConnection(ConnString))
            //    {
            //        conn.Open();
            //        SqlCommand comm = new SqlCommand(sqlquery, conn);


            //        comm.ExecuteNonQuery();

            //        conn.Close();

            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            refresh();

        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            if (dtg_inv.Rows.Count != 0)
            {
                int rowIndex = dtg_inv.CurrentCell.RowIndex;
                DataGridViewRow edit_row = dtg_inv.Rows[rowIndex];
                value1 = edit_row.Cells["INVOICE_NO"].Value.ToString();
                STATUS = edit_row.Cells["STATUS"].Value.ToString();

                if (STATUS == "ACTIVE")
                {
                    frm_invoice detialform = new frm_invoice();
                    detialform.mode = "VIEW INVOICE ";
                    detialform.MdiParent = frm_mid.ActiveForm;


                    //value2 = edit_row.Cells[0].Value.ToString();
                    //value2 = edit_row.Cells["CUSTOMER_ID"].Value.ToString();
                    detialform.view_form();
                    detialform.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("LIST IS CANCELED... \n PLEASE CHECK THE LIST ", "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("PLEASE ADD LIST", "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
            }
        }
        public void refresh()
        {
            txt_fillter.Text = "";
            from_date();
            String str = "SELECT  INVOICE_NO,INVOICE_DATE,CUSTOMER_NAME,NET_AMOUNT,STATUS FROM T_INVOICE" +
                 "   INNER JOIN[M_CUSTOMER] ON [T_INVOICE].CUSTOMER_ID = [M_CUSTOMER].CUSTOMER_ID " +
                 " WHERE [T_INVOICE].COMPANY_ID =" + comp_id + "" +
                 " order by INVOICE_ID desc";

            SqlConnection conn = new SqlConnection(ConnString);
            
                conn.Open();
                //SqlCommand comm = new SqlCommand(str, conn);
                //comm.Connection = conn;
                //comm.CommandText = str;
                SqlDataAdapter DA = new SqlDataAdapter(str, conn);
                DataSet DT = new DataSet();
                DA.Fill(DT);
                dtg_inv.DataSource = DT.Tables[0];
                conn.Close();
            DateTime startDate = txt_from.Value.Date;
            DateTime endDate = txt_to.Value.Date.AddDays(1).AddSeconds(-1);
            DataView dv = DT.Tables[0].DefaultView;
            dv.RowFilter = "INVOICE_DATE >= '" + startDate + "' AND INVOICE_DATE <= '" + endDate + "'";

           dtg_inv.DataSource = dv;

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void dtg_qut_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_fillter_TextChanged(object sender, EventArgs e)
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
            }
        }
        public void to_date()
        {
            

            String str = "SELECT fy_year_id, to_date FROM m_fy_year where  fy_year_id =" + year_id + "";


            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(str, conn);
                //comm.Connection = conn;
                //comm.CommandText = str;
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    txt_to.Tag = dr[0].ToString();

                    string convert = dr["to_date"].ToString();
                    if (!string.IsNullOrEmpty(convert))
                    {
                        txt_to.Value = DateTime.Parse(convert);
                    }
                }
            }
        }
        private void txt_from_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_to_TextChanged(object sender, EventArgs e)
        {

        }
        public void print()
        {

        }
        private void dtg_qut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //frmQouation detialform = new frmQouation();
            //detialform.MdiParent = frm_mid.ActiveForm;

            //int rowIndex = dtg_qut.CurrentCell.RowIndex;
            //DataGridViewRow edit_row = dtg_qut.Rows[rowIndex];
            //value1 = edit_row.Cells["QUOTATION_NO"].Value.ToString();
            ////value2 = edit_row.Cells["CUSTOMER_NAME"].Value.ToString();
            //detialform.edit_form();
            //if (dtg_qut.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            //{
            //    dtg_qut.CurrentRow.Selected = true;
            //    dtg_qut.Rows[e.RowIndex].Cells["QUOTATION_NO"].FormattedValue.ToString();
            //    dtg_qut.Rows[e.RowIndex].Cells["QUOTATION_DATE"].FormattedValue.ToString();
            //    dtg_qut.Rows[e.RowIndex].Cells["CUSTOMER_NAME"].FormattedValue.ToString();
            //    dtg_qut.Rows[e.RowIndex].Cells["TOTAL"].FormattedValue.ToString();
            //    dtg_qut.Rows[e.RowIndex].Cells["STATUS"].FormattedValue.ToString();

            //}
        }
        private int numberOfItemsPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string curdhead = "INVOICE";
            e.Graphics.DrawString(curdhead, new System.Drawing.Font("Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 370, 50);

            string l1 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(l1, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 100);

            string g1 = "INVOICE NO ";
            e.Graphics.DrawString(g1, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 20, 140);

            string g2 = "INVOICE DATE";
            e.Graphics.DrawString(g2, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 150, 140);

            string g3 = "CUSTOMER NAME";
            e.Graphics.DrawString(g3, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 350, 140);

            string g4 = "TOTAL";
            e.Graphics.DrawString(g4, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 590, 140);

            string g5 = "STATUS";
            e.Graphics.DrawString(g5, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 710, 140);

            string l2 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(l2, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 160);

            int height = 165;
            int l;
            for (l = numberOfItemsPrintedSoFar; l < dtg_inv.Rows.Count; l++)
            {
                numberOfItemsPerPage = numberOfItemsPerPage + 1;
                if (numberOfItemsPerPage <= 50)
                {
                    numberOfItemsPrintedSoFar++;

                    if (numberOfItemsPrintedSoFar <= dtg_inv.Rows.Count)
                    {

                        height += dtg_inv.Rows[0].Height;
                        e.Graphics.DrawString(dtg_inv.Rows[l].Cells["INVOICE_NO"].FormattedValue.ToString(), dtg_inv.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(40, height, dtg_inv.Columns[0].Width = 200, dtg_inv.Rows[0].Height));
                        e.Graphics.DrawString(dtg_inv.Rows[l].Cells[2].FormattedValue.ToString(), dtg_inv.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(160, height, dtg_inv.Columns[0].Width = 200, dtg_inv.Rows[0].Height));
                        e.Graphics.DrawString(dtg_inv.Rows[l].Cells[3].FormattedValue.ToString(), dtg_inv.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(320, height, dtg_inv.Columns[0].Width = 200, dtg_inv.Rows[0].Height));
                        e.Graphics.DrawString(dtg_inv.Rows[l].Cells["TOTAL"].FormattedValue.ToString(), dtg_inv.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(600, height, dtg_inv.Columns[0].Width = 200, dtg_inv.Rows[0].Height));

                        e.Graphics.DrawString(dtg_inv.Rows[l].Cells["STATUS"].FormattedValue.ToString(), dtg_inv.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(700, height, dtg_inv.Columns[0].Width = 200, dtg_inv.Rows[0].Height));
                        //string S4 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                        //e.Graphics.DrawString(S4, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 160);
                        //S4 = height + Convert.ToInt32(S4).ToString();

                    }
                                        else
                    {
                        e.HasMorePages = false;
                    }

                    if (numberOfItemsPrintedSoFar >= dtg_inv.Rows.Count)

                    {
                        //int lastRowIndex = dtg_inv.Rows.Count - 1;
                        //int lastRowHeight = dtg_inv.Rows[lastRowIndex].GetPreferredHeight(lastRowIndex, DataGridViewAutoSizeRowMode.AllCells, true);
                        //float lastlLineY = e.MarginBounds.Bottom - lastRowHeight;
                        string S4 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                        e.Graphics.DrawString(S4, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black,0 , height+22);
                        e.Graphics.DrawString("Net Amount : ", dtg_inv.Font = new Font(" Segoe UI Emoji", 10, FontStyle.Bold), Brushes.Black, dtg_inv.Columns[0].Width = 500, height + 44);
                        double sum = 0;
                        for (int i = 0; i < dtg_inv.Rows.Count; i++)
                        {
                            sum += Convert.ToDouble(dtg_inv.Rows[i].Cells["TOTAL"].Value.ToString());

                        }
                        e.Graphics.DrawString(sum.ToString(), dtg_inv.Font = new Font(" Segoe UI Emoji", 10, FontStyle.Bold), Brushes.Black, dtg_inv.Columns[0].Width = 600, height+44);



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

        private void print_Click(object sender, EventArgs e)
        {

            if (dtg_inv.Rows.Count != 0)
            {

                if (dtg_inv.SelectedRows.Count > 0)
                {
                    int rowIndex = dtg_inv.CurrentCell.RowIndex;
                    DataGridViewRow edit_row = dtg_inv.Rows[rowIndex];
                    value1 = edit_row.Cells["INVOICE_NO"].Value.ToString();
                    STATUS = edit_row.Cells["STATUS"].Value.ToString();
                    CUSTOMER = edit_row.Cells["CUSTOMER"].Value.ToString();
                    if (STATUS == "ACTIVE")
                    {
                        Frm_Invoice_print detialform = new Frm_Invoice_print();
                        detialform.mode = "PRINT INVOICE";
                        detialform.MdiParent = frm_mid.ActiveForm;

                        //value2 = edit_row.Cells["CUSTOMER_NAME"].Value.ToString();
                        //detialform.print_form();
                        detialform.Show();
                        this.Hide();

                        //frm_invoice detialform = new frm_invoice();
                        //detialform.MdiParent = frm_mid.ActiveForm;
                        //// detialform.mode = "VIEW QUOTATION";

                        ////value2 = edit_row.Cells[0].Value.ToString();
                        ////value2 = edit_row.Cells["CUSTOMER_ID"].Value.ToString();
                        //detialform.print_form();

                    }

                }
                else
                {
                    if (printPreviewDialog.ShowDialog() != 0)
                    {

                        System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();
                        PrintDialog1.AllowSomePages = true;
                        PrintDialog1.ShowHelp = true;
                        PrintDialog1.Document = printDocument;
                        DialogResult result = PrintDialog1.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            printDocument.Print();
                        }
                        refresh();
                    }

                }
            }
         }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //string curdhead = "QUOTATION";
            //e.Graphics.DrawString(curdhead, new System.Drawing.Font("Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 350, 50);

            //string l1 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            //e.Graphics.DrawString(l1, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 100);

            //string g1 = "QUOTATION_NO ";
            //e.Graphics.DrawString(g1, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 20, 140);

            //string g2 = "QUOTATION_DATE";
            //e.Graphics.DrawString(g2, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 150, 140);

            //string g3 = "CUSTOMER_NAME";
            //e.Graphics.DrawString(g3, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 350, 140);

            //string g4 = "TOTAL";
            //e.Graphics.DrawString(g4, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 590, 140);

            //string g5 = "STATUS";
            //e.Graphics.DrawString(g5, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 690, 140);

            //string l2 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            //e.Graphics.DrawString(l2, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 160);

            //int height = 165;
            //for (int l = numberOfItemsPrintedSoFar; l < dtg_qut.Rows.Count; l++)
            //{
            //    numberOfItemsPerPage = numberOfItemsPerPage + 1;
            //    if (numberOfItemsPerPage <= 50)
            //    {
            //        numberOfItemsPrintedSoFar++;

            //        if (numberOfItemsPrintedSoFar <= dtg_qut.Rows.Count)
            //        {

            //            height += dtg_qut.Rows[0].Height;
            //            e.Graphics.DrawString(dtg_qut.Rows[l].Cells["QUOTATION_NO"].FormattedValue.ToString(), dtg_qut.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(40, height, dtg_qut.Columns[0].Width = 200, dtg_qut.Rows[0].Height));
            //            e.Graphics.DrawString(dtg_qut.Rows[l].Cells["QUOTATION_DATE"].FormattedValue.ToString(), dtg_qut.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(160, height, dtg_qut.Columns[0].Width = 200, dtg_qut.Rows[0].Height));
            //            e.Graphics.DrawString(dtg_qut.Rows[l].Cells["CUSTOMER_NAME"].FormattedValue.ToString(), dtg_qut.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(320, height, dtg_qut.Columns[0].Width = 200, dtg_qut.Rows[0].Height));
            //            e.Graphics.DrawString(dtg_qut.Rows[l].Cells["TOTAL"].FormattedValue.ToString(), dtg_qut.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(600, height, dtg_qut.Columns[0].Width = 200, dtg_qut.Rows[0].Height));

            //            e.Graphics.DrawString(dtg_qut.Rows[l].Cells["STATUS"].FormattedValue.ToString(), dtg_qut.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(700, height, dtg_qut.Columns[0].Width = 200, dtg_qut.Rows[0].Height));
            //            //string S4 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            //            //e.Graphics.DrawString(S4, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 160);
            //            //S4 = height + Convert.ToInt32(S4).ToString();

            //        }
            //        else
            //        {
            //            e.HasMorePages = false;
            //        }

            //    }
            //    else
            //    {
            //        numberOfItemsPerPage = 0;
            //        e.HasMorePages = true;
            //        return;

            //    }


            //}
            //numberOfItemsPerPage = 0;
            //numberOfItemsPrintedSoFar = 0;
        }
      
        private void btn_load_Click(object sender, EventArgs e)
        {
            String str = "SELECT INVOICE_ID , INVOICE_NO,INVOICE_DATE,[M_CUSTOMER].CUSTOMER_NAME,NET_AMOUNT,STATUS FROM T_INVOICE" +
               " INNER JOIN[M_CUSTOMER] ON[T_INVOICE].CUSTOMER_ID = [M_CUSTOMER].CUSTOMER_ID" +

                " WHERE [T_INVOICE].COMPANY_ID =" + comp_id + "" +
                " order by INVOICE_ID desc";
            SqlConnection conn = new SqlConnection(ConnString);

            conn.Open();
            //SqlCommand comm = new SqlCommand(str, conn);
            //comm.Connection = conn;
            //comm.CommandText = str;
            SqlDataAdapter DA = new SqlDataAdapter(str, conn);
            DataSet DT = new DataSet();
            DA.Fill(DT);
            dtg_inv.DataSource = DT.Tables[0];
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
            dtg_inv.DataSource = dv;
        }
        public void name()
        {
            
            String str = "SELECT ENTRY_ID ,ENTRY_NAME FROM M_ENTRY WHERE ENTRY_NAME = '" + "INVOICE" + "'";


            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(str, conn);
                //comm.Connection = conn;
                //comm.CommandText = str;


                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    txt_name.Tag = dr["ENTRY_ID"].ToString();
                    txt_name.Text = dr["ENTRY_NAME"].ToString();
                    NAME_ID = txt_name.Tag.ToString();
                }
                dr.Close();
                conn.Close();
            }
        }

        private void dtg_qut_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //DataGridView gridView = sender as DataGridView;
            //if (null != gridView)
            //{
            //    foreach (DataGridViewRow r in gridView.Rows)
            //    {
            //        gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
            //    }
            //}

            foreach (DataGridViewColumn column in dtg_inv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dtg_qut_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dtg_inv.ClearSelection();
        }

        private void txt_from_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_fillter_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void frm_invoice_list_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_to_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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

      
    }
}
