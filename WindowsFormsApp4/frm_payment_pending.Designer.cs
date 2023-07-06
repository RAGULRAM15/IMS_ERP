
namespace IMS
{
    partial class frm_payment_pending
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_payment_pending));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_to = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_company = new System.Windows.Forms.TextBox();
            this.txt_from = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.dtg_pay_pending = new System.Windows.Forms.DataGridView();
            this.btn_reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_customer = new System.Windows.Forms.TextBox();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_gridview = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_balance = new System.Windows.Forms.TextBox();
            this.txt_paid = new System.Windows.Forms.TextBox();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.PAYMENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYMENT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYMENT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NET_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREDIT_NOTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BALANCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_pay_pending)).BeginInit();
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
            this.txt_to.TabIndex = 135;
            this.txt_to.Value = new System.DateTime(2023, 3, 20, 0, 0, 0, 0);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(102, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 136;
            this.label8.Text = "TO";
            // 
            // txt_company
            // 
            this.txt_company.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_company.Location = new System.Drawing.Point(430, 30);
            this.txt_company.Name = "txt_company";
            this.txt_company.ReadOnly = true;
            this.txt_company.Size = new System.Drawing.Size(228, 25);
            this.txt_company.TabIndex = 133;
            // 
            // txt_from
            // 
            this.txt_from.CustomFormat = "dd/MM/yyyy";
            this.txt_from.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txt_from.Location = new System.Drawing.Point(47, 34);
            this.txt_from.Name = "txt_from";
            this.txt_from.Size = new System.Drawing.Size(147, 21);
            this.txt_from.TabIndex = 134;
            this.txt_from.Value = new System.DateTime(2023, 3, 20, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(881, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 131;
            this.label7.Text = "PRINT VIEW";
            // 
            // btn_print
            // 
            this.btn_print.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_print.BackgroundImage")));
            this.btn_print.FlatAppearance.BorderSize = 0;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_print.Location = new System.Drawing.Point(893, 35);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(47, 47);
            this.btn_print.TabIndex = 130;
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(785, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 129;
            this.label5.Text = " GRID VIEW";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1065, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 128;
            this.label3.Text = "CLOSE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(992, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 127;
            this.label4.Text = "RESET";
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
            // dtg_pay_pending
            // 
            this.dtg_pay_pending.AllowUserToAddRows = false;
            this.dtg_pay_pending.AllowUserToDeleteRows = false;
            this.dtg_pay_pending.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_pay_pending.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.dtg_pay_pending.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_pay_pending.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dtg_pay_pending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_pay_pending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PAYMENT_ID,
            this.PAYMENT_NO,
            this.PAYMENT_DATE,
            this.customer_name,
            this.NET_AMOUNT,
            this.PAID,
            this.CREDIT_NOTE,
            this.BALANCE});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_pay_pending.DefaultCellStyle = dataGridViewCellStyle14;
            this.dtg_pay_pending.Location = new System.Drawing.Point(-1, 143);
            this.dtg_pay_pending.Name = "dtg_pay_pending";
            this.dtg_pay_pending.ReadOnly = true;
            this.dtg_pay_pending.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_pay_pending.Size = new System.Drawing.Size(1182, 286);
            this.dtg_pay_pending.TabIndex = 132;
            this.dtg_pay_pending.Visible = false;
            this.dtg_pay_pending.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtg_pay_pending_DataBindingComplete);
            // 
            // btn_reset
            // 
            this.btn_reset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_reset.BackgroundImage")));
            this.btn_reset.FlatAppearance.BorderSize = 0;
            this.btn_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reset.Location = new System.Drawing.Point(984, 29);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(47, 47);
            this.btn_reset.TabIndex = 126;
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 121;
            this.label1.Text = "CUSTOMER";
            // 
            // txt_customer
            // 
            this.txt_customer.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_customer.Location = new System.Drawing.Point(430, 85);
            this.txt_customer.Name = "txt_customer";
            this.txt_customer.Size = new System.Drawing.Size(228, 25);
            this.txt_customer.TabIndex = 120;
            this.txt_customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_customer_KeyDown);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // btn_close
            // 
            this.btn_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close.BackgroundImage")));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(1068, 30);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(47, 46);
            this.btn_close.TabIndex = 125;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_gridview
            // 
            this.btn_gridview.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_gridview.BackgroundImage")));
            this.btn_gridview.FlatAppearance.BorderSize = 0;
            this.btn_gridview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_gridview.Location = new System.Drawing.Point(788, 19);
            this.btn_gridview.Name = "btn_gridview";
            this.btn_gridview.Size = new System.Drawing.Size(60, 69);
            this.btn_gridview.TabIndex = 124;
            this.btn_gridview.UseVisualStyleBackColor = true;
            this.btn_gridview.Click += new System.EventHandler(this.btn_gridview_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(340, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 122;
            this.label2.Text = "COMPANY";
            // 
            // txt_balance
            // 
            this.txt_balance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.txt_balance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_balance.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_balance.Location = new System.Drawing.Point(1070, 441);
            this.txt_balance.Name = "txt_balance";
            this.txt_balance.Size = new System.Drawing.Size(106, 22);
            this.txt_balance.TabIndex = 139;
            this.txt_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_balance.Visible = false;
            // 
            // txt_paid
            // 
            this.txt_paid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.txt_paid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_paid.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_paid.Location = new System.Drawing.Point(783, 441);
            this.txt_paid.Name = "txt_paid";
            this.txt_paid.Size = new System.Drawing.Size(106, 22);
            this.txt_paid.TabIndex = 138;
            this.txt_paid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_paid.Visible = false;
            // 
            // txt_total
            // 
            this.txt_total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.txt_total.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_total.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.Location = new System.Drawing.Point(628, 441);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(109, 22);
            this.txt_total.TabIndex = 137;
            this.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_total.Visible = false;
            // 
            // PAYMENT_ID
            // 
            this.PAYMENT_ID.DataPropertyName = "PAYMENT_ID";
            this.PAYMENT_ID.HeaderText = "PAYMENT_ID";
            this.PAYMENT_ID.Name = "PAYMENT_ID";
            this.PAYMENT_ID.ReadOnly = true;
            this.PAYMENT_ID.Visible = false;
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
            // customer_name
            // 
            this.customer_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.customer_name.DataPropertyName = "CUSTOMER_NAME";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.customer_name.DefaultCellStyle = dataGridViewCellStyle9;
            this.customer_name.FillWeight = 177.665F;
            this.customer_name.HeaderText = "CUSTOMER NAME";
            this.customer_name.Name = "customer_name";
            this.customer_name.ReadOnly = true;
            // 
            // NET_AMOUNT
            // 
            this.NET_AMOUNT.DataPropertyName = "NET_AMOUNT";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NET_AMOUNT.DefaultCellStyle = dataGridViewCellStyle10;
            this.NET_AMOUNT.HeaderText = "NET AMOUNT";
            this.NET_AMOUNT.Name = "NET_AMOUNT";
            this.NET_AMOUNT.ReadOnly = true;
            // 
            // PAID
            // 
            this.PAID.DataPropertyName = "PAID";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PAID.DefaultCellStyle = dataGridViewCellStyle11;
            this.PAID.HeaderText = "PAID";
            this.PAID.Name = "PAID";
            this.PAID.ReadOnly = true;
            // 
            // CREDIT_NOTE
            // 
            this.CREDIT_NOTE.DataPropertyName = "CREDIT_NOTE";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CREDIT_NOTE.DefaultCellStyle = dataGridViewCellStyle12;
            this.CREDIT_NOTE.HeaderText = "CREDIT NOTE";
            this.CREDIT_NOTE.Name = "CREDIT_NOTE";
            this.CREDIT_NOTE.ReadOnly = true;
            // 
            // BALANCE
            // 
            this.BALANCE.DataPropertyName = "BALANCE";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BALANCE.DefaultCellStyle = dataGridViewCellStyle13;
            this.BALANCE.HeaderText = "BALANCE";
            this.BALANCE.Name = "BALANCE";
            this.BALANCE.ReadOnly = true;
            // 
            // frm_payment_pending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(184)))), ((int)(((byte)(194)))));
            this.ClientSize = new System.Drawing.Size(1182, 477);
            this.Controls.Add(this.txt_balance);
            this.Controls.Add(this.txt_paid);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.txt_to);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_company);
            this.Controls.Add(this.txt_from);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtg_pay_pending);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_customer);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_gridview);
            this.Controls.Add(this.label2);
            this.KeyPreview = true;
            this.Name = "frm_payment_pending";
            this.Text = "Payment Pending";
            this.Load += new System.EventHandler(this.frm_payment_pending_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_payment_pending_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_pay_pending)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker txt_to;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_company;
        private System.Windows.Forms.DateTimePicker txt_from;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.DataGridView dtg_pay_pending;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_customer;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_gridview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_balance;
        private System.Windows.Forms.TextBox txt_paid;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYMENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYMENT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYMENT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn NET_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREDIT_NOTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BALANCE;
    }
}