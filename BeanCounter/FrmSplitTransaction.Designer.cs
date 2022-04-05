using BeanCounter.BusinessLogic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    partial class FrmSplitTransaction
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
		
        private GroupBox groupBox1;

        public DataGridView dgvSplitTransaction;

        private SplitContainer scMain;

        private TextBox tbFullAmount;

        private Label label3;

        private TextBox tbDate;

        private Label label2;

        private TextBox tbBusinessName;

        private Label label1;

        private Button btnOk;

        private Button btnCancel;

        private TextBox tbBankMemo;

        private Label label4;

        private Transaction Transaction;

        public int BankAccountID;		

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
            this.scMain = new SplitContainer();
            this.tbBankMemo = new TextBox();
            this.label4 = new Label();
            this.tbFullAmount = new TextBox();
            this.label3 = new Label();
            this.tbDate = new TextBox();
            this.label2 = new Label();
            this.tbBusinessName = new TextBox();
            this.label1 = new Label();
            this.dgvSplitTransaction = new DataGridView();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize)this.scMain).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((ISupportInitialize)this.dgvSplitTransaction).BeginInit();
            base.SuspendLayout();
            this.groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.groupBox1.Controls.Add(this.scMain);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(704, 324);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.scMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.scMain.FixedPanel = FixedPanel.Panel1;
            this.scMain.Location = new Point(6, 10);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = Orientation.Horizontal;
            this.scMain.Panel1.Controls.Add(this.tbBankMemo);
            this.scMain.Panel1.Controls.Add(this.label4);
            this.scMain.Panel1.Controls.Add(this.tbFullAmount);
            this.scMain.Panel1.Controls.Add(this.label3);
            this.scMain.Panel1.Controls.Add(this.tbDate);
            this.scMain.Panel1.Controls.Add(this.label2);
            this.scMain.Panel1.Controls.Add(this.tbBusinessName);
            this.scMain.Panel1.Controls.Add(this.label1);
            this.scMain.Panel2.Controls.Add(this.dgvSplitTransaction);
            this.scMain.Size = new Size(692, 308);
            this.scMain.SplitterDistance = 54;
            this.scMain.TabIndex = 1;
            this.tbBankMemo.Location = new Point(389, 25);
            this.tbBankMemo.Name = "tbBankMemo";
            this.tbBankMemo.Size = new Size(218, 20);
            this.tbBankMemo.TabIndex = 7;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(389, 8);
            this.label4.Name = "label4";
            this.label4.Size = new Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "BankMemo";
            this.tbFullAmount.Location = new Point(313, 25);
            this.tbFullAmount.Name = "tbFullAmount";
            this.tbFullAmount.Size = new Size(63, 20);
            this.tbFullAmount.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(313, 8);
            this.label3.Name = "label3";
            this.label3.Size = new Size(65, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Full Amount:";
            this.tbDate.Location = new Point(237, 26);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new Size(63, 20);
            this.tbDate.TabIndex = 3;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(237, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date:";
            this.tbBusinessName.Location = new Point(6, 27);
            this.tbBusinessName.Name = "tbBusinessName";
            this.tbBusinessName.Size = new Size(218, 20);
            this.tbBusinessName.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Business Name:";
            this.dgvSplitTransaction.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvSplitTransaction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSplitTransaction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSplitTransaction.Location = new Point(3, 3);
            this.dgvSplitTransaction.Name = "dgvSplitTransaction";
            this.dgvSplitTransaction.Size = new Size(686, 244);
            this.dgvSplitTransaction.TabIndex = 0;
            this.btnOk.DialogResult = DialogResult.OK;
            this.btnOk.Location = new Point(641, 347);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(560, 347);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(728, 382);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOk);
            base.Controls.Add(this.groupBox1);
            base.Name = "FrmSplitTransaction";
            this.Text = "FrmSplitTransaction";
            base.Load += new EventHandler(this.FrmSplitTransaction_Load);
            this.groupBox1.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel1.PerformLayout();
            this.scMain.Panel2.ResumeLayout(false);
            ((ISupportInitialize)this.scMain).EndInit();
            this.scMain.ResumeLayout(false);
            ((ISupportInitialize)this.dgvSplitTransaction).EndInit();
            base.ResumeLayout(false);
        }

        #endregion
    }
}