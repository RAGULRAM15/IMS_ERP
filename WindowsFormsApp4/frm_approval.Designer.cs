
namespace IMS
{
    partial class frm_approval
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_approval));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_unapprove = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_approve = new System.Windows.Forms.Button();
            this.dtg_iapproval = new System.Windows.Forms.DataGridView();
            this.INVOICE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NET_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APPROVAL_CHECK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CUSTOMER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbtn_approve = new System.Windows.Forms.RadioButton();
            this.rbtn_unapprove = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_top = new System.Windows.Forms.Panel();
            this.txtcustomer = new System.Windows.Forms.TextBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_iapproval)).BeginInit();
            this.pnl_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(184)))), ((int)(((byte)(194)))));
            this.panel1.Controls.Add(this.btn_unapprove);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.btn_approve);
            this.panel1.Controls.Add(this.dtg_iapproval);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 379);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_unapprove
            // 
            this.btn_unapprove.BackColor = System.Drawing.Color.Green;
            this.btn_unapprove.FlatAppearance.BorderSize = 0;
            this.btn_unapprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_unapprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_unapprove.ForeColor = System.Drawing.Color.White;
            this.btn_unapprove.Location = new System.Drawing.Point(447, 337);
            this.btn_unapprove.Name = "btn_unapprove";
            this.btn_unapprove.Size = new System.Drawing.Size(86, 23);
            this.btn_unapprove.TabIndex = 31;
            this.btn_unapprove.Text = "UnApprove";
            this.btn_unapprove.UseVisualStyleBackColor = false;
            this.btn_unapprove.Visible = false;
            this.btn_unapprove.Click += new System.EventHandler(this.btn_unapprove_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Red;
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Location = new System.Drawing.Point(716, 337);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(99, 23);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "CLOSE";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_approve
            // 
            this.btn_approve.BackColor = System.Drawing.Color.Green;
            this.btn_approve.FlatAppearance.BorderSize = 0;
            this.btn_approve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_approve.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_approve.ForeColor = System.Drawing.Color.White;
            this.btn_approve.Location = new System.Drawing.Point(579, 337);
            this.btn_approve.Name = "btn_approve";
            this.btn_approve.Size = new System.Drawing.Size(104, 23);
            this.btn_approve.TabIndex = 4;
            this.btn_approve.Text = "Approve";
            this.btn_approve.UseVisualStyleBackColor = false;
            this.btn_approve.Click += new System.EventHandler(this.btn_approve_Click);
            // 
            // dtg_iapproval
            // 
            this.dtg_iapproval.AllowUserToAddRows = false;
            this.dtg_iapproval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_iapproval.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Malgun Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_iapproval.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtg_iapproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_iapproval.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INVOICE_NO,
            this.INVOICE_DATE,
            this.CUSTOMER_NAME,
            this.NET_AMOUNT,
            this.APPROVAL_CHECK,
            this.CUSTOMER_ID});
            this.dtg_iapproval.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtg_iapproval.Location = new System.Drawing.Point(0, 0);
            this.dtg_iapproval.Name = "dtg_iapproval";
            this.dtg_iapproval.Size = new System.Drawing.Size(840, 321);
            this.dtg_iapproval.TabIndex = 2;
            this.dtg_iapproval.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtg_iapproval_DataBindingComplete);
            // 
            // INVOICE_NO
            // 
            this.INVOICE_NO.DataPropertyName = "INVOICE_NO";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.INVOICE_NO.DefaultCellStyle = dataGridViewCellStyle8;
            this.INVOICE_NO.HeaderText = "ENTRY NO";
            this.INVOICE_NO.Name = "INVOICE_NO";
            // 
            // INVOICE_DATE
            // 
            this.INVOICE_DATE.DataPropertyName = "INVOICE_DATE";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.INVOICE_DATE.DefaultCellStyle = dataGridViewCellStyle9;
            this.INVOICE_DATE.HeaderText = "ENTRY DATE";
            this.INVOICE_DATE.Name = "INVOICE_DATE";
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.CUSTOMER_NAME.DefaultCellStyle = dataGridViewCellStyle10;
            this.CUSTOMER_NAME.HeaderText = "CUSTOMER NAME";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            // 
            // NET_AMOUNT
            // 
            this.NET_AMOUNT.DataPropertyName = "NET_AMOUNT";
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.NET_AMOUNT.DefaultCellStyle = dataGridViewCellStyle11;
            this.NET_AMOUNT.HeaderText = "AMOUNT";
            this.NET_AMOUNT.Name = "NET_AMOUNT";
            // 
            // APPROVAL_CHECK
            // 
            this.APPROVAL_CHECK.DataPropertyName = "APPROVAL_CHECK";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle12.NullValue = false;
            this.APPROVAL_CHECK.DefaultCellStyle = dataGridViewCellStyle12;
            this.APPROVAL_CHECK.HeaderText = "SELECT";
            this.APPROVAL_CHECK.Name = "APPROVAL_CHECK";
            this.APPROVAL_CHECK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.APPROVAL_CHECK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CUSTOMER_ID
            // 
            this.CUSTOMER_ID.DataPropertyName = "CUSTOMER_ID";
            this.CUSTOMER_ID.HeaderText = "CUSTOMER ID";
            this.CUSTOMER_ID.Name = "CUSTOMER_ID";
            this.CUSTOMER_ID.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(358, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "       INVOICE  APPROVAL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(407, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "Option";
            // 
            // rbtn_approve
            // 
            this.rbtn_approve.AutoSize = true;
            this.rbtn_approve.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_approve.Location = new System.Drawing.Point(579, 63);
            this.rbtn_approve.Name = "rbtn_approve";
            this.rbtn_approve.Size = new System.Drawing.Size(86, 20);
            this.rbtn_approve.TabIndex = 2;
            this.rbtn_approve.TabStop = true;
            this.rbtn_approve.Text = "Approved";
            this.rbtn_approve.UseVisualStyleBackColor = true;
            this.rbtn_approve.CheckedChanged += new System.EventHandler(this.rbtn_approve_CheckedChanged);
            // 
            // rbtn_unapprove
            // 
            this.rbtn_unapprove.AutoSize = true;
            this.rbtn_unapprove.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn_unapprove.Location = new System.Drawing.Point(470, 61);
            this.rbtn_unapprove.Name = "rbtn_unapprove";
            this.rbtn_unapprove.Size = new System.Drawing.Size(103, 20);
            this.rbtn_unapprove.TabIndex = 1;
            this.rbtn_unapprove.TabStop = true;
            this.rbtn_unapprove.Text = "UnApproved";
            this.rbtn_unapprove.UseVisualStyleBackColor = true;
            this.rbtn_unapprove.CheckedChanged += new System.EventHandler(this.rbtn_unapprove_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 20;
            this.label1.Text = "CUSTOMER";
            // 
            // pnl_top
            // 
            this.pnl_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(184)))), ((int)(((byte)(194)))));
            this.pnl_top.Controls.Add(this.txtcustomer);
            this.pnl_top.Controls.Add(this.btn_load);
            this.pnl_top.Controls.Add(this.label2);
            this.pnl_top.Controls.Add(this.rbtn_approve);
            this.pnl_top.Controls.Add(this.rbtn_unapprove);
            this.pnl_top.Controls.Add(this.label5);
            this.pnl_top.Controls.Add(this.label1);
            this.pnl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_top.ForeColor = System.Drawing.Color.Black;
            this.pnl_top.Location = new System.Drawing.Point(0, 0);
            this.pnl_top.Name = "pnl_top";
            this.pnl_top.Size = new System.Drawing.Size(840, 118);
            this.pnl_top.TabIndex = 4;
            this.pnl_top.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_top_Paint);
            // 
            // txtcustomer
            // 
            this.txtcustomer.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustomer.Location = new System.Drawing.Point(124, 62);
            this.txtcustomer.Name = "txtcustomer";
            this.txtcustomer.Size = new System.Drawing.Size(227, 22);
            this.txtcustomer.TabIndex = 0;
            this.txtcustomer.TextChanged += new System.EventHandler(this.txtcustomer_TextChanged);
            this.txtcustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcustomer_KeyDown);
            this.txtcustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtcustomer_KeyUp);
            // 
            // btn_load
            // 
            this.btn_load.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_load.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_load.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_load.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_load.ForeColor = System.Drawing.Color.Black;
            this.btn_load.Image = ((System.Drawing.Image)(resources.GetObject("btn_load.Image")));
            this.btn_load.Location = new System.Drawing.Point(682, 63);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(55, 23);
            this.btn_load.TabIndex = 3;
            this.btn_load.Text = "LOAD";
            this.btn_load.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // frm_approval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 497);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_approval";
            this.Text = "Approval";
            this.Load += new System.EventHandler(this.frm_approval_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_approval_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_iapproval)).EndInit();
            this.pnl_top.ResumeLayout(false);
            this.pnl_top.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_unapprove;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_approve;
        private System.Windows.Forms.DataGridView dtg_iapproval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtn_approve;
        private System.Windows.Forms.RadioButton rbtn_unapprove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_top;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.TextBox txtcustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn NET_AMOUNT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn APPROVAL_CHECK;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_ID;
    }
}