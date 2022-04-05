using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    partial class FrmCategories
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private SplitContainer scMain;

        private DataGridView dgvCategories;

        private GroupBox gbMonthlyAmounts;

        private Label label12;

        private Label label11;

        private TextBox tbDec;

        private TextBox tbNov;

        private TextBox tbOct;

        private Label label10;

        private TextBox tbSep;

        private Label label9;

        private TextBox tbAug;

        private Label label8;

        private TextBox tbJul;

        private Label label7;

        private TextBox tbJun;

        private Label label6;

        private TextBox tbMay;

        private Label label5;

        private TextBox tbApr;

        private Label label4;

        private TextBox tbMar;

        private Label label3;

        private TextBox tbFeb;

        private Label label2;

        private TextBox tbJan;

        private Label label1;

        private Button btnFill;

        private TextBox tbFill;

        private Label label19;

        private GroupBox gbProperties;

        private Button btnSave;

        private Button btnClear;

        private ContextMenuStrip cmsDelete;

        private ToolStripMenuItem tsmiDeleteCategory;

        private RadioButton rbSpending;

        private RadioButton rbIncome;

        private RadioButton rbWeekly;

        private RadioButton rbOneTime;

        private RadioButton rbMonthly;

        private RadioButton rbBiWeekly;

        private RadioButton rbAnytime;

        private RadioButton rbAnnually;

        private CheckBox chkByDate;

        private GroupBox groupBox1;

        private GroupBox groupBox2;

        private bool FinishedLoading;

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
            this.components = new Container();
            this.scMain = new SplitContainer();
            this.dgvCategories = new DataGridView();
            this.chkByDate = new CheckBox();
            this.gbProperties = new GroupBox();
            this.rbSpending = new RadioButton();
            this.rbIncome = new RadioButton();
            this.rbWeekly = new RadioButton();
            this.rbOneTime = new RadioButton();
            this.rbMonthly = new RadioButton();
            this.rbBiWeekly = new RadioButton();
            this.rbAnytime = new RadioButton();
            this.rbAnnually = new RadioButton();
            this.gbMonthlyAmounts = new GroupBox();
            this.btnClear = new Button();
            this.btnSave = new Button();
            this.btnFill = new Button();
            this.tbFill = new TextBox();
            this.label19 = new Label();
            this.label12 = new Label();
            this.label11 = new Label();
            this.tbDec = new TextBox();
            this.tbNov = new TextBox();
            this.tbOct = new TextBox();
            this.label10 = new Label();
            this.tbSep = new TextBox();
            this.label9 = new Label();
            this.tbAug = new TextBox();
            this.label8 = new Label();
            this.tbJul = new TextBox();
            this.label7 = new Label();
            this.tbJun = new TextBox();
            this.label6 = new Label();
            this.tbMay = new TextBox();
            this.label5 = new Label();
            this.tbApr = new TextBox();
            this.label4 = new Label();
            this.tbMar = new TextBox();
            this.label3 = new Label();
            this.tbFeb = new TextBox();
            this.label2 = new Label();
            this.tbJan = new TextBox();
            this.label1 = new Label();
            this.cmsDelete = new ContextMenuStrip(this.components);
            this.tsmiDeleteCategory = new ToolStripMenuItem();
            this.groupBox1 = new GroupBox();
            this.groupBox2 = new GroupBox();
            ((ISupportInitialize)this.scMain).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((ISupportInitialize)this.dgvCategories).BeginInit();
            this.gbProperties.SuspendLayout();
            this.gbMonthlyAmounts.SuspendLayout();
            this.cmsDelete.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.scMain.Dock = DockStyle.Fill;
            this.scMain.FixedPanel = FixedPanel.Panel2;
            this.scMain.Location = new Point(0, 0);
            this.scMain.Name = "scMain";
            this.scMain.Panel1.Controls.Add(this.dgvCategories);
            this.scMain.Panel2.Controls.Add(this.gbProperties);
            this.scMain.Panel2.Controls.Add(this.chkByDate);
            this.scMain.Panel2.Controls.Add(this.gbMonthlyAmounts);
            this.scMain.Size = new Size(846, 624);
            this.scMain.SplitterDistance = 651;
            this.scMain.TabIndex = 0;
            this.dgvCategories.AllowUserToOrderColumns = true;
            this.dgvCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.EditMode = DataGridViewEditMode.EditOnKeystroke;
            this.dgvCategories.Location = new Point(13, 12);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.Size = new Size(635, 599);
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.CellContentClick += new DataGridViewCellEventHandler(this.dgvCategories_CellContentClick);
            this.dgvCategories.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dgvCategories_CellMouseClick);
            this.dgvCategories.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dgvCategories_EditingControlShowing);
            this.dgvCategories.RowEnter += new DataGridViewCellEventHandler(this.dgvCategories_RowEnter);
            this.dgvCategories.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvCategories_RowHeaderMouseClick);
            this.dgvCategories.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dgvCategories_RowsAdded);
            this.chkByDate.AutoSize = true;
            this.chkByDate.Location = new Point(14, 551);
            this.chkByDate.Name = "chkByDate";
            this.chkByDate.Size = new Size(90, 17);
            this.chkByDate.TabIndex = 2;
            this.chkByDate.Text = "Order by date";
            this.chkByDate.UseVisualStyleBackColor = true;
            this.chkByDate.Visible = false;
            this.chkByDate.CheckedChanged += new EventHandler(this.chkByDate_CheckedChanged);
            this.gbProperties.Controls.Add(this.groupBox1);
            this.gbProperties.Controls.Add(this.groupBox2);
            this.gbProperties.Location = new Point(7, 6);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new Size(172, 165);
            this.gbProperties.TabIndex = 0;
            this.gbProperties.TabStop = false;
            this.rbSpending.AutoSize = true;
            this.rbSpending.Location = new Point(84, 18);
            this.rbSpending.Name = "rbSpending";
            this.rbSpending.Size = new Size(70, 17);
            this.rbSpending.TabIndex = 7;
            this.rbSpending.TabStop = true;
            this.rbSpending.Text = "Spending";
            this.rbSpending.UseVisualStyleBackColor = true;
            this.rbSpending.CheckedChanged += new EventHandler(this.rbSpending_CheckedChanged);
            this.rbIncome.AutoSize = true;
            this.rbIncome.Location = new Point(6, 18);
            this.rbIncome.Name = "rbIncome";
            this.rbIncome.Size = new Size(60, 17);
            this.rbIncome.TabIndex = 6;
            this.rbIncome.TabStop = true;
            this.rbIncome.Text = "Income";
            this.rbIncome.UseVisualStyleBackColor = true;
            this.rbIncome.CheckedChanged += new EventHandler(this.rbIncome_CheckedChanged);
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Location = new Point(84, 58);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Size = new Size(61, 17);
            this.rbWeekly.TabIndex = 5;
            this.rbWeekly.TabStop = true;
            this.rbWeekly.Text = "Weekly";
            this.rbWeekly.UseVisualStyleBackColor = true;
            this.rbWeekly.CheckedChanged += new EventHandler(this.rbWeekly_CheckedChanged);
            this.rbOneTime.AutoSize = true;
            this.rbOneTime.Location = new Point(84, 35);
            this.rbOneTime.Name = "rbOneTime";
            this.rbOneTime.Size = new Size(71, 17);
            this.rbOneTime.TabIndex = 4;
            this.rbOneTime.TabStop = true;
            this.rbOneTime.Text = "One Time";
            this.rbOneTime.UseVisualStyleBackColor = true;
            this.rbOneTime.CheckedChanged += new EventHandler(this.rbOneTime_CheckedChanged);
            this.rbMonthly.AutoSize = true;
            this.rbMonthly.Location = new Point(84, 10);
            this.rbMonthly.Name = "rbMonthly";
            this.rbMonthly.Size = new Size(62, 17);
            this.rbMonthly.TabIndex = 3;
            this.rbMonthly.TabStop = true;
            this.rbMonthly.Text = "Monthly";
            this.rbMonthly.UseVisualStyleBackColor = true;
            this.rbMonthly.CheckedChanged += new EventHandler(this.rbMonthly_CheckedChanged);
            this.rbBiWeekly.AutoSize = true;
            this.rbBiWeekly.Location = new Point(6, 58);
            this.rbBiWeekly.Name = "rbBiWeekly";
            this.rbBiWeekly.Size = new Size(73, 17);
            this.rbBiWeekly.TabIndex = 2;
            this.rbBiWeekly.TabStop = true;
            this.rbBiWeekly.Text = "Bi-Weekly";
            this.rbBiWeekly.UseVisualStyleBackColor = true;
            this.rbBiWeekly.CheckedChanged += new EventHandler(this.rbBiWeekly_CheckedChanged);
            this.rbAnytime.AutoSize = true;
            this.rbAnytime.Location = new Point(6, 34);
            this.rbAnytime.Name = "rbAnytime";
            this.rbAnytime.Size = new Size(62, 17);
            this.rbAnytime.TabIndex = 1;
            this.rbAnytime.TabStop = true;
            this.rbAnytime.Text = "Anytime";
            this.rbAnytime.UseVisualStyleBackColor = true;
            this.rbAnytime.CheckedChanged += new EventHandler(this.rbAnytime_CheckedChanged);
            this.rbAnnually.AutoSize = true;
            this.rbAnnually.Location = new Point(6, 10);
            this.rbAnnually.Name = "rbAnnually";
            this.rbAnnually.Size = new Size(65, 17);
            this.rbAnnually.TabIndex = 0;
            this.rbAnnually.TabStop = true;
            this.rbAnnually.Text = "Annually";
            this.rbAnnually.UseVisualStyleBackColor = true;
            this.rbAnnually.CheckedChanged += new EventHandler(this.rbAnnually_CheckedChanged);
            this.gbMonthlyAmounts.Controls.Add(this.btnClear);
            this.gbMonthlyAmounts.Controls.Add(this.btnSave);
            this.gbMonthlyAmounts.Controls.Add(this.btnFill);
            this.gbMonthlyAmounts.Controls.Add(this.tbFill);
            this.gbMonthlyAmounts.Controls.Add(this.label19);
            this.gbMonthlyAmounts.Controls.Add(this.label12);
            this.gbMonthlyAmounts.Controls.Add(this.label11);
            this.gbMonthlyAmounts.Controls.Add(this.tbDec);
            this.gbMonthlyAmounts.Controls.Add(this.tbNov);
            this.gbMonthlyAmounts.Controls.Add(this.tbOct);
            this.gbMonthlyAmounts.Controls.Add(this.label10);
            this.gbMonthlyAmounts.Controls.Add(this.tbSep);
            this.gbMonthlyAmounts.Controls.Add(this.label9);
            this.gbMonthlyAmounts.Controls.Add(this.tbAug);
            this.gbMonthlyAmounts.Controls.Add(this.label8);
            this.gbMonthlyAmounts.Controls.Add(this.tbJul);
            this.gbMonthlyAmounts.Controls.Add(this.label7);
            this.gbMonthlyAmounts.Controls.Add(this.tbJun);
            this.gbMonthlyAmounts.Controls.Add(this.label6);
            this.gbMonthlyAmounts.Controls.Add(this.tbMay);
            this.gbMonthlyAmounts.Controls.Add(this.label5);
            this.gbMonthlyAmounts.Controls.Add(this.tbApr);
            this.gbMonthlyAmounts.Controls.Add(this.label4);
            this.gbMonthlyAmounts.Controls.Add(this.tbMar);
            this.gbMonthlyAmounts.Controls.Add(this.label3);
            this.gbMonthlyAmounts.Controls.Add(this.tbFeb);
            this.gbMonthlyAmounts.Controls.Add(this.label2);
            this.gbMonthlyAmounts.Controls.Add(this.tbJan);
            this.gbMonthlyAmounts.Controls.Add(this.label1);
            this.gbMonthlyAmounts.Enabled = false;
            this.gbMonthlyAmounts.Location = new Point(7, 177);
            this.gbMonthlyAmounts.Name = "gbMonthlyAmounts";
            this.gbMonthlyAmounts.Size = new Size(172, 367);
            this.gbMonthlyAmounts.TabIndex = 1;
            this.gbMonthlyAmounts.TabStop = false;
            this.gbMonthlyAmounts.Text = "Monthly TransactionAmounts";
            this.btnClear.Location = new Point(93, 290);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(56, 23);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            this.btnSave.Location = new Point(7, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(54, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            this.btnFill.Location = new Point(94, 338);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new Size(55, 23);
            this.btnFill.TabIndex = 26;
            this.btnFill.Text = "Fill";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new EventHandler(this.btnFill_Click);
            this.tbFill.Location = new Point(6, 341);
            this.tbFill.Name = "tbFill";
            this.tbFill.Size = new Size(55, 20);
            this.tbFill.TabIndex = 25;
            this.label19.AutoSize = true;
            this.label19.Location = new Point(7, 325);
            this.label19.Name = "label19";
            this.label19.Size = new Size(22, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "Fill:";
            this.label12.AutoSize = true;
            this.label12.Location = new Point(96, 236);
            this.label12.Name = "label12";
            this.label12.Size = new Size(30, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Dec:";
            this.label11.AutoSize = true;
            this.label11.Location = new Point(96, 193);
            this.label11.Name = "label11";
            this.label11.Size = new Size(30, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Nov:";
            this.tbDec.Location = new Point(94, 255);
            this.tbDec.Name = "tbDec";
            this.tbDec.Size = new Size(55, 20);
            this.tbDec.TabIndex = 23;
            this.tbNov.Location = new Point(94, 211);
            this.tbNov.Name = "tbNov";
            this.tbNov.Size = new Size(55, 20);
            this.tbNov.TabIndex = 21;
            this.tbOct.Location = new Point(94, 167);
            this.tbOct.Name = "tbOct";
            this.tbOct.Size = new Size(55, 20);
            this.tbOct.TabIndex = 19;
            this.label10.AutoSize = true;
            this.label10.Location = new Point(96, 150);
            this.label10.Name = "label10";
            this.label10.Size = new Size(27, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Oct:";
            this.tbSep.Location = new Point(94, 123);
            this.tbSep.Name = "tbSep";
            this.tbSep.Size = new Size(55, 20);
            this.tbSep.TabIndex = 17;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(96, 106);
            this.label9.Name = "label9";
            this.label9.Size = new Size(29, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Sep:";
            this.tbAug.Location = new Point(94, 79);
            this.tbAug.Name = "tbAug";
            this.tbAug.Size = new Size(55, 20);
            this.tbAug.TabIndex = 15;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(96, 63);
            this.label8.Name = "label8";
            this.label8.Size = new Size(29, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Aug:";
            this.tbJul.Location = new Point(94, 36);
            this.tbJul.Name = "tbJul";
            this.tbJul.Size = new Size(55, 20);
            this.tbJul.TabIndex = 13;
            this.label7.AutoSize = true;
            this.label7.Location = new Point(96, 19);
            this.label7.Name = "label7";
            this.label7.Size = new Size(23, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Jul:";
            this.tbJun.Location = new Point(6, 255);
            this.tbJun.Name = "tbJun";
            this.tbJun.Size = new Size(55, 20);
            this.tbJun.TabIndex = 11;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(7, 238);
            this.label6.Name = "label6";
            this.label6.Size = new Size(27, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Jun:";
            this.tbMay.Location = new Point(6, 211);
            this.tbMay.Name = "tbMay";
            this.tbMay.Size = new Size(55, 20);
            this.tbMay.TabIndex = 9;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(7, 194);
            this.label5.Name = "label5";
            this.label5.Size = new Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "May:";
            this.tbApr.Location = new Point(6, 167);
            this.tbApr.Name = "tbApr";
            this.tbApr.Size = new Size(55, 20);
            this.tbApr.TabIndex = 7;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(7, 150);
            this.label4.Name = "label4";
            this.label4.Size = new Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Arp:";
            this.tbMar.Location = new Point(6, 123);
            this.tbMar.Name = "tbMar";
            this.tbMar.Size = new Size(55, 20);
            this.tbMar.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(7, 106);
            this.label3.Name = "label3";
            this.label3.Size = new Size(28, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mar:";
            this.tbFeb.Location = new Point(6, 79);
            this.tbFeb.Name = "tbFeb";
            this.tbFeb.Size = new Size(55, 20);
            this.tbFeb.TabIndex = 3;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(7, 63);
            this.label2.Name = "label2";
            this.label2.Size = new Size(25, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Feb";
            this.tbJan.Location = new Point(6, 36);
            this.tbJan.Name = "tbJan";
            this.tbJan.Size = new Size(55, 20);
            this.tbJan.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jan:";
            this.cmsDelete.Items.AddRange(new ToolStripItem[] { this.tsmiDeleteCategory });
            this.cmsDelete.Name = "contextMenuStrip1";
            this.cmsDelete.Size = new Size(159, 48);
            this.tsmiDeleteCategory.Enabled = false;
            this.tsmiDeleteCategory.Name = "tsmiDeleteCategory";
            this.tsmiDeleteCategory.Size = new Size(158, 22);
            this.tsmiDeleteCategory.Text = "Delete Category";
            this.tsmiDeleteCategory.Click += new EventHandler(this.tsmiDeleteCategory_Click);
            this.groupBox1.Controls.Add(this.rbWeekly);
            this.groupBox1.Controls.Add(this.rbOneTime);
            this.groupBox1.Controls.Add(this.rbAnnually);
            this.groupBox1.Controls.Add(this.rbMonthly);
            this.groupBox1.Controls.Add(this.rbAnytime);
            this.groupBox1.Controls.Add(this.rbBiWeekly);
            this.groupBox1.Location = new Point(5, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(161, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox2.Controls.Add(this.rbSpending);
            this.groupBox2.Controls.Add(this.rbIncome);
            this.groupBox2.Location = new Point(5, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(161, 47);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(846, 624);
            base.Controls.Add(this.scMain);
            base.Name = "FrmCategories";
            this.Text = "frmCategories";
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.Panel2.PerformLayout();
            ((ISupportInitialize)this.scMain).EndInit();
            this.scMain.ResumeLayout(false);
            ((ISupportInitialize)this.dgvCategories).EndInit();
            this.gbProperties.ResumeLayout(false);
            this.gbMonthlyAmounts.ResumeLayout(false);
            this.gbMonthlyAmounts.PerformLayout();
            this.cmsDelete.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
        }


        #endregion
    }
}