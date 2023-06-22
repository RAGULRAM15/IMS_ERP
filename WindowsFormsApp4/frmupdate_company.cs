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
    public partial class frmupdate_company : Form
    {
        public frmupdate_company()
        {
            InitializeComponent();
        }
        public string MODE { get; set; }
        private void frmupdate_company_Load(object sender, EventArgs e)
        {
            this.Text = MODE;

            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            // String str = "Select * from T_QUOTATION_ITEM";
            String SQLQuery = " SELECT DISTRICT_ID, DISTRICT FROM M_DISTRICT WHERE ACTIVE =1 ";


            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand comm = new SqlCommand(SQLQuery, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = comm;
                conn.Open();
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);


                DataRow row = dt.NewRow();
                row[1] = " ";
                dt.Rows.InsertAt(row, 0);
                ////SqlDataReader dr = comm.ExecuteReader();
                //while (dr.Read())
                //{
                //    string item = dr[0].ToString();
                //      txtquotation.Items.Add(item);

                //dr.Close();
                //DataTable dt = ds.Tables[0];
                // txt2.DataSource = ds.Tables["DOWN"].DefaultView;
                txt3.DataSource = dt;
                txt3.DisplayMember = "DISTRICT";
                txt3.ValueMember = "DISTRICT_ID";
                //txt2.Tag = txt2.ValueMember.ToString();
            }
            //String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            // String str = "Select * from T_QUOTATION_ITEM";
            String SQLQuery1 = " SELECT STATE_ID, STATE FROM M_STATE WHERE ACTIVE =1 ";


            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand comm = new SqlCommand(SQLQuery1, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = comm;
                conn.Open();
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);


                DataRow row = dt.NewRow();
                row[1] = "   ";
                dt.Rows.InsertAt(row, 0);
                ////SqlDataReader dr = comm.ExecuteReader();
                //while (dr.Read())
                //{
                //    string item = dr[0].ToString();
                //      txtquotation.Items.Add(item);

                //dr.Close();
                //DataTable dt = ds.Tables[0];
                // txt2.DataSource = ds.Tables["DOWN"].DefaultView;
                txt4.DataSource = dt;
                txt4.DisplayMember = "STATE";
                txt4.ValueMember = "STATE_ID";
                //txt2.Tag = txt2.ValueMember.ToString();

            }


            //String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            // String str = "Select * from T_QUOTATION_ITEM";
            String SQLQuery2 = " SELECT COUNTRY_ID, COUNTRY FROM M_COUNTRY WHERE ACTIVE =1 ";


            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand comm = new SqlCommand(SQLQuery2, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = comm;
                conn.Open();
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);


                DataRow row = dt.NewRow();
                row[1] = "";
                dt.Rows.InsertAt(row, 0);
                ////SqlDataReader dr = comm.ExecuteReader();
                //while (dr.Read())
                //{
                //    string item = dr[0].ToString();
                //      txtquotation.Items.Add(item);

                //dr.Close();
                //DataTable dt = ds.Tables[0];
                // txt2.DataSource = ds.Tables["DOWN"].DefaultView;
                txt5.DataSource = dt;
                txt5.DisplayMember = "COUNTRY";
                txt5.ValueMember = "COUNTRY_ID";
                //txt2.Tag = txt2.ValueMember.ToString();

            }
            String SQLQuery3 = " SELECT CITY_ID, CITY FROM M_CITY WHERE ACTIVE =1 ";


            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                SqlCommand comm = new SqlCommand(SQLQuery3, conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = comm;
                conn.Open();
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                da.Fill(dt);


                DataRow row = dt.NewRow();
                row[1] = "";
                dt.Rows.InsertAt(row, 0);
                ////SqlDataReader dr = comm.ExecuteReader();
                //while (dr.Read())
                //{
                //    string item = dr[0].ToString();
                //      txtquotation.Items.Add(item);

                //dr.Close();
                //DataTable dt = ds.Tables[0];
                // txt2.DataSource = ds.Tables["DOWN"].DefaultView;
                txt16.DataSource = dt;
                txt16.DisplayMember = "CITY";
                txt16.ValueMember = "CITY_ID";
                //txt2.Tag = txt2.ValueMember.ToString();

            }
           
        }
        private void txt16_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int item = txt16.SelectedIndex;
            txt16.Tag = item;
        }

        private void txt3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int item = txt3.SelectedIndex;
            txt3.Tag = item;
        }

        private void txt4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int item = txt4.SelectedIndex;
            txt4.Tag = item;
        }

        private void txt5_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int item = txt5.SelectedIndex;
            txt5.Tag = item;
        }

        public void edit_frm()
        {
            txt15.Text = frm_company.value2;
            txt1.Text = frm_company.value1;
            // [M_CUSTOMER] (  [,[ACTIVE

            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            // String str = "Select * from T_QUOTATION_ITEM";
            //String SQLQuery = "SELECT ROW_ID,ITEM_NAME,SIZE,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL FROM T_QUOTATION_ITEM WHERE QUOTATION_NO = '" + txtquotation.Text + "'";
            String sqlquery = "SELECT [COMPANY_NAME], [ADDRESS], [M_CITY].[CITY], M_DISTRICT.[DISTRICT], M_STATE.[STATE],M_COUNTRY.COUNTRY, [PINCODE],[PHONE],[MOBILE],[E_MAIL],[WEBSITE],[GSTIN]," +
                "[GST_STATE_CODE],[TIN],[PAN],[CST],[CST_DATE] FROM M_COMPANY " +
                "INNER JOIN[M_CITY] ON[M_COMPANY].CITY_ID = [M_CITY].CITY_ID " +
                "INNER JOIN M_DISTRICT ON  M_COMPANY.DISTRICT_ID = M_DISTRICT.DISTRICT_ID " +
                " INNER JOIN M_STATE ON M_COMPANY.STATE_ID = M_STATE.STATE_ID " +
                "INNER JOIN M_COUNTRY ON M_COMPANY.COUNTRY_ID = M_COUNTRY.COUNTRY_ID" +
                "  WHERE COMPANY_NAME = '" + txt1.Text + "'";
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

                        txt1.Text = dr1["COMPANY_NAME"].ToString();
                        txt2.Text = dr1["ADDRESS"].ToString();
                        txt16.Text = dr1["CITY"].ToString(); /*(DateTime)dr.GetValue(2);*/
                        txt3.Text = dr1["DISTRICT"].ToString();
                        txt4.Text = dr1["STATE"].ToString();
                        txt5.Text = dr1["COUNTRY"].ToString();
                        textBox1.Text = dr1["PINCODE"].ToString();
                        txt6.Text = dr1["PHONE"].ToString();
                        txt7.Text = dr1["MOBILE"].ToString();
                        txt8.Text = dr1["E_MAIL"].ToString(); /*(DateTime)dr.GetValue(2);*/
                        txt9.Text = dr1["WEBSITE"].ToString();
                        txt10.Text = dr1["GSTIN"].ToString();
                        txt17.Text = dr1["GST_STATE_CODE"].ToString();
                        txt11.Text = dr1["TIN"].ToString();
                        txt12.Text = dr1["PAN"].ToString();
                        txt13.Text = dr1["CST"].ToString();
                        txt14.Text = dr1["CST_DATE"].ToString();

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

        private void btnok_Click(object sender, EventArgs e)
        {
            txt15.Text = frm_company.value2;
            String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
            String Query;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    //INSERT (  ) VALUES ("
                    //comm.Connection = conn;

                    Query = @"UPDATE [dbo].[M_COMPANY] SET 
                           [COMPANY_NAME] =   '" + txt1.Text + "'," +
                        " [ADDRESS] = '" + txt2.Text + "', " +
                        "[CITY_ID]= '" + txt16.Tag + "'" +
                        ", [DISTRICT_ID] =" + "'" + txt3.Tag + "'" +
                        ", [STATE_ID]=" + "'" + txt4.Tag + "'" +
                        ", [COUNTRY_ID] =" + "'" + txt5.Tag + "'" +
                        ", [PINCODE]=" + "'" + textBox1.Text + "'" +
                        ", [PHONE]=" + "'" + txt6.Text + "'" +
                        ",[MOBILE]=" + "'" + txt7.Text + "'" +
                        ", [E_MAIL] =" + "'" + txt8.Text + "'" +
                        ",[WEBSITE] =" + "'" + txt9.Text + "'" +
                        " ,[GSTIN] =   " + "'" + txt10.Text + "'" +
                        " , [GST_STATE_CODE]=" + "'" + txt17.Text + "'" +
                        ",[TIN]=" + "'" + txt11.Text + "'" +
                        ",[PAN]=" + "'" + txt12.Text + "'" +
                        ",[CST]=" + "'" + txt13.Text + "'" +
                        ",[CST_DATE]=" + "'" + txt14.Text + "'" +
                        ",[ACTIVE]=" + "" + "1" + "  " +
                        "WHERE COMPANY_NAME =  '" + txt1.Text + "'";





                    //comm.CommandText = StrQuery;

                    SqlCommand comm = new SqlCommand(Query, conn);
                    conn.Open();
                    comm.ExecuteNonQuery();
                }



                MessageBox.Show("SAVED SUCESSFULLY", "Message", MessageBoxButtons.OK);
                // conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            CLEAR();
            frm_company _Company = new frm_company();
            _Company.MdiParent = frm_mid.ActiveForm;
            _Company.Show();
        }
        public void CLEAR()
        {
            txt1.Text = "";
            txt2.Text = "";

            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            txt10.Text = "";
            txt11.Text = "";
            txt12.Text = "";
            txt13.Text = "";
            txt14.Text = "";
            //txt15.Text = "";
            txt16.Text = "";
            txt17.Text = "";
            textBox1.Text = "";
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            CLEAR();
            this.Close();
            frm_company _Company = new frm_company();
            _Company.MdiParent = frm_mid.ActiveForm;
            _Company.Show();
        }

        private void frmupdate_company_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                CLEAR();
                this.Close();
                frm_company _Company = new frm_company();
                _Company.MdiParent = frm_mid.ActiveForm;
                _Company.Show();
            }
        }
        //public void view_form()
        //{
        //    txt1.Text = FrmCompany.value1;
        //    // [M_CUSTOMER] (  [,[ACTIVE

        //    String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
        //    // String str = "Select * from T_QUOTATION_ITEM";
        //    //String SQLQuery = "SELECT ROW_ID,ITEM_NAME,SIZE,STYLE_NAME,QUANTITY,RATE,DISCOUNT,TOTAL FROM T_QUOTATION_ITEM WHERE QUOTATION_NO = '" + txtquotation.Text + "'";
        //    String sqlquery = "SELECT [COMPANY_NAME], [ADDRESS_1], [CITY_ID], [DISTRICT_ID], [STATE_ID], [COUNTRY_ID], [POSTAL_CODE],[PHONE_NO],[MOBILE_NO],[EMAIL],[WEBSITE],[GST_NO]," +
        //        " [GST_STATE_CODE],[TIN],[PAN],[CST],[CST_DATE] FROM M_COMPANY WHERE COMPANY_NAME = '" + txt1.Text + "'";
        //    try
        //    {

        //        using (SqlConnection conn = new SqlConnection(ConnString))
        //        {

        //            SqlCommand comm = new SqlCommand(sqlquery, conn);
        //            conn.Open();
        //            SqlDataReader dr1 = comm.ExecuteReader();
        //            SqlDataAdapter dr = new SqlDataAdapter(comm);
        //            while (dr1.Read())
        //            {

        //                txt1.Text = dr1["COMPANY_NAME"].ToString();
        //                txt2.Text = dr1["ADDRESS_1"].ToString();
        //                txt16.Text = dr1["CITY_ID"].ToString(); /*(DateTime)dr.GetValue(2);*/
        //                txt3.Text = dr1["DISTRICT_ID"].ToString();
        //                txt4.Text = dr1["STATE_ID"].ToString();
        //                txt5.Text = dr1["COUNTRY_ID"].ToString();
        //                textBox1.Text = dr1["POSTAL_CODE"].ToString();
        //                txt6.Text = dr1["PHONE_NO"].ToString();
        //                txt7.Text = dr1["MOBILE_NO"].ToString();
        //                txt8.Text = dr1["EMAIL"].ToString(); /*(DateTime)dr.GetValue(2);*/
        //                txt9.Text = dr1["WEBSITE"].ToString();
        //                txt10.Text = dr1["GST_NO"].ToString();
        //                txt17.Text = dr1["GST_STATE_CODE"].ToString();
        //                txt11.Text = dr1["TIN"].ToString();
        //                txt12.Text = dr1["PAN"].ToString();
        //                txt13.Text = dr1["CST"].ToString();
        //                txt14.Text = dr1["CST_DATE"].ToString();

        //            }
        //            dr1.Close();
        //            conn.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    txt1.ReadOnly = true;
        //    txt2.ReadOnly = true;
        //    txt3.Enabled = false;
        //    txt4.Enabled = false;
        //    txt5.Enabled = false;
        //    txt6.ReadOnly = true;
        //    txt7.ReadOnly = true;
        //    txt8.ReadOnly = true;
        //    txt9.ReadOnly = true;
        //    txt10.ReadOnly = true;
        //    txt11.ReadOnly = true;
        //    txt12.ReadOnly = true;
        //    txt13.ReadOnly = true;
        //    txt14.ReadOnly = true;
        //    // txt15.ReadOnly = true;
        //    txt16.Enabled = false;
        //    txt17.ReadOnly = true;
        //    textBox1.ReadOnly = true;
        //    btnclose.Enabled = false;
        //    btnok.Enabled = false;

        //}

    }
}
