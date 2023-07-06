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
    public partial class frm_approval : Form
    {
        public frm_approval()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void clear()
        {
            dtg_iapproval.DataSource = null;
            dtg_iapproval.Rows.Clear();
            txtcustomer.Text = "";
            rbtn_approve.Checked = false;
            rbtn_unapprove.Checked = true;
            btn_approve.Text = "APPROVAL";
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
        public int COMPANY_ID { get; set; }
        private void frm_approval_Load(object sender, EventArgs e)
        {
            //drop_customer();
            dtg_iapproval.RowHeadersWidth = 50;
            //btn_approve.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_approve.Width, btn_approve.Height, 30, 30));
            btn_unapprove.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_unapprove.Width, btn_unapprove.Height, 30, 30));
            //btn_close.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_close.Width, btn_close.Height, 30, 30));
            //this.Region = Region.FromHrgn(CreateRoundRectRgn(3, 3, this.Width, this.Height, 20, 20));
             COMPANY_ID = frm_mid.comp_id;

        }
        public void drop_customer()
        {
            //String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
            //// String str = "Select * from T_QUOTATION_ITEM";
            //String SQLQuery = "SELECT CUSTOMER_ID, CUSTOMER_NAME FROM M_CUSTOMER ";
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
            //        txtcustomer.DataSource = dt;
            //        txtcustomer.DisplayMember = "CUSTOMER_NAME";
            //        txtcustomer.ValueMember = "CUSTOMER_ID";
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            clear();
            this.Close();
            frm_invoice_Approval newMDIChild = new frm_invoice_Approval();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = frm_mid.ActiveForm;

            // Display the new form.
            newMDIChild.Show();
        }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
        private void btn_approve_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    StringBuilder builder = new StringBuilder();
                    if (rbtn_unapprove.Checked == true)
                    {
                        //btn_approve.Text = "UNAPPROVE";


                        
                        foreach (DataGridViewRow row in dtg_iapproval.Rows)
                        {
                            int i = row.Cells["APPROVAL_CHECK"].RowIndex;
                            if (row.Cells["APPROVAL_CHECK"].Value != DBNull.Value)
                            {
                                String StrQuery = @"INSERT INTO [T_INVOICE_APPROVAL](APPROVAL,CUSTOMER_ID,INVOICE_NO,INVOICE_DATE,NET_AMOUNT,APPROVAL_CHECK,ACTIVE,COMPANY_ID) VALUES ("
                                  + "'" + (rbtn_approve.Checked ? 1 : 0) + "',"
                                  + "'" + dtg_iapproval.Rows[i].Cells["CUSTOMER_ID"].Value + "',"
                                  + "'" + dtg_iapproval.Rows[i].Cells["INVOICE_NO"].Value + "', "

                                  + "'" + dtg_iapproval.Rows[i].Cells["INVOICE_DATE"].Value + "' ,"
                                  + "'" + dtg_iapproval.Rows[i].Cells["NET_AMOUNT"].Value + "',"
                                  + "'" + ((bool)dtg_iapproval.Rows[i].Cells["APPROVAL_CHECK"].Value ? 1 : 0) + "',"
                                 + "'" + "1" + "',"
                                 + "'" + COMPANY_ID + "')";

                                builder.Append(StrQuery);
                                String update = "UPDATE [T_INVOICE] SET APPROVAL_CHECK = '" + ((bool)dtg_iapproval.Rows[i].Cells["APPROVAL_CHECK"].Value ? 1 : 0) + "'  WHERE CUSTOMER_ID ='" + txtcustomer.Tag + "' AND INVOICE_NO ='" + dtg_iapproval.Rows[i].Cells["INVOICE_NO"].Value + "'";
                                builder.Append(update);
                                //String update2 = "UPDATE [T_INVOICE_APPROVAL] SET APPROVAL_CHECK = '" + ((bool)dtg_iapproval.Rows[i].Cells["APPROVAL_CHECK"].Value ? 1 : 0) + "'  WHERE CUSTOMER_ID ='" + txtcustomer.Tag + "' AND INVOICE_NO ='" + dtg_iapproval.Rows[i].Cells["INVOICE_NO"].Value + "'";
                                //builder.Append(update2);
                            }
                            //else
                            //{
                            //    row.Cells["APPROVAL_CHECK"].Value = 1;
                            //}
                        }
                        MessageBox.Show("APPROVAL SUCESSFULLY", "Message", MessageBoxButtons.OK);
                        
                    }


                    if (rbtn_approve.Checked == true)
                    {



                        //
                        //for (int i = 0; i < dtg_iapproval.Rows.Count; i++)
                        //{
                        //    if (dtg_iapproval.Rows[i].Cells["APPROVAL_CHECK"].Value != DBNull.Value)
                        //    {
                        //        String Query = @"INSERT INTO [T_INVOICE_UNAPPROVAL](UNAPPROVAL,CUSTOMER_ID,INVOICE_NO,INVOICE_DATE,NET_AMOUNT,ACTIVE,CREATED_BY) VALUES ("
                        //       + "'" + (rbtn_unapprove.Checked ? 0 : 1) + "',"
                        //       + "'" + dtg_iapproval.Rows[i].Cells["CUSTOMER_ID"].Value + "',"
                        //       + "'" + dtg_iapproval.Rows[i].Cells["INVOICE_NO"].Value + "', "

                        //       + "'" + dtg_iapproval.Rows[i].Cells["INVOICE_DATE"].Value + "' ,"
                        //       + "'" + dtg_iapproval.Rows[i].Cells["NET_AMOUNT"].Value + "',"
                        //       + "'" + ((bool)dtg_iapproval.Rows[i].Cells["APPROVAL_CHECK"].Value ? 0 : 1) + "',"

                        //       + "'" + "1" + "')";
                        //        builder.Append(Query);
                        //    }
                        //}

                        foreach (DataGridViewRow row in dtg_iapproval.Rows)
                        {
                            int i = row.Cells["APPROVAL_CHECK"].RowIndex;
                            //    if (row.Cells["APPROVAL_CHECK"].Value != DBNull.Value)
                            //    {
                            bool clk = Convert.ToBoolean(row.Cells["APPROVAL_CHECK"].EditedFormattedValue);
                            if (clk != true)
                        {
                            String update = "UPDATE [T_INVOICE] SET APPROVAL_CHECK = '" + ((bool)dtg_iapproval.Rows[i].Cells["APPROVAL_CHECK"].Value ? 1 : 0) + "'  WHERE CUSTOMER_ID ='" + txtcustomer.Tag + "' AND INVOICE_NO ='" + dtg_iapproval.Rows[i].Cells["INVOICE_NO"].Value + "'";
                            builder.Append(update);
                            String update2 = "delete from [T_INVOICE_APPROVAL] WHERE INVOICE_NO ='" + dtg_iapproval.Rows[i].Cells["INVOICE_NO"].Value + "'";
                            builder.Append(update2);
                        }
                        }


                        //    }


                        //else
                        //{
                        //    dtg_iapproval.Rows[i].Cells["APPROVAL_CHECK"].Value = 1;
                        //}





                        MessageBox.Show("UNAPPROVAL SUCESSFULLY", "Message", MessageBoxButtons.OK);



                    }
                   
                    comm.CommandText = builder.ToString();
                    comm.Transaction = transaction;
                    comm.ExecuteNonQuery();
                    transaction.Commit();
                    
                    clear();
                   
                    this.Close();
                    frm_invoice_Approval newMDIChild = new frm_invoice_Approval();
                    // Set the Parent Form of the Child window.
                    newMDIChild.MdiParent = frm_mid.ActiveForm;

                    // Display the new form.
                    newMDIChild.Show();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show(ex.Message);
                    this.Close();
                    frm_invoice_Approval newMDIChild = new frm_invoice_Approval();
                    // Set the Parent Form of the Child window.
                    newMDIChild.MdiParent = frm_mid.ActiveForm;

                    // Display the new form.
                    newMDIChild.Show();
                }

            }
            
        }

        private void btn_unapprove_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void rbtn_approve_CheckedChanged(object sender, EventArgs e)
        {
            btn_approve.Text = "UNAPPROVE";
            //btn_approve.Visible = false;
            //btn_unapprove.Visible = true;



        }

        private void rbtn_unapprove_CheckedChanged(object sender, EventArgs e)
        {
            btn_approve.Text = "APPROVE";
            //btn_unapprove.Visible = false;
            //btn_approve.Visible = true;


        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            if (rbtn_approve.Checked == true)
            {
                
                // String str = "Select * from T_QUOTATION_ITEM";
                // String SQLQuery = "SELECT ROW_ID,ITEM_NAME,SIZE,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL FROM T_INVOICE_ITEM WHERE INVOICE_NO = '" + txtinvoice.Text + "'";
                String sqlquery = "SELECT INVOICE_NO,INVOICE_DATE,MC.CUSTOMER_NAME,NET_AMOUNT,TIA.CUSTOMER_ID,APPROVAL_CHECK  FROM T_INVOICE  AS TIA " +
                    "INNER JOIN M_CUSTOMER AS MC ON TIA.CUSTOMER_ID = MC.CUSTOMER_ID " +
                    "WHERE TIA.CUSTOMER_ID = '" + txtcustomer.Tag + "'  AND TIA.COMPANY_ID=" + COMPANY_ID + " AND TIA.APPROVAL_CHECK = 1 ";
                SqlDataAdapter da = new SqlDataAdapter(sqlquery, ConnString);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "INVOICE");
                //  dtg_iapproval.DataSource = ds.Tables["ACTIVE"];
                dtg_iapproval.DataSource = ds.Tables["INVOICE"].DefaultView;

            }
           
            else if (rbtn_unapprove.Checked == true)
            {
                
                // String str = "Select * from T_QUOTATION_ITEM";
                // String SQLQuery = "SELECT ROW_ID,ITEM_NAME,SIZE,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL FROM T_INVOICE_ITEM WHERE INVOICE_NO = '" + txtinvoice.Text + "'";

                String sqlquery = "SELECT INVOICE_NO,INVOICE_DATE,[M_CUSTOMER].CUSTOMER_NAME,NET_AMOUNT,T_INVOICE.CUSTOMER_ID,T_INVOICE.APPROVAL_CHECK FROM T_INVOICE  " +
                    "INNER JOIN[M_CUSTOMER]  ON T_INVOICE.CUSTOMER_ID = [M_CUSTOMER].CUSTOMER_ID " +
                    "WHERE T_INVOICE.CUSTOMER_ID = '" + txtcustomer.Tag + "' AND T_INVOICE.ACTIVE = 1 AND T_INVOICE.COMPANY_ID=" + COMPANY_ID + " AND ISNULL (APPROVAL_CHECK,0 )= 0 ";
                   
                SqlDataAdapter da = new SqlDataAdapter(sqlquery, ConnString);
                //SqlCommandBuilder CB = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds, "INVOICE");
                //da.Fill(ds, "ACTIVE");
                //dtg_iapproval.DataSource = ds.Tables["ACTIVE"];
                dtg_iapproval.DataSource = ds.Tables["INVOICE"].DefaultView;

            }
            else
            {

                MessageBox.Show("Statement not available", "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
            }
        }
        private void dtg_iapproval_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }

            foreach (DataGridViewColumn column in dtg_iapproval.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void txtcustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmf2 popup = new frmf2();
                popup.MdiParent = frm_mid.ActiveForm;
                string _query = "SELECT CUSTOMER_ID AS [ID], CUSTOMER_NAME, C.CITY FROM M_CUSTOMER CU INNER JOIN M_CITY C ON C.CITY_ID = CU.CITY_ID WHERE CU.ACTIVE = 1";
                popup.ShowF2(_query, "CUSTOMER_NAME", ((TextBox)sender).Text, "CUSTOMER_NAME", sender);
            }
        }
        public void UPDATE_APPROVAL()
        {

            //for (int i = 0;i<dtg_iapproval.Rows.Count; i++)
            //{

            //    //bool checkboxValue = (bool);
            //    //byte bitValue = checkboxValue ? (byte)1 : (byte)0;

               
               
            //    SqlConnection conn = new SqlConnection(ConnString);
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand(update, conn);
            //    cmd.ExecuteNonQuery();
            //    conn.Close();

            //}
        }
        private void txtcustomer_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void txtcustomer_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtcustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int ITEM = txtcustomer.SelectedIndex;
            //txtcustomer.Tag = ITEM;
        }

        private void txtcustomer_KeyDown_2(object sender, KeyEventArgs e)
        {

        }

        private void txtcustomer_KeyUp_1(object sender, KeyEventArgs e)
        {

        }

        private void frm_approval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
                frm_invoice_Approval newMDIChild = new frm_invoice_Approval();
                // Set the Parent Form of the Child window.
                newMDIChild.MdiParent = frm_mid.ActiveForm;

                // Display the new form.
                newMDIChild.Show();
            }
        }

        private void txtcustomer_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnl_top_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
