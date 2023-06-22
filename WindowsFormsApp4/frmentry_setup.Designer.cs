
namespace IMS
{
    partial class frmentry_setup
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
            this.dtg_entrysetup = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_entrysetup)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg_entrysetup
            // 
            this.dtg_entrysetup.AllowUserToAddRows = false;
            this.dtg_entrysetup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_entrysetup.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            this.dtg_entrysetup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtg_entrysetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(245)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg_entrysetup.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtg_entrysetup.Location = new System.Drawing.Point(12, 12);
            this.dtg_entrysetup.Name = "dtg_entrysetup";
            this.dtg_entrysetup.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dtg_entrysetup.Size = new System.Drawing.Size(657, 347);
            this.dtg_entrysetup.TabIndex = 1;
            this.dtg_entrysetup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_entrysetup_CellContentClick);
            this.dtg_entrysetup.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtg_entrysetup_DataBindingComplete);
            // 
            // frmentry_setup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(690, 450);
            this.Controls.Add(this.dtg_entrysetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmentry_setup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entry Setup";
            this.Load += new System.EventHandler(this.frmentry_setup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmentry_setup_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmentry_setup_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_entrysetup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_entrysetup;
    }
}