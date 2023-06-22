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
    public partial class frmf5 : Form
    {
        public frmf5()
        {
            InitializeComponent(); 
            txtSearch.Focus();
        }
        private string _myText;
        public object _ct;

        //SQL Declarations
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True");
        DataSet ds = new DataSet();



        public string MyText
        {
            get
            {
                return _myText;
            }
            set
            {
                _myText = value;
                txtSearch.Text = value;
            }
        }
        public void ShowF2(string _sqlQuery, string _DispColName, string _txtValue, string _SearchName, object _Object)
        {
            txtSearch.Text = _txtValue;
           // txtDataload.Text = _txtValue;
            this.Name = "Help " + _SearchName; lblSearch.Text = _DispColName;
            _ct = _Object;


            //Grid data load from SQL database
            con.Open(); //database connection open

            SqlDataAdapter da = new SqlDataAdapter(_sqlQuery, con);
            SqlCommandBuilder combuilder = new SqlCommandBuilder(da);

            da.Fill(ds);
            dgvHelp.DataSource = ds.Tables[0];

            con.Close(); //database connection close
            dgvHelp.Columns["ID"].Visible = false;
           
            this.Show();
        }
        public void ShowF5(string _sqlQuery, string _DispColName, string _DispColName1, string _txtValue, string _SearchName, object _Object)
        {
            txtSearch.Text = _txtValue;
            // txtDataload.Text = _txtValue;
            this.Name = "Help " + _SearchName; lblSearch.Text = _DispColName;lbl_2.Text = _DispColName1;
            _ct = _Object;


            //Grid data load from SQL database
            con.Open(); //database connection open

            SqlDataAdapter da = new SqlDataAdapter(_sqlQuery, con);
            SqlCommandBuilder combuilder = new SqlCommandBuilder(da);

            da.Fill(ds);
            dgvHelp.DataSource = ds.Tables[0];

            con.Close(); //database connection close
            dgvHelp.Columns["ID"].Visible = false;
            dgvHelp.Columns["ID1"].Visible = false;
            this.Show();
        }
        public void ShowF5e(string _sqlQuery, string _DispColName, string _DispColName1, string _txtValue, string _SearchName, object _Object)
        {
            txtSearch.Text = _txtValue;
            // txtDataload.Text = _txtValue;
            this.Name = "Help " + _SearchName; lblSearch.Text = _DispColName; lbl_2.Text = _DispColName1;
            _ct = _Object;


            //Grid data load from SQL database
            con.Open(); //database connection open

            SqlDataAdapter da = new SqlDataAdapter(_sqlQuery, con);
            SqlCommandBuilder combuilder = new SqlCommandBuilder(da);

            da.Fill(ds);
            dgvHelp.DataSource = ds.Tables[0];

            con.Close(); //database connection close
            dgvHelp.Columns["ID"].Visible = false;
            //dgvHelp.Columns["ID1"].Visible = false;
            this.Show();
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
        private void frmf5_Load(object sender, EventArgs e)
        {
           
            //btnok.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnok.Width, btnok.Height, 20, 20));
            //btnclose.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnclose.Width, btnclose.Height, 20, 20));
            //dgvHelp.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgvHelp.Width, dgvHelp.Height, 20, 20));
        }

        private void dgvHelp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
                if (dgvHelp.Rows.Count > 0)
                {
                    try
                    {
                        int selectedrowindex = dgvHelp.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = dgvHelp.Rows[selectedrowindex];
                        txtDataload.Tag = Convert.ToString(selectedRow.Cells["ID"].Value);
                        txtDataload.Text = Convert.ToString(selectedRow.Cells[lblSearch.Text.ToUpper()].Value);
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DataView dv = ds.Tables[0].DefaultView;
            //    dv.RowFilter = lblSearch.Text + " LIKE '" + txtSearch.Text.ToString() + "%'";
            //    dgvHelp.DataSource = dv;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
        //public static string item_tag { get; set; }
        public  string item_text { get; set; }
        private void btnok_Click(object sender, EventArgs e)
        {
            if (item_text == "INVOICE")
            {
                _myText = txtSearch.Text;
                //(()_ct).Text = txtDataload.Text;
                //frm_invoice.item_tag = txtDataload.Text;
                frm_invoice.item_text = txtDataload.Text;
                frm_invoice.item_tag = (string)txtDataload.Tag;
                frm_invoice.size_text = txt_text.Text;
                //frm_invoice.size_tag = (string)txt_text.Tag;
                // item_tag = (string)txt_text.Tag;
                //item_text = txt_text.Text;
                var instance = Application.OpenForms.OfType<frm_invoice>().FirstOrDefault();
                instance.ITEM_LOAD();
                frm_invoice invoice = new frm_invoice();
                invoice.ITEM_LOAD();
                //invoice.cou
                // action.Invoke();
                // //((TextBox)_ct).Tag = txtDataload.Tag;
                //((TextBox)_ct).Text = txtDataload.Text;
                this.Close();
            }
            if (item_text == "SALES ORDER")
            {
                _myText = txtSearch.Text;
                //(()_ct).Text = txtDataload.Text;
                //frm_invoice.item_tag = txtDataload.Text;
                frm_sales_order.item_text = (string)txtDataload.Tag;

                // item_tag = (string)txt_text.Tag;
                //item_text = txt_text.Text;
                var instance = Application.OpenForms.OfType<frm_sales_order>().FirstOrDefault();
                instance.ITEM_LOAD();
                frm_sales_order invoice = new frm_sales_order();
                invoice.ITEM_LOAD();
                //invoice.cou
                // action.Invoke();
                // //((TextBox)_ct).Tag = txtDataload.Tag;
                //((TextBox)_ct).Text = txtDataload.Text;
                this.Close();
            }
            if (item_text == "SALES ORDER_EDIT")
            {
                _myText = txtSearch.Text;
                //(()_ct).Text = txtDataload.Text;
                frm_sales_order.item_text = txtDataload.Text;
                frm_sales_order.item_tag = (string)txtDataload.Tag;
                frm_sales_order.size_text = txt_text.Text;
                //frm_sales_order.size_tag = (string)txt_text.Tag;
                // item_tag = (string)txt_text.Tag;
                //item_text = txt_text.Text;
                var instance = Application.OpenForms.OfType<frm_sales_order>().FirstOrDefault();
                instance.ITEM_LOAD();
                // instance.GST_CALCULATION();
                frm_sales_order invoice = new frm_sales_order();
                invoice.ITEM_LOAD();

                this.Close();
            }
            if (item_text == "PAYMENT")
            {
                _myText = txtSearch.Text;
                //(()_ct).Text = txtDataload.Text;
                frm_payment.item_text = txtDataload.Text;
                frm_payment.item_tag = (string)txtDataload.Tag;
                frm_payment.size_text = txt_text.Text;
                frm_payment.size_tag = (string)txt_text.Tag;
                // item_tag = (string)txt_text.Tag;
                //item_text = txt_text.Text;
                var instance = Application.OpenForms.OfType<frm_payment>().FirstOrDefault();
                instance.ITEM_LOAD();
                instance.GST_CALCULATION();
                frm_payment invoice = new frm_payment();
                invoice.ITEM_LOAD();
                
                //invoice.cou
                // action.Invoke();
                // //((TextBox)_ct).Tag = txtDataload.Tag;
                //((TextBox)_ct).Text = txtDataload.Text;
                this.Close();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvHelp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (dgvHelp.Rows.Count > 0 && e.RowIndex >= 0)
                {
                    int selectedrowindex = e.RowIndex;
                    DataGridViewRow selectedRow = dgvHelp.Rows[selectedrowindex];
                    txtDataload.Tag = Convert.ToString(selectedRow.Cells["ID"].Value);
                    txtDataload.Text = Convert.ToString(selectedRow.Cells[lblSearch.Text].Value);
                }
            
        }

        private void dgvHelp_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (item_text == "PAYMENT")
            {
                if (dgvHelp.Rows.Count > 0 && e.RowIndex >= 0)
                {
                    try
                    {
                        int selectedrowindex = e.RowIndex;
                        DataGridViewRow selectedRow = dgvHelp.Rows[selectedrowindex];
                        txtDataload.Tag = Convert.ToString(selectedRow.Cells["ID"].Value);
                        txtDataload.Text = Convert.ToString(selectedRow.Cells[lblSearch.Text.ToUpper()].Value);
                        txt_text.Tag = Convert.ToString(selectedRow.Cells["ID1"].Value);
                        txt_text.Text = Convert.ToString(selectedRow.Cells[lbl_2.Text.ToUpper()].Value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (item_text == "SALES ORDER_EDIT" || item_text == "INVOICE")
            {
                if (dgvHelp.Rows.Count > 0 && e.RowIndex >= 0)
                {
                    try
                    {
                        int selectedrowindex = e.RowIndex;
                        DataGridViewRow selectedRow = dgvHelp.Rows[selectedrowindex];
                        txtDataload.Tag = Convert.ToString(selectedRow.Cells["ID"].Value);
                        txtDataload.Text = Convert.ToString(selectedRow.Cells[lblSearch.Text.ToUpper()].Value);
                        //txt_text.Tag = Convert.ToString(selectedRow.Cells["ID1"].Value);
                        txt_text.Text = Convert.ToString(selectedRow.Cells[lbl_2.Text.ToUpper()].Value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                if (dgvHelp.Rows.Count > 0 && e.RowIndex >= 0)
                {
                    int selectedrowindex = e.RowIndex;
                    DataGridViewRow selectedRow = dgvHelp.Rows[selectedrowindex];
                    txtDataload.Tag = Convert.ToString(selectedRow.Cells["ID"].Value);
                    txtDataload.Text = Convert.ToString(selectedRow.Cells[lblSearch.Text].Value);
                }
            }
        }

        private void dgvHelp_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dgvHelp.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
