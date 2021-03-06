using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    partial class FrmRegister
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
		
        private GroupBox grpRegister;

        private DataGridView dgvRegister;

        private MenuStrip menuStrip1;

        private ToolStripMenuItem registerToolStripMenuItem;

        private ToolStripMenuItem viewToolStripMenuItem1;

        private ToolStripMenuItem sortToolStripMenuItem1;

        private ToolStripSeparator toolStripSeparator1;

        private StatusStrip statusStrip1;

        private ToolStripStatusLabel tsslTransactionCount;


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
            this.grpRegister = new System.Windows.Forms.GroupBox();
            this.dgvRegister = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowAllTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShowUnverifiedTransactionsOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByDate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiByCategoryBusinessName = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.markCategorizedTransactionsAsVerifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiYearToDateOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslTransactionCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpRegister
            // 
            this.grpRegister.Controls.Add(this.dgvRegister);
            this.grpRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRegister.Location = new System.Drawing.Point(0, 42);
            this.grpRegister.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpRegister.Name = "grpRegister";
            this.grpRegister.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grpRegister.Size = new System.Drawing.Size(1052, 711);
            this.grpRegister.TabIndex = 0;
            this.grpRegister.TabStop = false;
            // 
            // dgvRegister
            // 
            this.dgvRegister.AllowUserToAddRows = false;
            this.dgvRegister.AllowUserToDeleteRows = false;
            this.dgvRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegister.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvRegister.Location = new System.Drawing.Point(6, 30);
            this.dgvRegister.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dgvRegister.Name = "dgvRegister";
            this.dgvRegister.RowHeadersWidth = 72;
            this.dgvRegister.Size = new System.Drawing.Size(1041, 635);
            this.dgvRegister.TabIndex = 0;
            this.dgvRegister.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegister_CellContentClick);
            this.dgvRegister.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegister_CellLeave);
            this.dgvRegister.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvRegister_EditingControlShowing);
            this.dgvRegister.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRegister_RowHeaderMouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1052, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.sortToolStripMenuItem,
            this.toolStripSeparator2,
            this.markCategorizedTransactionsAsVerifiedToolStripMenuItem,
            this.tsmiYearToDateOnly});
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(105, 34);
            this.registerToolStripMenuItem.Text = "Register";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowAllTransactions,
            this.tsmiShowUnverifiedTransactionsOnly});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(544, 40);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // tsmiShowAllTransactions
            // 
            this.tsmiShowAllTransactions.Name = "tsmiShowAllTransactions";
            this.tsmiShowAllTransactions.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.tsmiShowAllTransactions.Size = new System.Drawing.Size(476, 40);
            this.tsmiShowAllTransactions.Text = "Show all transactions";
            this.tsmiShowAllTransactions.Click += new System.EventHandler(this.tsmiShowAllTransactions_Click);
            // 
            // tsmiShowUnverifiedTransactionsOnly
            // 
            this.tsmiShowUnverifiedTransactionsOnly.Checked = true;
            this.tsmiShowUnverifiedTransactionsOnly.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiShowUnverifiedTransactionsOnly.Name = "tsmiShowUnverifiedTransactionsOnly";
            this.tsmiShowUnverifiedTransactionsOnly.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.tsmiShowUnverifiedTransactionsOnly.Size = new System.Drawing.Size(476, 40);
            this.tsmiShowUnverifiedTransactionsOnly.Text = "Show unverified transactions only";
            this.tsmiShowUnverifiedTransactionsOnly.Click += new System.EventHandler(this.tsmiShowUnverifiedTransactionsOnly_Click);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiByDate,
            this.tsmiByCategoryBusinessName});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(544, 40);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // tsmiByDate
            // 
            this.tsmiByDate.Name = "tsmiByDate";
            this.tsmiByDate.Size = new System.Drawing.Size(381, 40);
            this.tsmiByDate.Text = "By date";
            this.tsmiByDate.Click += new System.EventHandler(this.tsmiByDate_Click);
            // 
            // tsmiByCategoryBusinessName
            // 
            this.tsmiByCategoryBusinessName.Checked = true;
            this.tsmiByCategoryBusinessName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiByCategoryBusinessName.Name = "tsmiByCategoryBusinessName";
            this.tsmiByCategoryBusinessName.Size = new System.Drawing.Size(381, 40);
            this.tsmiByCategoryBusinessName.Text = "By categoryname, Business";
            this.tsmiByCategoryBusinessName.Click += new System.EventHandler(this.tsmiByCategoryBusinessName_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(541, 6);
            // 
            // markCategorizedTransactionsAsVerifiedToolStripMenuItem
            // 
            this.markCategorizedTransactionsAsVerifiedToolStripMenuItem.Name = "markCategorizedTransactionsAsVerifiedToolStripMenuItem";
            this.markCategorizedTransactionsAsVerifiedToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.markCategorizedTransactionsAsVerifiedToolStripMenuItem.Size = new System.Drawing.Size(544, 40);
            this.markCategorizedTransactionsAsVerifiedToolStripMenuItem.Text = "Mark categorized transactions as verified";
            this.markCategorizedTransactionsAsVerifiedToolStripMenuItem.Click += new System.EventHandler(this.markCategorizedTransactionsAsVerifiedToolStripMenuItem_Click);
            // 
            // tsmiYearToDateOnly
            // 
            this.tsmiYearToDateOnly.Name = "tsmiYearToDateOnly";
            this.tsmiYearToDateOnly.Size = new System.Drawing.Size(544, 40);
            this.tsmiYearToDateOnly.Text = "Show Year To Date Only";
            this.tsmiYearToDateOnly.Click += new System.EventHandler(this.tsmiYearToDateOnly_Click);
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(307, 22);
            this.viewToolStripMenuItem1.Text = "View";
            // 
            // sortToolStripMenuItem1
            // 
            this.sortToolStripMenuItem1.Name = "sortToolStripMenuItem1";
            this.sortToolStripMenuItem1.Size = new System.Drawing.Size(307, 22);
            this.sortToolStripMenuItem1.Text = "Sort";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(304, 6);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslTransactionCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 731);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 26, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1052, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslTransactionCount
            // 
            this.tsslTransactionCount.Name = "tsslTransactionCount";
            this.tsslTransactionCount.Size = new System.Drawing.Size(0, 13);
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 753);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpRegister);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FrmRegister";
            this.Text = "frmRegister";
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            this.grpRegister.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegister)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStripMenuItem markCategorizedTransactionsAsVerifiedToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem tsmiShowAllTransactions;
        private ToolStripMenuItem tsmiShowUnverifiedTransactionsOnly;
        private ToolStripMenuItem sortToolStripMenuItem;
        public ToolStripMenuItem tsmiByDate;
        public ToolStripMenuItem tsmiByCategoryBusinessName;
        private ToolStripSeparator toolStripSeparator2;
        public ToolStripMenuItem tsmiYearToDateOnly;
    }
}