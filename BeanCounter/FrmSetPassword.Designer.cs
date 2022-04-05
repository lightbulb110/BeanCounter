using System;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    partial class FrmSetPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
		
        private GroupBox groupBox1;

        private Button btnCancel;

        private Button btnOk;

        public TextBox tbConfirmPassword;

        private Label label3;

        public TextBox tbNewPassword;

        private Label label2;

        public TextBox tbCurrentPassword;

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
            this.btnCancel = new Button();
            this.btnOk = new Button();
            this.tbConfirmPassword = new TextBox();
            this.label3 = new Label();
            this.tbNewPassword = new TextBox();
            this.label2 = new Label();
            this.tbCurrentPassword = new TextBox();
            this.label1 = new Label();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.tbConfirmPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbNewPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbCurrentPassword);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(228, 211);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(66, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnOk.DialogResult = DialogResult.OK;
            this.btnOk.Location = new Point(147, 171);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.tbConfirmPassword.Location = new Point(20, 116);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new Size(121, 20);
            this.tbConfirmPassword.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(17, 99);
            this.label3.Name = "label3";
            this.label3.Size = new Size(91, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Confirm Password";
            this.tbNewPassword.Location = new Point(20, 76);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.PasswordChar = '*';
            this.tbNewPassword.Size = new Size(121, 20);
            this.tbNewPassword.TabIndex = 3;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(17, 59);
            this.label2.Name = "label2";
            this.label2.Size = new Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Password";
            this.tbCurrentPassword.Location = new Point(20, 32);
            this.tbCurrentPassword.Name = "tbCurrentPassword";
            this.tbCurrentPassword.PasswordChar = '*';
            this.tbCurrentPassword.Size = new Size(121, 20);
            this.tbCurrentPassword.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Password";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(252, 235);
            base.Controls.Add(this.groupBox1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "FrmSetPassword";
            this.Text = "Set Password";
            base.Load += new EventHandler(this.FrmSetPassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        #endregion
    }
}