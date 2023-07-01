using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    public partial class Frm_Invoice_print : Form
    {
        public Frm_Invoice_print()
        {
            InitializeComponent();
        }
        public string customer { get; set; }
        public string value1 { get; set; }
        public int company { get; set; }
        public string mode { get; set; }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=QUOTATION;Integrated Security=True";

        private void Frm_Invoice_print_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QUOTATIONDataSet1.M_COMPANY_VIEW' table. You can move, or remove it, as needed.
            //this.M_COMPANY_VIEWTableAdapter.Fill(this.QUOTATIONDataSet1.M_COMPANY_VIEW);
            //// TODO: This line of code loads data into the 'QUOTATIONDataSet2.M_CUSTOMER_VIEW' table. You can move, or remove it, as needed.
            //this.M_CUSTOMER_VIEWTableAdapter.Fill(this.QUOTATIONDataSet2.M_CUSTOMER_VIEW);
            //// TODO: This line of code loads data into the 'QUOTATIONDataSet5.T_INVOICE_REPORT' table. You can move, or remove it, as needed.
            //this.T_INVOICE_REPORTTableAdapter.Fill(this.QUOTATIONDataSet5.T_INVOICE_REPORT);
            //// TODO: This line of code loads data into the 'QUOTATIONDataSet6.T_INVOICE_ITEM_REPORT' table. You can move, or remove it, as needed.
            //this.T_INVOICE_ITEM_REPORTTableAdapter.Fill(this.QUOTATIONDataSet6.T_INVOICE_ITEM_REPORT);

            //this.reportViewer1.RefreshReport();
            customer = frm_invoice_list.CUSTOMER;
            value1 = frm_invoice_list.value1;
            company = frm_invoice_list.comp_id;
            if (mode == "PRINT INVOICE")
            {


                String SQLQuery = "SELECT * FROM T_INVOICE_ITEM_REPORT" +
                 " WHERE INVOICE_NO = '" + value1 + "' ";
                String sqlquery = "SELECT * FROM T_INVOICE_REPORT" +
                    " WHERE INVOICE_NO = '" + value1 + "'";
                String SQLQUERY = "SELECT * FROM M_COMPANY_VIEW" +
                    " WHERE COMPANY_ID =" + company + "";
                string sqlQuery = "SELECT * FROM M_CUSTOMER_VIEW" +
                    " WHERE CUSTOMER_NAME = '" + customer + "'";
                SqlDataAdapter da = new SqlDataAdapter(SQLQuery, ConnString);
                QUOTATIONDataSet6 ds = new QUOTATIONDataSet6();
                da.Fill(ds, QUOTATIONDataSet6.T_INVOICE_ITEM_REPORT.TableName);
                SqlDataAdapter da1 = null;
                da1 = new SqlDataAdapter(sqlquery, ConnString);
                QUOTATIONDataSet7 ds1 = new QUOTATIONDataSet7();
                da1.Fill(ds1, QUOTATIONDataSet7.T_INVOICE_REPORT.TableName);
                SqlDataAdapter da2 = new SqlDataAdapter(SQLQUERY, ConnString);
                QUOTATIONDataSet ds2 = new QUOTATIONDataSet();
                da2.Fill(ds2, QUOTATIONDataSet1.M_COMPANY_VIEW.TableName);
                SqlDataAdapter da3 = null;
                da3 = new SqlDataAdapter(sqlQuery, ConnString);
                QUOTATIONDataSet1 ds3 = new QUOTATIONDataSet1();
                da3.Fill(ds3, QUOTATIONDataSet2.M_CUSTOMER_VIEW.TableName);
                ReportDataSource dataSource3 = new ReportDataSource("dtset_Quotation_report", ds2.Tables[0]);
                
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(dataSource3);

                ReportDataSource dataSource = new ReportDataSource("dtset_invoice_report3", ds.Tables[0]);
                ReportDataSource dataSource1 = null;
                dataSource1 = new ReportDataSource("dtset_invoice_report2", ds1.Tables[0]);
                ReportDataSource dataSource2 = null;
                dataSource2 = new ReportDataSource("dtset_Quotation_report1", ds3.Tables["M_CUSTOMER_VIEW"]);


                this.reportViewer1.LocalReport.DataSources.Add(dataSource1);
                this.reportViewer1.LocalReport.DataSources.Add(dataSource2);
                this.reportViewer1.LocalReport.DataSources.Add(dataSource);
                this.reportViewer1.RefreshReport();
            }

        }
    }
}
