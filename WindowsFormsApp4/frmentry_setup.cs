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
    public partial class frmentry_setup : Form
    {
        public frmentry_setup()
        {
            InitializeComponent();
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
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
        private void frmentry_setup_Load(object sender, EventArgs e)
        {

            //String c;
           
            String str = "SELECT ENTRY_SETUP_ID AS [ID],M_FY_YEAR.FY_YEAR,M_COMPANY.COMPANY_NAME,M_ENTRY.ENTRY_NAME,PREFIIX,RESET_BY,LAST_NO FROM  M_ENTRY_SETUP INNER JOIN M_FY_YEAR  ON M_ENTRY_SETUP.ACTIVE = M_FY_YEAR.ACTIVE INNER JOIN M_COMPANY  ON M_ENTRY_SETUP.ACTIVE = M_COMPANY.ACTIVE INNER JOIN M_ENTRY  ON M_ENTRY_SETUP.ACTIVE = M_ENTRY.ACTIVE WHERE M_FY_YEAR.FY_YEAR_ID = M_ENTRY_SETUP.FY_YEAR_ID AND M_COMPANY.COMPANY_ID = M_ENTRY_SETUP.COMPANY_ID AND M_ENTRY.ENTRY_ID = M_ENTRY_SETUP.ENTRY_ID";



            using (SqlConnection conn = new SqlConnection(ConnString))
            {

                using (SqlCommand comm = conn.CreateCommand())
                {
                    //comm.Connection = conn;
                    //comm.CommandText = str;
                    conn.Open();
                    comm.CommandText = str;
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dtg_entrysetup.DataSource = ds.Tables[0].DefaultView;
                    conn.Close();
                }
            }
        }

        private void dtg_entrysetup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmentry_setup_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmentry_setup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
            }



        }

        private void dtg_entrysetup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dtg_entrysetup.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
