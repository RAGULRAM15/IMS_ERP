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
    public partial class frmf2 : Form
    {
        public frmf2()
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
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
           (int nTop,
            int nLeft,
            int nRight,
            int nBottum,
            int nWidthEllipse,
            int nHeightEllipse
           );
        private void frmf2_Load(object sender, EventArgs e)
        {
            //btnok.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnok.Width, btnok.Height, 20, 20));
            //btnclose.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnclose.Width, btnclose.Height, 20, 20));
            //dgvHelp.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, dgvHelp.Width, dgvHelp.Height, 20, 20));
        }

        private void dgvHelp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowF2(string _sqlQuery, string _DispColName, string _txtValue, string _SearchName, object _Object)
        {
            txtSearch.Text = _txtValue; txtDataload.Text = _txtValue;
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
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Grid fillter
           //// DataView dv = ds.Tables[0].DefaultView;
           // dv.RowFilter = lblSearch.Text + " LIKE '" + txtSearch.Text.ToString() + "%'";
           // dgvHelp.DataSource = dv;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            _myText = txtSearch.Text;
            ((TextBox)_ct).Tag = txtDataload.Tag;
            ((TextBox)_ct).Text = txtDataload.Text;
            this.Close();
        }

        private void dgvHelp_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvHelp.Rows.Count > 0)
            //{
            //    int selectedrowindex = ;//dgvHelp.SelectedCells[0].RowIndex;
            //    DataGridViewRow selectedRow = dgvHelp.Rows[selectedrowindex];
            //    txtDataload.Tag = Convert.ToString(selectedRow.Cells["ID"].Value);
            //    txtDataload.Text = Convert.ToString(selectedRow.Cells[lblSearch.Text].Value);
            //}
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
            if (dgvHelp.Rows.Count > 0 && e.RowIndex >= 0)
            {
                int selectedrowindex = e.RowIndex;
                DataGridViewRow selectedRow = dgvHelp.Rows[selectedrowindex];
                txtDataload.Tag = Convert.ToString(selectedRow.Cells["ID"].Value);
                txtDataload.Text = Convert.ToString(selectedRow.Cells[lblSearch.Text].Value);
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
