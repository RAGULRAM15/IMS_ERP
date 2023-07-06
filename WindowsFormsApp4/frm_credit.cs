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
    public partial class frm_credit : Form
    {
        public frm_credit()
        {
            InitializeComponent();
        }
        public string mode { get; set; }
        public string valuetoadd { get; set; }
        public void last_no()
        {

            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
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


            //

            SqlConnection conn = new SqlConnection(ConnString);


            //comm.Connection = conn;

            String Query = @"UPDATE  [M_ENTRY_SETUP] SET LAST_NO ="
                         + "'" + textBox1.Text + "' WHERE ENTRY_SETUP_ID =9";


            //comm.CommandText = StrQuery;

            SqlCommand comm = new SqlCommand(Query, conn);
            conn.Open();
            comm.ExecuteNonQuery();




        }
        public void DEBIT_NO()
        {
            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
            String Query = " SELECT CONCAT([PREFIIX],'-',[SUFFIX],'',[LAST_NO]) AS[CREDIT_NO] FROM[M_ENTRY_SETUP] WHERE ENTRY_SETUP_ID = 9";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand comm = new SqlCommand(Query, conn);
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    cmbo_debit.Text = dr["CREDIT_NO"].ToString();

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
            dtg_debit.DataSource = null;
            dtg_debit.Rows.Clear();
            //txt_no.Text = "1";
            txt_debit.Text = "";
            //textBox1.Text = "";
            txt_total.Text = "";
            cmbo_debit.Text = "";


        }
        private void dtg_debit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {


            }
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            clear();
            this.Close();
            frm_credit_list credit_List = new frm_credit_list();
            credit_List.MdiParent = frm_mid.ActiveForm;
            credit_List.Show();

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
        public void valueadd()
        {
            if (this.dtg_debit.SelectedRows.Count > 0)
            {
                DataGridViewRow row = this.dtg_debit.SelectedRows[0];
                valuetoadd = row.Cells[3].Value.ToString();
               
            }
        }
        private void frm_debit_Load(object sender, EventArgs e)
        {
            //drop_customer();\
            //KeyPreview = true;
            //this.Focus();
            //this.BringToFront();
            //this.KeyDown += KeyEventHandler(frm_credit_KeyDown);
            //valueadd();
            btn_close.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_close.Width, btn_close.Height, 70, 70));
            btn_save.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn_save.Width, btn_save.Height, 70, 70));
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 70, 70));
        }

        public void sum_total()
        {
            Double sum = 0;
            //int i;
            Double sum1 = 0;
            Double sum2 = 0;

            foreach (DataGridViewRow viewRow in dtg_debit.Rows)
            {
                if (viewRow.Cells["total"].Value != null && viewRow.Cells["total"].Value.ToString() != string.Empty )
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

        private void dtg_debit_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
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

        private void txtcustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                frmf2 popup = new frmf2();
                string _query = "SELECT CUSTOMER_ID AS [ID], CUSTOMER_NAME, CUSTOMER_TITLE FROM M_CUSTOMER WHERE ACTIVE = 1";
                popup.ShowF2(_query, "CUSTOMER_NAME", ((TextBox)sender).Text, "CUSTOMER_NAME", sender);
            }

        }

        private void txtcustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

               

            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DEBIT_NO();
            last_no();

            clear();
        }

        private void dtg_debit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                int s_no;
                DataGridViewRow selectedRow = dtg_debit.Rows[e.RowIndex];
                s_no = Convert.ToInt32(selectedRow.Cells["active"].Value);
                // if ((dtg_debit.Rows[e.RowIndex].Cells["active"].ValueType) != null)
                bool clk = Convert.ToBoolean(dtg_debit.Rows[e.RowIndex].Cells["active"].EditedFormattedValue);
                int value_check = Convert.ToInt32(dtg_debit.Rows[e.RowIndex].Cells["active"].RowIndex);

                if (clk == true)
                {
                    if (selectedRow.Cells["TOTAL"].Value != null)
                    {
                        if (selectedRow.Cells["active"].ValueType != null)
                        {
                            while (value_check <= dtg_debit.Rows.Count)
                            {

                                string sum3 = dtg_debit.Rows[value_check].Cells["TOTAL"].Value.ToString();
                                dtg_debit.Rows[value_check].Cells["credit_note"].Value = sum3.ToString();

                                break;

                            }
                        }
                    }
                    else
                    {
                        selectedRow.Cells["TOTAL"].Value = "";


                    }


                }
                else
                {  // bool clk = Convert.ToBoolean(dtg_debit.Rows[e.RowIndex].Cells["active"].Value);
                    if (clk == false)
                    //if ((dtg_debit.Rows[e.RowIndex].Cells["active"].ValueType) == null)
                    {
                        //for(int i =0;i<dtg_debit.Rows.Count;i++)
                        // {
                        double sum = 0;
                        dtg_debit.Rows[e.RowIndex].Cells["CREDIT_NOTE"].Value = sum.ToString();

                        //}
                    }

                }

           
               
                Double sum4 = 0;
               

                for (int i = 0; i < dtg_debit.Rows.Count; i++)

                {
                    if (dtg_debit.Rows[i].Cells["CREDIT_NOTE"].Value != null)
                    {
                        sum4 += Double.Parse(dtg_debit.Rows[i].Cells["CREDIT_NOTE"].Value.ToString());
                        txt_debit.Text = sum4.ToString();
                        txt_total.Text = sum4.ToString();
                       
                    }

                    else
                    {
                        dtg_debit.Rows[i].Cells["CREDIT_NOTE"].Value = 0;
                    }
                }

            }
        }
        private void dtg_debit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dtg_debit_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        public void ITEM_LOAD()
        {
            foreach(DataGridViewRow dataGrid in dtg_debit.SelectedRows)
            {
                dataGrid.Cells["description"].Value = item_text;
                dataGrid.Cells["item_id"].Value = item_tag;

            }
        }
        public static string item_tag { get; set; }
        public static string item_text { get; set; }
        private void frm_credit_KeyDown(object sender, KeyEventArgs e)
        { 
            if(e.KeyCode == Keys.F5)
            {
                //if (mode == "ADD" || mode == "EDIT INVOICE")
                //{

                    if (e.KeyCode == Keys.F5)
                    {

                        //frmf3 popup = new frmf3();
                        //popup.ShowF3("RETURN OF GOODS", valuetoadd, sender);
                        ////popup.Show();
                        frmf5 popup = new frmf5();
                        popup.item_text = "CREDIT";
                        string _query = "SELECT ITEM_ID AS [ID],  ITEM_NAME, HSN_CODE FROM M_ITEM WHERE ACTIVE = 1";
                        popup.ShowF2(_query, "ITEM_NAME", (item_text), "ITEM_NAME", sender);


                        //  ITEM_LOAD();


                    }




                //}
            }
            
            
            if (e.KeyCode == Keys.X && e.Alt)
            {
                clear();
                this.Close();
                frm_credit_list credit_List = new frm_credit_list();
                credit_List.MdiParent = frm_mid.ActiveForm;
                credit_List.Show();
            }
        }

        private void pnl_top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_credit_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
          
        }

        private void txtcustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                frmf3 popup = new frmf3();
                popup.ShowF3("RETURN OF GOODS",valuetoadd,sender);
            popup.Show();
            
        }

        private void dtg_debit_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void dtg_debit_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
           
        }

        private void dtg_debit_SelectionChanged(object sender, EventArgs e)
        {
            

        }

        private void dtg_debit_MouseClick(object sender, MouseEventArgs e)
        {

        }
        public void GST_CALCULATION()
        {
            foreach (DataGridViewRow row in dtg_debit.SelectedRows)
            {
                string ITEM = row.Cells["ITEM_ID"].Value.ToString();
                String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
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
        public string sgst { get; set; }
        public string igst { get; set; }
        public string cgst { get; set; }
        private void dtg_debit_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            decimal sum4;
            foreach (DataGridViewRow row in dtg_debit.SelectedRows)
            {
                if (row.Cells["description"].Value != null)
                {
                    //row.Cells["paid"].Value = 0;
                    
                   

                    double Sgst = Convert.ToDouble(sgst);
                    double Cgst = Convert.ToDouble(cgst);
                    double Igst = Convert.ToDouble(igst);
                    if (row.Cells["balance"].Value != null)
                    {
                        decimal sum2 = decimal.Parse(row.Cells["paid"].Value.ToString());
                        decimal sum3 = decimal.Parse(row.Cells["balance"].Value.ToString());
                        sum4 = sum3 * sum2;
                        row.Cells["SGST"].Value = Convert.ToString((Sgst / 100.00) * (Convert.ToDouble(sum4)));
                        row.Cells["CGST"].Value = Convert.ToString((Cgst / 100.00) * (Convert.ToDouble(sum4)));


                        row.Cells["IGST"].Value = Convert.ToString((Igst / 100.00) * (Convert.ToDouble(sum4)));

                        Decimal GST = Convert.ToDecimal(Convert.ToDouble(row.Cells["SGST"].Value) + Convert.ToDouble(row.Cells["CGST"].Value) + Convert.ToDouble(row.Cells["IGST"].Value));
                        Double TOTAL = Convert.ToDouble (GST + sum4);
                        row.Cells["TOTAL"].Value = TOTAL .ToString();
                        sum_total();
                    }
                }
                else
                {
                    MessageBox.Show("PLEASE CHOOSE RETURN ITEM");
                }
               
            }
           
        }

        private void clk_select_all_CheckedChanged(object sender, EventArgs e)
        {
            if (clk_select_all.Checked == true)
            {
                foreach (DataGridViewRow viewRow in dtg_debit.Rows)
                {
                    DataGridViewCheckBoxCell selectall = (DataGridViewCheckBoxCell)viewRow.Cells["ACTIVE"];
                    selectall.Value = true;
                    select_all();
                }
            }
            else
            {
                if (clk_select_all.Checked == false)
                {
                    foreach (DataGridViewRow viewRow in dtg_debit.Rows)
                    {
                        DataGridViewCheckBoxCell selectall = (DataGridViewCheckBoxCell)viewRow.Cells["ACTIVE"];
                        selectall.Value = false;
                        select_all();
                    }
                }
            }
            
        }
        public void select_all()
        {
            int s_no;
            foreach (DataGridViewRow selectedRow in dtg_debit.Rows)
            {
                s_no = Convert.ToInt32(selectedRow.Cells["active"].Value);
                // if ((dtg_debit.Rows[e.RowIndex].Cells["active"].ValueType) != null)
                bool clk = Convert.ToBoolean(selectedRow.Cells["active"].EditedFormattedValue);
                int value_check = Convert.ToInt32(selectedRow.Cells["active"].RowIndex);

                if (clk == true)
                {
                    if (selectedRow.Cells["TOTAL"].Value != null)
                    {
                        if (selectedRow.Cells["active"].ValueType != null)
                        {
                            while (value_check <= dtg_debit.Rows.Count)
                            {

                                string sum3 = dtg_debit.Rows[value_check].Cells["TOTAL"].Value.ToString();
                                dtg_debit.Rows[value_check].Cells["credit_note"].Value = sum3.ToString();

                                break;

                            }
                        }

                    }
                    else
                    {
                        selectedRow.Cells["TOTAL"].Value = 0;
                        

                    }
                }



                else
                {  // bool clk = Convert.ToBoolean(dtg_debit.Rows[e.RowIndex].Cells["active"].Value);
                    if (clk == false)
                    //if ((dtg_debit.Rows[e.RowIndex].Cells["active"].ValueType) == null)
                    {
                        //for(int i =0;i<dtg_debit.Rows.Count;i++)
                        // {
                        double sum = 0;
                        selectedRow.Cells["CREDIT_NOTE"].Value = sum.ToString();

                        //}
                    }

                }



                Double sum4 = 0;


                for (int i = 0; i < dtg_debit.Rows.Count; i++)

                {
                    if (dtg_debit.Rows[i].Cells["CREDIT_NOTE"].Value != null)
                    {
                        sum4 += Double.Parse(dtg_debit.Rows[i].Cells["CREDIT_NOTE"].Value.ToString());
                        txt_debit.Text = sum4.ToString();
                        txt_total.Text = sum4.ToString();

                    }

                    else
                    {
                        dtg_debit.Rows[i].Cells["CREDIT_NOTE"].Value = 0;
                    }
                }
            }
        }

        private void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            String Con = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
            //String str = "Select * from T_QUOTATION_ITEM";
            try
            {
                String sqlquery = "SELECT INVOICE_NO,INVOICE_DATE  FROM T_INVOICE WHERE CUSTOMER_ID = '" + txtcustomer.Tag + "' ";

                SqlDataAdapter da = new SqlDataAdapter(sqlquery, Con);
                DataSet ds = new DataSet();
                da.Fill(ds, "INVOICE");
                dtg_debit.DataSource = ds.Tables["INVOICE"].DefaultView;



                //for (int i = 0; i < dtg_debit.Rows.Count; i++)
                //{
                //    dtg_debit.Rows[i].Cells["paid"].Value = 0;
                //    dtg_debit.Rows[i].Cells["balance"].Value = 0;
                //    decimal sum2 = decimal.Parse(dtg_debit.Rows[i].Cells["paid"].Value.ToString());
                //    decimal sum3 = decimal.Parse(dtg_debit.Rows[i].Cells["balance"].Value.ToString());
                //    sum3 *= sum2;
                //    dtg_debit.Rows[i].Cells["TOTAL"].Value = sum3.ToString();
                //}


                //sum_total();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
