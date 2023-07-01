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
using Microsoft.Reporting.WinForms;

namespace IMS
{
    public partial class Frm_Quotation_print : Form
    {
        private const string dirreportPath = @"C:\Report";
        private const string reportPath = "Rpt_Quotation.rdlc";
        public Frm_Quotation_print()
        {
            InitializeComponent();
        }
        public string customer { get; set; }
        public string value1 { get; set; }
        public int company { get; set; }
        public string mode { get; set; }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";
        private void Frm_Quotation_print_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QUOTATIONDataSet1.M_COMPANY_VIEW' table. You can move, or remove it, as needed.
           // this.M_COMPANY_VIEWTableAdapter.Fill(this.QUOTATIONDataSet1.M_COMPANY_VIEW);
            // TODO: This line of code loads data into the 'QUOTATIONDataSet2.M_CUSTOMER_VIEW' table. You can move, or remove it, as needed.
           // this.M_CUSTOMER_VIEWTableAdapter.Fill(this.QUOTATIONDataSet2.M_CUSTOMER_VIEW);
            // TODO: This line of code loads data into the 'QUOTATIONDataSet3.T_QUOTATION_REPORT' table. You can move, or remove it, as needed.
            //this.T_QUOTATION_REPORTTableAdapter.Fill(this.QUOTATIONDataSet3.T_QUOTATION_REPORT);
            // TODO: This line of code loads data into the 'QUOTATIONDataSet4.T_QUOTATOIN_ITEM_REPORT' table. You can move, or remove it, as needed.
            //this.T_QUOTATOIN_ITEM_REPORTTableAdapter.Fill(this.QUOTATIONDataSet4.T_QUOTATOIN_ITEM_REPORT);
            customer = frm_quotation_list.CUSTOMER;
            value1 = frm_quotation_list.value1;
            company = frm_quotation_list.camp_id;
            if (mode == "PRINT QUOTATION")
            {


                String SQLQuery = "SELECT * FROM T_QUOTATOIN_ITEM_REPORT" +
                 " WHERE QUOTATION_NO = '" + value1 + "' ";
                String sqlquery = "SELECT * FROM T_QUOTATION_REPORT" +
                    " WHERE QUOTATION_NO = '" + value1 + "'";
                String SQLQUERY = "SELECT * FROM M_COMPANY_VIEW" +
                    " WHERE COMPANY_ID =" + company + "";
                string sqlQuery = "SELECT * FROM M_CUSTOMER_VIEW" +
                    " WHERE CUSTOMER_NAME = '" + customer + "'";
                SqlDataAdapter da = new SqlDataAdapter(SQLQuery, ConnString);
                QUOTATIONDataSet4 ds = new QUOTATIONDataSet4();
                da.Fill(ds, "T_QUOTATOIN_ITEM_REPORT");
                SqlDataAdapter da1 = null;
                 da1 = new SqlDataAdapter(sqlquery, ConnString);
                QUOTATIONDataSet3 ds1 = new QUOTATIONDataSet3();
                da1.Fill(ds1, QUOTATIONDataSet3.T_QUOTATION_REPORT.TableName);
                SqlDataAdapter da2 = new SqlDataAdapter(SQLQUERY, ConnString);
                QUOTATIONDataSet ds2 = new QUOTATIONDataSet();
                da2.Fill(ds2, "M_COMPANY_VIEW");
                SqlDataAdapter da3 = null;
                 da3 = new SqlDataAdapter(sqlQuery, ConnString);
                QUOTATIONDataSet1 ds3 = new QUOTATIONDataSet1();
                da3.Fill(ds3, QUOTATIONDataSet2.M_CUSTOMER_VIEW.TableName);
                ReportDataSource dataSource3 = new ReportDataSource("dtset_Quotation_report", ds2.Tables[0]);
                ReportDataSource dataSource = new ReportDataSource("dtset_Quotation_report3", ds.Tables[0]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(dataSource3);


                ReportDataSource dataSource1 = null;
                 dataSource1 = new ReportDataSource("dtset_Quotation_report2", ds1.Tables[0]);
                ReportDataSource dataSource2 = null;
                 dataSource2 = new ReportDataSource("dtset_Quotation_report1", ds3.Tables["M_CUSTOMER_VIEW"]);
               

                this.reportViewer1.LocalReport.DataSources.Add(dataSource1);
                this.reportViewer1.LocalReport.DataSources.Add(dataSource2);
                this.reportViewer1.LocalReport.DataSources.Add(dataSource);
                
               // this.reportViewer1.Width = 75;
               // reportViewer1.ProcessingMode = ProcessingMode.Local;
               // reportViewer1.SetPageSettings(new System.Drawing.Printing.PageSettings
               // {
               //     PaperSize= new System.Drawing.Printing.PaperSize("A4",827,1169),
               //     Margins = new System.Drawing.Printing.Margins(0,0,0,0)
               // });
               //// LoadandAdjustReport();
                this.reportViewer1.RefreshReport();
            }
            // this.reportViewer1.RefreshReport();
            // this.reportViewer3.RefreshReport();
        }
        private void LoadandAdjustReport()
        {
            
            //byte[] reportDefinition = System.IO.File.ReadAllBytes(reportPath);
            //String reportDefinitionXml = System.Text.Encoding.UTF8.GetString(reportDefinition);
            //reportDefinitionXml = reportDefinitionXml.Replace("<Width>8.5in</Width>", "<Width>8.27in</Width>");
            //reportDefinition = System.Text.Encoding.UTF8.GetBytes(reportDefinitionXml);
            //using(var stream = new System.IO.MemoryStream(reportDefinition))
            //{
            //    reportViewer1.LocalReport.LoadReportDefinition(stream);
            //}
        }
       
        public void print_form()
        {

           
        }
        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer3_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           
        }

        private void Frm_Quotation_print_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                this.Close();
            }
        }
    }
}
