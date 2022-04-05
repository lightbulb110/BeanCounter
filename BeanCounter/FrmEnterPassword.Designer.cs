using System;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    partial class FrmEnterPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
		
        private GroupBox groupBox1;

        private TextBox tbPassword;

        private Button btnCancel;

        private Button btnOk;

        private Label label2;

        private Label label1;		

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
            this.groupBox1 = new GroupBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.tbPassword = new TextBox();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(229, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(180, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "This database is password protected";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(18, 48);
            this.label2.Name = "label2";
            this.label2.Size = new Size(171, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please enter the correct password:";
            this.btnOk.DialogResult = DialogResult.OK;
            this.btnOk.Location = new Point(148, 106);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(67, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.tbPassword.Location = new Point(21, 64);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new Size(202, 20);
            this.tbPassword.TabIndex = 4;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(253, 167);
            base.Controls.Add(this.groupBox1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEnterPassword";
            this.Text = "Enter Password";
            base.FormClosing += new FormClosingEventHandler(this.frmEnterPassword_FormClosing);
            base.Load += new EventHandler(this.frmEnterPassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        #endregion
    }
}