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

namespace IMS
{
    public partial class frm_mid : Form
    {
        public frm_mid()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();

        }
       
        private void mnuCity_Click(object sender, EventArgs e)
        {
            frm_city newMDIChild = new frm_city();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnudistrict_Click(object sender, EventArgs e)
        {
            frm_district newMDIChild = new frm_district();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }

        private void mnuState_Click(object sender, EventArgs e)
        {
            frm_state newMDIChild = new frm_state();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnuCountry_Click(object sender, EventArgs e)
        {
            frm_country newMDIChild = new frm_country();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnutax_Click(object sender, EventArgs e)
        {
            frmtax newMDIChild = new frmtax();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }

        private void mnucompany_Click(object sender, EventArgs e)
        {
            frm_company newMDIChild = new frm_company();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnubank_Click(object sender, EventArgs e)
        {
            frm_bank newMDIChild = new  frm_bank();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnuentry_Click(object sender, EventArgs e)
        {
            frm_entry newMDIChild = new frm_entry();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void eNTRYNAMEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.txttime.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtdate.Text = DateTime.Now.ToString("hh:mm:sstt");
        }

        

        private void btn_create_user_Click(object sender, EventArgs e)
        {
            //frm_reg create = new frm_reg();
            //create.MdiParent = this;
            //create.Show();
        }

        private void btn_forgot_Click(object sender, EventArgs e)
        {
            //
        }
        private void mnuitem_REPORT_Click(object sender, EventArgs e)
        {
            frm_item newMDIChild = new frm_item();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnusize_Click(object sender, EventArgs e)
        {
            frmsize newMDIChild = new frmsize();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }

        private void sIZEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lbl_cname_Click(object sender, EventArgs e)
        {
            frmyearselection FRM = new frmyearselection();
            FRM.Show();
            this.Close();
        }

        private void lbl_fyear_Click(object sender, EventArgs e)
        {
            frmyearselection FRM = new frmyearselection();
            FRM.Show();
            this.Close();
        }
        private void mnuquotation_Click(object sender, EventArgs e)
        {
            //frm_qut newMDIChild = new frm_qut();
            //// Set the Parent Form of the Child window.
            //newMDIChild.MdiParent = this;

            //// Display the new form.
            //newMDIChild.Show();

            frm_quotation_list frm = new frm_quotation_list();
            frm.MdiParent = this;
            frm.Show();
        }
        private void mnuINVOICE_Click(object sender, EventArgs e)
        {
            frm_invoice_list newMDIChild = new frm_invoice_list();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
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
        public static int comp_id { get; set; }
        public static int year_id { get; set; }
        public static string User_name { get; set; }
        private void frm_mid_Load(object sender, EventArgs e)
        {
            User_name = frmyearselection.user_name;

            lbl_comp_tag.Tag = frmyearselection.item1;
            lbl_year_tag.Tag = frmyearselection.item2;
            comp_id = frmyearselection.item1;
            year_id = frmyearselection.item2;
            this.MaximizeBox = true;
            this.IsMdiContainer = true;
            //base.OnLoad(e);
            if (this.IsMdiContainer == true)
            {
                this.BackColor = Color.White;
            }
            lbl_cname.Text = frmyearselection.setcompanyname;
            lbl_fyear.Text = frmyearselection.company_year;

            //txtcompany.Text = Frmyearselection.setcompanyname;

            //frm_main_graph create = new frm_main_graph();
            //create.MdiParent = this;
            //create.Show();

        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult done = (MessageBox.Show("Are you sure want to EXIT this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (done == DialogResult.Yes)
            {

                Application.Exit();
            }
        }
        private void mnucalculater_Click(object sender, EventArgs e)
        {
            Calculater newMDIChild = new Calculater();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnuentrysetup_Click(object sender, EventArgs e)
        {
            frmentry_setup newMDIChild = new frmentry_setup();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnuCUSTOMER_Click(object sender, EventArgs e)
        {
            frmcustomer newMDIChild = new frmcustomer();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }

       

        private void btnprofile_Click(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.Show();
            this.Close();
        }

        private void tRANSACTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void mnuapproval_Click(object sender, EventArgs e)
        {
            frm_invoice_Approval newMDIChild = new frm_invoice_Approval();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnudebit_Click(object sender, EventArgs e)
        {
            //frm_credit_list newMDIChild = new frm_credit_list();
            //// Set the Parent Form of the Child window.
            //newMDIChild.MdiParent = this;

            //// Display the new form.
            //newMDIChild.Show();
        }
        private void mnupayment_Click(object sender, EventArgs e)
        {
            frm_payment_list newMDIChild = new frm_payment_list();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnuQUOTATION_Click(object sender, EventArgs e)
        {
            frm_quotation_report newMDIChild = new frm_quotation_report();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnuINVOICELIST_Click(object sender, EventArgs e)
        {
            frm_invoice_report newMDIChild = new frm_invoice_report();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnuPAYMENTLIST_Click(object sender, EventArgs e)
        {
            Frm_payment_report newMDIChild = new Frm_payment_report();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void mnuORDERLIST_Click(object sender, EventArgs e)
        {
            frm_Order_list newMDIChild = new frm_Order_list();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;

            // Display the new form.
            newMDIChild.Show();
        }
        private void sALESORDERToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cHANGEPASSWORDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_forgot create = new frm_forgot();
            create.MdiParent = this;
            create.Show();
        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_main_graph create = new frm_main_graph();
            create.MdiParent = this;
            create.Show();
        }
    }
}
