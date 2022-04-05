using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private MenuStrip msTop;

        private ToolStripMenuItem fileToolStripMenuItem;

        private ToolStripMenuItem tsmiNewAccount;

        private ToolStripSeparator toolStripSeparator1;

        private ToolStrip tsTop;

        private SplitContainer scTop;

        private SplitContainer scTopLeft;

        private SplitContainer scTopRight;

        private GroupBox gbCash;

        private GroupBox gbCredit;

        private GroupBox gbBalances;

        private DataGridView dgvCashAccounts;

        private DataGridView dgvCreditAccounts;

        private DataGridView dgvBalances;

        private ToolStripButton tsbCategories;
        private ToolStripButton tsbReports;

        private ToolStripButton tsbBusinesses;

        private ToolStripSeparator toolStripSeparator10;
        private ToolStrip tsBottom;

        private ToolStripLabel tslMain;

        private ToolStripSeparator toolStripSeparator6;

        private ToolStripProgressBar tspbMain;

        private BackgroundWorker bwLoadOFXfile;

        private BackgroundWorker bwImportTransactions;

        private ToolStripMenuItem donateToolStripMenuItem;

        

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.msTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.tsbCategories = new System.Windows.Forms.ToolStripButton();
            this.tsbReports = new System.Windows.Forms.ToolStripButton();
            this.tsbBusinesses = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.scTop = new System.Windows.Forms.SplitContainer();
            this.scTopLeft = new System.Windows.Forms.SplitContainer();
            this.gbCash = new System.Windows.Forms.GroupBox();
            this.dgvCashAccounts = new System.Windows.Forms.DataGridView();
            this.gbCredit = new System.Windows.Forms.GroupBox();
            this.dgvCreditAccounts = new System.Windows.Forms.DataGridView();
            this.scTopRight = new System.Windows.Forms.SplitContainer();
            this.gbBalances = new System.Windows.Forms.GroupBox();
            this.dgvBalances = new System.Windows.Forms.DataGridView();
            this.tsBottom = new System.Windows.Forms.ToolStrip();
            this.tslMain = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tspbMain = new System.Windows.Forms.ToolStripProgressBar();
            this.bwLoadOFXfile = new System.ComponentModel.BackgroundWorker();
            this.bwImportTransactions = new System.ComponentModel.BackgroundWorker();
            this.tsbYearToDateOnly = new System.Windows.Forms.ToolStripButton();
            this.msTop.SuspendLayout();
            this.tsTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTop)).BeginInit();
            this.scTop.Panel1.SuspendLayout();
            this.scTop.Panel2.SuspendLayout();
            this.scTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scTopLeft)).BeginInit();
            this.scTopLeft.Panel1.SuspendLayout();
            this.scTopLeft.Panel2.SuspendLayout();
            this.scTopLeft.SuspendLayout();
            this.gbCash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashAccounts)).BeginInit();
            this.gbCredit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scTopRight)).BeginInit();
            this.scTopRight.Panel1.SuspendLayout();
            this.scTopRight.SuspendLayout();
            this.gbBalances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalances)).BeginInit();
            this.SuspendLayout();
            // 
            // msTop
            // 
            this.msTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
            this.msTop.Location = new System.Drawing.Point(0, 0);
            this.msTop.Name = "msTop";
            this.msTop.Size = new System.Drawing.Size(1166, 24);
            this.msTop.TabIndex = 0;
            this.msTop.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAccountToolStripMenuItem,
            this.tsmiSetPassword,
            this.toolStripSeparator2,
            this.tsmiExit});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // newAccountToolStripMenuItem
            // 
            this.newAccountToolStripMenuItem.Name = "newAccountToolStripMenuItem";
            this.newAccountToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newAccountToolStripMenuItem.Text = "New Account";
            this.newAccountToolStripMenuItem.Click += new System.EventHandler(this.tsbNewAccount_Click);
            // 
            // tsmiSetPassword
            // 
            this.tsmiSetPassword.Name = "tsmiSetPassword";
            this.tsmiSetPassword.Size = new System.Drawing.Size(146, 22);
            this.tsmiSetPassword.Text = "Set Password";
            this.tsmiSetPassword.Click += new System.EventHandler(this.tsmiSetPassword_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(146, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmiNewAccount
            // 
            this.tsmiNewAccount.Name = "tsmiNewAccount";
            this.tsmiNewAccount.Size = new System.Drawing.Size(152, 22);
            this.tsmiNewAccount.Text = "New Account";
            this.tsmiNewAccount.Click += new System.EventHandler(this.tsmiNewAccount_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // tsTop
            // 
            this.tsTop.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCategories,
            this.tsbReports,
            this.tsbBusinesses,
            this.toolStripSeparator10,
            this.tsbYearToDateOnly});
            this.tsTop.Location = new System.Drawing.Point(0, 24);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(1166, 39);
            this.tsTop.TabIndex = 1;
            this.tsTop.Text = "toolStrip1";
            // 
            // tsbCategories
            // 
            this.tsbCategories.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCategories.Image = ((System.Drawing.Image)(resources.GetObject("tsbCategories.Image")));
            this.tsbCategories.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCategories.Name = "tsbCategories";
            this.tsbCategories.Size = new System.Drawing.Size(36, 36);
            this.tsbCategories.Text = "Categories";
            this.tsbCategories.Click += new System.EventHandler(this.tsbCategories_Click);
            // 
            // tsbReports
            // 
            this.tsbReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReports.Image = ((System.Drawing.Image)(resources.GetObject("tsbReports.Image")));
            this.tsbReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReports.Name = "tsbReports";
            this.tsbReports.Size = new System.Drawing.Size(36, 36);
            this.tsbReports.Text = "Reports";
            this.tsbReports.Click += new System.EventHandler(this.tsbReports_Click);
            // 
            // tsbBusinesses
            // 
            this.tsbBusinesses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBusinesses.Image = ((System.Drawing.Image)(resources.GetObject("tsbBusinesses.Image")));
            this.tsbBusinesses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBusinesses.Name = "tsbBusinesses";
            this.tsbBusinesses.Size = new System.Drawing.Size(36, 36);
            this.tsbBusinesses.Text = "Businesses";
            this.tsbBusinesses.Click += new System.EventHandler(this.tsbBusinesses_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // scTop
            // 
            this.scTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.scTop.Location = new System.Drawing.Point(0, 63);
            this.scTop.Name = "scTop";
            // 
            // scTop.Panel1
            // 
            this.scTop.Panel1.Controls.Add(this.scTopLeft);
            // 
            // scTop.Panel2
            // 
            this.scTop.Panel2.Controls.Add(this.scTopRight);
            this.scTop.Size = new System.Drawing.Size(1166, 131);
            this.scTop.SplitterDistance = 580;
            this.scTop.TabIndex = 0;
            // 
            // scTopLeft
            // 
            this.scTopLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTopLeft.Location = new System.Drawing.Point(0, 0);
            this.scTopLeft.Name = "scTopLeft";
            // 
            // scTopLeft.Panel1
            // 
            this.scTopLeft.Panel1.Controls.Add(this.gbCash);
            // 
            // scTopLeft.Panel2
            // 
            this.scTopLeft.Panel2.Controls.Add(this.gbCredit);
            this.scTopLeft.Size = new System.Drawing.Size(580, 131);
            this.scTopLeft.SplitterDistance = 284;
            this.scTopLeft.TabIndex = 0;
            // 
            // gbCash
            // 
            this.gbCash.Controls.Add(this.dgvCashAccounts);
            this.gbCash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCash.Location = new System.Drawing.Point(0, 0);
            this.gbCash.Name = "gbCash";
            this.gbCash.Size = new System.Drawing.Size(284, 131);
            this.gbCash.TabIndex = 0;
            this.gbCash.TabStop = false;
            this.gbCash.Text = "Cash";
            // 
            // dgvCashAccounts
            // 
            this.dgvCashAccounts.AllowUserToAddRows = false;
            this.dgvCashAccounts.AllowUserToDeleteRows = false;
            this.dgvCashAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCashAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCashAccounts.Location = new System.Drawing.Point(3, 16);
            this.dgvCashAccounts.Name = "dgvCashAccounts";
            this.dgvCashAccounts.ReadOnly = true;
            this.dgvCashAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashAccounts.Size = new System.Drawing.Size(278, 112);
            this.dgvCashAccounts.TabIndex = 0;
            this.dgvCashAccounts.Click += new System.EventHandler(this.dgvCashAccounts_Click);
            // 
            // gbCredit
            // 
            this.gbCredit.Controls.Add(this.dgvCreditAccounts);
            this.gbCredit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCredit.Location = new System.Drawing.Point(0, 0);
            this.gbCredit.Name = "gbCredit";
            this.gbCredit.Size = new System.Drawing.Size(292, 131);
            this.gbCredit.TabIndex = 0;
            this.gbCredit.TabStop = false;
            this.gbCredit.Text = "Lines of Credit";
            // 
            // dgvCreditAccounts
            // 
            this.dgvCreditAccounts.AllowUserToAddRows = false;
            this.dgvCreditAccounts.AllowUserToDeleteRows = false;
            this.dgvCreditAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCreditAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCreditAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCreditAccounts.Location = new System.Drawing.Point(3, 16);
            this.dgvCreditAccounts.Name = "dgvCreditAccounts";
            this.dgvCreditAccounts.ReadOnly = true;
            this.dgvCreditAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCreditAccounts.Size = new System.Drawing.Size(286, 112);
            this.dgvCreditAccounts.TabIndex = 0;
            this.dgvCreditAccounts.Click += new System.EventHandler(this.dgvCreditAccounts_Click);
            // 
            // scTopRight
            // 
            this.scTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTopRight.Location = new System.Drawing.Point(0, 0);
            this.scTopRight.Name = "scTopRight";
            // 
            // scTopRight.Panel1
            // 
            this.scTopRight.Panel1.Controls.Add(this.gbBalances);
            this.scTopRight.Size = new System.Drawing.Size(582, 131);
            this.scTopRight.SplitterDistance = 291;
            this.scTopRight.TabIndex = 0;
            // 
            // gbBalances
            // 
            this.gbBalances.Controls.Add(this.dgvBalances);
            this.gbBalances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBalances.Location = new System.Drawing.Point(0, 0);
            this.gbBalances.Name = "gbBalances";
            this.gbBalances.Size = new System.Drawing.Size(291, 131);
            this.gbBalances.TabIndex = 0;
            this.gbBalances.TabStop = false;
            this.gbBalances.Text = "Balances";
            // 
            // dgvBalances
            // 
            this.dgvBalances.AllowUserToAddRows = false;
            this.dgvBalances.AllowUserToDeleteRows = false;
            this.dgvBalances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBalances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBalances.ColumnHeadersVisible = false;
            this.dgvBalances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBalances.Location = new System.Drawing.Point(3, 16);
            this.dgvBalances.Name = "dgvBalances";
            this.dgvBalances.ReadOnly = true;
            this.dgvBalances.RowHeadersVisible = false;
            this.dgvBalances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBalances.Size = new System.Drawing.Size(285, 112);
            this.dgvBalances.TabIndex = 0;
            // 
            // tsBottom
            // 
            this.tsBottom.AutoSize = false;
            this.tsBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsBottom.Location = new System.Drawing.Point(0, 636);
            this.tsBottom.Name = "tsBottom";
            this.tsBottom.Size = new System.Drawing.Size(1166, 18);
            this.tsBottom.TabIndex = 3;
            this.tsBottom.Text = "toolStrip2";
            // 
            // tslMain
            // 
            this.tslMain.AutoSize = false;
            this.tslMain.Name = "tslMain";
            this.tslMain.Size = new System.Drawing.Size(200, 15);
            this.tslMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 18);
            // 
            // tspbMain
            // 
            this.tspbMain.AutoSize = false;
            this.tspbMain.Name = "tspbMain";
            this.tspbMain.Size = new System.Drawing.Size(200, 15);
            this.tspbMain.Visible = false;
            // 
            // bwLoadOFXfile
            // 
            this.bwLoadOFXfile.WorkerReportsProgress = true;
            this.bwLoadOFXfile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwLoadOFXfile_DoWork);
            this.bwLoadOFXfile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwLoadOFXfile_RunWorkerCompleted);
            // 
            // bwImportTransactions
            // 
            this.bwImportTransactions.WorkerReportsProgress = true;
            this.bwImportTransactions.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwImportTransactions_DoWork);
            this.bwImportTransactions.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwImportTransactions_ProgressChanged);
            this.bwImportTransactions.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwImportTransactions_RunWorkerCompleted);
            // 
            // tsbYearToDateOnly
            // 
            this.tsbYearToDateOnly.Checked = true;
            this.tsbYearToDateOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbYearToDateOnly.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbYearToDateOnly.Image = ((System.Drawing.Image)(resources.GetObject("tsbYearToDateOnly.Image")));
            this.tsbYearToDateOnly.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbYearToDateOnly.Name = "tsbYearToDateOnly";
            this.tsbYearToDateOnly.Size = new System.Drawing.Size(36, 36);
            this.tsbYearToDateOnly.Text = "toolStripButton1";
            this.tsbYearToDateOnly.Visible = false;
            this.tsbYearToDateOnly.Click += new System.EventHandler(this.tsbYearToDateOnly_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 654);
            this.Controls.Add(this.tsBottom);
            this.Controls.Add(this.scTop);
            this.Controls.Add(this.tsTop);
            this.Controls.Add(this.msTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msTop;
            this.Name = "FrmMain";
            this.Text = "BeanCounter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.msTop.ResumeLayout(false);
            this.msTop.PerformLayout();
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.scTop.Panel1.ResumeLayout(false);
            this.scTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTop)).EndInit();
            this.scTop.ResumeLayout(false);
            this.scTopLeft.Panel1.ResumeLayout(false);
            this.scTopLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTopLeft)).EndInit();
            this.scTopLeft.ResumeLayout(false);
            this.gbCash.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashAccounts)).EndInit();
            this.gbCredit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCreditAccounts)).EndInit();
            this.scTopRight.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTopRight)).EndInit();
            this.scTopRight.ResumeLayout(false);
            this.gbBalances.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBalances)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



#endregion

        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem newAccountToolStripMenuItem;
        private ToolStripMenuItem tsmiSetPassword;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem tsmiExit;
        private ToolStripButton tsbYearToDateOnly;
    }
}