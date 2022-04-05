using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    partial class frmWebAddress
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
		
        private Label label1;

        public TextBox tbWebsiteAddress;

        private Button btnCancel;

        private Button btnOK;		

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
            this.label1 = new Label();
            this.tbWebsiteAddress = new TextBox();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new Size(166, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the bank's &website address:";
            this.tbWebsiteAddress.Location = new Point(9, 38);
            this.tbWebsiteAddress.Name = "tbWebsiteAddress";
            this.tbWebsiteAddress.Size = new Size(181, 20);
            this.tbWebsiteAddress.TabIndex = 1;
            this.tbWebsiteAddress.Text = "http://www.";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(37, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(119, 76);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            base.AcceptButton = this.btnOK;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(202, 111);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.tbWebsiteAddress);
            base.Controls.Add(this.label1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmWebAddress";
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Enter web address";
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion
    }
}