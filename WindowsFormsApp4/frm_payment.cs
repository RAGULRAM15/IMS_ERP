using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IMS
{
    public partial class frm_payment : Form
    {
        public frm_payment()
        {
            InitializeComponent();
        }
        public string mode { get; set; }
        private void dtg_paymain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //    for (int i = 0; i < dtg_paymain.Rows.Count; i++)
            //    {
            //        bool isclicked = Convert.ToBoolean(dtg_paymain.Columns["active"].ValueType);
            //        if (isclicked == true)
            //        {

            //            int indexRow = e.RowIndex;
            //            DataGridViewRow row = this.dtg_paymain.Rows[indexRow];
            //            object temp = row.Cells["Payment"].Value;
            //            //int row = dgvitemform.SelectedCells[0].RowIndex;
            //            //DataGridViewRow selectedRow = dgvitemform.Rows[row];


            //            // txt_no.Text = row.Cells[0].Value.ToString();
            //            row.Cells["Payment"].Value = row.Cells["balance"].Value.ToString();
            //            row.Cells["balance"].Value = temp;

            //        }
            //    }
        }

        private void dtg_paymain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }

            foreach (DataGridViewColumn column in dtg_paymain.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dtg_credit.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dtg_pay_bank.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void last_no()
        {

            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            {
                string query = "select LAST_NO from M_ENTRY_SETUP  WHERE COMPANY_ID=" + lbl_comp.Tag + " AND ENTRY_ID = " + entry_name + "";
                SqlConnection con = new SqlConnection(ConnString);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    textBox1.Text = dr["LAST_NO"].ToString();
                    if (btn_save.Focused)
                    {
                        break;
                    }
                }
                dr.Close();
                con.Close();
            }
            // int s = Convert.ToInt32(textBox1.Text);
            int N = 1000000;
            for (int s = Convert.ToInt32(textBox1.Text); s <= N; s++)
            {
                s += 1;
                textBox1.Text = s.ToString();
                if (btn_save.Focused)
                {
                    break;
                }

            }






        }
        public void payment_no()
        {
            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            String Query = " SELECT CONCAT([PREFIIX],'-',[LAST_NO]+1) AS[PAYMENT_NO] FROM[M_ENTRY_SETUP] WHERE ENTRY_SETUP_ID = 5";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand comm = new SqlCommand(Query, conn);
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    txt_pay_no.Text = dr["PAYMENT_NO"].ToString();

                }
                dr.Close();
                conn.Close();
            }
        }
        public void clear()
        {
            txtcustomer.Text = "";
            txt_amount.Text = "";
            txt_balance.Text = "";
            txt_paid.Text = "";
            dtg_paymain.DataSource = null;
            dtg_paymain.Rows.Clear();
            //txt_no.Text = "1";
            txt_payment.Text = "";
            //textBox1.Text = "";
            txt_refer.Text = "";
            txt_pay_no.Text = "";


        }
        public string entry_name { get; set; }
        private void btn_save_Click(object sender, EventArgs e)
        {


            if (dtg_paymain.Rows.Count != 0 && txtcustomer.Text != "" && txt_payment.Text != "" && txt_refer.Text != "")
            {
                if (mode == "ADD")
                {

                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        conn.Open();
                        SqlTransaction Transaction = conn.BeginTransaction();





                        String StrQuery;
                        String Query;
                        try
                        {

                            last_no();
                            payment_no();
                            SqlCommand comm = new SqlCommand();
                            comm.Connection = conn;


                            StringBuilder sb = new StringBuilder();

                            String invoice_update = @"UPDATE  [M_ENTRY_SETUP] SET LAST_NO ="
                                + "'" + textBox1.Text + "'    WHERE COMPANY_ID=" + lbl_comp.Tag + " AND ENTRY_ID = " + entry_name + "";


                            Query = @"INSERT INTO [T_PAYMENT_MAIN](PAYMENT_NO,PAYMENT_DATE,PAID,BALANCE,AMOUNT,PAYMENT,
                                         RECEIVED_BY,CUSTOMER_ID,COMPANY_ID,STATUS,ACTIVE) VALUES ("
                                       + "'" + txt_pay_no.Text + "',"
                                       + "'" + txt_datetime.Value.Date + "',"
                                       + "" + txt_paid.Text + ","
                                        + "" + txt_balance.Text + ","
                                       + "" + txt_amount.Text + ","
                                       + "" + txt_payment.Text + ","


                                       + "'" + txt_refer.Text + "',"
                                         + "" + txtcustomer.Tag + ","
                                        + "'" + lbl_comp.Tag + "',"

                                       + "'" + "ACTIVE" + "',"
                                       + "" + "1" + ")";
                            sb.Append(Query);
                            //foreach (DataGridViewRow row in dgvitemform.Rows)
                            for (int i = 0; i < dtg_paymain.Rows.Count; i++)
                            {
                                StrQuery = @"INSERT INTO  T_PAYMENT_ITEM (PAYMENT_NO,INVOICE_NO,INVOICE_DATE,PAID,BALANCE,
                                  NET_AMOUNT,PAYMENT,ACTIVE) VALUES ("
                                  + "'" + txt_pay_no.Text + "',"
                                  + "'" + dtg_paymain.Rows[i].Cells["INVOICE_NO"].Value + "', "
                                  + "'" + dtg_paymain.Rows[i].Cells["INVOICE_DATE"].Value + "' ,"
                                  + "" + dtg_paymain.Rows[i].Cells["PAID"].Value + ","
                                  + "" + dtg_paymain.Rows[i].Cells["BALANCE"].Value + ","
                                  + "" + dtg_paymain.Rows[i].Cells["TOTAL"].Value + ","
                                  + "" + dtg_paymain.Rows[i].Cells["PAYMENT"].Value + ","


                                  + "'" + "1" + "')";
                                sb.Append(StrQuery);


                            }

                           

                               

                            
                            for (int i = 0; i < dtg_pay_bank.Rows.Count; i++)
                            {
                                if (dtg_pay_bank.Rows[i].Cells["amount"].Value != null)
                                {
                                    
                                    StrQuery = @"INSERT INTO T_PAID_ITEM (PAYMENT_NO,PAY_MODE,REF_NO,REF_DATE,BANK,
                                  AMOUNT,RECEIVED_BY,ACTIVE) VALUES ("
                                      + "'" + txt_pay_no.Text + "',"
                                      + "" + dtg_pay_bank.Rows[i].Cells["PAY_MODE"].Value + ", "
                                      + "'" + dtg_pay_bank.Rows[i].Cells["ref_no"].Value + "' ,"
                                      + "'" + dtg_pay_bank.Rows[i].Cells["ref_date"].Value + "',"
                                      + "" + dtg_pay_bank.Rows[i].Cells["BANK"].Value + ","
                                      + "" + dtg_pay_bank.Rows[i].Cells["amount"].Value + ","
                                     + "'" + txt_refer.Text + "',"


                                      + "" + "1" + ")";
                                    sb.Append(StrQuery);

                                }
                            }

                            //comm.Connection = conn;

                            for (int i = 0; i < dtg_credit.Rows.Count; i++)
                            {
                                if (dtg_credit.Rows[i].Cells[7].Value != null)
                                {
                                    String CREDITQuery = @"INSERT INTO  T_PAYMENT_CREDIT_NOTE (PAYMENT_NO,ITEM_ID,SIZE_ID,QUANTITY,RATE,
                                  TOTAL,CGST,SGST,IGST,RECEIVED_BY,ACTIVE) VALUES ("
                                  + "'" + txt_pay_no.Text + "',"
                                  + "'" + dtg_credit.Rows[i].Cells["ITEM_ID"].Value + "', "
                                  + "'" + dtg_credit.Rows[i].Cells["SIZE_ID"].Value + "' ,"
                                  + "" + dtg_credit.Rows[i].Cells["QUANTITY"].Value + ","
                                  + "" + dtg_credit.Rows[i].Cells["RATE"].Value + ","
                                  + "" + dtg_credit.Rows[i].Cells[5].Value + ","
                                  + "" + dtg_credit.Rows[i].Cells["CGST"].Value + ","
                                   + "" + dtg_credit.Rows[i].Cells["SGST"].Value + ","
                                  + "" + dtg_credit.Rows[i].Cells["IGST"].Value + ","
                                  + "'" + txt_refer.Text + "',"
                                  + "'" + "1" + "')";
                                    sb.Append(CREDITQuery);


                                }
                            }
                            sb.Append(invoice_update);

                            //for (int i = 0; i < dgvitemform.Rows.Count; i++)
                            //{
                            //    String SalesQuery = @"UPDATE [T_SALES_ORDER_ITEM] SET
                            //              " +
                            //                "BALANCE_QUANTITY= '" + dgvitemform.Rows[i].Cells["SALES_ORDER_BALANCE_QUANTITY"].Value + "'," +

                            //                   "BALANCE_TOTAL = '" + dgvitemform.Rows[i].Cells["netamount"].Value + "'," +
                            //                    " WHERE SALES_ORDER_NO ='" + txt_salesorder.Text + "'";

                            //    sb.Append(SalesQuery);
                            //}



                            comm.CommandText = sb.ToString();
                            comm.Transaction = Transaction;
                            comm.ExecuteNonQuery();


                            Transaction.Commit();

                            StringBuilder builder = new StringBuilder();
                            builder.Append("SAVED SUCESSFULLY \n PAYMENT_NO - ");
                            builder.Append(txt_pay_no.Text);
                            MessageBox.Show(builder.ToString(), "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
                            conn.Close();

                            clear();
                            this.Close();
                            frm_payment_list frm_payment_list = new frm_payment_list();
                            frm_payment_list.MdiParent = frm_mid.ActiveForm;
                            frm_payment_list.Show();
                        }
                        catch (Exception ex)
                        {
                            Transaction.Rollback();
                            MessageBox.Show(ex.Message);
                            clear();
                            this.Close();
                            frm_payment_list frm_payment_list = new frm_payment_list();
                            frm_payment_list.MdiParent = frm_mid.ActiveForm;
                            frm_payment_list.Show();
                        }
                    }
                }
                else if (mode == "EDIT PAYMENT")
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();
                        try
                        {

                            string StrQuery;


                            SqlCommand comm = new SqlCommand();


                            comm.Connection = conn;
                            StringBuilder sb = new StringBuilder();
                            String Query;
                            //comm.Connection = conn;

                            Query = @"UPDATE [T_PAYMENT_MAIN]  SET
                                 PAYMENT_NO ='" + txt_pay_no.Text + "'," +
                          "PAYMENT_DATE = '" + txt_datetime.Value.Date + "'," +
                           "PAID = '" + txt_paid.Text + "'," +
                           "BALANCE ='" + txt_balance.Text + "'," +
                             "AMOUNT = '" + txt_amount.Text + "'," +
                          "CUSTOMER_ID = '" + txtcustomer.Tag + "'," +

                        "[PAYMENT] = '" + txt_payment.Text + "'," +
                        "RECEIVED_BY = '" + txt_refer.Text + "'," +

                       "COMPANY_ID = '" + lbl_comp.Tag + "'," +
                        "STATUS = '" + "ACTIVE" + "'," +
                    " ACTIVE ='" + "1" + "'" +
                    "WHERE PAYMENT_NO ='" + txt_pay_no.Text + "'";

                            sb.Append(Query);

                            for (int i = 0; i < dtg_paymain.Rows.Count; i++)
                            {
                                StrQuery = @"UPDATE [T_PAYMENT_ITEM] SET
                                          PAYMENT_NO= '" + txt_pay_no.Text + "'," +
                                          "INVOICE_NO = '" + dtg_paymain.Rows[i].Cells["INVOICE_NO"].Value + "', " +
                                          "INVOICE_DATE = '" + dtg_paymain.Rows[i].Cells["INVOICE_DATE"].Value + "' ," +
                                          "PAID='" + dtg_paymain.Rows[i].Cells["PAID"].Value + "'," +
                                           "BALANCE='" + dtg_paymain.Rows[i].Cells["BALANCE"].Value + "'," +
                                           "NET_AMOUNT= '" + dtg_paymain.Rows[i].Cells["TOTAL"].Value + "'," +
                                             "PAYMENT='" + dtg_paymain.Rows[i].Cells["PAYMENT"].Value + "'," +


                                              "" + "ACTIVE =" + "1" + " WHERE PAYMENT_NO ='" + txt_pay_no.Text + "'";

                                sb.Append(StrQuery);

                                //StrQuery = @"INSERT INTO T_PAID_ITEM (PAYMENT_NO,PAY_MODE_ID,REF_NO,REF_DATE,BANK_ID,
                                //  AMOUNT,RECEIVED_BY,ACTIVE) VALUES ("
                                //     + "'" + txt_pay_no.Text + "',"
                                //     + "" + dtg_pay_bank.Rows[i].Cells["pay_mode"].Value + ", "
                                //     + "'" + dtg_pay_bank.Rows[i].Cells["ref_no"].Value + "' ,"
                                //     + "'" + dtg_pay_bank.Rows[i].Cells["ref_date"].Value + "',"
                                //     + "" + dtg_pay_bank.Rows[i].Cells["bank"].Value + ","
                                //     + "" + dtg_pay_bank.Rows[i].Cells["amount"].Value + ","
                                //    + "'" + txt_refer.Text + "',"

                            }
                            
                            for (int i = 0; i < dtg_pay_bank.Rows.Count; i++)
                            {
                                if (dtg_pay_bank.Rows[i].Cells["amount"].Value != null)
                                {
                                    String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
                                    String MAIN_QUERY = " SELECT BANK_ID, BANK FROM M_BANK where Bank = '" + dtg_pay_bank.Rows[i].Cells["BANK"].Value + "'";
                                    using (SqlConnection con = new SqlConnection(ConnString))
                                    {
                                        con.Open();
                                        SqlCommand command = new SqlCommand(MAIN_QUERY, con);

                                        SqlDataReader dr1 = command.ExecuteReader();
                                        SqlDataAdapter dr = new SqlDataAdapter(command);
                                        while (dr1.Read())
                                        {
                                            label6.Text = dr1["BANK_ID"].ToString();
                                        }
                                        dr1.Close();
                                     
                                        String _QUERY = " SELECT PAY_MODE_ID, PAY_MODE FROM M_PAY where PAY_MODE = '" + dtg_pay_bank.Rows[i].Cells["PAY_MODE"].Value + "'";
                                        SqlCommand cmd = new SqlCommand(_QUERY, con);

                                        SqlDataReader dr2 = cmd.ExecuteReader();
                                        SqlDataAdapter dr4 = new SqlDataAdapter(cmd);
                                        while (dr2.Read())
                                        {
                                            label7.Text = dr2["PAY_MODE_ID"].ToString();
                                        }
                                        dr2.Close();
                                        con.Close();
                                    }

                                    if (dtg_pay_bank.Rows[i].Cells["PAYMENT_REF"].Value != DBNull.Value)
                                    {
                                       



                                            String PAY_Query = @"UPDATE [T_PAID_ITEM] SET
                                          PAYMENT_NO= '" + txt_pay_no.Text + "'," +
                                              "PAY_MODE = '" + label7.Text + "', " +
                                              "REF_NO = '" + dtg_pay_bank.Rows[i].Cells["ref_no"].Value + "' ," +
                                              "REF_DATE='" + dtg_pay_bank.Rows[i].Cells["ref_date"].Value + "'," +
                                               "BANK ='" + label6.Text + "'," +
                                               "AMOUNT= '" + dtg_pay_bank.Rows[i].Cells["amount"].Value + "'," +
                                                 "RECEIVED_BY='" + txt_refer.Text + "'," +


                                                   "" + "ACTIVE =" + "1" + " WHERE PAYMENT_NO ='" + txt_pay_no.Text + "'";

                                        sb.Append(PAY_Query);
                                        label7.Text = "";
                                        label6.Text = "";
                                    }
                                    else
                                    {
                                       
                                            if (dtg_pay_bank.Rows[i].Cells["amount"].Value != null)
                                            {

                                               string insertQuery = @"INSERT INTO T_PAID_ITEM (PAYMENT_NO,PAY_MODE,REF_NO,REF_DATE,BANK,
                                  AMOUNT,RECEIVED_BY,ACTIVE) VALUES ("
                                                  + "'" + txt_pay_no.Text + "',"
                                                  + "" + label7.Text + ", "
                                                  + "'" + dtg_pay_bank.Rows[i].Cells["ref_no"].Value + "' ,"
                                                  + "'" + dtg_pay_bank.Rows[i].Cells["ref_date"].Value + "',"
                                                  + "" + label6.Text + ","
                                                  + "" + dtg_pay_bank.Rows[i].Cells["amount"].Value + ","
                                                 + "'" + txt_refer.Text + "',"


                                                  + "" + "1" + ")";
                                                sb.Append(insertQuery);
                                            label7.Text = "";
                                            label6.Text = "";
                                        }
                                        
                                    }
                                }
                            }
                            if (lblcreditcheck.Text == "")
                            {

                                for (int i = 0; i < dtg_credit.Rows.Count; i++)
                                {
                                    if (dtg_credit.Rows[i].Cells[7].Value != null)

                                    {
                                        if (dtg_credit.Rows[i].Cells["PAYMENT_ID"].Value != DBNull.Value)
                                        {
                                            String creditQuery = @"UPDATE [T_PAYMENT_CREDIT_NOTE] SET
                                          PAYMENT_NO= '" + txt_pay_no.Text + "'," +
                                                  "ITEM_ID = '" + dtg_credit.Rows[i].Cells["ITEM_ID"].Value + "', " +
                                                  "SIZE_ID = '" + dtg_credit.Rows[i].Cells["SIZE_ID"].Value + "' ," +
                                                  "QUANTITY='" + dtg_credit.Rows[i].Cells["QUANTITY"].Value + "'," +
                                                   "RATE='" + dtg_credit.Rows[i].Cells["RATE"].Value + "'," +
                                                   "TOTAL= '" + dtg_credit.Rows[i].Cells["NET_AMOUNT"].Value + "'," +
                                                     "CGST='" + dtg_credit.Rows[i].Cells["CGST"].Value + "'," +
                                                   "SGST=  '" + dtg_credit.Rows[i].Cells["SGST"].Value + "'," +
                                        "IGST='" + dtg_credit.Rows[i].Cells["IGST"].Value + "'," +
                                        "RECEIVED_BY='" + txt_refer.Text + "'," +

                                                      "" + "ACTIVE =" + "1" + " WHERE PAYMENT_NO ='" + txt_pay_no.Text + "'" +
                                                      " AND PAYMENT_ID = '" + dtg_credit.Rows[i].Cells["PAYMENT_ID"].Value + "'";

                                            sb.Append(creditQuery);
                                        }
                                        else
                                        {
                                            String updateQuery = @"INSERT INTO  T_PAYMENT_CREDIT_NOTE (PAYMENT_NO,ITEM_ID,SIZE_ID,QUANTITY,RATE,
                                  TOTAL,CGST,SGST,IGST,RECEIVED_BY,ACTIVE) VALUES ("
                                    + "'" + txt_pay_no.Text + "',"
                                    + "'" + dtg_credit.Rows[i].Cells["ITEM_ID"].Value + "', "
                                    + "'" + dtg_credit.Rows[i].Cells["SIZE_ID"].Value + "' ,"
                                    + "" + dtg_credit.Rows[i].Cells["QUANTITY"].Value + ","
                                    + "" + dtg_credit.Rows[i].Cells["RATE"].Value + ","
                                    + "" + dtg_credit.Rows[i].Cells["NET_AMOUNT"].Value + ","
                                    + "" + dtg_credit.Rows[i].Cells["CGST"].Value + ","
                                     + "" + dtg_credit.Rows[i].Cells["SGST"].Value + ","
                                    + "" + dtg_credit.Rows[i].Cells["IGST"].Value + ","
                                    + "'" + txt_refer.Text + "',"
                                    + "'" + "1" + "')";
                                            sb.Append(updateQuery);

                                        }
                                    }
                                }

                               
                            }
                            else
                            {

                                for (int i = 0; i < dtg_credit.Rows.Count; i++)
                                {
                                    if (dtg_credit.Rows[i].Cells[7].Value != null)
                                    {
                                        String INSERTQuery = @"INSERT INTO  T_PAYMENT_CREDIT_NOTE (PAYMENT_NO,ITEM_ID,SIZE_ID,QUANTITY,RATE,
                                  TOTAL,CGST,SGST,IGST,RECEIVED_BY,ACTIVE) VALUES ("
                                      + "'" + txt_pay_no.Text + "',"
                                      + "'" + dtg_credit.Rows[i].Cells["ITEM_ID"].Value + "', "
                                      + "'" + dtg_credit.Rows[i].Cells["SIZE_ID"].Value + "' ,"
                                      + "" + dtg_credit.Rows[i].Cells["QUANTITY"].Value + ","
                                      + "" + dtg_credit.Rows[i].Cells["RATE"].Value + ","
                                      + "" + dtg_credit.Rows[i].Cells[7].Value + ","
                                      + "" + dtg_credit.Rows[i].Cells["CGST"].Value + ","
                                       + "" + dtg_credit.Rows[i].Cells["SGST"].Value + ","
                                      + "" + dtg_credit.Rows[i].Cells["IGST"].Value + ","
                                      + "'" + txt_refer.Text + "',"
                                      + "'" + "1" + "')";
                                        sb.Append(INSERTQuery);


                                    }
                                }
                            }
                            //for (int i = 0; i < dgvitemform.Rows.Count; i++)
                            //{
                            //    String SalesQuery = @"UPDATE [T_SALES_ORDER_ITEM] SET
                            //              " +
                            //                "BALANCE_QUANTITY= '" + dgvitemform.Rows[i].Cells["SALES_ORDER_BALANCE_QUANTITY"].Value + "'," +

                            //                   "BALANCE_TOTAL = '" + dgvitemform.Rows[i].Cells["netamount"].Value + "'," +
                            //                    " WHERE SALES_ORDER_NO ='" + txt_salesorder.Text + "'";

                            //    sb.Append(SalesQuery);
                            //}



                            comm.CommandText = sb.ToString(); ;


                            comm.Transaction = transaction;
                            comm.ExecuteNonQuery();
                            transaction.Commit();

                            StringBuilder builder = new StringBuilder();
                            builder.Append("SAVED SUCESSFULLY \n PAYMENT_NO - ");
                            builder.Append(txt_pay_no.Text);
                            MessageBox.Show(builder.ToString(), "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
                            // conn.Close();

                            clear();
                            this.Close();
                            frm_payment_list frm_payment_list = new frm_payment_list();
                            frm_payment_list.MdiParent = frm_mid.ActiveForm;
                            frm_payment_list.Show();



                            //MessageBox.Show("SAVED SUCESSFULLY", "Message", MessageBoxButtons.OK);
                            // conn.Close();





                            // MessageBox.Show("UPLOADED SUCESSFULLY", "Message", MessageBoxButtons.OK);
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show(ex.Message);
                            clear();
                            this.Close();
                            frm_payment_list frm_payment_list = new frm_payment_list();
                            frm_payment_list.MdiParent = frm_mid.ActiveForm;
                            frm_payment_list.Show();
                        }
                    }


                }

                else
                {
                    if (mode == "DELETE PAYMENT")
                    {
                        using (SqlConnection conn = new SqlConnection(ConnString))
                        {
                            conn.Open();
                            SqlTransaction transaction = conn.BeginTransaction();


                            DialogResult done = (MessageBox.Show("Are you sure want to CANCEL this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                            if (done == DialogResult.Yes)
                            {


                                string StrQuery = "UPDATE [T_PAYMENT_MAIN] SET STATUS = '" + "CANCELED" + "'," +
                                    "  ACTIVE = " + "0" + " WHERE PAYMENT_NO ='" + txt_pay_no.Text + "'";
                                string Query = "UPDATE [T_PAYMENT_ITEM] SET   ACTIVE = " + "0" + " WHERE PAYMENT_NO ='" + txt_pay_no.Text + "'";
                                string PAY_Query = "UPDATE [T_PAID_ITEM] SET   ACTIVE = " + "0" + " WHERE PAYMENT_NO ='" + txt_pay_no.Text + "'";
                                try
                                {

                                    SqlCommand comm = new SqlCommand();


                                    comm.Connection = conn;

                                    //foreach (DataGridViewRow row in dgvitemform.Rows)
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append(StrQuery);
                                    sb.Append(Query);
                                    sb.Append(PAY_Query);

                                    comm.CommandText = sb.ToString();
                                    comm.Transaction = transaction;
                                    comm.ExecuteNonQuery();
                                    transaction.Commit();
                                    StringBuilder builder = new StringBuilder();
                                    builder.Append("CANCELED SUCESSFULLY \n PAYMENT_NO - ");
                                    builder.Append(txt_pay_no.Text);
                                    MessageBox.Show(builder.ToString(), "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
                                    // conn.Close();

                                    clear();
                                    this.Close();
                                    frm_payment_list frm_payment_list = new frm_payment_list();
                                    frm_payment_list.MdiParent = frm_mid.ActiveForm;
                                    frm_payment_list.Show();




                                }

                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    MessageBox.Show(ex.Message);
                                    clear();
                                    this.Close();
                                    frm_payment_list frm_payment_list = new frm_payment_list();
                                    frm_payment_list.MdiParent = frm_mid.ActiveForm;
                                    frm_payment_list.Show();
                                }

                            }
                        }
                    }
                }
            }

            else
            {
                MessageBox.Show("Entry is Wrong \n Please Check Entry ", "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
            }

        }
        public void amount_add()
        {
            Double sum = 0;
            int i;
            Double sum1 = 0;
            Double sum2 = 0;



            for (i = 0; i < dtg_paymain.Rows.Count; i++)
            {
                sum += Double.Parse(dtg_paymain.Rows[i].Cells["total"].Value.ToString());
                sum1 += Double.Parse(dtg_paymain.Rows[i].Cells["paid"].Value.ToString());
                sum2 += Double.Parse(dtg_paymain.Rows[i].Cells["balance"].Value.ToString());


            }

            txt_amount.Text = sum.ToString();
            txt_paid.Text = sum1.ToString();
            txt_balance.Text = sum2.ToString();


            dtg_paymain.Refresh(); ;

        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            clear();
            this.Close();
            frm_payment_list payment_List = new frm_payment_list();
            payment_List.MdiParent = frm_mid.ActiveForm;
            payment_List.Show();
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
        public void edit_form()
        {
            if (mode == "EDIT PAYMENT")
            {
                txt_pay_no.Text = frm_payment_list.value1;
                //txtcustomer.Text = frm_payment_list.value2;
                this.Text = mode;
                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
                // String str = "Select * from T_QUOTATION_ITEM";
                string MAIN_QUERY = "SELECT PAYMENT_DATE,PAID,BALANCE,AMOUNT,PAYMENT,RECEIVED_BY,M_CUSTOMER.CUSTOMER_NAME,T_PAYMENT_MAIN.COMPANY_ID,T_PAYMENT_MAIN.CUSTOMER_ID FROM T_PAYMENT_MAIN " +
                     "INNER JOIN M_CUSTOMER ON M_CUSTOMER.CUSTOMER_ID = T_PAYMENT_MAIN.CUSTOMER_ID " +
                     "WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                String SQLQuery = "SELECT M_PAY.PAY_MODE,REF_NO,REF_DATE,M_BANK.BANK,AMOUNT,T_PAID_ITEM.PAY_MODE AS [PAY_MODE_ID],T_PAID_ITEM.BANK AS [BANK_ID],PAYMENT_ID FROM T_PAID_ITEM " +
                    "INNER JOIN M_PAY ON M_PAY.PAY_MODE_ID = T_PAID_ITEM.PAY_MODE " +
                    "INNER JOIN  M_BANK ON M_BANK.BANK_ID = T_PAID_ITEM.BANK " +
                    "WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                String sqlquery = "SELECT INVOICE_NO, INVOICE_DATE,NET_AMOUNT,PAID,BALANCE,PAYMENT FROM T_PAYMENT_ITEM " +
                    "WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(SQLQuery, ConnString);
                DataSet ds = new DataSet();
                da.Fill(ds, "PAYMENT");
                dt = ds.Tables["PAYMENT"];
                dtg_pay_bank.DataSource = dt;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlquery, ConnString);
                DataSet data = new DataSet();
                sqlDataAdapter.Fill(data, "PAYMENT_MAIN");
                dtg_paymain.DataSource = data.Tables["PAYMENT_MAIN"].DefaultView;
                String query = "  SELECT MI.ITEM_NAME,MS.SIZE_NAME,QUANTITY,RATE,TOTAL,TP.CGST,TP.SGST,TP.IGST,TP.ITEM_ID,TP.SIZE_ID,PAYMENT_ID FROM T_PAYMENT_CREDIT_NOTE AS TP " +
                    "INNER JOIN M_ITEM AS MI ON TP.ITEM_ID = MI.ITEM_ID " +
                    "INNER JOIN M_SIZE AS MS ON TP.SIZE_ID = MS.SIZE_ID" +
                   " WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                SqlDataAdapter dc = new SqlDataAdapter(query, ConnString);
                DataSet dpc = new DataSet();
                dc.Fill(dpc, "PAYMENT_CREDIT");
                dk = dpc.Tables["PAYMENT_CREDIT"];
                dtg_credit.DataSource = dk;
                //try
                //{

                using (SqlConnection conn = new SqlConnection(ConnString))
                {

                    SqlCommand comm = new SqlCommand(MAIN_QUERY, conn);
                    conn.Open();
                    SqlDataReader dr1 = comm.ExecuteReader();
                    SqlDataAdapter dr = new SqlDataAdapter(comm);
                    while (dr1.Read())
                    {
                        txt_paid.Text = dr1["paid"].ToString();
                        txt_balance.Text = dr1["BALANCE"].ToString();
                        lbl_comp.Tag = dr1["COMPANY_ID"].ToString();
                        txtcustomer.Tag = dr1["CUSTOMER_ID"].ToString();
                        txtcustomer.Text = dr1["CUSTOMER_NAME"].ToString();

                        txt_datetime.Value = Convert.ToDateTime(dr1["PAYMENT_DATE"].ToString()); /*(DateTime)dr.GetValue(2);*/
                        txt_amount.Text = dr1["AMOUNT"].ToString();

                        txt_payment.Text = dr1["PAYMENT"].ToString();
                        txt_refer.Text = dr1["RECEIVED_BY"].ToString();


                    }
                    dr1.Close();
                    conn.Close();
                }
                if (this.mode == "EDIT PAYMENT")
                {
                    foreach (DataGridViewRow row in dtg_credit.SelectedRows)
                    {
                        if (row.Cells["ITEM"].Value != null)
                        {
                            string ITEM = row.Cells["ITEM_ID"].Value.ToString();

                            String checkquery = "select cgst,igst,sgst from m_item where ITEM_ID='" + ITEM + "'";
                            SqlConnection conn = new SqlConnection(ConnString);
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(checkquery, conn);
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                cgst = dr["CGST"].ToString();
                                igst = dr["IGST"].ToString();
                                sgst = dr["SGST"].ToString();
                            }
                            dr.Close();
                            conn.Close();
                        }
                    }
                }

                for (int i = 0; i < 1; i++)
                {
                    if (dtg_credit.Rows[i].Cells[7].Value == null)
                    {
                        lblcreditcheck.Text = "1";
                    }
                }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
         }
        DataTable dt = new DataTable();
        DataTable dk = new DataTable();
        public void view_form()
        {
            if (mode == "VIEW PAYMENT")
            {
                txt_pay_no.Text = frm_payment_list.value1;
                //txtcustomer.Text = frm_payment_list.value2;
                this.Text = mode;
                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
               
                // String str = "Select * from T_QUOTATION_ITEM";
                string MAIN_QUERY = "SELECT PAYMENT_DATE,PAID,BALANCE,AMOUNT,PAYMENT,RECEIVED_BY,M_CUSTOMER.CUSTOMER_NAME,T_PAYMENT_MAIN.COMPANY_ID,T_PAYMENT_MAIN.CUSTOMER_ID FROM T_PAYMENT_MAIN " +
                     "INNER JOIN M_CUSTOMER ON M_CUSTOMER.CUSTOMER_ID = T_PAYMENT_MAIN.CUSTOMER_ID " +
                     "WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                String SQLQuery = "SELECT M_PAY.PAY_MODE,REF_NO,REF_DATE,M_BANK.BANK,AMOUNT,T_PAID_ITEM.PAY_MODE AS [PAY_MODE_ID],T_PAID_ITEM.BANK AS [BANK_ID] FROM T_PAID_ITEM " +
                     "INNER JOIN M_PAY ON M_PAY.PAY_MODE_ID = T_PAID_ITEM.PAY_MODE " +
                     "INNER JOIN  M_BANK ON M_BANK.BANK_ID = T_PAID_ITEM.BANK " +
                     "WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                String sqlquery = "SELECT INVOICE_NO, INVOICE_DATE,NET_AMOUNT,PAID,BALANCE,PAYMENT FROM T_PAYMENT_ITEM " +
                    "WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(SQLQuery, ConnString);
                DataSet ds = new DataSet();
                da.Fill(ds, "PAYMENT");
                dtg_pay_bank.DataSource = ds.Tables["PAYMENT"].DefaultView;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlquery, ConnString);
                DataSet data = new DataSet();
                sqlDataAdapter.Fill(data, "PAYMENT_MAIN");

                dtg_paymain.DataSource = data.Tables["PAYMENT_MAIN"].DefaultView;
                                 String query = "  SELECT MI.ITEM_NAME,MS.SIZE_NAME,QUANTITY,RATE,TOTAL,TP.CGST,TP.SGST,TP.IGST,TP.ITEM_ID,TP.SIZE_ID FROM T_PAYMENT_CREDIT_NOTE AS TP " +
                    "INNER JOIN M_ITEM AS MI ON TP.ITEM_ID = MI.ITEM_ID " +
                    "INNER JOIN M_SIZE AS MS ON TP.SIZE_ID = MS.SIZE_ID" +
                   " WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                SqlDataAdapter dc = new SqlDataAdapter(query, ConnString);
                DataSet dpc = new DataSet();
                dc.Fill(dpc, "PAYMENT_CREDIT");
                dtg_credit.DataSource = dpc.Tables["PAYMENT_CREDIT"].DefaultView;
                try
                {

                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {

                        SqlCommand comm = new SqlCommand(MAIN_QUERY, conn);
                        conn.Open();
                        SqlDataReader dr1 = comm.ExecuteReader();
                        SqlDataAdapter dr = new SqlDataAdapter(comm);
                        while (dr1.Read())
                        {
                            lbl_comp.Tag = dr1["COMPANY_ID"].ToString();
                            txtcustomer.Tag = dr1["CUSTOMER_ID"].ToString();
                            txtcustomer.Text = dr1["CUSTOMER_NAME"].ToString();

                            txt_datetime.Value = Convert.ToDateTime(dr1["PAYMENT_DATE"].ToString()); /*(DateTime)dr.GetValue(2);*/
                            txt_amount.Text = dr1["AMOUNT"].ToString();
                            txt_paid.Text = dr1["paid"].ToString();
                            txt_balance.Text = dr1["BALANCE"].ToString();
                            txt_payment.Text = dr1["PAYMENT"].ToString();
                            txt_refer.Text = dr1["RECEIVED_BY"].ToString();


                        }
                        dr1.Close();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txtcustomer.Enabled = false;
                dtg_paymain.ReadOnly = true;
                dtg_paymain.Enabled = false;
                btn_close.Enabled = false;
                txt_pay_no.Enabled = false;
                dtg_pay_bank.ReadOnly = true;
                dtg_pay_bank.Enabled = false;
                clk_select_all.Enabled = false;
                rbtn_credit_note.Enabled = false;
                txt_amount.ReadOnly = true;
                txt_amount.Enabled = false;
                txt_paid.Enabled = false;
                txt_balance.Enabled = false;
                txt_payment.Enabled = false;
                txt_refer.Enabled = false;
                btn_close.Enabled =false;
                btn_save.Enabled = false;
                ///*btnadd*/.Enabled = false;

            }
        }
        public void DELETE_form()
        {

            if (mode == "DELETE PAYMENT")
            {
                txt_pay_no.Text = frm_payment_list.value1;
                //txtcustomer.Text = frm_payment_list.value2;
                this.Text = mode;
                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
                // String str = "Select * from T_QUOTATION_ITEM";
                string MAIN_QUERY = "SELECT PAYMENT_DATE,PAID,BALANCE,AMOUNT,PAYMENT,RECEIVED_BY,M_CUSTOMER.CUSTOMER_NAME,T_PAYMENT_MAIN.COMPANY_ID,T_PAYMENT_MAIN.CUSTOMER_ID FROM T_PAYMENT_MAIN " +
                     "INNER JOIN M_CUSTOMER ON M_CUSTOMER.CUSTOMER_ID = T_PAYMENT_MAIN.CUSTOMER_ID " +
                     "WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                String SQLQuery = "SELECT M_PAY.PAY_MODE,REF_NO,REF_DATE,M_BANK.BANK,AMOUNT,T_PAID_ITEM.PAY_MODE AS [PAY_MODE_ID],T_PAID_ITEM.BANK AS [BANK_ID] FROM T_PAID_ITEM " +
                     "INNER JOIN M_PAY ON M_PAY.PAY_MODE_ID = T_PAID_ITEM.PAY_MODE " +
                     "INNER JOIN  M_BANK ON M_BANK.BANK_ID = T_PAID_ITEM.BANK " +
                     "WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                String sqlquery = "SELECT INVOICE_NO, INVOICE_DATE,NET_AMOUNT,PAID,BALANCE,PAYMENT FROM T_PAYMENT_ITEM " +
                    "WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(SQLQuery, ConnString);
                DataSet ds = new DataSet();
                da.Fill(ds, "PAYMENT");
                dtg_pay_bank.DataSource = ds.Tables["PAYMENT"].DefaultView;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlquery, ConnString);
                DataSet data = new DataSet();
                sqlDataAdapter.Fill(data, "PAYMENT_MAIN");
                dtg_paymain.DataSource = data.Tables["PAYMENT_MAIN"].DefaultView;
                String query = "  SELECT MI.ITEM_NAME,MS.SIZE_NAME,QUANTITY,RATE,TOTAL,TP.CGST,TP.SGST,TP.IGST,TP.ITEM_ID,TP.SIZE_ID FROM T_PAYMENT_CREDIT_NOTE AS TP " +
                    "INNER JOIN M_ITEM AS MI ON TP.ITEM_ID = MI.ITEM_ID " +
                    "INNER JOIN M_SIZE AS MS ON TP.SIZE_ID = MS.SIZE_ID" +
                   " WHERE PAYMENT_NO = '" + txt_pay_no.Text + "'";
                SqlDataAdapter dc = new SqlDataAdapter(query, ConnString);
                DataSet dpc = new DataSet();
                dc.Fill(dpc, "PAYMENT_CREDIT");
                dtg_credit.DataSource = dpc.Tables["PAYMENT_CREDIT"].DefaultView;
                try
                {

                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {

                        SqlCommand comm = new SqlCommand(MAIN_QUERY, conn);
                        conn.Open();
                        SqlDataReader dr1 = comm.ExecuteReader();
                        SqlDataAdapter dr = new SqlDataAdapter(comm);
                        while (dr1.Read())
                        {
                            lbl_comp.Tag = dr1["COMPANY_ID"].ToString();
                            txtcustomer.Tag = dr1["CUSTOMER_ID"].ToString();
                            txtcustomer.Text = dr1["CUSTOMER_NAME"].ToString();

                            txt_datetime.Value = Convert.ToDateTime(dr1["PAYMENT_DATE"].ToString()); /*(DateTime)dr.GetValue(2);*/
                            txt_amount.Text = dr1["AMOUNT"].ToString();
                            txt_paid.Text = dr1["paid"].ToString();
                            txt_balance.Text = dr1["BALANCE"].ToString();
                            txt_payment.Text = dr1["PAYMENT"].ToString();
                            txt_refer.Text = dr1["RECEIVED_BY"].ToString();


                        }
                        dr1.Close();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                txtcustomer.Enabled = false;
                dtg_paymain.ReadOnly = true;
                dtg_paymain.Enabled = false;
                // btn_close.Enabled = false;
                rbtn_credit_note.Enabled = false;
                txt_pay_no.Enabled = false;
                dtg_pay_bank.ReadOnly = true;
                dtg_pay_bank.Enabled = false;
                clk_select_all.Enabled = false;
                txt_amount.ReadOnly = true;
                txt_amount.Enabled = false;
                txt_paid.Enabled = false;
                txt_balance.Enabled = false;
                txt_payment.Enabled = false;
                txt_refer.Enabled = false;
                ///*btnadd*/.Enabled = false;

            }
        }
        //public void print_form()
        //{

        //    if (printPreviewDialog.ShowDialog() != 0)
        //    {

        //        System.Windows.Forms.PrintDialog PrintDialog1 = new PrintDialog();
        //        PrintDialog1.AllowSomePages = true;
        //        PrintDialog1.ShowHelp = true;
        //        PrintDialog1.Document = printDocument;
        //        DialogResult result = PrintDialog1.ShowDialog();
        //        if (result == DialogResult.OK)
        //        {
        //            printDocument.Print();
        //        }
        //        refresh();
        //    }
        //}
        private void frm_payment_Load(object sender, EventArgs e)
        {
            lbl_comp.Tag = frm_payment_list.comp_id;
            entry_name = frm_payment_list.NAME_ID;
            
            //bank_ddown();
            // btn_close.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_close.Width, btn_close.Height, 70, 70));
            //btn_save.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_save.Width, btn_save.Height, 70, 70));
            //this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 70, 70));
        }

        private void txtcustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void txtcustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmf2 popup = new frmf2();
                popup.MdiParent = frm_mid.ActiveForm;
                string _query = "SELECT CUSTOMER_ID AS [ID], CUSTOMER_NAME, CUSTOMER_TITLE FROM M_CUSTOMER WHERE ACTIVE = 1";
                popup.ShowF2(_query, "CUSTOMER_NAME", ((TextBox)sender).Text, "CUSTOMER_NAME", sender);
            }
        }

        private void dtg_paymain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == disabledRowIndex)
            {
                dtg_paymain.ClearSelection();
            }
        }

        private void dtg_paymain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                DataGridViewRow selectedRow = dtg_paymain.Rows[e.RowIndex];
                string s_no = Convert.ToString(selectedRow.Cells[0].Value);
                rate_txt.Text = selectedRow.Cells["paid"].Value.ToString();
                //int over = Convert.ToInt32(selectedRow.Cells["balance"].Value.ToString());
                //if (over != 0 && over > 0)
                //{
                    // if ((dtg_paymain.Rows[e.RowIndex].Cells["select"].ValueType) != null)
                    bool clk = Convert.ToBoolean(selectedRow.Cells["SELECT"].EditedFormattedValue);
                    int value_change = Convert.ToInt32(dtg_paymain.Rows[e.RowIndex].Cells["SELECT"].RowIndex);
                    if (clk == true)
                    {
                        if (selectedRow.Cells["SELECT"].ValueType != null)
                        {
                            while (value_change <= dtg_paymain.Rows.Count)
                            {
                                if (rbtn_credit_note.Checked == true)
                                {
                                    foreach (DataGridViewRow viewRow in dtg_paymain.Rows)
                                    {
                                        //string index = dtg_paymain.CurrentCell["select"].Value.ToString();
                                        int rowIndex = e.RowIndex;
                                        DataGridViewRow select_row = dtg_credit.Rows[rowIndex];
                                        int payindex = dtg_paymain.CurrentCell.RowIndex;
                                        DataGridViewRow pay_row = dtg_paymain.Rows[payindex];
                                        //int value_change = Convert.ToInt32(viewRow.Cells["SELECT"].RowIndex);
                                        //if (viewRow.Cells["SELECT"].Value != null)
                                        //{

                                        //    if (row.Cells["amount"].Value != null)
                                        //    {
                                        //bool clk = Convert.ToBoolean(viewRow.Cells["SELECT"].EditedFormattedValue);
                                        if (select_row.Cells["NET_AMOUNT"].Value != null)
                                        {
                                            if (clk == true)
                                            {
                                                //object Value1 = select_row.Cells["NET_AMOUNT"].Value;
                                                //paid_value = Value1;


                                                //txt_credit.Text = paid_value.ToString();
                                                decimal sum2 = decimal.Parse(txt_credit.Text);
                                                decimal sum7 = decimal.Parse(viewRow.Cells["balance"].Value.ToString());
                                                sum7 -= sum2;
                                                if (sum7 >= 0)
                                                {
                                                    viewRow.Cells["balance"].Value = sum7.ToString();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("PAYMENT CROSSING LIMIT");
                                                }
                                                amount_add();
                                                break;

                                            }
                                            else
                                            {
                                                viewRow.Cells["paid"].Value = 0;
                                            }
                                            //    }
                                            //}

                                        }
                                    }
                                }
                                else if (rate_txt.Text != "0" && mode == "EDIT PAYMENT")
                                {
                                    foreach (DataGridViewRow viewRow in dtg_paymain.Rows)
                                    {
                                        //string index = dtg_paymain.CurrentCell["select"].Value.ToString();
                                        int rowIndex = e.RowIndex + 1;
                                        DataGridViewRow select_row = dtg_pay_bank.Rows[rowIndex];
                                        int payindex = dtg_paymain.CurrentCell.RowIndex;
                                        DataGridViewRow pay_row = dtg_paymain.Rows[payindex];
                                        //int value_change = Convert.ToInt32(viewRow.Cells["SELECT"].RowIndex);
                                        //if (viewRow.Cells["SELECT"].Value != null)
                                        //{

                                        //    if (row.Cells["amount"].Value != null)
                                        //    {
                                        //bool clk = Convert.ToBoolean(viewRow.Cells["SELECT"].EditedFormattedValue);
                                        if (select_row.Cells["amount"].Value != null)
                                        {
                                            if (clk == true)
                                            {
                                                object Value1 = select_row.Cells["amount"].Value;
                                                paid_value = Value1;



                                                decimal total_pay = Convert.ToDecimal(Convert.ToDouble(pay_row.Cells["paid"].Value.ToString()) + Convert.ToDouble(paid_value.ToString()));
                                                viewRow.Cells["paid"].Value = total_pay.ToString();
                                                decimal sum2 = decimal.Parse(viewRow.Cells["paid"].Value.ToString());
                                                decimal sum7 = decimal.Parse(viewRow.Cells["total"].Value.ToString());
                                                sum7 -= sum2;
                                                if (sum7 >= 0)
                                                {
                                                    viewRow.Cells["balance"].Value = sum7.ToString();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("PAYMENT CROSSING LIMIT");
                                                }
                                                amount_add();
                                                break;

                                            }
                                            else
                                            {
                                                viewRow.Cells["paid"].Value = 0;
                                            }
                                            //    }
                                            //}

                                        }
                                    }
                                }
                                else
                                {
                                    foreach (DataGridViewRow viewRow in dtg_paymain.Rows)
                                    {
                                        //string index = dtg_paymain.CurrentCell["select"].Value.ToString();
                                        int rowIndex = e.RowIndex;
                                       
                                        int payindex = dtg_paymain.CurrentCell.RowIndex;
                                        DataGridViewRow pay_row = dtg_paymain.Rows[payindex];
                                    //int value_change = Convert.ToInt32(viewRow.Cells["SELECT"].RowIndex);
                                    //if (viewRow.Cells["SELECT"].Value != null)
                                    //{

                                    //    if (row.Cells["amount"].Value != null)
                                    //    {
                                    //bool clk = Convert.ToBoolean(viewRow.Cells["SELECT"].EditedFormattedValue);
                                    //()
                                        foreach (DataGridViewRow _row in dtg_pay_bank.Rows) {
                                       
                                        if (_row.Cells["amount"].Value != null)
                                        {
                                            DataGridViewRow select_row = dtg_pay_bank.Rows[rowIndex];

                                            if (clk == true)
                                            {
                                                object Value1 = select_row.Cells["amount"].Value;
                                                paid_value = Value1;



                                                pay_row.Cells["paid"].Value = paid_value.ToString();
                                                decimal sum2 = decimal.Parse(viewRow.Cells["paid"].Value.ToString());
                                                decimal sum7 = decimal.Parse(viewRow.Cells["total"].Value.ToString());
                                                sum7 -= sum2;
                                                if (sum7 >= 0)
                                                {
                                                    viewRow.Cells["balance"].Value = sum7.ToString();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("PAYMENT CROSSING LIMIT");
                                                }
                                                amount_add();
                                                break;

                                            }
                                            else
                                            {
                                                viewRow.Cells["paid"].Value = 0;
                                            }
                                            //    }
                                            //}
                                        }
                                        }
                                    }
                                }

                                string sum3 = dtg_paymain.Rows[value_change].Cells["BALANCE"].Value.ToString();
                                dtg_paymain.Rows[value_change].Cells["PAYMENT"].Value = sum3.ToString();

                                break;

                            }
                        }



                        // txt_total.Text = sum4.ToString();

                    }
                    else
                    {
                        if (clk == false)
                        //if ((dtg_debit.Rows[e.RowIndex].Cells["active"].ValueType) == null)
                        {
                            double sum = 0;
                            dtg_paymain.Rows[value_change].Cells["PAYMENT"].Value = sum.ToString();

                            //txt_payment.Text = "";

                            // txt_total.Text = sum4.ToString();
                        }
                    }


                    Double sum4 = 0;


                    for (int i = 0; i < dtg_paymain.Rows.Count; i++)

                    {
                        if (dtg_paymain.Rows[i].Cells["PAYMENT"].Value != null)
                        {
                            sum4 += Double.Parse(dtg_paymain.Rows[i].Cells["PAYMENT"].Value.ToString());
                            txt_payment.Text = sum4.ToString();


                        }

                        else
                        {
                            dtg_paymain.Rows[i].Cells["PAYMENT"].Value = 0;
                        }
                    }
                    rate_txt.Text = "";
                //}
                //else
                //{
                //    MessageBox.Show("PAYMENT CROSSING LIMIT");
                //}
            }
        }

        private void clk_select_all_CheckedChanged(object sender, EventArgs e)
        {
            if (clk_select_all.Checked == true)
            {
                foreach (DataGridViewRow viewRow in dtg_paymain.Rows)
                {
                    DataGridViewCheckBoxCell selectall = (DataGridViewCheckBoxCell)viewRow.Cells["SELECT"];
                    selectall.Value = true;
                    select_all();
                }
            }
            else
            {
                if (clk_select_all.Checked == false)
                {
                    foreach (DataGridViewRow viewRow in dtg_paymain.Rows)
                    {
                        DataGridViewCheckBoxCell selectall = (DataGridViewCheckBoxCell)viewRow.Cells["SELECT"];
                        selectall.Value = false;
                        select_all();
                    }
                }
            }
        }
        public void select_all()
        {
            foreach (DataGridViewRow selectedRow in dtg_paymain.Rows)
            {
                string s_no = Convert.ToString(selectedRow.Cells[0].Value);

                // if ((dtg_paymain.Rows[e.RowIndex].Cells["select"].ValueType) != null)
                bool clk = Convert.ToBoolean(selectedRow.Cells["SELECT"].EditedFormattedValue);
                int value_change = Convert.ToInt32(selectedRow.Cells["SELECT"].RowIndex);
                if (clk == true)
                {
                    if (selectedRow.Cells["SELECT"].ValueType != null)
                    {
                        while (value_change <= dtg_paymain.Rows.Count)
                        {

                            string sum3 = dtg_paymain.Rows[value_change].Cells["BALANCE"].Value.ToString();
                            dtg_paymain.Rows[value_change].Cells["PAYMENT"].Value = sum3.ToString();

                            break;

                        }
                    }



                    // txt_total.Text = sum4.ToString();

                }
                else
                {
                    if (clk == false)
                    //if ((dtg_debit.Rows[e.RowIndex].Cells["active"].ValueType) == null)
                    {
                        double sum = 0;
                        dtg_paymain.Rows[value_change].Cells["PAYMENT"].Value = sum.ToString();

                        //txt_payment.Text = "";

                        // txt_total.Text = sum4.ToString();
                    }
                }


                Double sum4 = 0;


                for (int i = 0; i < dtg_paymain.Rows.Count; i++)

                {
                    if (dtg_paymain.Rows[i].Cells["PAYMENT"].Value != null)
                    {
                        sum4 += Double.Parse(dtg_paymain.Rows[i].Cells["PAYMENT"].Value.ToString());
                        txt_payment.Text = sum4.ToString();


                    }

                    else
                    {
                        dtg_paymain.Rows[i].Cells["PAYMENT"].Value = 0;
                    }
                }
            }
        }
        public void pay_method()
        {
            
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT PAY_MODE_ID, PAY_MODE FROM M_PAY", ConnString);
                dataAdapter.Fill(dataTable);
                DataRow row = dataTable.NewRow();
                row[1] = "";
                dataTable.Rows.InsertAt(row, 0);
                //dtg_pay_bank.DataSource = dataTable;
                DataGridViewComboBoxColumn comboBoxColumn = dtg_pay_bank.Columns["pay_mode"] as DataGridViewComboBoxColumn;
                comboBoxColumn.DataSource = dataTable;
                comboBoxColumn.DisplayMember = "PAY_MODE";
                comboBoxColumn.ValueMember = "PAY_MODE_ID";

                //foreach(DataRow list in dataTable.Rows)
                //{
                //    int l = dtg_pay_bank.Rows.Add();
                //    dtg_pay_bank.Rows[l].Cells["bank"].Value = list[0].ToString(); 
                //}
            
        }
        public void edit_pay_method()
        {
            if (mode == "EDIT PAYMENT")
            {


                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT PAY_MODE_ID, PAY_MODE FROM M_PAY", ConnString);
                dataAdapter.Fill(dataTable);
                DataRow row = dataTable.NewRow();
                row[1] = "";
                dataTable.Rows.InsertAt(row, 0);
                //dtg_pay_bank.DataSource = dataTable;
                DataGridViewComboBoxColumn comboBoxColumn = dtg_pay_bank.Columns["pay_mode"] as DataGridViewComboBoxColumn;
                comboBoxColumn.DataSource = dataTable;
                comboBoxColumn.DisplayMember = "PAY_MODE";
                comboBoxColumn.ValueMember = "PAY_MODE_ID";

                //foreach(DataRow list in dataTable.Rows)
                //{
                //    int l = dtg_pay_bank.Rows.Add();
                //    dtg_pay_bank.Rows[l].Cells["bank"].Value = list[0].ToString(); 

            }
        }
        public void bank_ddown()
        {
           
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT BANK_ID, BANK FROM M_BANK", ConnString);
                dataAdapter.Fill(dataTable);
                //DataRow row = dataTable.NewRow();
                //row[1] = "";
                //dataTable.Rows.InsertAt(row, 0);
                //dtg_pay_bank.DataSource = dataTable;
                DataGridViewComboBoxColumn comboBoxColumn = dtg_pay_bank.Columns["BANK"] as DataGridViewComboBoxColumn;

                comboBoxColumn.DataSource = dataTable;

                comboBoxColumn.DisplayMember = "BANK"; // Set the name of the column to display in the dropdown list
                comboBoxColumn.ValueMember = "BANK_ID";
                //foreach(DataRow list in dataTable.Rows)
                //{
                //    int l = dtg_pay_bank.Rows.Add();
                //    dtg_pay_bank.Rows[l].Cells["bank"].Value = list[0].ToString(); 
                //}
            
        }
        public void bank_editdown()
        {
            if (mode == "EDIT PAYMENT")
            {
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT BANK_ID, BANK FROM M_BANK", ConnString);
                dataAdapter.Fill(dataTable);
                //DataRow row = dataTable.NewRow();
                //row[1] = "";
                //dataTable.Rows.InsertAt(row, 0);
                //dtg_pay_bank.DataSource = dataTable;
                DataGridViewComboBoxColumn comboBoxColumn = dtg_pay_bank.Columns["BANK"] as DataGridViewComboBoxColumn;

                comboBoxColumn.DataSource = dataTable;

                comboBoxColumn.DisplayMember = "BANK"; // Set the name of the column to display in the dropdown list
                comboBoxColumn.ValueMember = "BANK";
            }

        }
        private void dtg_pay_bank_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        public object paid_value { get; set; }
        public void amount_pay()
        {

        }

        private void dtg_pay_bank_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          
            foreach (DataGridViewRow viewRow in dtg_paymain.Rows)
            {
                DataGridViewCheckBoxCell selectall = (DataGridViewCheckBoxCell)viewRow.Cells["SELECT"];
                selectall.Value = false;
                select_all();
            }
            rbtn_credit_note.Checked = false;
          
            if (mode == "EDIT INVOICE")
            {
                foreach (DataGridViewRow viewRow in dtg_pay_bank.Rows)
                {

                    DataRow row = dt.NewRow();
                    row["pay_mode"] = viewRow.Cells["pay_mode"].Value;
                    row["ref_no"] = viewRow.Cells["ref_no"].Value;
                    row["ref_date"] = viewRow.Cells["ref_date"].Value;
                    row["bank"] = viewRow.Cells["bank"].Value;
                    row["amount"] = viewRow.Cells["amount"].Value;
                    dt.AcceptChanges();

                }
            }
           
            //if (mode == "EDIT PAYMENT")
            //{
            //    for (int i = 0; i < dtg_pay_bank.Rows.Count; i++)
            //    {
            //        if (dtg_pay_bank.Rows[i].Cells["amount"].Value == null)
            //        {


            //            if (dtg_pay_bank.Rows[i].Cells["pay_mode"] != null)
            //            {




            //                    String qurey = "SELECT PAY_MODE_ID,pay_mode FROM M_PAY where pay_mode = @paymode";
            //                    SqlConnection conn = new SqlConnection(ConnString);
            //                    conn.Open();
            //                    SqlCommand cmd = new SqlCommand();
            //                cmd.Connection = conn;
            //                cmd.CommandText = qurey;

            //                cmd.Parameters.Add(parameter);
            //                SqlDataReader dr = cmd.ExecuteReader();
            //                    while (dr.Read())
            //                    {

            //                        dtg_pay_bank.Rows[i].Cells["pay_mode_id"].Value = dr["PAY_MODE_ID"].ToString();

            //                    }
            //                    dr.Close();
            //                    conn.Close();


            //            }

            //            if (dtg_pay_bank.Rows[i].Cells["BANK"].Value !=null)
            //            {



            //                String qurey = "SELECT BANK_ID, BANK FROM M_BANK where BANK =" + dtg_pay_bank.Rows[i].Cells["BANK"].Value + "";
            //                SqlConnection conn1 = new SqlConnection(ConnString);
            //                conn1.Open();
            //                SqlCommand cmd1 = new SqlCommand(qurey, conn1);
            //                SqlDataReader dr1 = cmd1.ExecuteReader();
            //                while (dr1.Read())
            //                {

            //                    dtg_pay_bank.Rows[i].Cells["BANK_ID"].Value = dr1["BANK_ID"].ToString();

            //                }
            //                dr1.Close();
            //                conn1.Close();

            //            }
            //        }
            //    }
            //}


        }

            private void dtg_paymain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtg_paymain_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtcustomer_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        private void txtcustomer_KeyUp_1(object sender, KeyEventArgs e)
        {

        }

        private void clk_select_all_CheckedChanged_1(object sender, EventArgs e)
        {

        }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
        private void dtg_pay_bank_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            
        }
        public DateTimePicker dateTimePicker;
        private void dtg_pay_bank_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (dtg_pay_bank.CurrentCell.ColumnIndex == 2)
            //{
            //    ComboBox combobox = e.Control as ComboBox;
            //    if(combobox != null)
            //    {
            //        combobox.DropDownStyle = ComboBoxStyle.DropDownList ;
            //         dateTimePicker = new DateTimePicker();
            //        dateTimePicker.Format = DateTimePickerFormat.Custom;
            //        dateTimePicker.CustomFormat = "dd/MM/yyyy";
            //        combobox.Controls.Add(dateTimePicker);
            //    }

            //}
        }
        private void ComboBox_DropDown(object sender, EventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            if (combobox != null)
            {
                Rectangle rectangle = dtg_pay_bank.GetCellDisplayRectangle(dtg_pay_bank.CurrentCell.ColumnIndex, dtg_pay_bank.CurrentCell.RowIndex, false);
                dateTimePicker.Location = new Point(rectangle.X, rectangle.Y + rectangle.Height);
                dateTimePicker.Width = rectangle.Width;
                dateTimePicker.Visible = true;
            }


        }
        private void dateTimePicker_CloseUP(object sender, EventArgs e)
        {
            dtg_pay_bank.CurrentCell.Value = dateTimePicker.Text;
            dateTimePicker.Visible = false;
        }
        public void combobox()
        {
            
        }
        private void dtg_pay_bank_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dateTimePicker.Visible = false;
        }
        private void dtg_pay_bank_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

           // dateTimePicker.Visible = false;
            //dtg_pay_bank.EndEdit();


        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void dtg_pay_bank_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
           
        }
        private void Dtp_CloseUp(object sender, EventArgs e)
        {
           
        }
        private void dtg_pay_bank_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (mode == "ADD" )
            {
                if (e.ColumnIndex == bank.Index && e.RowIndex >= 0)
                {
                    bank_ddown();
                }
                if (e.ColumnIndex == pay_mode.Index && e.RowIndex >= 0)
                {
                    pay_method();
                }
            }
        }

        private void dtg_pay_bank_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        public static string item_tag { get; set; }
        public static string item_text { get; set; }
        public static string size_tag { get; set; }
        public static string size_text { get; set; }
        private void frm_payment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                //if (mode == "ADD" || mode == "EDIT INVOICE")
                //{
                if (rbtn_credit_note.Checked == true)
                {
                    foreach (DataGridViewRow viewRow in dtg_paymain.SelectedRows)
                    {
                        //bool clk = Convert.ToBoolean(viewRow.Cells["SELECT"].EditedFormattedValue);
                        //if (clk == true)
                        //{
                        //frmf3 popup = new frmf3();
                        //popup.ShowF3("RETURN OF GOODS", valuetoadd, sender);
                        ////popup.Show();
                        frmf5 popup = new frmf5();
                        popup.MdiParent = frm_mid.ActiveForm;
                        popup.item_text = "PAYMENT";
                        string _query = "SELECT T_INVOICE_ITEM.ITEM_ID AS [ID],T_INVOICE_ITEM.SIZE_ID AS [ID],  ITEM_NAME,SIZE_NAME FROM T_INVOICE_ITEM " +
                            "INNER JOIN M_ITEM ON T_INVOICE_ITEM.ITEM_ID = M_ITEM.ITEM_ID " +
                            "INNER JOIN M_SIZE ON T_INVOICE_ITEM.SIZE_ID = M_SIZE.SIZE_ID " +
                            "WHERE INVOICE_NO = '" + viewRow.Cells["invoice_no"].Value + "'";
                        popup.ShowF5(_query, "ITEM_NAME", "SIZE_NAME", (item_text), "ITEM_NAME", sender);
                        //}
                    }
                    //  ITEM_LOAD();
                }
            }


            if (e.KeyCode == Keys.X && e.Alt)
            {
                clear();
                this.Close();
                frm_payment_list payment_List = new frm_payment_list();
                payment_List.MdiParent = frm_mid.ActiveForm;
                payment_List.Show();
            }
        }

        private void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            if (txtcustomer.Tag != null)
            {
                if (mode == "ADD")
                {
                    String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
                    //String str = "Select * from T_QUOTATION_ITEM";

                    String sqlquery = "SELECT INVOICE_NO,INVOICE_DATE,NET_AMOUNT  FROM T_INVOICE_APPROVAL WHERE CUSTOMER_ID = '" + txtcustomer.Tag + "' AND APPROVAL_CHECK =" + "1" + " AND COMPANY_ID =" + lbl_comp.Tag + "";
                    SqlDataAdapter da = new SqlDataAdapter(sqlquery, ConnString);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "INVOICE");
                    dtg_paymain.DataSource = ds.Tables["INVOICE"].DefaultView;

                    for (int i = 0; i < dtg_paymain.Rows.Count; i++)
                    {
                        paid_value = "0";
                        dtg_paymain.Rows[i].Cells["paid"].Value = paid_value;
                        decimal sum2 = decimal.Parse(dtg_paymain.Rows[i].Cells["paid"].Value.ToString());
                        decimal sum3 = decimal.Parse(dtg_paymain.Rows[i].Cells["total"].Value.ToString());
                        sum3 -= sum2;
                        dtg_paymain.Rows[i].Cells["balance"].Value = sum3.ToString();
                    }
                    amount_add();
                }
            }
        }
        public void ITEM_LOAD()
        {
            //foreach (DataGridViewRow dataGrid in dtg_credit.SelectedRows)
            //{
            //    dataGrid.Cells["ITEM"].Value =    item_text;
            //    dataGrid.Cells["item_id"].Value = item_tag;
            //    dataGrid.Cells["SIZE"].Value =    size_text;
            //    dataGrid.Cells["SIZE_ID"].Value = size_tag;

            //}
            string value1 =  item_text;
            string value3 =  item_tag;
            string value2 = size_text;
            string value4 = size_tag;
            if (mode == "ADD")
            {
                if (IsDuplicateValueadd(value1, value2, dtg_credit))
                {
                    MessageBox.Show("Duplicate value! Insertion cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dtg_credit);


                    newRow.Cells[0].Value = value1;
                    newRow.Cells[1].Value = value2;
                    newRow.Cells[8].Value = value3;
                    newRow.Cells[9].Value = value4;


                    dtg_credit.Rows.Add(newRow);
                }
            }
            if (mode == "EDIT PAYMENT")
            {
                if (dtg_credit.Rows.Count == 0)
                {
                    if (IsDuplicateValueadd(value1, value2, dtg_credit))
                    {
                        MessageBox.Show("Duplicate value! Insertion cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells(dtg_credit);


                        newRow.Cells[0].Value = value1;
                        newRow.Cells[1].Value = value2;
                        newRow.Cells[8].Value = value3;
                        newRow.Cells[9].Value = value4;


                        dtg_credit.Rows.Add(newRow);
                    }
                }
                else
                {
                    if (IsDuplicateValueedit(value1, value2, dk))
                    {
                        MessageBox.Show("Duplicate value! Insertion cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DataRow row = dk.NewRow();



                        row["ITEM_NAME"] = value1;
                        row["SIZE_NAME"] = value2;
                        row["ITEM_ID"] = value3;
                        row["SIZE_ID"] = value4;
                        dk.Rows.Add(row);
                        dtg_credit.DataSource = dk;

                    }
                }
            }
        }


        private bool IsDuplicateValueadd(string value1, string value2, DataGridView dgv)
        {

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[0].Value?.ToString() == value1 &&
                    row.Cells[1].Value?.ToString() == value2)
                {
                    //if (value1 == "" && value2 == "")
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    return true;
                    //}


                }
            }

            return false;

        }
        private bool IsDuplicateValueedit(string value1, string value2, DataTable dgv)
        {

            foreach (DataRow row in dgv.Rows)
            {
                if (row["ITEM_NAME"].ToString() == value1 &&
            row["SIZE_NAME"].ToString() == value2)
                {
                    //if (value1 == "" && value2 == "")
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    return true;
                    //}


                }
            }

            return false;

        }





        public void GST_CALCULATION()
        {
            if (this.mode == "EDIT PAYMENT" || this.mode == "ADD")
            {
                foreach (DataGridViewRow row in dtg_credit.SelectedRows)
                {
                    string ITEM = row.Cells["ITEM_ID"].Value.ToString();

                    String query = "select cgst,igst,sgst from m_item where ITEM_ID='" + ITEM + "'";
                    SqlConnection conn = new SqlConnection(ConnString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cgst = dr["CGST"].ToString();
                        igst = dr["IGST"].ToString();
                        sgst = dr["SGST"].ToString();
                    }
                    dr.Close();
                    conn.Close();
                }
            }
        }
        public string sgst { get; set; }
        public string igst { get; set; }
        public string cgst { get; set; }
        private void dtg_credit_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (this.mode == "EDIT PAYMENT" || this.mode == "ADD")
            {
                if (rbtn_credit_note.Checked == true)
                {

                    foreach (DataGridViewRow row in dtg_credit.SelectedRows)
                    { if (row.Cells["ITEM_ID"].Value != null)
                        { 

                            string ITEM = row.Cells["ITEM_ID"].Value.ToString();

                            String query = "select cgst,igst,sgst from m_item where ITEM_ID='" + ITEM + "'";
                            SqlConnection conn = new SqlConnection(ConnString);
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(query, conn);
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                cgst = dr["CGST"].ToString();
                                igst = dr["IGST"].ToString();
                                sgst = dr["SGST"].ToString();
                            }
                            dr.Close();
                            conn.Close();
                        }
                    }
                }
            }
            //    if (this.mode == "EDIT PAYMENT")

            //{
            //                foreach (DataGridViewRow row in dtg_credit.SelectedRows)
            //    {
            //        if (mode == "EDIT PAYMENT")
            //        {
            //            row.Cells["PAYMENT_ID"].Value = "0";
            //            txtpay_id.Text = "0";
            //        }
            //        if (txtpay_id.Text == "0")
            //        {
            //            if (row.Cells["PAYMENT_ID"].Value == null)
            //            {


            //                if (row.Cells["ITEM"].Value != null)
            //                {
            //                    //row.Cells["paid"].Value = 0;



            //                    double Sgst = Convert.ToDouble(sgst);
            //                    double Cgst = Convert.ToDouble(cgst);
            //                    double Igst = Convert.ToDouble(igst);
            //                    if (row.Cells["RATE"].Value != null)
            //                    {
            //                        decimal sum2 = decimal.Parse(row.Cells["QUANTITY"].Value.ToString());
            //                        decimal sum3 = decimal.Parse(row.Cells["RATE"].Value.ToString());
            //                        decimal sum4 = sum3 * sum2;
            //                        row.Cells["SGST"].Value = Convert.ToString((Sgst / 100.00) * (Convert.ToDouble(sum4)));
            //                        row.Cells["CGST"].Value = Convert.ToString((Cgst / 100.00) * (Convert.ToDouble(sum4)));


            //                        row.Cells["IGST"].Value = Convert.ToString((Igst / 100.00) * (Convert.ToDouble(sum4)));

            //                        Decimal GST = Convert.ToDecimal(Convert.ToDouble(row.Cells["SGST"].Value) + Convert.ToDouble(row.Cells["CGST"].Value) + Convert.ToDouble(row.Cells["IGST"].Value));
            //                        Double TOTAL = Convert.ToDouble(GST + sum4);
            //                        row.Cells["NET_AMOUNT"].Value = TOTAL.ToString();
            //                        //sum_total();
            //                        double sum8 = 0;
            //                        foreach (DataGridViewRow dataGrid in dtg_credit.Rows)
            //                        {

            //                            if (dataGrid.Cells["RATE"].Value != null && dataGrid.Cells["QUANTITY"].Value != null && dataGrid.Cells["NET_AMOUNT"].Value != null && dataGrid.Cells["NET_AMOUNT"].Value.ToString() != string.Empty)
            //                            {

            //                                sum8 += Convert.ToDouble(dataGrid.Cells["NET_AMOUNT"].Value);
            //                                txt_credit.Text = sum8.ToString();
            //                            }
            //                        }


            //                        //}

            //                    }

            //                }
            //            }
                    
                        
            //       }
            //    }
                if (this.mode == "ADD" || mode == "EDIT PAYMENT")
                {
                if (rbtn_credit_note.Checked == true)
                {

                    for (int i = 0; i < dtg_credit.Rows.Count; i++)
                    {
                        if (dtg_credit.Rows[i].Cells["ITEM"].Value != null)
                        {
                            //row.Cells["paid"].Value = 0;
                          
                                rate_txt.Text= dtg_credit.Rows[i].Cells["RATE"].Value .ToString();

                                double Sgst = Convert.ToDouble(sgst);
                            double Cgst = Convert.ToDouble(cgst);
                            double Igst = Convert.ToDouble(igst);
                                if (rate_txt.Text != "")
                                {
                                    decimal sum2 = decimal.Parse(dtg_credit.Rows[i].Cells["QUANTITY"].Value.ToString());
                                    decimal sum3 = decimal.Parse(dtg_credit.Rows[i].Cells["RATE"].Value.ToString());
                                    decimal sum4 = sum3 * sum2;
                                    dtg_credit.Rows[i].Cells["SGST"].Value = Convert.ToString((Sgst / 100.00) * (Convert.ToDouble(sum4)));
                                    dtg_credit.Rows[i].Cells["CGST"].Value = Convert.ToString((Cgst / 100.00) * (Convert.ToDouble(sum4)));


                                    dtg_credit.Rows[i].Cells["IGST"].Value = Convert.ToString((Igst / 100.00) * (Convert.ToDouble(sum4)));

                                    Decimal GST = Convert.ToDecimal(Convert.ToDouble(dtg_credit.Rows[i].Cells["SGST"].Value) + Convert.ToDouble(dtg_credit.Rows[i].Cells["CGST"].Value) + Convert.ToDouble(dtg_credit.Rows[i].Cells["IGST"].Value));
                                    Double TOTAL = Convert.ToDouble(GST + sum4);
                                    dtg_credit.Rows[i].Cells["NET_AMOUNT"].Value = TOTAL.ToString();
                                    //sum_total();
                                    double sum8 = 0;
                                    foreach (DataGridViewRow dataGrid in dtg_credit.Rows)
                                    {

                                        if (dataGrid.Cells["RATE"].Value != null && dataGrid.Cells["QUANTITY"].Value != null && dataGrid.Cells["NET_AMOUNT"].Value != null && dataGrid.Cells["NET_AMOUNT"].Value.ToString() != string.Empty)
                                        {

                                            sum8 += Convert.ToDouble(dataGrid.Cells["NET_AMOUNT"].Value);
                                            txt_credit.Text = sum8.ToString();
                                        }
                                    }


                                    //}
                                }
                            

                        }
                    }



                }
                }

                
            //}


        }
        public void sum_total()
        {
            Double sum = 0;
            //int i;
            Double sum1 = 0;
            Double sum2 = 0;

            foreach (DataGridViewRow viewRow in dtg_credit.Rows)
            {
                if (viewRow.Cells["total"].Value != null && viewRow.Cells["NET_AMOUNT"].Value.ToString() != string.Empty)
                {
                    //for (i = 0; i < dtg_debit.Rows.Count; i++)
                    //{
                    sum += Double.Parse(viewRow.Cells["total"].Value.ToString());
                    sum1 += Double.Parse(viewRow.Cells["paid"].Value.ToString());
                    sum2 += Double.Parse(viewRow.Cells["balance"].Value.ToString());


                    //}

                    txt_amount.Text = sum.ToString();
                    txt_paid.Text = sum1.ToString();
                    txt_balance.Text = sum2.ToString();

                }
                else
                {

                }
            }

        }

        private void dtg_credit_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;
            if (null != gridView)
            {
                foreach (DataGridViewRow r in gridView.Rows)
                {
                    gridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                }
            }
        }

        private void dtg_credit_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (mode == "EDIT INVOICE")
            {
                foreach (DataGridViewRow viewRow in dtg_pay_bank.Rows)
                {

                    DataRow row = dk.NewRow();
                    row["ITEM_NAME"] = viewRow.Cells["ITEM"].Value;
                    row["SIZE_NAME"] = viewRow.Cells["SIZE"].Value;
                    row["QUANTITY"] = viewRow.Cells["QUANTITY"].Value;
                    row["RATE"] = viewRow.Cells["RATE"].Value;
                    row["CGST"] = viewRow.Cells["CGST"].Value;
                    row["SGST"] = viewRow.Cells["SGST"].Value;
                    row["IGST"] = viewRow.Cells["IGST"].Value;
                    row["TOTAL"] = viewRow.Cells[5].Value;
                    dk.AcceptChanges();

                }
            }

        }

        private void rbtn_credit_note_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_credit_note.Checked == true)
            {
                if (clk_select_all.Checked == false)
                {
                    foreach (DataGridViewRow viewRow in dtg_paymain.Rows)
                    {
                        DataGridViewCheckBoxCell selectall = (DataGridViewCheckBoxCell)viewRow.Cells["SELECT"];
                        selectall.Value = false;
                        select_all();
                    }
                }
            }
        }

        private void dtg_pay_bank_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (mode == "EDIT PAYMENT")
            {
                if (e.ColumnIndex == bank.Index && e.RowIndex >= 0)
                {
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT BANK_ID, BANK FROM M_BANK", ConnString);
                    dataAdapter.Fill(dataTable);
                    //DataRow row = dataTable.NewRow();
                    //row[1] = "";
                    //dataTable.Rows.InsertAt(row, 0);
                    //dtg_pay_bank.DataSource = dataTable;
                    DataGridViewComboBoxColumn comboBoxColumn = dtg_pay_bank.Columns["BANK"] as DataGridViewComboBoxColumn;


                    comboBoxColumn.DataSource = dataTable;
                    comboBoxColumn.DisplayMember = "BANK";
                    comboBoxColumn.ValueMember = "BANK";



                }
                if (e.ColumnIndex == pay_mode.Index && e.RowIndex >= 0)
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT PAY_MODE_ID, PAY_MODE FROM M_PAY", ConnString);
                    da.Fill(dt);
                    //DataRow row = dataTable.NewRow();
                    //row[1] = "";
                    //dataTable.Rows.InsertAt(row, 0);
                    //dtg_pay_bank.DataSource = dataTable;
                    DataGridViewComboBoxColumn cm = dtg_pay_bank.Columns["pay_mode"] as DataGridViewComboBoxColumn;
                    cm.DataSource = dt;
                    cm.DisplayMember = "PAY_MODE";
                    cm.ValueMember = "PAY_MODE";
                   





                }


            }
        }

        private void dtg_credit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void dtg_pay_bank_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
            if (mode == "VIEW PAYMENT" || mode == "DELETE PAYMENT")
            {
               
                    bank_ddown();
                
               
                    pay_method();
                
            }
        }

        private void dtg_pay_bank_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
        }

        private void dtg_pay_bank_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dtg_paymain_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
          
        }
        private int disabledRowIndex = 2;
        private void dtg_paymain_SelectionChanged(object sender, EventArgs e)
        {
            //if (dtg_paymain.SelectedCells.Count > 0 && dtg_paymain.SelectedCells[0].RowIndex == disabledRowIndex)
            //{
            //    dtg_paymain.ClearSelection();
            //}
        }
        private int editableColumnIndex = 5;
        private void dtg_paymain_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (e.ColumnIndex != editableColumnIndex)
            //{
            //    e.Cancel = true;
            //}
        }
    }
}
