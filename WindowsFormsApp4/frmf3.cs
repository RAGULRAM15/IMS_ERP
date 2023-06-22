using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    public partial class frmf3 : Form
    {
        public frmf3()
        {
            InitializeComponent();
        }
        
        public void ShowF3(String _duplicte_name,String _value,object _Object)
        {
            lblsearch.Text = _duplicte_name;
            txt_load.Text = _value;
            _ct = _Object;
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            frm_credit credit = new frm_credit();
            credit.valuetoadd = this.txt_load.Text;
           
            this.Close();

        }
        public object _ct;
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_load.Text = "";
            this.Close();
        }

        private void frmf3_Load(object sender, EventArgs e)
        {

        }
    }
}
