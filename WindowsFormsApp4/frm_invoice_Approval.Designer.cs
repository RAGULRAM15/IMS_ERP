
namespace IMS
{
    partial class frm_invoice_Approval
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_invoice_Approval));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_add = new System.Windows.Forms.Button();
            this.dtg_iapproval = new System.Windows.Forms.DataGridView();
            this.INVOICE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NET_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APPROVAL_CHECK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CUSTOMER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_load = new System.Windows.Forms.Button();
            this.txt_to = new System.Windows.Forms.DateTimePicker();
            this.txt_from = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_fillter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_iapproval)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 15);
            this.label1.TabIndex = 96;
            this.label1.Text = "INVOICE APPROVAL";
            // 
            // txt_add
            // 
            this.txt_add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txt_add.BackgroundImage")));
            this.txt_add.FlatAppearance.BorderSize = 0;
            this.txt_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txt_add.ImageKey = "(none)";
            this.txt_add.Location = new System.Drawing.Point(72, 12);
            this.txt_add.Name = "txt_add";
            this.txt_add.Size = new System.Drawing.Size(53, 49);
            this.txt_add.TabIndex = 95;
            this.txt_add.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.txt_add.UseVisualStyleBackColor = true;
            this.txt_add.Click += new System.EventHandler(this.txt_add_Click);
            // 
            // dtg_iapproval
            // 
            this.dtg_iapproval.AllowUserToAddRows = false;
            this.dtg_iapproval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_iapproval.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(184)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_iapproval.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_iapproval.ColumnHeadersHeight = 30;
            this.dtg_iapproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtg_iapproval.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INVOICE_NO,
            this.INVOICE_DATE,
            this.CUSTOMER_NAME,
            this.NET_AMOUNT,
            this.APPROVAL_CHECK,
            this.CUSTOMER_ID});
            this.dtg_iapproval.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtg_iapproval.Location = new System.Drawing.Point(0, 129);
            this.dtg_iapproval.Name = "dtg_iapproval";
            this.dtg_iapproval.ReadOnly = true;
            this.dtg_iapproval.ShowRowErrors = false;
            this.dtg_iapproval.Size = new System.Drawing.Size(800, 321);
            this.dtg_iapproval.TabIndex = 97;
            this.dtg_iapproval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtg_iapproval_DataBindingComplete);
            // 
            // INVOICE_NO
            // 
            this.INVOICE_NO.DataPropertyName = "INVOICE_NO";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.INVOICE_NO.DefaultCellStyle = dataGridViewCellStyle2;
            this.INVOICE_NO.HeaderText = "ENTRY NO";
            this.INVOICE_NO.Name = "INVOICE_NO";
            this.INVOICE_NO.ReadOnly = true;
            // 
            // INVOICE_DATE
            // 
            this.INVOICE_DATE.DataPropertyName = "INVOICE_DATE";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.INVOICE_DATE.DefaultCellStyle = dataGridViewCellStyle3;
            this.INVOICE_DATE.HeaderText = "ENTRY DATE";
            this.INVOICE_DATE.Name = "INVOICE_DATE";
            this.INVOICE_DATE.ReadOnly = true;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.CUSTOMER_NAME.DefaultCellStyle = dataGridViewCellStyle4;
            this.CUSTOMER_NAME.HeaderText = "CUSTOMER NAME";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            // 
            // NET_AMOUNT
            // 
            this.NET_AMOUNT.DataPropertyName = "NET_AMOUNT";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.NET_AMOUNT.DefaultCellStyle = dataGridViewCellStyle5;
            this.NET_AMOUNT.HeaderText = "AMOUNT";
            this.NET_AMOUNT.Name = "NET_AMOUNT";
            this.NET_AMOUNT.ReadOnly = true;
            // 
            // APPROVAL_CHECK
            // 
            this.APPROVAL_CHECK.DataPropertyName = "APPROVAL_CHECK";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle6.NullValue = false;
            this.APPROVAL_CHECK.DefaultCellStyle = dataGridViewCellStyle6;
            this.APPROVAL_CHECK.HeaderText = "SELECT";
            this.APPROVAL_CHECK.Name = "APPROVAL_CHECK";
            this.APPROVAL_CHECK.ReadOnly = true;
            this.APPROVAL_CHECK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.APPROVAL_CHECK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.APPROVAL_CHECK.Visible = false;
            // 
            // CUSTOMER_ID
            // 
            this.CUSTOMER_ID.DataPropertyName = "CUSTOMER_ID";
            this.CUSTOMER_ID.HeaderText = "CUSTOMER ID";
            this.CUSTOMER_ID.Name = "CUSTOMER_ID";
            this.CUSTOMER_ID.ReadOnly = true;
            this.CUSTOMER_ID.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(750, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 113;
            this.label9.Text = "LOAD";
            this.label9.Visible = false;
            // 
            // btn_load
            // 
            this.btn_load.FlatAppearance.BorderSize = 0;
            this.btn_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_load.Image = ((System.Drawing.Image)(resources.GetObject("btn_load.Image")));
            this.btn_load.Location = new System.Drawing.Point(753, 44);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(30, 31);
            this.btn_load.TabIndex = 112;
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // txt_to
            // 
            this.txt_to.CustomFormat = "dd/MM/yyyy";
            this.txt_to.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_to.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txt_to.Location = new System.Drawing.Point(195, 69);
            this.txt_to.Name = "txt_to";
            this.txt_to.Size = new System.Drawing.Size(147, 21);
            this.txt_to.TabIndex = 111;
            this.txt_to.Value = new System.DateTime(2023, 3, 20, 0, 0, 0, 0);
            // 
            // txt_from
            // 
            this.txt_from.CustomFormat = "dd/MM/yyyy";
            this.txt_from.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_from.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txt_from.Location = new System.Drawing.Point(195, 28);
            this.txt_from.Name = "txt_from";
            this.txt_from.Size = new System.Drawing.Size(147, 21);
            this.txt_from.TabIndex = 110;
            this.txt_from.Value = new System.DateTime(2023, 3, 20, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(242, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 109;
            this.label6.Text = "TO";
            // 
            // txt_fillter
            // 
            this.txt_fillter.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_fillter.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txt_fillter.Location = new System.Drawing.Point(361, 47);
            this.txt_fillter.Name = "txt_fillter";
            this.txt_fillter.Size = new System.Drawing.Size(386, 25);
            this.txt_fillter.TabIndex = 108;
            this.txt_fillter.Text = "Customer Name";
            this.txt_fillter.Enter += new System.EventHandler(this.txt_fillter_Enter);
            this.txt_fillter.Leave += new System.EventHandler(this.txt_fillter_Leave);
            // 
            // frm_invoice_Approval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(184)))), ((int)(((byte)(194)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.txt_to);
            this.Controls.Add(this.txt_from);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_fillter);
            this.Controls.Add(this.dtg_iapproval);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_add);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frm_invoice_Approval";
            this.Text = "Approval_List";
            this.Load += new System.EventHandler(this.frm_invoice_Approval_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_invoice_Approval_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_iapproval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button txt_add;
        private System.Windows.Forms.DataGridView dtg_iapproval;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn NET_AMOUNT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn APPROVAL_CHECK;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_ID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.DateTimePicker txt_to;
        private System.Windows.Forms.DateTimePicker txt_from;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_fillter;
    }
}