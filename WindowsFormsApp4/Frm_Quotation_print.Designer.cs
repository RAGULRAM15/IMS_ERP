
namespace IMS
{
    partial class Frm_Quotation_print
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.M_COMPANY_VIEWBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUOTATIONDataSet1 = new IMS.QUOTATIONDataSet1();
            this.M_CUSTOMER_VIEWBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUOTATIONDataSet2 = new IMS.QUOTATIONDataSet2();
            this.T_QUOTATION_REPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QUOTATIONDataSet3 = new IMS.QUOTATIONDataSet3();
            this.T_QUOTATOIN_ITEM_REPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.T_QUOTATOIN_ITEM_REPORTTableAdapter = new IMS.QUOTATIONDataSet4TableAdapters.T_QUOTATOIN_ITEM_REPORTTableAdapter();
            this.M_COMPANY_VIEWTableAdapter = new IMS.QUOTATIONDataSet1TableAdapters.M_COMPANY_VIEWTableAdapter();
            this.M_CUSTOMER_VIEWTableAdapter = new IMS.QUOTATIONDataSet2TableAdapters.M_CUSTOMER_VIEWTableAdapter();
            this.T_QUOTATION_REPORTTableAdapter = new IMS.QUOTATIONDataSet3TableAdapters.T_QUOTATION_REPORTTableAdapter();
            this.QUOTATIONDataSet4 = new IMS.QUOTATIONDataSet4();
            ((System.ComponentModel.ISupportInitialize)(this.M_COMPANY_VIEWBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.M_CUSTOMER_VIEWBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_QUOTATION_REPORTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_QUOTATOIN_ITEM_REPORTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet4)).BeginInit();
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
            // T_QUOTATION_REPORTBindingSource
            // 
            this.T_QUOTATION_REPORTBindingSource.DataMember = "T_QUOTATION_REPORT";
            this.T_QUOTATION_REPORTBindingSource.DataSource = this.QUOTATIONDataSet3;
            // 
            // QUOTATIONDataSet3
            // 
            this.QUOTATIONDataSet3.DataSetName = "QUOTATIONDataSet3";
            this.QUOTATIONDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 6;
            reportDataSource5.Name = "dtset_Quotation_report";
            reportDataSource5.Value = this.M_COMPANY_VIEWBindingSource;
            reportDataSource6.Name = "dtset_Quotation_report1";
            reportDataSource6.Value = this.M_CUSTOMER_VIEWBindingSource;
            reportDataSource7.Name = "dtset_Quotation_report2";
            reportDataSource7.Value = this.T_QUOTATION_REPORTBindingSource;
            reportDataSource8.Name = "dtset_Quotation_report3";
            reportDataSource8.Value = this.T_QUOTATOIN_ITEM_REPORTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "IMS.Rpt_Quototion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // T_QUOTATOIN_ITEM_REPORTTableAdapter
            // 
            this.T_QUOTATOIN_ITEM_REPORTTableAdapter.ClearBeforeFill = true;
            // 
            // M_COMPANY_VIEWTableAdapter
            // 
            this.M_COMPANY_VIEWTableAdapter.ClearBeforeFill = true;
            // 
            // M_CUSTOMER_VIEWTableAdapter
            // 
            this.M_CUSTOMER_VIEWTableAdapter.ClearBeforeFill = true;
            // 
            // T_QUOTATION_REPORTTableAdapter
            // 
            this.T_QUOTATION_REPORTTableAdapter.ClearBeforeFill = true;
            // 
            // QUOTATIONDataSet4
            // 
            this.QUOTATIONDataSet4.DataSetName = "QUOTATIONDataSet4";
            this.QUOTATIONDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Frm_Quotation_print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "Frm_Quotation_print";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "preview";
            this.Load += new System.EventHandler(this.Frm_Quotation_print_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Quotation_print_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.M_COMPANY_VIEWBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.M_CUSTOMER_VIEWBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_QUOTATION_REPORTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.T_QUOTATOIN_ITEM_REPORTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QUOTATIONDataSet4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        //private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private QUOTATIONDataSet4TableAdapters.T_QUOTATOIN_ITEM_REPORTTableAdapter T_QUOTATOIN_ITEM_REPORTTableAdapter;
        private System.Windows.Forms.BindingSource M_COMPANY_VIEWBindingSource;
        private QUOTATIONDataSet1 QUOTATIONDataSet1;
        private System.Windows.Forms.BindingSource M_CUSTOMER_VIEWBindingSource;
        private QUOTATIONDataSet2 QUOTATIONDataSet2;
        private QUOTATIONDataSet3 QUOTATIONDataSet3;
        private System.Windows.Forms.BindingSource T_QUOTATOIN_ITEM_REPORTBindingSource;
        private QUOTATIONDataSet1TableAdapters.M_COMPANY_VIEWTableAdapter M_COMPANY_VIEWTableAdapter;
        private QUOTATIONDataSet2TableAdapters.M_CUSTOMER_VIEWTableAdapter M_CUSTOMER_VIEWTableAdapter;
        private System.Windows.Forms.BindingSource T_QUOTATION_REPORTBindingSource;
        private QUOTATIONDataSet3TableAdapters.T_QUOTATION_REPORTTableAdapter T_QUOTATION_REPORTTableAdapter;
        private QUOTATIONDataSet4 QUOTATIONDataSet4;
    }
}