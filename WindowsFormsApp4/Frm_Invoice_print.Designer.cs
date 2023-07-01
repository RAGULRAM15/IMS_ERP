
namespace IMS
{
    partial class Frm_Invoice_print
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.M_COMPANY_VIEWBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUOTATIONDataSet1 = new IMS.QUOTATIONDataSet1();
            this.M_CUSTOMER_VIEWBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUOTATIONDataSet2 = new IMS.QUOTATIONDataSet2();
            this.T_INVOICE_REPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUOTATIONDataSet5 = new IMS.QUOTATIONDataSet5();
            this.T_INVOICE_ITEM_REPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUOTATIONDataSet6 = new IMS.QUOTATIONDataSet6();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.M_COMPANY_VIEWTableAdapter = new IMS.QUOTATIONDataSet1TableAdapters.M_COMPANY_VIEWTableAdapter();
            this.M_CUSTOMER_VIEWTableAdapter = new IMS.QUOTATIONDataSet2TableAdapters.M_CUSTOMER_VIEWTableAdapter();
            this.T_INVOICE_REPORTTableAdapter = new IMS.QUOTATIONDataSet5TableAdapters.T_INVOICE_REPORTTableAdapter();
            this.T_INVOICE_ITEM_REPORTTableAdapter = new IMS.QUOTATIONDataSet6TableAdapters.T_INVOICE_ITEM_REPORTTableAdapter();
            this.QUOTATIONDataSet7 = new IMS.QUOTATIONDataSet7();
            ((System.ComponentModel.ISupportInitialize)(this.M_COMPANY_VIEWBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M_CUSTOMER_VIEWBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_INVOICE_REPORTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_INVOICE_ITEM_REPORTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet7)).BeginInit();
            this.SuspendLayout();
            // 
            // M_COMPANY_VIEWBindingSource
            // 
            this.M_COMPANY_VIEWBindingSource.DataMember = "M_COMPANY_VIEW";
            this.M_COMPANY_VIEWBindingSource.DataSource = this.QUOTATIONDataSet1;
            // 
            // QUOTATIONDataSet1
            // 
            this.QUOTATIONDataSet1.DataSetName = "QUOTATIONDataSet1";
            this.QUOTATIONDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // M_CUSTOMER_VIEWBindingSource
            // 
            this.M_CUSTOMER_VIEWBindingSource.DataMember = "M_CUSTOMER_VIEW";
            this.M_CUSTOMER_VIEWBindingSource.DataSource = this.QUOTATIONDataSet2;
            // 
            // QUOTATIONDataSet2
            // 
            this.QUOTATIONDataSet2.DataSetName = "QUOTATIONDataSet2";
            this.QUOTATIONDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // T_INVOICE_REPORTBindingSource
            // 
            this.T_INVOICE_REPORTBindingSource.DataMember = "T_INVOICE_REPORT";
            this.T_INVOICE_REPORTBindingSource.DataSource = this.QUOTATIONDataSet5;
            // 
            // QUOTATIONDataSet5
            // 
            this.QUOTATIONDataSet5.DataSetName = "QUOTATIONDataSet5";
            this.QUOTATIONDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // T_INVOICE_ITEM_REPORTBindingSource
            // 
            this.T_INVOICE_ITEM_REPORTBindingSource.DataMember = "T_INVOICE_ITEM_REPORT";
            this.T_INVOICE_ITEM_REPORTBindingSource.DataSource = this.QUOTATIONDataSet6;
            // 
            // QUOTATIONDataSet6
            // 
            this.QUOTATIONDataSet6.DataSetName = "QUOTATIONDataSet6";
            this.QUOTATIONDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dtset_Quotation_report";
            reportDataSource1.Value = this.M_COMPANY_VIEWBindingSource;
            reportDataSource2.Name = "dtset_Quotation_report1";
            reportDataSource2.Value = this.M_CUSTOMER_VIEWBindingSource;
            reportDataSource3.Name = "dtset_invoice_report2";
            reportDataSource3.Value = this.T_INVOICE_REPORTBindingSource;
            reportDataSource4.Name = "dtset_invoice_report3";
            reportDataSource4.Value = this.T_INVOICE_ITEM_REPORTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS.Rpt_Invoice.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // M_COMPANY_VIEWTableAdapter
            // 
            this.M_COMPANY_VIEWTableAdapter.ClearBeforeFill = true;
            // 
            // M_CUSTOMER_VIEWTableAdapter
            // 
            this.M_CUSTOMER_VIEWTableAdapter.ClearBeforeFill = true;
            // 
            // T_INVOICE_REPORTTableAdapter
            // 
            this.T_INVOICE_REPORTTableAdapter.ClearBeforeFill = true;
            // 
            // T_INVOICE_ITEM_REPORTTableAdapter
            // 
            this.T_INVOICE_ITEM_REPORTTableAdapter.ClearBeforeFill = true;
            // 
            // QUOTATIONDataSet7
            // 
            this.QUOTATIONDataSet7.DataSetName = "QUOTATIONDataSet7";
            this.QUOTATIONDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Frm_Invoice_print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_Invoice_print";
            this.Text = "Frm_Invoice_print";
            this.Load += new System.EventHandler(this.Frm_Invoice_print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.M_COMPANY_VIEWBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M_CUSTOMER_VIEWBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_INVOICE_REPORTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_INVOICE_ITEM_REPORTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource M_COMPANY_VIEWBindingSource;
        private QUOTATIONDataSet1 QUOTATIONDataSet1;
        private System.Windows.Forms.BindingSource M_CUSTOMER_VIEWBindingSource;
        private QUOTATIONDataSet2 QUOTATIONDataSet2;
        private System.Windows.Forms.BindingSource T_INVOICE_REPORTBindingSource;
        private QUOTATIONDataSet5 QUOTATIONDataSet5;
        private System.Windows.Forms.BindingSource T_INVOICE_ITEM_REPORTBindingSource;
        private QUOTATIONDataSet6 QUOTATIONDataSet6;
        private QUOTATIONDataSet1TableAdapters.M_COMPANY_VIEWTableAdapter M_COMPANY_VIEWTableAdapter;
        private QUOTATIONDataSet2TableAdapters.M_CUSTOMER_VIEWTableAdapter M_CUSTOMER_VIEWTableAdapter;
        private QUOTATIONDataSet5TableAdapters.T_INVOICE_REPORTTableAdapter T_INVOICE_REPORTTableAdapter;
        private QUOTATIONDataSet6TableAdapters.T_INVOICE_ITEM_REPORTTableAdapter T_INVOICE_ITEM_REPORTTableAdapter;
        private QUOTATIONDataSet7 QUOTATIONDataSet7;
    }
}