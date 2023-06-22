using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    
    public partial class frmQouation_old : Form
    {
        public frmQouation_old()
        {
            InitializeComponent();
        }

        DataTable table;

        private void frmQouation_Load(object sender, EventArgs e)
        {
            table = new DataTable();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            table.Columns.Add("City", typeof(string));

            table.Rows.Add(1, "Leon","Ardon","Paris");
            table.Rows.Add((2, "Ben", "Jamir", "London");
            table.Rows.Add((3, "Samuel", "Toe", "Berlin");
            table.Rows.Add((4, "Lila", "Foe", "Madrid");

            dgvItemList.DataSource = table;
        }

        private void dgvItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
