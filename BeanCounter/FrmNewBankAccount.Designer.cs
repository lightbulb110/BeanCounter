using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    partial class FrmNewBankAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
		
        private GroupBox grpNewAccount;

        private SplitContainer scMain;

        private Label label4;

        private Label label3;

        public TextBox tbNickname;

        public TextBox tbWebAddress;

        private Label lblWebAddress;

        private Label lblNickName;

        private Button btnCancel;

        private Button btnOk;

        private DataGridView dgvTransactions;

        private Label lblColumnChoice;

        private GroupBox groupBox1;

        public RadioButton rbColumnB;

        public RadioButton rbColumnA;

        public ComboBox cbRemoveFromColumnB;

        public ComboBox cbRemoveFromColumnA;		

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
            this.grpNewAccount = new GroupBox();
            this.scMain = new SplitContainer();
            this.groupBox1 = new GroupBox();
            this.cbRemoveFromColumnB = new ComboBox();
            this.cbRemoveFromColumnA = new ComboBox();
            this.tbWebAddress = new TextBox();
            this.rbColumnB = new RadioButton();
            this.lblNickName = new Label();
            this.rbColumnA = new RadioButton();
            this.lblWebAddress = new Label();
            this.btnCancel = new Button();
            this.tbNickname = new TextBox();
            this.lblColumnChoice = new Label();
            this.label3 = new Label();
            this.btnOk = new Button();
            this.label4 = new Label();
            this.dgvTransactions = new DataGridView();
            this.grpNewAccount.SuspendLayout();
            ((ISupportInitialize)this.scMain).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((ISupportInitialize)this.dgvTransactions).BeginInit();
            base.SuspendLayout();
            this.grpNewAccount.Controls.Add(this.scMain);
            this.grpNewAccount.Dock = DockStyle.Fill;
            this.grpNewAccount.Location = new Point(0, 0);
            this.grpNewAccount.Name = "grpNewAccount";
            this.grpNewAccount.Size = new Size(641, 340);
            this.grpNewAccount.TabIndex = 0;
            this.grpNewAccount.TabStop = false;
            this.scMain.Dock = DockStyle.Fill;
            this.scMain.FixedPanel = FixedPanel.Panel1;
            this.scMain.Location = new Point(3, 16);
            this.scMain.Name = "scMain";
            this.scMain.Panel1.Controls.Add(this.groupBox1);
            this.scMain.Panel2.Controls.Add(this.dgvTransactions);
            this.scMain.Size = new Size(635, 321);
            this.scMain.SplitterDistance = 297;
            this.scMain.TabIndex = 0;
            this.groupBox1.Controls.Add(this.cbRemoveFromColumnB);
            this.groupBox1.Controls.Add(this.cbRemoveFromColumnA);
            this.groupBox1.Controls.Add(this.tbWebAddress);
            this.groupBox1.Controls.Add(this.rbColumnB);
            this.groupBox1.Controls.Add(this.lblNickName);
            this.groupBox1.Controls.Add(this.rbColumnA);
            this.groupBox1.Controls.Add(this.lblWebAddress);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.tbNickname);
            this.groupBox1.Controls.Add(this.lblColumnChoice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(282, 315);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.cbRemoveFromColumnB.FormattingEnabled = true;
            this.cbRemoveFromColumnB.Items.AddRange(new object[] { "[Everything]", "[Nothing]", "[Remove Business Name]" });
            this.cbRemoveFromColumnB.Location = new Point(6, 181);
            this.cbRemoveFromColumnB.Name = "cbRemoveFromColumnB";
            this.cbRemoveFromColumnB.Size = new Size(270, 21);
            this.cbRemoveFromColumnB.TabIndex = 7;
            this.cbRemoveFromColumnA.FormattingEnabled = true;
            this.cbRemoveFromColumnA.Items.AddRange(new object[] { "[Everything]", "[Nothing]", "[Remove Business Name]" });
            this.cbRemoveFromColumnA.Location = new Point(6, 141);
            this.cbRemoveFromColumnA.Name = "cbRemoveFromColumnA";
            this.cbRemoveFromColumnA.Size = new Size(270, 21);
            this.cbRemoveFromColumnA.TabIndex = 5;
            this.tbWebAddress.Location = new Point(6, 102);
            this.tbWebAddress.Name = "tbWebAddress";
            this.tbWebAddress.Size = new Size(270, 20);
            this.tbWebAddress.TabIndex = 3;
            this.tbWebAddress.Leave += new EventHandler(this.tbWebAddress_Leave);
            this.rbColumnB.AutoSize = true;
            this.rbColumnB.Location = new Point(194, 235);
            this.rbColumnB.Name = "rbColumnB";
            this.rbColumnB.Size = new Size(70, 17);
            this.rbColumnB.TabIndex = 10;
            this.rbColumnB.TabStop = true;
            this.rbColumnB.Text = "Column B";
            this.rbColumnB.UseVisualStyleBackColor = true;
            this.lblNickName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblNickName.Location = new Point(6, 18);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new Size(189, 28);
            this.lblNickName.TabIndex = 0;
            this.lblNickName.Text = "Please enter account Nickname (e.g. Checking)";
            this.rbColumnA.AutoSize = true;
            this.rbColumnA.Location = new Point(8, 235);
            this.rbColumnA.Name = "rbColumnA";
            this.rbColumnA.Size = new Size(70, 17);
            this.rbColumnA.TabIndex = 9;
            this.rbColumnA.TabStop = true;
            this.rbColumnA.Text = "Column A";
            this.rbColumnA.UseVisualStyleBackColor = true;
            this.lblWebAddress.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblWebAddress.Location = new Point(6, 72);
            this.lblWebAddress.Name = "lblWebAddress";
            this.lblWebAddress.Size = new Size(200, 27);
            this.lblWebAddress.TabIndex = 2;
            this.lblWebAddress.Text = "Please enter the website address (e.g. www.bank.com): ";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(113, 282);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.tbNickname.Location = new Point(6, 49);
            this.tbNickname.Name = "tbNickname";
            this.tbNickname.Size = new Size(270, 20);
            this.tbNickname.TabIndex = 1;
            this.tbNickname.Leave += new EventHandler(this.tbNickname_Leave);
            this.lblColumnChoice.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblColumnChoice.Location = new Point(5, 205);
            this.lblColumnChoice.Name = "lblColumnChoice";
            this.lblColumnChoice.Size = new Size(259, 27);
            this.lblColumnChoice.TabIndex = 8;
            this.lblColumnChoice.Text = "Choose the column that best describes the Business's name:";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(6, 125);
            this.label3.Name = "label3";
            this.label3.Size = new Size(261, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Any text you wish to remove from all cells in Column A:";
            this.btnOk.DialogResult = DialogResult.OK;
            this.btnOk.Location = new Point(194, 282);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(75, 23);
            this.btnOk.TabIndex = 11;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(6, 165);
            this.label4.Name = "label4";
            this.label4.Size = new Size(261, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Any text you wish to remove from all cells in Column B:";
            this.dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Dock = DockStyle.Fill;
            this.dgvTransactions.Location = new Point(0, 0);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.Size = new Size(334, 321);
            this.dgvTransactions.TabIndex = 0;
            base.AcceptButton = this.btnOk;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(641, 340);
            base.Controls.Add(this.grpNewAccount);
            base.MinimizeBox = false;
            base.Name = "FrmNewBankAccount";
            this.Text = "New Bank Account";
            base.Load += new EventHandler(this.FrmNewBankAccount_Load);
            this.grpNewAccount.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((ISupportInitialize)this.scMain).EndInit();
            this.scMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((ISupportInitialize)this.dgvTransactions).EndInit();
            base.ResumeLayout(false);
        }

        #endregion
    }
}