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
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Globalization;

namespace IMS
{
    public partial class frmQuotation : Form
    {
        // private int borderradius = 40;
        private int bordersize = 0;
        private Color bordercolor = Color.White;
        //private int borderradius1 = 30;
        //private int bordersize1 = 0;
        private Color bordercolor1 = Color.White;
        public string mode { get; set; }
        
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
        public frmQuotation()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(bordersize);
            //timer1.Interval = 1000;
            //timer1.Start();
        }


        int indexRow;
        //double multi;


        double deletedRowValue;
        double deletedRowValue1;
        // private object Session;

        void selecttxt(TextBox txt)
        {
            txt.BackColor = Color.FromArgb(139, 199, 255);
        }
        void leavetxt(TextBox txt)
        {
            txt.BackColor = Color.White;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (pnlclose.Width == 266)
            {
                pnlclose.Visible = true;
                for (int i = 0; i < 10; i++)
                {
                    pnlclose.Width = pnlclose.Width - 30;

                }

            }
            else
            {
                pnlclose.Visible = false;
                for (int i = 0; i < 10; i++)
                {
                    pnlclose.Width = pnlclose.Width + 30;

                }

            }
            Timer.Stop();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            Timer.Start();
            pnlright.Visible = true;
            pnlclose.Visible = true;
            btn_update.Visible = false;
            btnok.Visible = true;
            btn_save.Visible = false;
            btn_cancel.Visible = false;

            //row_add();

            //pnlTop.Enabled = true;


        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            pnlright.Visible = false;
            pnlclose.Visible = false;
            btn_update.Visible = false;
            btn_save.Visible = true;
            btn_cancel.Visible = true;
            txt_clear();


        }
        public void datasource()
        {
            String qry = "SELECT  QI.ROW_ID,MI.ITEM_NAME,MS.SIZE_NAME,STYLE_NAME,QI.QUANTITY,QI.RATE,QI.DISCOUNT,TOTAL,QI.ITEM_ID,QI.SIZE_ID,QI.IS_ADD,QI.QUOTATION_ROW_ID,QI.IS_UPDATE FROM T_QUOTATION_ITEM AS QI " +
                "INNER JOIN M_ITEM AS MI ON QI.ITEM_ID = MI.ITEM_ID INNER JOIN M_SIZE AS MS ON QI.SIZE_ID = MS.SIZE_ID WHERE QI.QUOTATION_NO = '" + txtquotation.Text + "'";
            if (mode == "EDIT QUOTATION")
            { 

                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    SqlCommand comm = new SqlCommand(qry, conn);

                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    SqlCommandBuilder scb = new SqlCommandBuilder(da);

                    //da.(ds);
                    //da.Fill(dt);|| txt_quantity_sum.Text != ""
                    da.Fill(ds, "UPDATE");


                    dt = ds.Tables["UPDATE"];

               

                }
            }
        }
        DataTable dt = new DataTable();
        private void btnok_Click(object sender, EventArgs e)
        {
            if(txt_discount.Text == "")
            {
                txt_discount.Text = "0";
            }
            
            if (mode == "EDIT QUOTATION")
            //if (txtquotation.focus)
            {
               
                txt_qut_row_id.Text = "0";




                if (IsDuplicateValueedit(txt_item.Text, txt_size.Text, dt))
                {
                    MessageBox.Show("Duplicate value! Insertion cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    DataRow row = dt.NewRow();


                    //row["ROW_ID"] = txt_no.Text;
                    row["ITEM_NAME"] = txt_item.Text;
                    row["SIZE_NAME"] = txt_size.Text;
                    row["STYLE_NAME"] = txt_style.Text;
                    row["QUANTITY"] = txt_quantity.Text;
                    row["RATE"] = txt_rate.Text;
                    row["DISCOUNT"] = Convert.ToInt32(txt_discount.Text);
                    row["TOTAL"] = txt_total.Text;
                    row["ITEM_ID"] = txt_item.Tag;
                    row["SIZE_ID"] = txt_size.Tag;
                    row["IS_ADD"] = txt_add.Text;
                    row["QUOTATION_ROW_ID"] = txt_qut_row_id.Text;
                    row["IS_UPDATE"] = txt_qut_row_id.Text;
                    dt.Rows.Add(row);
                    // BindingSource bs = new BindingSource();
                    // bs.DataSource = dt;
                    //// bs.Add(row);
                    // dgvitemform.DataSource = bs;
                    dgvitemform.DataSource = dt;
                    //    //DataGridViewRow dgvRow = new DataGridViewRow();
                    //    //dgvRow.CreateCells(dgvitemform);
                    //    //dgvRow.Cells[1].Value = row["ITEM_NAME"];
                    //    //dgvRow.Cells[2].Value = row["SIZE_NAME"];
                    //    //dgvRow.Cells[3].Value = row["STYLE_NAME"];
                    //    //dgvRow.Cells[4].Value = row["QUANTITY"];
                    //    //dgvRow.Cells[5].Value = row["RATE"];
                    //    //dgvRow.Cells[6].Value = row["DISCOUNT"];
                    //    //dgvRow.Cells[7].Value = row["TOTAL"];
                    //    //dgvRow.Cells[10].Value = row["ITEM_ID"];
                    //    //dgvRow.Cells[11].Value = row["SIZE_ID"];
                    //    //dgvRow.Cells[12].Value = row["QUOTATION_ROW_ID"];
                    //    //dgvRow.Cells[13].Value = row["IS_UPDATE"];
                    //    //dgvRow.Cells[14].Value = row["IS_ADD"];
                    //    //dgvitemform.Rows.Add(dgvRow);
                    //    sum_total();
                    //    total_sum();
                    //    sum_dicount();
                    //    quantity_sum();
                    //}

                }

                
            }
            else
            {
                if (IsDuplicateValueadd(txt_item.Text, txt_size.Text, dgvitemform))
                {
                    MessageBox.Show("Duplicate value! Insertion cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dgvitemform);

                    //newRow.Cells["ROW_ID"].Value = txt_no.Text;
                    newRow.Cells[1].Value = txt_item.Text;
                    newRow.Cells[2].Value = txt_size.Text;
                    newRow.Cells[3].Value = txt_style.Text;
                    newRow.Cells[4].Value = txt_quantity.Text;
                    newRow.Cells[5].Value = txt_rate.Text;
                    newRow.Cells[6].Value = txt_discount.Text;
                    newRow.Cells[7].Value = txt_total.Text;
                    newRow.Cells[10].Value = txt_item.Tag;
                    newRow.Cells[11].Value = txt_size.Tag;
                    dgvitemform.Rows.Add(newRow);
                    //add_data(txt_no.Text, txt_item.Text, txt_size.Text, txt_style.Text, txt_quantity.Text, txt_rate.Text, txt_discount.Text, txt_total.Text, txt_item.Tag, txt_size.Tag);
                }
                sum_total();
                sum_dicount();


            }
            duplicate_size();


            pnlright.Visible = false;
            txt_clear();
            btn_update.Visible = false;
            btn_save.Visible = true;
            btn_cancel.Visible = true;
            quantity_sum();
            // row_add();
            
           // sum_discount();



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
        private bool IsDuplicateValueadd(string value1, string value2, DataGridView dgv)
        {

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[1].Value?.ToString() == value1 &&
                    row.Cells[2].Value?.ToString() == value2)
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


        public void total_sum()
        {
            Decimal sum = 0;



            if (txt_total_sum.Text != "" && txt_total_sum.Text == "")
            {
                for (int i = 0; i < dgvitemform.Rows.Count; i++)
                {
                    sum +=  (Decimal.Parse(dgvitemform.Rows[i].Cells["total"].Value.ToString()));

                }

                txt_total_sum.Text = sum.ToString();
           
               

                //    for (int j = 0; j < dgvitemform.Rows.Count; j++)
                //    {
                //        sum = ((Convert.ToDecimal(txt_total_sum.Text)) + (Decimal.Parse(dgvitemform.Rows[j].Cells["total"].Value.ToString())));
                //    }
                //    txt_total_sum.Text = sum.ToString();
                //}
            }
        }
        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            //Double discount;
            //txt_sum_discount.Text = "0";
            //Double sum_dicount = ;
            if (txt_discount.Text != "")
            {
                if (txt_rate.Text != "" && txt_discount.Text != "")
                {
                    txt_total.Text = Convert.ToString((1 - Convert.ToDouble(txt_discount.Text) / 100.00) * ((Convert.ToDouble(txt_rate.Text) * (Convert.ToDouble(txt_quantity.Text)))));
                    //Decimal sum = Convert.ToDecimal(discount);

                }
            }
            else
            {
                if (txt_rate.Text != "" && txt_discount.Text == "")
                {
                    txt_total.Text = Convert.ToString(((Convert.ToDecimal(txt_rate.Text) * (Convert.ToDecimal(txt_quantity.Text)))));
                }
            }


            if (txt_discount.Text != "" )
            {
                double  i = 99.9;

                double  s = Convert.ToDouble(txt_discount.Text);
               //int r = Convert.ToInt32(txt_discount.Text);
                while (s > i )
                {
                    MessageBox.Show("not allow negative value ", "Inventry Management", MessageBoxButtons.OK);
                    //txt_quantity.Text = "";
                    //txt_rate.Text = "";
                    txt_discount.Text = "";
                    break;
                }
            }
        }
        public void sum_dicount()
        {
            if (txt_sum_discount.Text != "")
            {
                Decimal sum = 0;
                for (int i = 0; i < dgvitemform.Rows.Count; i++)
                {
                    sum += Decimal.Parse(dgvitemform.Rows[i].Cells["DISCOUNT"].Value.ToString());
                }
                txt_sum_discount.Text = sum.ToString();

            }
            else
            {
                if (txt_sum_discount.Text == "")
                {

                    Decimal sum = 0;
                    for (int i = 0; i < dgvitemform.Rows.Count; i++)
                    {
                        sum += Decimal.Parse(dgvitemform.Rows[i].Cells["DISCOUNT"].Value.ToString());
                    }
                    txt_sum_discount.Text = sum.ToString();

                }
            }
        }
        public void sum_total()
        {
            Decimal sum = 0;
            int i;

            if (txt_total_sum.Text == "")
            {
                for (i = 0; i < dgvitemform.Rows.Count; i++)
                {
                    sum += Decimal.Parse(dgvitemform.Rows[i].Cells["total"].Value.ToString());

                }

                txt_total_sum.Text = sum.ToString();
            }
            else
            {
                if (txt_total_sum.Text != "")
                {
                    for (i = 0; i < dgvitemform.Rows.Count; i++)
                    {
                        sum += Decimal.Parse(dgvitemform.Rows[i].Cells["total"].Value.ToString());

                    }

                    txt_total_sum.Text = sum.ToString();
                }
            }

          
        }
        public void quantity_sum()
        {
            Decimal sum = 0;
            if (txt_total_sum.Text != "" )
            {
                for (int i = 0; i < dgvitemform.Rows.Count; i++)
                {
                    sum += Decimal.Parse(dgvitemform.Rows[i].Cells["quantity"].Value.ToString());
                }
                txt_quantity_sum.Text = sum.ToString();
            }
            else
            {
                if (txt_total_sum.Text == "")
                {
                    for (int i = 0; i < dgvitemform.Rows.Count; i++)
                    {
                        sum += Decimal.Parse(dgvitemform.Rows[i].Cells["quantity"].Value.ToString());
                    }
                    txt_quantity_sum.Text = sum.ToString();
                }
            }
        }
      

        public void row_add()
        {

            int i = 1;

            for (int x = 0; x < dgvitemform.Rows.Count; x++)
            {
                if (txt_add.Text == string.Empty)
                {
                    txt_add.Text = i.ToString();
                }
                else
                {
                    i = i + 1;
                    txt_add.Text = i.ToString();
                }
            }

        }


        public void add_data(string row_id, string item_name, string size, string style_name, string quantity, string rate, string discount, string total, object item_id, object size_id)
        {
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dgvitemform);

            newRow.Cells[0].Value = row_id;
            newRow.Cells[1].Value = item_name;
            newRow.Cells[2].Value = size;
            newRow.Cells[3].Value = style_name;
            newRow.Cells[4].Value = quantity;
            newRow.Cells[5].Value = rate;
            newRow.Cells[6].Value = discount;
            newRow.Cells[7].Value = total;
            newRow.Cells[10].Value = item_id;
            newRow.Cells[11].Value = size_id;
            dgvitemform.Rows.Add(newRow);







        }
        public void btnedit()
        {
            if (mode == "ADD QUOTATION")
            {
                if (IsDuplicateValueadd(txt_item.Text, txt_size.Text, dgvitemform))
                {
                    MessageBox.Show("Duplicate value! Insertion cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int rowIndex = Convert.ToInt32(txt_no.Text) - 1;
                    DataGridViewRow edit_row = dgvitemform.Rows[rowIndex];
                    edit_row.Cells["ROW_ID"].Value = txt_no.Text;
                    edit_row.Cells["ITEM_NAME"].Value = txt_item.Text;
                    edit_row.Cells["SIZE"].Value = txt_size.Text;
                    edit_row.Cells["STYLE_NAME"].Value = txt_style.Text;
                    edit_row.Cells["QUANTITY"].Value = txt_quantity.Text;
                    edit_row.Cells["RATE"].Value = txt_rate.Text;
                    edit_row.Cells["DISCOUNT"].Value = txt_discount.Text;
                    edit_row.Cells["TOTAL"].Value = txt_total.Text;
                    edit_row.Cells["ITEM_ID"].Value = txt_item.Tag;
                    edit_row.Cells["SIZE_ID"].Value = txt_size.Tag;
                    edit_row.Cells["IS_UPDATE"].Value = txt_isupdate.Text;
                }
            }
            if (mode == "EDIT QUOTATION")
            {
                if (IsDuplicateValueedit(txt_item.Text, txt_size.Text, dt))
                {
                    MessageBox.Show("Duplicate value! Insertion cancelled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    int rowIndex = Convert.ToInt32(txt_no.Text) - 1;
                DataGridViewRow edit_row = dgvitemform.Rows[rowIndex];
                edit_row.Cells["ROW_ID"].Value = txt_no.Text;
                edit_row.Cells["ITEM_NAME"].Value = txt_item.Text;
                edit_row.Cells["SIZE"].Value = txt_size.Text;
                edit_row.Cells["STYLE_NAME"].Value = txt_style.Text;
                edit_row.Cells["QUANTITY"].Value = txt_quantity.Text;
                edit_row.Cells["RATE"].Value = txt_rate.Text;
                edit_row.Cells["DISCOUNT"].Value = txt_discount.Text;
                edit_row.Cells["TOTAL"].Value = txt_total.Text;
                edit_row.Cells["ITEM_ID"].Value = txt_item.Tag;
                edit_row.Cells["SIZE_ID"].Value = txt_size.Tag;
                edit_row.Cells["IS_UPDATE"].Value = txt_isupdate.Text;
                    if (txtquotation.Text != "")
                    {
                        int RowIndex = Convert.ToInt32(txt_no.Text) - 1;
                        //int RowIndex = dgvitemform.CurrentRow.Index;
                        //DataGridViewRow edit_Row = dgvitemform.Rows[rowIndex];
                        //row["ROW_ID"] = txt_no.Text;
                        DataRow row = dt.Rows[RowIndex];
                        row["ITEM_NAME"] = txt_item.Text;
                        row["SIZE_NAME"] = txt_size.Text;
                        row["STYLE_NAME"] = txt_style.Text;
                        row["QUANTITY"] = txt_quantity.Text;
                        row["RATE"] = txt_rate.Text;
                        row["DISCOUNT"] = txt_discount.Text;
                        row["TOTAL"] = txt_total.Text;
                        row["ITEM_ID"] = txt_item.Tag;
                        row["SIZE_ID"] = txt_size.Tag;
                        row["IS_ADD"] = txt_add.Text;
                        //string row_no = int.Parse(txt_qut_row_id.Text).ToString();

                        // row["QUOTATION_ROW_ID"] = row_no;
                        row["IS_UPDATE"] = txt_add.Text;
                        dt.AcceptChanges();
                        btn_save.Visible = true;
                        btn_cancel.Visible = true;
                    }
                }
            }




            }
        public void txt_clear()
        {

            txt_item.Text = "";
            txt_size.Text = "";
            txt_style.Text = "";
            txt_quantity.Text = "";
            txt_rate.Text = "";
            txt_discount.Text = "";
            txt_total.Text = "";
            
        }
        public void clear()
        {
            txtcustomer.Text = "";
            txtaddress.Text = "";
            txtquotation.Text = "";
            user_box.Text = "";
            dgvitemform.DataSource = null;
            dgvitemform.Rows.Clear();
            txt_no.Text = "";
            txt_total_sum.Text = "";
            txt_quantity_sum.Text = "";
            txt_add.Text = "";


        }
       
        private void btn_save_Click(object sender, EventArgs e)
        {
            if(txt_discount.Text == "")
            {
                txt_discount.Text = "0";
            }

            //double convert_total = Convert.ToDouble(txt_total_sum.Text);
            //double convert_discount = Convert.ToDouble(txt_sum_discount);
            if (dgvitemform.Rows.Count != 0 && txtcustomer.Text!="" && txt_sum_discount.Text!="" && txt_total_sum.Text!= "" )
            {

                if (mode == "ADD QUOTATION")
                {
                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        //DateTime Convert_Date = DateTime.ParseExact(txt_datetime.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        conn.Open();
                        String Query;

                        SqlTransaction Transaction = conn.BeginTransaction();
                        try
                        {
                            last_no();
                            quotation_no();

                            SqlCommand comm = new SqlCommand();
                            comm.Connection = conn;

                            String update_last_name_Query = @"UPDATE  [M_ENTRY_SETUP] SET LAST_NO ="
                                + "'" + textBox1.Text + "'  WHERE COMPANY_ID=" + lbl_comp.Tag + " AND ENTRY_ID = " + textBox1.Tag + "";


                            //comm.CommandText = StrQuery;


                            //comm.Connection = conn;

                            Query = "INSERT INTO [T_QUOTATION](QUOTATION_NO,QUOTATION_DATE,DISCOUNT,QUANTITY,TOTAL,CUSTOMER_ID,USER_NAME,COMPANY_ID,STATUS,ACTIVE) VALUES ("
                                        + "'" + txtquotation.Text + "',"
                                        + "'" + txt_datetime.Value.Date + "',"
                                        + "" + txt_sum_discount.Text + ","
                                        + "" + txt_quantity_sum.Text + ","
                                        + "" + txt_total_sum.Text + ","
                                        + "'" + txtcustomer.Tag + "',"
                                        + "'" + user_box.Text + "',"
                                         + "'" + lbl_comp.Tag + "',"
                                         + "'" + "ACTIVE" + "',"
                                        + "'" + "1" + "')";

                            StringBuilder sb = new StringBuilder();
                            sb.Append(Query);
                            //comm.CommandText = StrQuery;

                            //SqlCommand comm = new SqlCommand();
                            //foreach (DataGridViewRow row in dgvitemform.Rows)
                            string StrQuery;
                            for (int i = 0; i < dgvitemform.Rows.Count; i++)
                            {
                                StrQuery = "INSERT INTO [T_QUOTATION_ITEM](QUOTATION_NO,ROW_ID,ITEM_ID,SIZE_ID,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL,ACTIVE) VALUES ("
                                  + "'" + txtquotation.Text + "',"
                                  + "'" + dgvitemform.Rows[i].Cells["row_id"].Value + "', "
                                  + "'" + dgvitemform.Rows[i].Cells["item_id"].Value + "' ,"
                                  + "'" + dgvitemform.Rows[i].Cells["size_id"].Value + "',"
                                  + "'" + dgvitemform.Rows[i].Cells["style_name"].Value + "',"
                                  + "'" + dgvitemform.Rows[i].Cells["quantity"].Value + "',"
                                  + "'" + dgvitemform.Rows[i].Cells["rate"].Value + "',"
                                  + "'" + dgvitemform.Rows[i].Cells["discount"].Value + "',"
                                  + "'" + dgvitemform.Rows[i].Cells["total"].Value + "',"
                                  + "'" + "1" + "')";
                                //comm.CommandText = StrQuery;

                                sb.Append(StrQuery);

                            }



                            sb.Append(update_last_name_Query);
                            comm.CommandText = sb.ToString();
                            comm.Transaction = Transaction;

                            comm.ExecuteNonQuery();

                            Transaction.Commit();
                            // MessageBox.Show("UPLOADED SUCESSFULLY", "Message", MessageBoxButtons.OK);
                            conn.Close();
                            StringBuilder builder = new StringBuilder();
                            builder.Append("SAVED SUCESSFULLY \n QUOTATION_NO IS ");
                            builder.Append(txtquotation.Text);
                            MessageBox.Show(builder.ToString(), "INVENTORY MANAGEMENT", MessageBoxButtons.OK);

                            clear();
                            this.Close();
                            frm_quotation_list qut = new frm_quotation_list();
                            qut.MdiParent = frm_mid.ActiveForm;
                            qut.Show();
                        }
                        catch (Exception ex)
                        {
                            Transaction.Rollback();
                            MessageBox.Show(ex.Message);
                            clear();
                            this.Close();
                            frm_quotation_list qutation_List = new frm_quotation_list();
                            qutation_List.MdiParent = frm_mid.ActiveForm;
                            qutation_List.Show();

                        }






                    }
                }
                else if (mode == "EDIT QUOTATION")
                {

                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {
                        conn.Open();
                        SqlTransaction Transaction = conn.BeginTransaction();
                        try
                        {


                            string StrQuery;


                            SqlCommand comm = new SqlCommand();



                            comm.Connection = conn;




                            String Query;

                            //comm.Connection = conn;
                            Query = @"UPDATE  [T_QUOTATION]  SET
                                 QUOTATION_NO ='" + txtquotation.Text + "'," +
                          "QUOTATION_DATE = '" + txt_datetime.Value.Date + "'," +
                           "DISCOUNT = '" + txt_sum_discount.Text + "'," +
                           "QUANTITY ='" + txt_quantity_sum.Text + "'," +
                             "TOTAL = '" + txt_total_sum.Text + "'," +
                          "CUSTOMER_ID = '" + txtcustomer.Tag + "'," +

                        "[USER_NAME] = '" + user_box.Text + "'," +
                         "COMPANY_ID = '" + lbl_comp.Tag + "'," +
                          "STATUS = '" + "ACTIVE" + "'," +

                    " ACTIVE ='" + "1" + "'WHERE QUOTATION_NO ='" + txtquotation.Text + "'";

                            StringBuilder sb = new StringBuilder();
                            sb.Append(Query);
                            //sb.Append(query);


                            //comm.CommandText = StrQuery;
                            foreach (DataGridViewRow row in dgvitemform.Rows)
                            {

                                if (row.Cells["IS_UPDATE"].Value != DBNull.Value)
                                {
                                    int update_new = Convert.ToInt32(row.Cells["IS_UPDATE"].Value);
                                    int QUOTATION_ROW_ID = Convert.ToInt32(row.Cells["QUOTATION_ROW_ID"].Value);

                                    int UPDATE_ROW = Convert.ToInt32(row.Cells["IS_UPDATE"].RowIndex);
                                    //for (int i = 0; i < update_new; i++)
                                    //{
                                    //int update_new = 0;



                                    int i = UPDATE_ROW;
                                    while (update_new != 0)
                                    {
                                        StrQuery = @"UPDATE [T_QUOTATION_ITEM] SET
                                          QUOTATION_NO= '" + txtquotation.Text + "'," +
                                                              "ROW_ID = '" + dgvitemform.Rows[i].Cells["row_id"].Value + "', " +
                                                              "ITEM_ID = '" + dgvitemform.Rows[i].Cells["item_id"].Value + "' ," +
                                                              "SIZE_ID='" + dgvitemform.Rows[i].Cells["size_id"].Value + "'," +
                                                               "STYLE_NAME='" + dgvitemform.Rows[i].Cells["style_name"].Value + "'," +
                                                               "QUANTITY= '" + dgvitemform.Rows[i].Cells["quantity"].Value + "'," +
                                                                 "RATE='" + dgvitemform.Rows[i].Cells["rate"].Value + "'," +
                                                                  "DISCOUNT = '" + dgvitemform.Rows[i].Cells["discount"].Value + "'," +
                                                                  "TOTAL = '" + dgvitemform.Rows[i].Cells["total"].Value + "'," +
                                                                  "" + "ACTIVE =" + "1" + "WHERE ROW_ID =" + dgvitemform.Rows[i].Cells["row_id"].Value + "";

                                        sb.Append(StrQuery);
                                        break;
                                        //sb.Append(update_last_name_Query);

                                    }
                                    //}




                                }
                                else
                                {
                                    row.Cells["IS_UPDATE"].Value = 0;
                                }

                            }




                            foreach (DataGridViewRow row2 in dgvitemform.Rows)
                            {
                                if (row2.Cells["IS_ADDED"].Value != DBNull.Value)
                                {
                                    int add_id = Convert.ToInt32(row2.Cells["IS_ADDED"].Value);
                                    int QUOTATION_ROW_ID = Convert.ToInt32(row2.Cells["QUOTATION_ROW_ID"].Value);
                                    int row_index = Convert.ToInt32(row2.Cells["IS_ADDED"].RowIndex);
                                    //for (int l = 0; l < add_id; l++)
                                    //{
                                    string StrQuery3;

                                    int l = 0;

                                    if (l == QUOTATION_ROW_ID)
                                    {

                                        //foreach (DataGridViewRow row in dgvitemform.Rows)
                                        for (int i = row_index; i < dgvitemform.Rows.Count; i++)
                                        {
                                            StrQuery3 = @"INSERT INTO [T_QUOTATION_ITEM](QUOTATION_NO,ROW_ID,ITEM_ID,SIZE_ID,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL,ACTIVE) VALUES ("
                                              + "'" + txtquotation.Text + "',"
                                              + "'" + dgvitemform.Rows[i].Cells["row_id"].Value + "', "
                                              + "'" + dgvitemform.Rows[i].Cells["item_id"].Value + "' ,"
                                              + "'" + dgvitemform.Rows[i].Cells["size_id"].Value + "',"
                                              + "'" + dgvitemform.Rows[i].Cells["style_name"].Value + "',"
                                              + "'" + dgvitemform.Rows[i].Cells["quantity"].Value + "',"
                                              + "'" + dgvitemform.Rows[i].Cells["rate"].Value + "',"
                                              + "'" + dgvitemform.Rows[i].Cells["discount"].Value + "',"
                                              + "'" + dgvitemform.Rows[i].Cells["total"].Value + "',"
                                              + "'" + "1" + "')";


                                            sb.Append(StrQuery3);

                                        }
                                        //}
                                        // MessageBox.Show("UPLOADED SUCESSFULLY", "Message", MessageBoxButtons.OK);


                                        string delete_query = "DELETE FROM T_QUOTATION_ITEM WHERE DELETED =" + 1 + "";
                                        sb.Append(delete_query);
                                    }
                                }


                                else
                                {
                                    row2.Cells["IS_ADDED"].Value = 0;
                                }
                            }

                            comm.CommandText = sb.ToString();
                            comm.Transaction = Transaction;

                            comm.ExecuteNonQuery();
                            Transaction.Commit();


                            conn.Close();
                            StringBuilder builder = new StringBuilder();
                            builder.Append("SAVED SUCESSFULLY \n QUOTATION_NO IS ");
                            builder.Append(txtquotation.Text);
                            MessageBox.Show(builder.ToString(), "INVENTORY MANAGEMENT", MessageBoxButtons.OK);
                            // conn.Close();

                            clear();
                            this.Close();
                            frm_quotation_list qut = new frm_quotation_list();
                            qut.MdiParent = frm_mid.ActiveForm;
                            qut.Show();
                        }



                        catch (Exception ex)
                        {
                            Transaction.Rollback();
                            MessageBox.Show(ex.Message);
                            delete_cancel();
                            clear();
                            this.Close();
                            frm_quotation_list qutation_List = new frm_quotation_list();
                            qutation_List.MdiParent = frm_mid.ActiveForm;
                            qutation_List.Show();
                        }









                        // MessageBox.Show("UPLOADED SUCESSFULLY", "Message", MessageBoxButtons.OK);




                    }


                }
                else
                {
                    if (mode == "CANCEL QUOTATION")
                    {
                        DialogResult done = (MessageBox.Show("Are you sure want to CANCEL this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                        if (done == DialogResult.Yes)
                        {
                            using (SqlConnection conn = new SqlConnection(ConnString))
                            {
                                conn.Open();
                                SqlTransaction Transaction = conn.BeginTransaction();

                                try
                                {

                                    using (SqlCommand comm = new SqlCommand())
                                    {

                                        comm.Connection = conn;

                                        //foreach (DataGridViewRow row in dgvitemform.Rows)
                                        string StrQuery = "UPDATE [T_QUOTATION] SET STATUS = '" + "CANCELED" + "'," +
                               " ACTIVE = " + "0" + " WHERE QUOTATION_NO ='" + txtquotation.Text + "'";
                                        string Query = "UPDATE [T_QUOTATION_ITEM] SET  ACTIVE = " + "0" + " WHERE QUOTATION_NO ='" + txtquotation.Text + "'";

                                        StringBuilder SB = new StringBuilder();
                                        SB.Append(StrQuery);
                                        SB.Append(Query);
                                        comm.CommandText = SB.ToString();
                                        comm.Transaction = Transaction;
                                        comm.ExecuteNonQuery();

                                        Transaction.Commit();

                                    }
                                    StringBuilder builder = new StringBuilder();
                                    builder.Append("CANCELED SUCESSFULLY \n QUOTATION_NO IS ");
                                    builder.Append(txtquotation.Text);
                                    MessageBox.Show(builder.ToString(), "INVENTORY MANAGEMENT", MessageBoxButtons.OK);

                                    conn.Close();
                                    txt_clear();
                                    clear();
                                    this.Close();
                                    frm_quotation_list qut = new frm_quotation_list();
                                    qut.MdiParent = frm_mid.ActiveForm;
                                    qut.Show();



                                }

                                catch (Exception ex)
                                {
                                    Transaction.Rollback();
                                    MessageBox.Show(ex.Message);
                                    frm_quotation_list qut = new frm_quotation_list();
                                    qut.MdiParent = frm_mid.ActiveForm;
                                    qut.Show();
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
        public void duplicate_size()
        {
            
                //string newCellValue = txt_size.Text; 
                ////bool isDuplicate = false;
                //int count = 0;

                
                //foreach (DataGridViewRow row in dgvitemform.Rows)
                //{
                //    if (row.Cells[2].Value != null && row.Cells[2].Value.ToString().Equals(newCellValue))
                //    {
                //    //isDuplicate = true;
                //    count++;
                //    }
                //}

                
                //if (count <= 1)
                //{
                //    dgvitemform.Rows.Add(newCellValue);
                //}
                //else
                //{
                //    MessageBox.Show("Duplicate value not allowed.");
                //}
           

        }

        public void neg_quantity()
        {
            if ( txt_quantity.Text != "")
            {
                int i = 0;
                int s = Convert.ToInt32(txt_quantity.Text);
                //int r = Convert.ToInt32(txt_rate.Text);
                while (s <= i)
                {
                    MessageBox.Show("not allow negative value ", "Inventry Management", MessageBoxButtons.OK);
                    txt_quantity.Text = "";
                    //txt_rate.Text = "";
                    //txt_total.Text = "";
                    break;
                }
            }
        }
        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {
            if (txt_rate.Text != "" && txt_quantity.Text != "")
            {
                txt_total.Text = Convert.ToString(((Convert.ToDecimal(txt_rate.Text) * (Convert.ToDecimal(txt_quantity.Text)))));
            }
            //neg_quantity();

        }
        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' && txt_quantity.Text.Length == 0)
            {
                e.Handled = false; 
                MessageBox.Show("not allow negative value ", "Inventry Management", MessageBoxButtons.OK);
                txt_quantity.Text = "";

            }
            else if (!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                
            }
            else
            {
                //txt_quantity.Text = "";

            }
        }
        private void txt_rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' && txt_rate.Text.Length == 0)
            {
                e.Handled = false;
                MessageBox.Show("not allow negative value ", "Inventry Management", MessageBoxButtons.OK);
                txt_rate.Text = "";

            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
               
            }
            else
            {
                //txt_rate.Text = "";
            }
        }
        private void txt_rate_TextChanged(object sender, EventArgs e)
        {
            // double multi = 0;
            //if (txt_rate.Text != "" && txt_quantity.Text != "")
            //{
            //    int i = 0;

            //    ///int s = Convert.ToInt32(txt_quantity.Text);
            //    int r = Convert.ToInt32(txt_rate.Text);
            //    while (r <= i)
            //    {
            //        MessageBox.Show("not allow negative value ", "Inventry Management", MessageBoxButtons.OK);
            //         txt_quantity.Text = "";
            //        txt_rate.Text = "";
            //        txt_total.Text = "";
            //        break;
            //    }
            //}
            if (txt_rate.Text != "" && txt_quantity.Text != "")
            {
                txt_total.Text = (Convert.ToString(Convert.ToDecimal(txt_rate.Text) * Convert.ToDecimal(txt_quantity.Text)));
                //txt_total.Text = (double.Parse(txt_rate.Text) * (double.Parse(txt_quantity.Text))).ToString();
                // = multi.ToString();
                
            }
           
            //if (txt_quantity_sum.Text != "" && txt_quantity_sum.Text == "")
            //{
            //    txt_quantity.Text = double.Parse(txt_quantity.Text).ToString();
            //    txt_rate.Text = double.Parse(txt_rate.Text).ToString();
            //    txt_total.Text = double.Parse(txt_total.Text).ToString();
            //}
            // txt_total.Text = multi.ToString();

        }

        private void txt_discount_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        [DllImport("user07.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void Releasecapture();
        [DllImport("user07.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000;
                return cp;
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {

            GraphicsPath path = new GraphicsPath();
            float curvesize = radius + 2F;
            path.AddArc(rect.X, rect.Y, curvesize, curvesize, 180, 90);
            path.AddArc(rect.Right - curvesize, rect.Y, curvesize, curvesize, 270, 90);
            path.AddArc(rect.Right - curvesize, rect.Bottom - curvesize, curvesize, curvesize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curvesize, curvesize, curvesize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private GraphicsPath GetRoundedPath1(Rectangle rect, float radius)
        {

            GraphicsPath path1 = new GraphicsPath();
            float curvesize1 = radius + 2F;
            path1.AddArc(rect.X, rect.Y, curvesize1, curvesize1, 180, 90);
            path1.AddArc(rect.Right - curvesize1, rect.Y, curvesize1, curvesize1, 270, 90);
            path1.AddArc(rect.Right - curvesize1, rect.Bottom - curvesize1, curvesize1, curvesize1, 0, 90);
            path1.AddArc(rect.X, rect.Bottom - curvesize1, curvesize1, curvesize1, 90, 90);
            path1.CloseFigure();
            return path1;
        }

       


        private void FormRegionAndBorder1(Panel pnlright, float radius, Graphics graph, Color bordercolor1, float bordersize1)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundpath = GetRoundedPath1(pnlright.ClientRectangle, radius))
                using (Pen penborder = new Pen(bordercolor1, bordersize1))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    pnlright.Region = new Region(roundpath);
                    if (bordersize1 >= 1)
                    {
                        Rectangle rect = pnlright.ClientRectangle;
                        float scaleX = 1.0f - (bordersize1 + 1) / rect.Width;
                        float scaleY = 1.0f - (bordersize1 + 1) / rect.Height;

                        transform.Scale(scaleX, scaleY);
                        transform.Translate(bordersize1 / 1.6f, bordersize1 / 1.6f);
                        graph.Transform = transform;
                        graph.DrawPath(penborder, roundpath);
                    }
                }
            }
        }


        private void pnlright_Paint(object sender, PaintEventArgs e)
        {
            int borderradius1 = 30;
            int bordersize1 = 0;
            Color bordercolor1 = Color.Black;
            FormRegionAndBorder1(this.pnlright, borderradius1, e.Graphics, bordercolor1, bordersize1);
        }


        private void dgvitemform_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (dgvitemform.Columns[e.ColumnIndex].HeaderText == "EDIT")
            {

                DialogResult done = (MessageBox.Show("Are you sure want to Edit this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (done == DialogResult.Yes)
                {
                    pnlright.Visible = true;
                    pnlright.Enabled = true;
                    pnlclose.Visible = true;
                    btnok.Visible = false;
                    btn_update.Visible = true;
                    btn_save.Visible = false;
                    btn_cancel.Visible = false;
                    indexRow = e.RowIndex;
                    DataGridViewRow row = this.dgvitemform.Rows[indexRow];
                    //int row = dgvitemform.SelectedCells[0].RowIndex;
                    //DataGridViewRow selectedRow = dgvitemform.Rows[row];

                    indexRow = indexRow + 1;
                    txt_no.Text = indexRow.ToString();
                    txt_item.Text = row.Cells["ITEM_NAME"].Value.ToString();
                    txt_size.Text = row.Cells["SIZE"].Value.ToString();
                    txt_style.Text = row.Cells["style_name"].Value.ToString();
                    txt_quantity.Text = row.Cells["QUANTITY"].Value.ToString();
                    txt_rate.Text = row.Cells["RATE"].Value.ToString();
                    txt_discount.Text = row.Cells["DISCOUNT"].Value.ToString();
                    txt_total.Text = row.Cells["TOTAL"].Value.ToString();
                    txt_item.Tag = row.Cells["ITEM_ID"].Value.ToString();
                    txt_size.Tag = row.Cells["SIZE_ID"].Value.ToString();




                    






                    //dgvitemform.Refresh();




                }
                //txt_clear();

            }


            else
            {
                if (dgvitemform.Columns[e.ColumnIndex].HeaderText == "DELETE")
                {
                    int s_no;

                    DataGridViewRow selectedRow = dgvitemform.Rows[e.RowIndex];
                    s_no = Convert.ToInt32(selectedRow.Cells["row_id"].Value);
                   int delete_row = Convert.ToInt32(selectedRow.Cells["QUOTATION_ROW_ID"].Value);
                    textBox5.Text = (s_no.ToString());
                    //MessageBox.Show(s_no.ToString());

                    DialogResult done = (MessageBox.Show("Are you sure want to Delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                    if (done == DialogResult.Yes)
                    {
                        if (s_no > 0)
                        {
                            if(mode == "ADD QUOTATION")
                            {

                                int selectedRowIndex = dgvitemform.SelectedRows[0].Index;
                                dgvitemform.Rows.RemoveAt(selectedRowIndex);


                                MessageBox.Show("DELETED SUCCESSFULLY");
                                deletedRowValue = Convert.ToDouble(selectedRow.Cells[7].Value);
                                deletedRowValue1 = Convert.ToDouble(selectedRow.Cells[4].Value);
                                sum_total();
                                total_sum();
                                quantity_sum();
                                sum_dicount();
                            }
                            if(mode == "EDIT QUOTATION")
                            {
                                
                                string delete = "UPDATE  [T_QUOTATION_ITEM] SET DELETED ="
                            + "'" + txt_isupdate.Text + "'  WHERE QUOTATION_ROW_ID=" + delete_row + "";
                                SqlConnection conn = new SqlConnection(ConnString);
                                conn.Open();
                                SqlCommand cmd = new SqlCommand(delete,conn);
                                cmd.ExecuteNonQuery();
                                conn.Close();

                               
                              
                               
                                int selectedRowIndex = dgvitemform.SelectedRows[0].Index;
                                DataRow row = dt.Rows[selectedRowIndex];
                                dt.Rows.Remove(row);
                                dgvitemform.Rows.RemoveAt(selectedRowIndex);


                                MessageBox.Show("DELETED SUCCESSFULLY");
                                deletedRowValue = Convert.ToDouble(selectedRow.Cells[7].Value);
                                deletedRowValue1 = Convert.ToDouble(selectedRow.Cells[4].Value);
                                //UpdateTotalValue();
                                sum_total();
                                total_sum();
                                quantity_sum();
                                //sum_quantity_update();
                                sum_dicount();
                            }
                            
                            
                               
                            
                        }
                       
                    }

                       
                    }

            }




        }

        
        private void UpdateTotalValue()
        {
            int totalvalue1 = 0;
            if (txtquotation.Text == "")
            {
                foreach (DataGridViewRow row in dgvitemform.Rows)
                {
                    //totalValue += Convert.ToInt32(dgvitemform.Rows[i].Cells[7].Value);
                    totalvalue1 += Convert.ToInt32(row.Cells["total"].Value);
                }
                if (txt_total_sum.Text == "" || txt_total_sum.Text != "")
                {
                    double updatedValue1 = Convert.ToInt32(txt_total_sum.Text) - deletedRowValue /*+ totalvalue1*/;
                    Decimal sum = Convert.ToDecimal( updatedValue1);
                    txt_total_sum.Text = sum.ToString();
                }
            }
            else
            {
                if (txtquotation.Text != "")
                {
                    foreach (DataGridViewRow row in dgvitemform.Rows)
                    {
                        //totalValue += Convert.ToInt32(dgvitemform.Rows[i].Cells[7].Value);
                        totalvalue1 += Convert.ToInt32(row.Cells["total"].Value);
                    }
                    if (txt_total_sum.Text == "" || txt_total_sum.Text != "")
                    {
                        double updatedValue1 = /*Convert.ToInt32(txt_total_sum.Text)*/ -deletedRowValue + totalvalue1;
                        Decimal sum = Convert.ToDecimal(updatedValue1);
                        txt_total_sum.Text = sum.ToString();
                    }
                }
            }

        }
        public void sum_quantity_update()
        {
            int totalvalue1 = 0;
            if (txtquotation.Text == "")
            {
                foreach (DataGridViewRow row in dgvitemform.Rows)
                {
                    //totalValue += Convert.ToInt32(dgvitemform.Rows[i].Cells[7].Value);
                    totalvalue1 += Convert.ToInt32(row.Cells["quantity"].Value);
                }
                if (txt_quantity_sum.Text == "" || txt_quantity_sum.Text != "")
                {
                    double updatedValue1 = Convert.ToInt32(txt_quantity_sum.Text) - deletedRowValue1 /*+ totalvalue1*/;
                    Decimal sum = Convert.ToDecimal(updatedValue1);
                    txt_quantity_sum.Text = sum.ToString();
                }
            }
            else
            {
                if (txtquotation.Text != "")
                {
                    foreach (DataGridViewRow row in dgvitemform.Rows)
                    {
                        //totalValue += Convert.ToInt32(dgvitemform.Rows[i].Cells[7].Value);
                        totalvalue1 += Convert.ToInt32(row.Cells["quantity"].Value);
                    }
                    if (txt_quantity_sum.Text == "" || txt_quantity_sum.Text != "")
                    {
                        double updatedValue1 = /*Convert.ToInt32(txt_total_sum.Text)*/ -deletedRowValue + totalvalue1;
                        Decimal sum = Convert.ToDecimal(updatedValue1);
                        txt_quantity_sum.Text = sum.ToString();
                    }
                }
            }
        }
        public void sum_discount()
        {
            //txt_sum_discount.Text = "0";
            //int totalvalue1 = 0;
            //if (txtquotation.Text == "")
            //{
            //    foreach (DataGridViewRow row in dgvitemform.Rows)
            //    {
            //        //totalValue += Convert.ToInt32(dgvitemform.Rows[i].Cells[7].Value);
            //        totalvalue1 += Convert.ToInt32(row.Cells[6].Value);
            //    }
            //    if (txt_sum_discount.Text == "" || txt_sum_discount.Text != "")
            //    {
            //        double updatedValue1 = Convert.ToInt32(txt_sum_discount.Text) - deletedRowValue1 /*+ totalvalue1*/;
            //        Decimal sum = Convert.ToDecimal(updatedValue1);
            //        txt_sum_discount.Text = sum.ToString();
            //    }
            //}
            //else
            //{
            //    if (txtquotation.Text != "")
            //    {
            //        foreach (DataGridViewRow row in dgvitemform.Rows)
            //        {
            //            //totalValue += Convert.ToInt32(dgvitemform.Rows[i].Cells[7].Value);
            //            totalvalue1 += Convert.ToInt32(row.Cells[6].Value);
            //        }
            //        if (txt_sum_discount.Text == "" || txt_sum_discount.Text != "")
            //        {
            //            double updatedValue1 = /*Convert.ToInt32(txt_total_sum.Text)*/ -deletedRowValue + totalvalue1;
            //            // Decimal sum = Convert.ToDecimal(updatedValue1);
            //            txt_sum_discount.Text = updatedValue1.ToString();
            //        }
            //    }
            //}
        }
       
        private void btn_update_Click(object sender, EventArgs e)
        {

            //try
            //{
                btnedit();
                total_sum();
                quantity_sum();
                pnlright.Visible = false;
                txt_clear();
                
                sum_total();
                sum_dicount();
                btn_update.Visible = false;
                duplicate_size();
           
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        public void in_update()
        {

        }

       
       
        public void last_no()
        {
           
            {
                string query = "select LAST_NO from M_ENTRY_SETUP AS ES  WHERE ES.COMPANY_ID=" + lbl_comp.Tag + " AND ES.ENTRY_ID = " +textBox1.Tag+ "";
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
               int sum = s + 1;
                textBox1.Text = sum.ToString();
                if (btn_save.Focused)
                {
                    break;
                }

            }
            
            {
                //

                //SqlConnection conn = new SqlConnection(ConnString);


                //comm.Connection = conn;

               



            }

           
           
        }
        public void quotation_no()
        {
           
            String Query = " SELECT CONCAT([PREFIIX],'-',[LAST_NO]+1) AS[QUOTATION_NO] FROM[M_ENTRY_SETUP]  WHERE COMPANY_ID=" + lbl_comp.Tag + " AND ENTRY_ID = " + textBox1.Tag + "";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand comm = new SqlCommand(Query, conn);
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    txtquotation.Text = dr["QUOTATION_NO"].ToString();

                }
                dr.Close();
                conn.Close();
            }
            //,[SUFFIX],''
        }


        public void edit_form()
        {
            txtquotation.Text = frm_quotation_list.value1;
            textBox3.Text = frm_quotation_list.value2;

            //btn_save.Visible = false;
            //btn_save_update.Visible = true;
            STATUS = frm_quotation_list.STATUS;
            this.Text = mode;
            try
            {
               
                    // String str = "Select * from T_QUOTATION_ITEM";
                    String SQLQuery = "SELECT QUOTATION_ROW_ID,ROW_ID,M_ITEM.ITEM_NAME,M_SIZE.SIZE_NAME,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL,QI.ITEM_ID,QI.SIZE_ID FROM T_QUOTATION_ITEM AS QI" +
                " INNER JOIN M_ITEM ON M_ITEM.ITEM_ID = QI.ITEM_ID " +
                "INNER JOIN  M_SIZE ON M_SIZE.SIZE_ID = QI.SIZE_ID  " +
            "WHERE QI.QUOTATION_NO = '" + txtquotation.Text + "'  AND QI.ACTIVE =" + "1" + "";
            String sqlquery = "SELECT QUOTATION_DATE,DISCOUNT,QUANTITY,TOTAL,CUSTOMER_NAME,QUANTITY,USER_NAME,T_QUOTATION.CUSTOMER_ID FROM T_QUOTATION" +
                " INNER JOIN M_CUSTOMER ON M_CUSTOMER.CUSTOMER_ID = T_QUOTATION.CUSTOMER_ID " +
                "WHERE QUOTATION_NO = '" + txtquotation.Text + "'AND STATUS = '" + "ACTIVE" + "' AND T_QUOTATION.ACTIVE =" + "1" + " ";
            SqlDataAdapter da = new SqlDataAdapter(SQLQuery, ConnString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Quation");
            dgvitemform.DataSource = ds.Tables["Quation"].DefaultView;

           

                using (SqlConnection conn = new SqlConnection(ConnString))
                {

                    SqlCommand comm = new SqlCommand(sqlquery, conn);
                    conn.Open();
                    SqlDataReader dr1 = comm.ExecuteReader();
                    SqlDataAdapter dr = new SqlDataAdapter(comm);
                    while (dr1.Read())
                    {

                        txtcustomer.Text = dr1["CUSTOMER_NAME"].ToString();
                        txt_quantity_sum.Text = dr1["QUANTITY"].ToString();
                        txt_datetime.Value = Convert.ToDateTime( dr1["QUOTATION_DATE"].ToString()); /*(DateTime)dr.GetValue(2);*/
                        txt_sum_discount.Text = dr1["DISCOUNT"].ToString();
                        txt_total_sum.Text = dr1["TOTAL"].ToString();
                        user_box.Text = dr1["USER_NAME"].ToString();
                        txtcustomer.Tag = dr1["CUSTOMER_ID"].ToString();
                    }
                    dr1.Close();
                    conn.Close();
                    }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Address();
        }
        public string STATUS { get; set; }
        public void view_form()
        {
            txtquotation.Text = frm_quotation_list.value1;
            // txtcustomer.Text = frm_qut.value2;
            STATUS = frm_quotation_list.STATUS;
            this.Text = mode;
            try
            {
               
                    // String str = "Select * from T_QUOTATION_ITEM";
                    String SQLQuery = "SELECT ROW_ID,M_ITEM.ITEM_NAME,M_SIZE.SIZE_NAME,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL,QI.ITEM_ID,QI.SIZE_ID FROM T_QUOTATION_ITEM AS QI" +
                    " INNER JOIN M_ITEM ON M_ITEM.ITEM_ID = QI.ITEM_ID " +
                    "INNER JOIN  M_SIZE ON M_SIZE.SIZE_ID = QI.SIZE_ID  " +
                "WHERE QI.QUOTATION_NO = '" + txtquotation.Text + "'  AND QI.ACTIVE =" + "1" + "  ";
                    String sqlquery = "SELECT QUOTATION_DATE,DISCOUNT,QUANTITY,TOTAL,CUSTOMER_NAME,QUANTITY,USER_NAME,T_QUOTATION.CUSTOMER_ID FROM T_QUOTATION" +
                        " INNER JOIN M_CUSTOMER ON M_CUSTOMER.CUSTOMER_ID = T_QUOTATION.CUSTOMER_ID " +
                        "WHERE QUOTATION_NO = '" + txtquotation.Text + "' AND T_QUOTATION.STATUS = '" + "ACTIVE" + "'  AND T_QUOTATION.ACTIVE =" + "1" + " ";

                    SqlDataAdapter da = new SqlDataAdapter(SQLQuery, ConnString);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Quation");
                    dgvitemform.DataSource = ds.Tables["Quation"].DefaultView;



                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {

                        SqlCommand comm = new SqlCommand(sqlquery, conn);
                        conn.Open();
                        SqlDataReader dr1 = comm.ExecuteReader();
                        SqlDataAdapter dr = new SqlDataAdapter(comm);
                        while (dr1.Read())
                        {

                            txtcustomer.Text = dr1["CUSTOMER_NAME"].ToString();
                            txt_quantity_sum.Text = dr1["QUANTITY"].ToString();
                            txt_datetime.Value = Convert.ToDateTime(dr1["QUOTATION_DATE"].ToString()); /*(DateTime)dr.GetValue(2);*/
                            txt_sum_discount.Text = dr1["DISCOUNT"].ToString();
                            txt_total_sum.Text = dr1["TOTAL"].ToString();
                            user_box.Text = dr1["USER_NAME"].ToString();
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
            txtaddress.ReadOnly = true;
            txtquotation.Enabled = false;
            user_box.Enabled = false;
            dgvitemform.Enabled = false;
            btnadd.Enabled = false;
            btn_save.Enabled = false;
            btn_cancel.Enabled = false;
            Address();
        }
        public void DELETE_form()
        {
            txtquotation.Text = frm_quotation_list.value1;
            // txtcustomer.Text = frm_qut.value2;
            //btn_clear.Visible = true;
            STATUS = frm_quotation_list.STATUS;
            // String str = "Select * from T_QUOTATION_ITEM"; 
            this.Text = mode;
            try
            {
               
                    String SQLQuery = "SELECT ROW_ID,M_ITEM.ITEM_NAME,M_SIZE.SIZE_NAME,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL,T_QUOTATION_ITEM.ITEM_ID,T_QUOTATION_ITEM.SIZE_ID FROM T_QUOTATION_ITEM " +
            "INNER JOIN M_ITEM ON M_ITEM.ITEM_ID = T_QUOTATION_ITEM.ITEM_ID " +
            "INNER JOIN  M_SIZE ON M_SIZE.SIZE_ID = T_QUOTATION_ITEM.SIZE_ID " +
            "WHERE QUOTATION_NO = '" + txtquotation.Text + "' AND T_QUOTATION_ITEM. ACTIVE =" + "1" + "";
                    String sqlquery = "SELECT QUOTATION_DATE,DISCOUNT,QUANTITY,TOTAL,CUSTOMER_NAME,QUANTITY,USER_NAME FROM T_QUOTATION" +
                        " INNER JOIN M_CUSTOMER ON M_CUSTOMER.CUSTOMER_ID = T_QUOTATION.CUSTOMER_ID " +
                        "WHERE QUOTATION_NO = '" + txtquotation.Text + "'AND STATUS = '" + "ACTIVE" + "' AND T_QUOTATION.ACTIVE =" + "1" + " ";
                    SqlDataAdapter da = new SqlDataAdapter(SQLQuery, ConnString);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Quation");
                    dgvitemform.DataSource = ds.Tables["Quation"].DefaultView;



                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {

                        SqlCommand comm = new SqlCommand(sqlquery, conn);
                        conn.Open();
                        SqlDataReader dr1 = comm.ExecuteReader();
                        SqlDataAdapter dr = new SqlDataAdapter(comm);
                        while (dr1.Read())
                        {

                            txtcustomer.Text = dr1["CUSTOMER_NAME"].ToString();
                            txt_quantity_sum.Text = dr1["QUANTITY"].ToString();
                            txt_datetime.Value = Convert.ToDateTime(dr1["QUOTATION_DATE"].ToString()); /*(DateTime)dr.GetValue(2);*/
                            txt_sum_discount.Text = dr1["DISCOUNT"].ToString();
                            txt_total_sum.Text = dr1["TOTAL"].ToString();
                            user_box.Text = dr1["USER_NAME"].ToString();
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
            txtaddress.ReadOnly = true;
            txtquotation.Enabled = false;
            user_box.Enabled = false;
            dgvitemform.Enabled = false;
            btnadd.Enabled = false;
            Address();

        }
        public void print_form()
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

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (int nTop,
        int nLeft,
        int nRight,
        int nBottum,
        int nWidthEllipse,
        int nHeightEllipse
       );




        public void drop_down()
        {
            
            // String str = "Select * from T_QUOTATION_ITEM";
            String SQLQuery = "SELECT QUOTATION_ID, QUOTATION_NO FROM T_QUOTATION WHERE CUSTOMER_ID  = '" + txtcustomer.Tag + "'";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    SqlCommand comm = new SqlCommand(SQLQuery, conn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = comm;
                    conn.Open();
                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "drop");

                    //SqlDataReader dr = comm.ExecuteReader();
                    //while (dr.Read())
                    //{
                    //    string item = dr[0].ToString();
                    //      txtquotation.Items.Add(item);

                    //dr.Close();
                    //DataTable dt = ds.Tables[0];
                    txtquotation.DataSource = ds.Tables["drop"].DefaultView;
                    txtquotation.DisplayMember = "QUOTATION_NO";
                    txtquotation.ValueMember = "QUOTATION_ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




           



        }
         public static string User_Name { get; set; }
        public void user()
        {
            String Query = "SELECT [USER] FROM  [M_USER_MANAGEMENT] WHERE USER_NAME = '"+lbluser.Text+"' ";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand comm = new SqlCommand(Query, conn);
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    user_box.Text = dr["USER"].ToString();

                }
                dr.Close();
                conn.Close();
            }
        }
        private void Frm_Quotation_Load(object sender, EventArgs e)
        {
            pnlclose.Width = 0;
            //drop_customer();
           
            lbluser.Text = frm_quotation_list.user_name;
            lbl_comp.Tag = frm_quotation_list.camp_id;
            textBox1.Tag = frm_quotation_list.NAME_ID;
            this.KeyPreview = true;
            datasource();
            user();
            btn_close.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_close.Width, btn_close.Height, 70, 70));
            //btnclose.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnclose.Width, btnclose.Height, 70, 70));
            //btnok.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnok.Width, btnok.Height, 70, 70));
            //btn_update.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_update.Width, btn_update.Height, 70, 70));
            //btn_save.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_save.Width, btn_save.Height, 30, 30));
           // btnadd.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnadd.Width, btnadd.Height, 30, 30));
            this.Region = Region.FromHrgn(CreateRoundRectRgn(3, 3, this.Width, this.Height, 20, 20));

            
        }
       
        private void txt_total_TextChanged(object sender, EventArgs e)
        {

            
        }

       

        private void txtcustomer_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (txtcustomer.Text == "")
                {
                    frmf2 popup = new frmf2();
                    popup.MdiParent = frm_mid.ActiveForm;
                    popup.mode = "Quotation";
                    string _query = "SELECT CUSTOMER_ID AS [ID], CUSTOMER_NAME, C.CITY FROM M_CUSTOMER CU INNER JOIN M_CITY C ON C.CITY_ID = CU.CITY_ID WHERE CU.ACTIVE = 1";
                    popup.ShowF2(_query, "CUSTOMER_NAME", ((TextBox)sender).Text, "CUSTOMER_NAME", sender);
                }

                //}
                //}

            }
            //if (e.KeyCode == Keys.F5)
            //{
            //    drop_down();
            //}
        }
       

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {
            //txtaddress.Text = txtaddress.Tag.ToString();

        }

        private void txtaddress_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmf5 popup = new frmf5();
                string _query = "SELECT CUSTOMER_ID AS [ID],CONCAT(ADDRESS_1,'   ',CITY,'   ',DISTRICT,'   ', STATE,' " +
                    " ',COUNTRY,'  ', POSTAL_CODE, '   PH:'," +
                    "PHONE_NO) AS[ADDRESS] FROM[M_CUSTOMER]" +
                    "WHERE ACTIVE = 1";


                popup.ShowF2(_query, "ADDRESS", ((TextBox)sender).Text, "ADDRESS", sender);
            }
        }
       

        

        private void txtcustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                // btn_load.Visible = true;
                // drop_down();
            }
        }

        
        
        public void refresh()
        {
            
            // String str = "Select * from T_QUOTATION_ITEM";
            String SQLQuery = "SELECT ROW_ID,ITEM_NAME,SIZE_NAME,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL FROM T_QUOTATION_ITEM " +
            "INNER JOIN M_ITEM ON M_ITEM.ITEM_ID = T_QUOTATION_ITEM.ITEM_ID " +
            "INNER JOIN  M_SIZE ON M_SIZE.SIZE_ID = T_QUOTATION_ITEM.SIZE_ID " +
            "WHERE QUOTATION_NO = '" + txtquotation.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(SQLQuery, ConnString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Quation");
            dgvitemform.DataSource = ds.Tables["Quation"].DefaultView;
        }
        private void Frm_Quotation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

               
                // String str = "Select * from T_QUOTATION_ITEM";
                String SQLQuery = "SELECT ROW_ID,ITEM_NAME,SIZE_NAME,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL FROM T_QUOTATION_ITEM " +
                "INNER JOIN M_ITEM ON M_ITEM.ITEM_ID = T_QUOTATION_ITEM.ITEM_ID " +
                "INNER JOIN  M_SIZE ON M_SIZE.SIZE_ID = T_QUOTATION_ITEM.SIZE_ID " +
                "WHERE QUOTATION_NO = '" + txtquotation.Text + "'";
                String sqlquery = "SELECT QUOTATION_DATE,DISCOUNT,QUANTITY,TOTAL,CUSTOMER_NAME,CUSTOMER_ADDRESS,USER_NAME FROM T_QUOTATION" +
                    " INNER JOIN M_CUSTOMER ON M_CUSTOMER.CUSTOMER_ID = T_QUOTATION.CUSTOMER_ID " +
                    "WHERE QUOTATION_NO = '" + txtquotation.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(SQLQuery, ConnString);
                DataSet ds = new DataSet();
                da.Fill(ds, "Quation");
                dgvitemform.DataSource = ds.Tables["Quation"].DefaultView;

                try
                {

                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {

                        SqlCommand comm = new SqlCommand(sqlquery, conn);
                        conn.Open();
                        SqlDataReader dr1 = comm.ExecuteReader();
                        SqlDataAdapter dr = new SqlDataAdapter(comm);
                        while (dr1.Read())
                        {

                            txtcustomer.Text = dr1["CUSTOMER_NAME"].ToString();
                            txtaddress.Text = dr1["CUSTOMER_ADDRESS"].ToString();
                            txt_datetime.Text = dr1["QUOTATION_DATE"].ToString(); /*(DateTime)dr.GetValue(2);*/
                            txt_sum_discount.Text = dr1["DISCOUNT"].ToString();
                            txt_total_sum.Text = dr1["TOTAL"].ToString();
                            user_box.Text = dr1["USER_NAME"].ToString();
                        }
                        dr1.Close();
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.txt_datetime.Text = DateTime.Now.ToString("dd/MM/yyyy");
            

        }

        private void txt_datetime_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void txtquotation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_item_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F2)
            {
                frmf2 popup = new frmf2();
                popup.MdiParent = frm_mid.ActiveForm;
                string _query = "SELECT  ITEM_ID AS [ID],ITEM_NAME, HSN_CODE FROM M_ITEM WHERE ACTIVE = 1";
                popup.ShowF2(_query, "ITEM_NAME", ((TextBox)sender).Text, "ITEM_NAME", sender);


            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            txt_clear();
            delete_cancel();
            clear();
            this.Close();
            frm_quotation_list list = new frm_quotation_list();
            list.MdiParent = frm_mid.ActiveForm;
            list.Show();
        }
        public void delete_cancel()
        {
            string cancel_query = "UPDATE [T_QUOTATION_ITEM] SET DELETED =" + 0 + " WHERE DELETED ="+1+"";
            SqlConnection conn = new SqlConnection(ConnString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(cancel_query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }
        private void txt_size_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmf2 popup = new frmf2();
                popup.MdiParent = frm_mid.ActiveForm;
                string _query = "SELECT SIZE_ID AS [ID], SIZE_NAME FROM M_SIZE WHERE ACTIVE = 1";
                popup.ShowF2(_query, "SIZE_NAME", ((TextBox)sender).Text, "SIZE_NAME", sender);


            }
        }
        private void dgvitemform_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvitemform.Rows[e.RowIndex].Cells["ROW_ID"].Value = (e.RowIndex + 1).ToString();
        }
        // DataTable table;
       

        private void txtcustomer_KeyPress_2(object sender, KeyPressEventArgs e)
        {

        }

      

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_add_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvitemform_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void dgvitemform_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }
        public void Address()
        {
            if (txtcustomer.Tag != null)
            {
                string _query1 = "SELECT CONCAT(ADDRESS_1,' '," +
                "[M_CITY].CITY,'  ,',[M_DISTRICT] .DISTRICT,'  ,'," +
                "[M_STATE].STATE,' ,',[M_COUNTRY].COUNTRY,'  ,'," +
                "POSTAL_CODE,' ,',PHONE_NO ) AS [ADDRESS] FROM [M_CUSTOMER]" +
                " INNER JOIN[dbo].[M_CITY]  ON[M_CUSTOMER].CITY_ID = [M_CITY].CITY_ID" +
                " INNER JOIN[dbo].[M_DISTRICT]  ON[M_CUSTOMER].DISTRICT_ID = [M_DISTRICT].DISTRICT_ID" +
                " INNER JOIN[dbo].[M_STATE]  ON[M_CUSTOMER].STATE_ID = [M_STATE].STATE_ID " +
                " INNER JOIN[dbo].[M_COUNTRY] ON[M_CUSTOMER].COUNTRY_ID = [M_COUNTRY].COUNTRY_ID " +
                " WHERE [M_CUSTOMER]. CUSTOMER_NAME = '" + txtcustomer.Text + "'";

                SqlConnection conn = new SqlConnection(ConnString);
                SqlCommand cmd = new SqlCommand(_query1, conn);
                conn.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    txtaddress.Text = dataReader["ADDRESS"].ToString();
                }

                conn.Close();

            }
        }
        private void txtcustomer_TextChanged(object sender, EventArgs e)
        {
          

        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_clear();
            delete_cancel();
            clear();
            this.Close();
            frm_quotation_list list = new frm_quotation_list();
            list.MdiParent = frm_mid.ActiveForm;
            list.Show();
        }
        private int numberOfItemsPerPage = 0;
        private int numberOfItemsPrintedSoFar = 0;
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string curdhead = "QUOTATION";
            e.Graphics.DrawString(curdhead, new System.Drawing.Font("Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 350, 50);

            string l1 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(l1, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 100);

            string g1 = "QUOTATION_NO ";
            e.Graphics.DrawString(g1, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 20, 140);

            string g2 = "QUOTATION_DATE";
            e.Graphics.DrawString(g2, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 150, 140);

            string g3 = "CUSTOMER_NAME";
            e.Graphics.DrawString(g3, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 350, 140);

            string g4 = "TOTAL";
            e.Graphics.DrawString(g4, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 590, 140);

            string g5 = "STATUS";
            e.Graphics.DrawString(g5, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 690, 140);

            string l2 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            e.Graphics.DrawString(l2, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 160);

            int height = 165;
            for (int l = numberOfItemsPrintedSoFar; l < dgvitemform.Rows.Count; l++)
            {
                numberOfItemsPerPage = numberOfItemsPerPage + 1;
                if (numberOfItemsPerPage <= 50)
                {
                    numberOfItemsPrintedSoFar++;

                    if (numberOfItemsPrintedSoFar <= dgvitemform.Rows.Count)
                    {

                        height += dgvitemform.Rows[0].Height;
                        e.Graphics.DrawString(dgvitemform.Rows[l].Cells["QUOTATION_NO"].FormattedValue.ToString(), dgvitemform.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(40, height, dgvitemform.Columns[0].Width = 200, dgvitemform.Rows[0].Height));
                        e.Graphics.DrawString(dgvitemform.Rows[l].Cells["QUOTATION_DATE"].FormattedValue.ToString(), dgvitemform.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(160, height, dgvitemform.Columns[0].Width = 200, dgvitemform.Rows[0].Height));
                        e.Graphics.DrawString(dgvitemform.Rows[l].Cells["CUSTOMER_NAME"].FormattedValue.ToString(), dgvitemform.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(320, height, dgvitemform.Columns[0].Width = 200, dgvitemform.Rows[0].Height));
                        e.Graphics.DrawString(dgvitemform.Rows[l].Cells["TOTAL"].FormattedValue.ToString(), dgvitemform.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(600, height, dgvitemform.Columns[0].Width = 200, dgvitemform.Rows[0].Height));

                        e.Graphics.DrawString(dgvitemform.Rows[l].Cells["STATUS"].FormattedValue.ToString(), dgvitemform.Font = new Font(" Segoe UI Emoji", 8), Brushes.Black, new RectangleF(700, height, dgvitemform.Columns[0].Width = 200, dgvitemform.Rows[0].Height));
                        //string S4 = "---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                        //e.Graphics.DrawString(S4, new System.Drawing.Font(" Segoe UI Emoji", 9, FontStyle.Bold), Brushes.Black, 0, 160);
                        //S4 = height + Convert.ToInt32(S4).ToString();

                    }
                    else
                    {
                        e.HasMorePages = false;
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

        private void dgvitemform_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dgvitemform.ClearSelection();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void txtcustomer_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtcustomer_MouseMove(object sender, MouseEventArgs e)
        {
            txtcustomer.SelectionLength = 0;
        }

        private void frmQuotation_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                if (pnlright.Visible == false)
                {
                    Timer.Start();
                    pnlright.Visible = true;
                    pnlclose.Visible = true;
                    btn_update.Visible = false;
                    btnok.Visible = true;
                    btn_save.Visible = false;
                    btn_cancel.Visible = false;
                }
            }
            if (e.KeyCode == Keys.X && e.Alt)
            {
                txt_clear();
                delete_cancel();
                clear();
                this.Close();
                frm_quotation_list list = new frm_quotation_list();
                list.MdiParent = frm_mid.ActiveForm;
                list.Show();
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void dgvitemform_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dgvitemform.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}



    



