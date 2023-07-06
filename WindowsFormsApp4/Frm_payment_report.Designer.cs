
namespace IMS
{
    partial class Frm_payment_report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_payment_report));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_to = new System.Windows.Forms.DateTimePicker();
            this.txt_from = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_company = new System.Windows.Forms.TextBox();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.dtg_pay_report = new System.Windows.Forms.DataGridView();
            this.INVOICE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYMENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYMENT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYMENT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NET_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREDIT_NOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BALANCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_customer = new System.Windows.Forms.TextBox();
            this.rbtn_pay = new System.Windows.Forms.RadioButton();
            this.rbtn_inv = new System.Windows.Forms.RadioButton();
            this.btn_gridview = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_reset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_paid = new System.Windows.Forms.TextBox();
            this.txt_balance = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_pay_report)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_to
            // 
            this.txt_to.CustomFormat = "dd/MM/yyyy";
            this.txt_to.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txt_to.Location = new System.Drawing.Point(47, 83);
            this.txt_to.Name = "txt_to";
            this.txt_to.Size = new System.Drawing.Size(147, 21);
            this.txt_to.TabIndex = 118;
            this.txt_to.Value = new System.DateTime(2023, 3, 20, 0, 0, 0, 0);
            // 
            // txt_from
            // 
            this.txt_from.CustomFormat = "dd/MM/yyyy";
            this.txt_from.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txt_from.Location = new System.Drawing.Point(47, 34);
            this.txt_from.Name = "txt_from";
            this.txt_from.Size = new System.Drawing.Size(147, 21);
            this.txt_from.TabIndex = 117;
            this.txt_from.Value = new System.DateTime(2023, 3, 20, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(102, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 119;
            this.label8.Text = "TO";
            // 
            // txt_company
            // 
            this.txt_company.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_company.Location = new System.Drawing.Point(316, 30);
            this.txt_company.Name = "txt_company";
            this.txt_company.ReadOnly = true;
            this.txt_company.Size = new System.Drawing.Size(228, 25);
            this.txt_company.TabIndex = 116;
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // dtg_pay_report
            // 
            this.dtg_pay_report.AllowUserToAddRows = false;
            this.dtg_pay_report.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_pay_report.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.dtg_pay_report.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_pay_report.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_pay_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_pay_report.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INVOICE_ID,
            this.PAYMENT_ID,
            this.INVOICE_NO,
            this.PAYMENT_NO,
            this.PAYMENT_DATE,
            this.INVOICE_DATE,
            this.CUSTOMER_NAME,
            this.NET_AMOUNT,
            this.PAID,
            this.CREDIT_NOTE,
            this.BALANCE});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_pay_report.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtg_pay_report.Location = new System.Drawing.Point(-1, 143);
            this.dtg_pay_report.Name = "dtg_pay_report";
            this.dtg_pay_report.ReadOnly = true;
            this.dtg_pay_report.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_pay_report.Size = new System.Drawing.Size(1071, 286);
            this.dtg_pay_report.TabIndex = 115;
            this.dtg_pay_report.Visible = false;
            this.dtg_pay_report.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtg_pay_report_DataBindingComplete);
            // 
            // INVOICE_ID
            // 
            this.INVOICE_ID.DataPropertyName = "INVOICE_ID";
            this.INVOICE_ID.HeaderText = "INVOICE_ID";
            this.INVOICE_ID.Name = "INVOICE_ID";
            this.INVOICE_ID.ReadOnly = true;
            this.INVOICE_ID.Visible = false;
            // 
            // PAYMENT_ID
            // 
            this.PAYMENT_ID.DataPropertyName = "PAYMENT_ID";
            this.PAYMENT_ID.HeaderText = "PAYMENT_ID";
            this.PAYMENT_ID.Name = "PAYMENT_ID";
            this.PAYMENT_ID.ReadOnly = true;
            this.PAYMENT_ID.Visible = false;
            // 
            // INVOICE_NO
            // 
            this.INVOICE_NO.DataPropertyName = "INVOICE_NO";
            this.INVOICE_NO.HeaderText = "INVOICE_NO";
            this.INVOICE_NO.Name = "INVOICE_NO";
            this.INVOICE_NO.ReadOnly = true;
            // 
            // PAYMENT_NO
            // 
            this.PAYMENT_NO.DataPropertyName = "PAYMENT_NO";
            this.PAYMENT_NO.HeaderText = "PAYMENT NO";
            this.PAYMENT_NO.Name = "PAYMENT_NO";
            this.PAYMENT_NO.ReadOnly = true;
            // 
            // PAYMENT_DATE
            // 
            this.PAYMENT_DATE.DataPropertyName = "PAYMENT_DATE";
            this.PAYMENT_DATE.HeaderText = "PAYMENT DATE";
            this.PAYMENT_DATE.Name = "PAYMENT_DATE";
            this.PAYMENT_DATE.ReadOnly = true;
            // 
            // INVOICE_DATE
            // 
            this.INVOICE_DATE.DataPropertyName = "INVOICE_DATE";
            this.INVOICE_DATE.HeaderText = "INVOICE_DATE";
            this.INVOICE_DATE.Name = "INVOICE_DATE";
            this.INVOICE_DATE.ReadOnly = true;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.HeaderText = "CUSTOMER NAME";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            // 
            // NET_AMOUNT
            // 
            this.NET_AMOUNT.DataPropertyName = "NET_AMOUNT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NET_AMOUNT.DefaultCellStyle = dataGridViewCellStyle2;
            this.NET_AMOUNT.HeaderText = "NET AMOUNT";
            this.NET_AMOUNT.Name = "NET_AMOUNT";
            this.NET_AMOUNT.ReadOnly = true;
            // 
            // PAID
            // 
            this.PAID.DataPropertyName = "PAID";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PAID.DefaultCellStyle = dataGridViewCellStyle3;
            this.PAID.HeaderText = "PAID";
            this.PAID.Name = "PAID";
            this.PAID.ReadOnly = true;
            // 
            // CREDIT_NOTE
            // 
            this.CREDIT_NOTE.DataPropertyName = "CREDIT_NOTE";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CREDIT_NOTE.DefaultCellStyle = dataGridViewCellStyle4;
            this.CREDIT_NOTE.HeaderText = "CREDIT NOTE";
            this.CREDIT_NOTE.Name = "CREDIT_NOTE";
            this.CREDIT_NOTE.ReadOnly = true;
            // 
            // BALANCE
            // 
            this.BALANCE.DataPropertyName = "BALANCE";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BALANCE.DefaultCellStyle = dataGridViewCellStyle5;
            this.BALANCE.HeaderText = "BALANCE";
            this.BALANCE.Name = "BALANCE";
            this.BALANCE.ReadOnly = true;
            // 
            // txt_total
            // 
            this.txt_total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.txt_total.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_total.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.Location = new System.Drawing.Point(613, 443);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(109, 22);
            this.txt_total.TabIndex = 106;
            this.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_total.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 105;
            this.label2.Text = "COMPANY";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "CUSTOMER";
            // 
            // txt_customer
            // 
            this.txt_customer.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_customer.Location = new System.Drawing.Point(316, 85);
            this.txt_customer.Name = "txt_customer";
            this.txt_customer.Size = new System.Drawing.Size(228, 25);
            this.txt_customer.TabIndex = 103;
            this.txt_customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_customer_KeyDown);
            // 
            // rbtn_pay
            // 
            this.rbtn_pay.AutoSize = true;
            this.rbtn_pay.Checked = true;
            this.rbtn_pay.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_pay.Location = new System.Drawing.Point(575, 34);
            this.rbtn_pay.Name = "rbtn_pay";
            this.rbtn_pay.Size = new System.Drawing.Size(77, 20);
            this.rbtn_pay.TabIndex = 120;
            this.rbtn_pay.TabStop = true;
            this.rbtn_pay.Text = "PAYMENT";
            this.rbtn_pay.UseVisualStyleBackColor = true;
            // 
            // rbtn_inv
            // 
            this.rbtn_inv.AutoSize = true;
            this.rbtn_inv.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_inv.Location = new System.Drawing.Point(575, 76);
            this.rbtn_inv.Name = "rbtn_inv";
            this.rbtn_inv.Size = new System.Drawing.Size(72, 20);
            this.rbtn_inv.TabIndex = 121;
            this.rbtn_inv.Text = "INVOICE";
            this.rbtn_inv.UseVisualStyleBackColor = true;
            // 
            // btn_gridview
            // 
            this.btn_gridview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_gridview.BackgroundImage")));
            this.btn_gridview.FlatAppearance.BorderSize = 0;
            this.btn_gridview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_gridview.Location = new System.Drawing.Point(693, 33);
            this.btn_gridview.Name = "btn_gridview";
            this.btn_gridview.Size = new System.Drawing.Size(60, 69);
            this.btn_gridview.TabIndex = 107;
            this.btn_gridview.UseVisualStyleBackColor = true;
            this.btn_gridview.Click += new System.EventHandler(this.btn_gridview_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close.BackgroundImage")));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(973, 44);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(47, 46);
            this.btn_close.TabIndex = 108;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_reset
            // 
            this.btn_reset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_reset.BackgroundImage")));
            this.btn_reset.FlatAppearance.BorderSize = 0;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Location = new System.Drawing.Point(889, 43);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(47, 47);
            this.btn_reset.TabIndex = 109;
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(897, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 110;
            this.label4.Text = "RESET";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(973, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 111;
            this.label3.Text = "CLOSE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(690, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 112;
            this.label5.Text = " GRID VIEW";
            // 
            // btn_print
            // 
            this.btn_print.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_print.BackgroundImage")));
            this.btn_print.FlatAppearance.BorderSize = 0;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_print.Location = new System.Drawing.Point(798, 49);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(47, 47);
            this.btn_print.TabIndex = 113;
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(786, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 114;
            this.label7.Text = "PRINT VIEW";
            // 
            // txt_paid
            // 
            this.txt_paid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.txt_paid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_paid.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_paid.Location = new System.Drawing.Point(739, 443);
            this.txt_paid.Name = "txt_paid";
            this.txt_paid.Size = new System.Drawing.Size(106, 22);
            this.txt_paid.TabIndex = 122;
            this.txt_paid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_paid.Visible = false;
            // 
            // txt_balance
            // 
            this.txt_balance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.txt_balance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_balance.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_balance.Location = new System.Drawing.Point(964, 443);
            this.txt_balance.Name = "txt_balance";
            this.txt_balance.Size = new System.Drawing.Size(106, 22);
            this.txt_balance.TabIndex = 123;
            this.txt_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_balance.Visible = false;
            // 
            // Frm_payment_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(184)))), ((int)(((byte)(194)))));
            this.ClientSize = new System.Drawing.Size(1070, 477);
            this.Controls.Add(this.txt_balance);
            this.Controls.Add(this.txt_paid);
            this.Controls.Add(this.rbtn_inv);
            this.Controls.Add(this.rbtn_pay);
            this.Controls.Add(this.txt_to);
            this.Controls.Add(this.txt_from);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_company);
            this.Controls.Add(this.dtg_pay_report);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_gridview);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_customer);
            this.KeyPreview = true;
            this.Name = "Frm_payment_report";
            this.Text = "Payment Report";
            this.Load += new System.EventHandler(this.Frm_payment_report_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_payment_report_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_pay_report)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker txt_to;
        private System.Windows.Forms.DateTimePicker txt_from;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_company;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.DataGridView dtg_pay_report;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_customer;
        private System.Windows.Forms.RadioButton rbtn_pay;
        private System.Windows.Forms.RadioButton rbtn_inv;
        private System.Windows.Forms.Button btn_gridview;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYMENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYMENT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYMENT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn NET_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREDIT_NOTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BALANCE;
        private System.Windows.Forms.TextBox txt_paid;
        private System.Windows.Forms.TextBox txt_balance;
    }
}