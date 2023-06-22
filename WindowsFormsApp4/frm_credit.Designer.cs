
namespace IMS
{
    partial class frm_credit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_credit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtg_debit = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnl_full = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_debit = new System.Windows.Forms.TextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.txt_balance = new System.Windows.Forms.TextBox();
            this.txt_paid = new System.Windows.Forms.TextBox();
            this.txtcustomer = new System.Windows.Forms.TextBox();
            this.cmbo_debit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_datetime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clk_select_all = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.invoice_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.credit_note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_debit)).BeginInit();
            this.pnl_full.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtg_debit
            // 
            this.dtg_debit.AllowUserToAddRows = false;
            this.dtg_debit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_debit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg_debit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_debit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_debit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoice_no,
            this.invoice_date,
            this.description,
            this.paid,
            this.balance,
            this.CGST,
            this.SGST,
            this.IGST,
            this.total,
            this.active,
            this.credit_note,
            this.item_id});
            this.dtg_debit.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtg_debit.Location = new System.Drawing.Point(0, 0);
            this.dtg_debit.MultiSelect = false;
            this.dtg_debit.Name = "dtg_debit";
            this.dtg_debit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_debit.Size = new System.Drawing.Size(994, 276);
            this.dtg_debit.TabIndex = 1;
            this.dtg_debit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_debit_CellClick);
            this.dtg_debit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_debit_CellContentClick);
            this.dtg_debit.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dtg_debit_CellMouseClick);
            this.dtg_debit.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_debit_CellValidated);
            this.dtg_debit.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtg_debit_CellValidating);
            this.dtg_debit.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_debit_CellValueChanged);
            this.dtg_debit.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtg_debit_DataBindingComplete);
            this.dtg_debit.SelectionChanged += new System.EventHandler(this.dtg_debit_SelectionChanged);
            this.dtg_debit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtg_debit_KeyDown);
            this.dtg_debit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dtg_debit_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(973, 504);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(10, 20);
            this.textBox1.TabIndex = 45;
            this.textBox1.Text = "0";
            this.textBox1.Visible = false;
            // 
            // pnl_full
            // 
            this.pnl_full.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(184)))), ((int)(((byte)(194)))));
            this.pnl_full.Controls.Add(this.btn_save);
            this.pnl_full.Controls.Add(this.txt_total);
            this.pnl_full.Controls.Add(this.dtg_debit);
            this.pnl_full.Controls.Add(this.label2);
            this.pnl_full.Controls.Add(this.txt_debit);
            this.pnl_full.Controls.Add(this.btn_close);
            this.pnl_full.Controls.Add(this.txt_amount);
            this.pnl_full.Controls.Add(this.txt_balance);
            this.pnl_full.Controls.Add(this.txt_paid);
            this.pnl_full.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_full.Location = new System.Drawing.Point(0, 125);
            this.pnl_full.Name = "pnl_full";
            this.pnl_full.Size = new System.Drawing.Size(994, 394);
            this.pnl_full.TabIndex = 47;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.Green;
            this.btn_save.Location = new System.Drawing.Point(754, 361);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 53;
            this.btn_save.Text = "SAVE";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_total
            // 
            this.txt_total.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.Location = new System.Drawing.Point(665, 316);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(326, 39);
            this.txt_total.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(582, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 51;
            this.label2.Text = "TOTAL";
            // 
            // txt_debit
            // 
            this.txt_debit.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_debit.Location = new System.Drawing.Point(885, 282);
            this.txt_debit.Name = "txt_debit";
            this.txt_debit.Size = new System.Drawing.Size(102, 25);
            this.txt_debit.TabIndex = 5;
            this.txt_debit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.Red;
            this.btn_close.Location = new System.Drawing.Point(867, 361);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 44;
            this.btn_close.Text = "CLOSE";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // txt_amount
            // 
            this.txt_amount.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_amount.Location = new System.Drawing.Point(665, 282);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(106, 25);
            this.txt_amount.TabIndex = 2;
            this.txt_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_balance
            // 
            this.txt_balance.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_balance.Location = new System.Drawing.Point(553, 282);
            this.txt_balance.Name = "txt_balance";
            this.txt_balance.Size = new System.Drawing.Size(95, 25);
            this.txt_balance.TabIndex = 4;
            this.txt_balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_paid
            // 
            this.txt_paid.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_paid.Location = new System.Drawing.Point(434, 282);
            this.txt_paid.Name = "txt_paid";
            this.txt_paid.Size = new System.Drawing.Size(96, 25);
            this.txt_paid.TabIndex = 3;
            this.txt_paid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtcustomer
            // 
            this.txtcustomer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustomer.Location = new System.Drawing.Point(149, 75);
            this.txtcustomer.Name = "txtcustomer";
            this.txtcustomer.Size = new System.Drawing.Size(241, 21);
            this.txtcustomer.TabIndex = 54;
            this.txtcustomer.TextChanged += new System.EventHandler(this.txtcustomer_TextChanged);
            this.txtcustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcustomer_KeyDown);
            this.txtcustomer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcustomer_KeyPress);
            this.txtcustomer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtcustomer_KeyUp);
            // 
            // cmbo_debit
            // 
            this.cmbo_debit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(184)))), ((int)(((byte)(194)))));
            this.cmbo_debit.Location = new System.Drawing.Point(857, 36);
            this.cmbo_debit.Name = "cmbo_debit";
            this.cmbo_debit.ReadOnly = true;
            this.cmbo_debit.Size = new System.Drawing.Size(121, 20);
            this.cmbo_debit.TabIndex = 53;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(746, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 52;
            this.label4.Text = "ENTRY NO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(447, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 19);
            this.label5.TabIndex = 51;
            this.label5.Text = "       CREDIT NOTE";
            // 
            // txt_datetime
            // 
            this.txt_datetime.CustomFormat = "dd/MM/yyyy";
            this.txt_datetime.Enabled = false;
            this.txt_datetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_datetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txt_datetime.Location = new System.Drawing.Point(857, 78);
            this.txt_datetime.Name = "txt_datetime";
            this.txt_datetime.Size = new System.Drawing.Size(121, 22);
            this.txt_datetime.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(785, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 49;
            this.label3.Text = "DATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 48;
            this.label1.Text = "CUSTOMER";
            // 
            // clk_select_all
            // 
            this.clk_select_all.AutoSize = true;
            this.clk_select_all.Location = new System.Drawing.Point(853, 106);
            this.clk_select_all.Name = "clk_select_all";
            this.clk_select_all.Size = new System.Drawing.Size(89, 17);
            this.clk_select_all.TabIndex = 55;
            this.clk_select_all.Text = "SELECT ALL";
            this.clk_select_all.UseVisualStyleBackColor = true;
            this.clk_select_all.CheckedChanged += new System.EventHandler(this.clk_select_all_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(550, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 161;
            this.label8.Text = "ADD ITEM => F5";
            // 
            // invoice_no
            // 
            this.invoice_no.DataPropertyName = "invoice_no";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.invoice_no.DefaultCellStyle = dataGridViewCellStyle2;
            this.invoice_no.HeaderText = "INVOICE NO";
            this.invoice_no.Name = "invoice_no";
            // 
            // invoice_date
            // 
            this.invoice_date.DataPropertyName = "invoice_date";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.invoice_date.DefaultCellStyle = dataGridViewCellStyle3;
            this.invoice_date.HeaderText = "INVOICE DATE";
            this.invoice_date.Name = "invoice_date";
            // 
            // description
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.description.DefaultCellStyle = dataGridViewCellStyle4;
            this.description.HeaderText = "RETURN OF GOODS";
            this.description.Name = "description";
            // 
            // paid
            // 
            this.paid.DataPropertyName = "paid";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.paid.DefaultCellStyle = dataGridViewCellStyle5;
            this.paid.HeaderText = "QUANTITY";
            this.paid.Name = "paid";
            // 
            // balance
            // 
            this.balance.DataPropertyName = "balance";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.balance.DefaultCellStyle = dataGridViewCellStyle6;
            this.balance.HeaderText = "RATE";
            this.balance.Name = "balance";
            // 
            // CGST
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.CGST.DefaultCellStyle = dataGridViewCellStyle7;
            this.CGST.HeaderText = "CGST";
            this.CGST.Name = "CGST";
            // 
            // SGST
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.SGST.DefaultCellStyle = dataGridViewCellStyle8;
            this.SGST.HeaderText = "SGST";
            this.SGST.Name = "SGST";
            // 
            // IGST
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.IGST.DefaultCellStyle = dataGridViewCellStyle9;
            this.IGST.HeaderText = "IGST";
            this.IGST.Name = "IGST";
            // 
            // total
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.total.DefaultCellStyle = dataGridViewCellStyle10;
            this.total.HeaderText = "TOTAL";
            this.total.Name = "total";
            // 
            // active
            // 
            this.active.DataPropertyName = "active";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle11.NullValue = false;
            this.active.DefaultCellStyle = dataGridViewCellStyle11;
            this.active.HeaderText = "SELECT";
            this.active.Name = "active";
            // 
            // credit_note
            // 
            this.credit_note.DataPropertyName = "credit_note";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.credit_note.DefaultCellStyle = dataGridViewCellStyle12;
            this.credit_note.HeaderText = "CRIDIT NOTE";
            this.credit_note.Name = "credit_note";
            this.credit_note.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.credit_note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // item_id
            // 
            this.item_id.HeaderText = "ITEM_ID";
            this.item_id.Name = "item_id";
            this.item_id.Visible = false;
            // 
            // frm_credit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(184)))), ((int)(((byte)(194)))));
            this.ClientSize = new System.Drawing.Size(994, 519);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.clk_select_all);
            this.Controls.Add(this.txtcustomer);
            this.Controls.Add(this.cmbo_debit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_datetime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnl_full);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frm_credit";
            this.Text = "CREDIT NOTE";
            this.Load += new System.EventHandler(this.frm_debit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_credit_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.frm_credit_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_debit)).EndInit();
            this.pnl_full.ResumeLayout(false);
            this.pnl_full.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dtg_debit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel pnl_full;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_debit;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.TextBox txt_balance;
        private System.Windows.Forms.TextBox txt_paid;
        private System.Windows.Forms.TextBox txtcustomer;
        private System.Windows.Forms.TextBox cmbo_debit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker txt_datetime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox clk_select_all;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn CGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn SGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewCheckBoxColumn active;
        private System.Windows.Forms.DataGridViewTextBoxColumn credit_note;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_id;
    }
}