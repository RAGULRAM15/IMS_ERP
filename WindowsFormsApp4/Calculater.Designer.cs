
namespace IMS
{
    partial class Calculater
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
            this.txtbox = new System.Windows.Forms.TextBox();
            this.txtclear = new System.Windows.Forms.Button();
            this.txtplus = new System.Windows.Forms.Button();
            this.txtequal = new System.Windows.Forms.Button();
            this.txtdot = new System.Windows.Forms.Button();
            this.txt0 = new System.Windows.Forms.Button();
            this.txtsub = new System.Windows.Forms.Button();
            this.txtmulti = new System.Windows.Forms.Button();
            this.txtdiv = new System.Windows.Forms.Button();
            this.txt7 = new System.Windows.Forms.Button();
            this.txt8 = new System.Windows.Forms.Button();
            this.txt9 = new System.Windows.Forms.Button();
            this.txt4 = new System.Windows.Forms.Button();
            this.txt5 = new System.Windows.Forms.Button();
            this.txt6 = new System.Windows.Forms.Button();
            this.txt3 = new System.Windows.Forms.Button();
            this.txt2 = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.Button();
            this.lbltxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbox
            // 
            this.txtbox.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox.Location = new System.Drawing.Point(4, 67);
            this.txtbox.Name = "txtbox";
            this.txtbox.Size = new System.Drawing.Size(256, 29);
            this.txtbox.TabIndex = 35;
            this.txtbox.Text = "0";
            this.txtbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtclear
            // 
            this.txtclear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclear.Location = new System.Drawing.Point(215, 115);
            this.txtclear.Name = "txtclear";
            this.txtclear.Size = new System.Drawing.Size(45, 45);
            this.txtclear.TabIndex = 34;
            this.txtclear.Text = "C";
            this.txtclear.UseVisualStyleBackColor = true;
            this.txtclear.Click += new System.EventHandler(this.txtclear_Click_1);
            // 
            // txtplus
            // 
            this.txtplus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtplus.Location = new System.Drawing.Point(215, 175);
            this.txtplus.Name = "txtplus";
            this.txtplus.Size = new System.Drawing.Size(45, 105);
            this.txtplus.TabIndex = 33;
            this.txtplus.Text = "+";
            this.txtplus.UseVisualStyleBackColor = true;
            this.txtplus.Click += new System.EventHandler(this.oprater_click);
            // 
            // txtequal
            // 
            this.txtequal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtequal.Location = new System.Drawing.Point(164, 286);
            this.txtequal.Name = "txtequal";
            this.txtequal.Size = new System.Drawing.Size(96, 45);
            this.txtequal.TabIndex = 32;
            this.txtequal.Text = "=";
            this.txtequal.UseVisualStyleBackColor = true;
            this.txtequal.Click += new System.EventHandler(this.txtequal_Click_1);
            // 
            // txtdot
            // 
            this.txtdot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdot.Location = new System.Drawing.Point(113, 286);
            this.txtdot.Name = "txtdot";
            this.txtdot.Size = new System.Drawing.Size(45, 45);
            this.txtdot.TabIndex = 31;
            this.txtdot.Text = ".";
            this.txtdot.UseVisualStyleBackColor = true;
            this.txtdot.Click += new System.EventHandler(this.txt0_Click);
            // 
            // txt0
            // 
            this.txt0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt0.Location = new System.Drawing.Point(4, 286);
            this.txt0.Name = "txt0";
            this.txt0.Size = new System.Drawing.Size(103, 45);
            this.txt0.TabIndex = 30;
            this.txt0.Text = "0";
            this.txt0.UseVisualStyleBackColor = true;
            this.txt0.Click += new System.EventHandler(this.txt0_Click);
            // 
            // txtsub
            // 
            this.txtsub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsub.Location = new System.Drawing.Point(164, 235);
            this.txtsub.Name = "txtsub";
            this.txtsub.Size = new System.Drawing.Size(45, 45);
            this.txtsub.TabIndex = 29;
            this.txtsub.Text = "-";
            this.txtsub.UseVisualStyleBackColor = true;
            this.txtsub.Click += new System.EventHandler(this.oprater_click);
            // 
            // txtmulti
            // 
            this.txtmulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmulti.Location = new System.Drawing.Point(164, 175);
            this.txtmulti.Name = "txtmulti";
            this.txtmulti.Size = new System.Drawing.Size(45, 45);
            this.txtmulti.TabIndex = 28;
            this.txtmulti.Text = "x";
            this.txtmulti.UseVisualStyleBackColor = true;
            this.txtmulti.Click += new System.EventHandler(this.oprater_click);
            // 
            // txtdiv
            // 
            this.txtdiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiv.Location = new System.Drawing.Point(164, 115);
            this.txtdiv.Name = "txtdiv";
            this.txtdiv.Size = new System.Drawing.Size(45, 45);
            this.txtdiv.TabIndex = 27;
            this.txtdiv.Text = "/";
            this.txtdiv.UseVisualStyleBackColor = true;
            this.txtdiv.Click += new System.EventHandler(this.oprater_click);
            // 
            // txt7
            // 
            this.txt7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt7.Location = new System.Drawing.Point(4, 115);
            this.txt7.Name = "txt7";
            this.txt7.Size = new System.Drawing.Size(45, 45);
            this.txt7.TabIndex = 26;
            this.txt7.Text = "7";
            this.txt7.UseVisualStyleBackColor = true;
            this.txt7.Click += new System.EventHandler(this.txt0_Click);
            // 
            // txt8
            // 
            this.txt8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt8.Location = new System.Drawing.Point(62, 115);
            this.txt8.Name = "txt8";
            this.txt8.Size = new System.Drawing.Size(45, 45);
            this.txt8.TabIndex = 25;
            this.txt8.Text = "8";
            this.txt8.UseVisualStyleBackColor = true;
            this.txt8.Click += new System.EventHandler(this.txt0_Click);
            // 
            // txt9
            // 
            this.txt9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt9.Location = new System.Drawing.Point(113, 115);
            this.txt9.Name = "txt9";
            this.txt9.Size = new System.Drawing.Size(45, 45);
            this.txt9.TabIndex = 24;
            this.txt9.Text = "9";
            this.txt9.UseVisualStyleBackColor = true;
            this.txt9.Click += new System.EventHandler(this.txt0_Click);
            // 
            // txt4
            // 
            this.txt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt4.Location = new System.Drawing.Point(4, 175);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(45, 45);
            this.txt4.TabIndex = 23;
            this.txt4.Text = "4";
            this.txt4.UseVisualStyleBackColor = true;
            this.txt4.Click += new System.EventHandler(this.txt0_Click);
            // 
            // txt5
            // 
            this.txt5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt5.Location = new System.Drawing.Point(62, 175);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(45, 45);
            this.txt5.TabIndex = 22;
            this.txt5.Text = "5";
            this.txt5.UseVisualStyleBackColor = true;
            this.txt5.Click += new System.EventHandler(this.txt0_Click);
            // 
            // txt6
            // 
            this.txt6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt6.Location = new System.Drawing.Point(113, 175);
            this.txt6.Name = "txt6";
            this.txt6.Size = new System.Drawing.Size(45, 45);
            this.txt6.TabIndex = 21;
            this.txt6.Text = "6";
            this.txt6.UseVisualStyleBackColor = true;
            this.txt6.Click += new System.EventHandler(this.txt0_Click);
            // 
            // txt3
            // 
            this.txt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt3.Location = new System.Drawing.Point(113, 235);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(45, 45);
            this.txt3.TabIndex = 20;
            this.txt3.Text = "3";
            this.txt3.UseVisualStyleBackColor = true;
            this.txt3.Click += new System.EventHandler(this.txt0_Click);
            // 
            // txt2
            // 
            this.txt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2.Location = new System.Drawing.Point(62, 235);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(45, 45);
            this.txt2.TabIndex = 19;
            this.txt2.Text = "2";
            this.txt2.UseVisualStyleBackColor = true;
            this.txt2.Click += new System.EventHandler(this.txt0_Click);
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.Location = new System.Drawing.Point(4, 235);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(45, 45);
            this.txt1.TabIndex = 18;
            this.txt1.Text = "1";
            this.txt1.UseVisualStyleBackColor = true;
            this.txt1.Click += new System.EventHandler(this.txt0_Click);
            // 
            // lbltxt
            // 
            this.lbltxt.AutoSize = true;
            this.lbltxt.Location = new System.Drawing.Point(13, 48);
            this.lbltxt.Name = "lbltxt";
            this.lbltxt.Size = new System.Drawing.Size(0, 13);
            this.lbltxt.TabIndex = 36;
            // 
            // Calculater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(232)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(265, 337);
            this.Controls.Add(this.lbltxt);
            this.Controls.Add(this.txtbox);
            this.Controls.Add(this.txtclear);
            this.Controls.Add(this.txtplus);
            this.Controls.Add(this.txtequal);
            this.Controls.Add(this.txtdot);
            this.Controls.Add(this.txt0);
            this.Controls.Add(this.txtsub);
            this.Controls.Add(this.txtmulti);
            this.Controls.Add(this.txtdiv);
            this.Controls.Add(this.txt7);
            this.Controls.Add(this.txt8);
            this.Controls.Add(this.txt9);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.txt6);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Name = "Calculater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculater";
            this.Load += new System.EventHandler(this.Calculater_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbox;
        private System.Windows.Forms.Button txtclear;
        private System.Windows.Forms.Button txtplus;
        private System.Windows.Forms.Button txtequal;
        private System.Windows.Forms.Button txtdot;
        private System.Windows.Forms.Button txt0;
        private System.Windows.Forms.Button txtsub;
        private System.Windows.Forms.Button txtmulti;
        private System.Windows.Forms.Button txtdiv;
        private System.Windows.Forms.Button txt7;
        private System.Windows.Forms.Button txt8;
        private System.Windows.Forms.Button txt9;
        private System.Windows.Forms.Button txt4;
        private System.Windows.Forms.Button txt5;
        private System.Windows.Forms.Button txt6;
        private System.Windows.Forms.Button txt3;
        private System.Windows.Forms.Button txt2;
        private System.Windows.Forms.Button txt1;
        private System.Windows.Forms.Label lbltxt;
    }
}