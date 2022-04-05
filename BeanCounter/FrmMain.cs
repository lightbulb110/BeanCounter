using BeanCounter.BusinessLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanCounter
{
    public partial class FrmMain : Form
    {
        public string[] Args;

        public FrmMain(string[] args)
        {
            Args = args;
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (this.Args != null && (int)this.Args.Length != 0 && !this.bwLoadOFXfile.IsBusy)
            {
                this.tslMain.Text = "Loading OFX file...";
                this.bwLoadOFXfile.RunWorkerAsync(this.Args[0]);
            }
            this.AddColumns();
            this.LoadGrids();
        }

        private void bwLoadOFXfile_DoWork(object sender, DoWorkEventArgs e)
        {
            OpenFinancialExchange data = OpenFinancialExchange.GetData(e.Argument as string);
            data.BankAccount = BankAccount.GetBankAccount(data);
            e.Result = data;
        }

        private void bwLoadOFXfile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool flag = false;
            OpenFinancialExchange data = e.Result as OpenFinancialExchange;
            if (data.BankAccount.BankAccountID == 0)
            {
                FrmNewBankAccount frmNewBankAccount = new FrmNewBankAccount(data)
                {
                    WindowState = FormWindowState.Maximized
                };
                switch (frmNewBankAccount.ShowDialog())
                {
                    case DialogResult.OK:
                        {
                            data.BankAccount.AccountName = frmNewBankAccount.tbNickname.Text;
                            data.BankAccount.WebAddress = frmNewBankAccount.tbWebAddress.Text;
                            if (!data.BankAccount.WebAddress.Contains("http://"))
                            {
                                data.BankAccount.WebAddress = string.Concat("http://", data.BankAccount.WebAddress);
                            }
                            if (frmNewBankAccount.rbColumnA.Checked)
                            {
                                data.BankAccount.ReverseFields = false;
                            }
                            else if (frmNewBankAccount.rbColumnB.Checked)
                            {
                                data.BankAccount.ReverseFields = true;
                            }
                            if (!string.IsNullOrEmpty(frmNewBankAccount.cbRemoveFromColumnA.Text))
                            {
                                if (!data.BankAccount.ReverseFields)
                                {
                                    data.BankAccount.RemoveFromBusiness = frmNewBankAccount.cbRemoveFromColumnA.Text;
                                }
                                else
                                {
                                    data.BankAccount.RemoveFromBusiness = frmNewBankAccount.cbRemoveFromColumnB.Text;
                                }
                            }
                            if (!string.IsNullOrEmpty(frmNewBankAccount.cbRemoveFromColumnB.Text))
                            {
                                if (!data.BankAccount.ReverseFields)
                                {
                                    data.BankAccount.RemoveFromBankMemo = frmNewBankAccount.cbRemoveFromColumnB.Text;
                                }
                                else
                                {
                                    data.BankAccount.RemoveFromBankMemo = frmNewBankAccount.cbRemoveFromColumnA.Text;
                                }
                            }
                            data.BankAccount.BankAccountID = BankAccount.CreateBankAccount(data.BankAccount);
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            flag = true;
                            break;
                        }
                    default:
                        {
                            flag = true;
                            break;
                        }
                }
            }
            if (!flag)
            {
                this.tslMain.Text = "Importing Transctions...";
                this.tspbMain.Value = 0;
                this.tspbMain.Visible = true;
                this.bwImportTransactions.RunWorkerAsync(data);
            }
        }

        private void AddColumns()
        {
            this.dgvCashAccounts.Rows.Clear();
            this.dgvCreditAccounts.Rows.Clear();
            this.dgvCashAccounts.Columns.Clear();
            this.dgvCreditAccounts.Columns.Clear();
            this.dgvBalances.Columns.Clear();
            this.dgvCashAccounts.Columns.Add(this.Column("AccountName", true, "Account"));
            this.dgvCreditAccounts.Columns.Add(this.Column("AccountName", true, "Account"));
            this.dgvCashAccounts.Columns.Add(this.Column("OnlineBalance", true, "Balance"));
            this.dgvCreditAccounts.Columns.Add(this.Column("OnlineBalance", true, "Balance"));
            this.dgvCashAccounts.Columns.Add(this.Column("BankAccountID", false, ""));
            this.dgvCreditAccounts.Columns.Add(this.Column("BankAccountID", false, ""));
            this.dgvCashAccounts.Columns.Add(this.Column("WebAddress", false, ""));
            this.dgvCreditAccounts.Columns.Add(this.Column("WebAddress", false, ""));
            this.dgvBalances.Columns.Add(this.Column("label", true, ""));
            this.dgvBalances.Columns.Add(this.Column("StaticAmount", true, ""));
        }

        private void bwImportTransactions_DoWork(object sender, DoWorkEventArgs e)
        {
            OpenFinancialExchange data = e.Argument as OpenFinancialExchange;
            ImportUtilities.UpdateBalance(data);
            ImportUtilities.LogBalanceHistory(data);
            decimal count = data.Transactions.Count;
            decimal i = 0;
            List<Business> Businesses = Business.NationalBusinesses();
            foreach (Transaction transaction in data.Transactions)
            {
                if (!ImportUtilities.DoesTransactionExists(transaction, data.BankAccount.BankAccountID))
                {
                    Transaction _transaction = Transaction.CheckBankTricks(transaction, data.BankAccount);
                    string category = "";
                    if (!string.IsNullOrEmpty(transaction.CategoryName))
                    {
                        // this is to account for bank specific stuff
                        category = transaction.CategoryName;
                    }
                    if (category == "")
                    {
                        category = ImportUtilities.GetCategoryName(_transaction, Businesses);
                    }
                    int num1 = ImportUtilities.InsertIntoOringalTransaction(data.BankAccount, _transaction, category);
                    ImportUtilities.InsertIntoSplitTransction(category, num1, _transaction);
                }
                i = i++;
                decimal progress = (i / count) * new decimal(100);
                this.bwImportTransactions.ReportProgress((int)progress);
            }
        }

        private void bwImportTransactions_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tspbMain.Value = e.ProgressPercentage;
        }

        private void bwImportTransactions_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.tslMain.Text = "Finished importing transactions!";
            this.tspbMain.Value = 0;
            this.tspbMain.Visible = false;
            this.RefreshMainForm();
        }

        private DataGridViewTextBoxColumn Column(string name, bool visable, string headerText)
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
            {
                Name = name,
                HeaderText = headerText,
                Visible = visable
            };
            return dataGridViewTextBoxColumn;
        }

        private void dgvCashAccounts_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedRow in this.dgvCreditAccounts.SelectedRows)
            {
                selectedRow.Selected = false;
            }
            if (this.dgvCashAccounts.CurrentRow.Cells["BankAccountID"].Value != null && FrmMain.IsNumber(this.dgvCashAccounts.CurrentRow.Cells["BankAccountID"].Value.ToString()))
            {
                int bankAccountId = Convert.ToInt32(this.dgvCashAccounts.CurrentRow.Cells["BankAccountID"].Value.ToString());
                string accountName = string.Empty;
                if (this.dgvCashAccounts.CurrentRow.Cells["AccountName"].Value != null)
                {
                    accountName = this.dgvCashAccounts.CurrentRow.Cells["AccountName"].Value.ToString();
                }
                this.LoadBankAccount(bankAccountId, accountName);
            }
        }

        private void dgvCreditAccounts_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedRow in this.dgvCashAccounts.SelectedRows)
            {
                selectedRow.Selected = false;
            }
            this.tslMain.Text = "";
            if (this.dgvCreditAccounts.CurrentRow.Cells["BankAccountID"].Value != null && FrmMain.IsNumber(this.dgvCreditAccounts.CurrentRow.Cells["BankAccountID"].Value.ToString()))
            {
                int bankAccountId = Convert.ToInt32(this.dgvCreditAccounts.CurrentRow.Cells["BankAccountID"].Value.ToString());
                string accountName = string.Empty;
                if (this.dgvCreditAccounts.CurrentRow.Cells["AccountName"].Value != null)
                {
                    accountName = this.dgvCreditAccounts.CurrentRow.Cells["AccountName"].Value.ToString();
                }
                this.LoadBankAccount(bankAccountId, accountName);
            }
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("iexplore.exe", "www.personalsoftwaresolutions.com/donate.aspx");
        }

        private static bool IsNumber(string text)
        {
            double num;
            text = text.Trim();
            return double.TryParse(text, out num);
        }

        private void LoadBalances()
        {
            decimal cashBalance = BankAccount.GetAccountBalance("CASH");
            decimal creditBalance = BankAccount.GetAccountBalance("CREDIT");

            this.dgvBalances.Rows.Clear();
            DataGridViewRowCollection rows = this.dgvBalances.Rows;
            object[] totalCash = new object[] { "Total Cash: ", cashBalance.ToString("c") };
            rows.Add(totalCash);
            DataGridViewRowCollection dataGridViewRowCollections = this.dgvBalances.Rows;
            object[] totalDebt = new object[] { "Total Debt: ", creditBalance.ToString("c") };
            dataGridViewRowCollections.Add(totalDebt);
            DataGridViewRowCollection rows1 = this.dgvBalances.Rows;
            object[] networth = new object[] { "Networth: ", GetNetworth(cashBalance, creditBalance).ToString("c") };
            rows1.Add(networth);
            foreach (DataGridViewRow row in this.dgvBalances.Rows)
            {
                if (double.Parse(row.Cells[1].Value.ToString(), NumberStyles.Currency) >= 0)
                {
                    continue;
                }
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
            this.dgvBalances.Rows[2].DefaultCellStyle.Font = new Font(this.dgvBalances.DefaultCellStyle.Font.FontFamily, this.dgvBalances.DefaultCellStyle.Font.Size, FontStyle.Bold);
            foreach (DataGridViewRow row in this.dgvBalances.SelectedRows)
            {
                row.Selected = false;
            }
        }

        private static decimal GetNetworth(decimal cashBalance, decimal creditBalance)
        {
            decimal networth = 0;
            if (cashBalance != 0)
            {
                networth = cashBalance;
            }
            if (creditBalance != 0)
            {
                networth += creditBalance;
            }

            return networth;
        }

        private void LoadBankAccount(int bankAccountID, string accountName)
        {
            this.tslMain.Text = "";
            FrmRegister frmRegister = new FrmRegister(bankAccountID, accountName);
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["YearToDateOnly"].ToString()))
            {
                frmRegister.tsmiYearToDateOnly.Checked = false;
            }
            else
            {
                frmRegister.tsmiYearToDateOnly.Checked = true;
            }
            frmRegister.tsmiByDate.Checked = false;
            frmRegister.tsmiByCategoryBusinessName.Checked = true;
            frmRegister.WindowState = FormWindowState.Maximized;
            frmRegister.MdiParent = this;
            frmRegister.Show();
        }

        private void LoadCashAccounts()
        {
            foreach (BankAccount bankAccount in BankAccount.GetBankAccounts("CASH"))
            {
                int i = 0;
                DataGridViewRowCollection rows = this.dgvCashAccounts.Rows;
                object[] cashAccount = new object[] { bankAccount.AccountName, bankAccount.Balance.ToString("c"), Convert.ToString(bankAccount.BankAccountID), bankAccount.WebAddress };
                rows.Add(cashAccount);
                if (bankAccount.Balance < new decimal(0))
                {
                    DataGridViewRow item = this.dgvCashAccounts.Rows[i];
                    item.DefaultCellStyle.ForeColor = Color.Red;
                }
                i++;
            }
        }

        private void LoadCreditAccounts()
        {
            int i = 0;
            foreach (BankAccount bankAccount in BankAccount.GetBankAccounts("CREDIT"))
            {
                DataGridViewRowCollection rows = this.dgvCreditAccounts.Rows;
                object[] accountName = new object[] { bankAccount.AccountName, bankAccount.Balance.ToString("c"), Convert.ToString(bankAccount.BankAccountID), bankAccount.WebAddress };
                rows.Add(accountName);
                if (bankAccount.Balance < new decimal(0))
                {
                    DataGridViewRow item = this.dgvCreditAccounts.Rows[i];
                    item.DefaultCellStyle.ForeColor = Color.Red;
                }
                i++;
            }
        }

        private void LoadGrids()
        {
            DatabaseProperties.PasswordProtected();
            this.LoadCashAccounts();
            this.LoadCreditAccounts();
            this.LoadBalances();
            foreach (DataGridViewRow row in this.dgvCashAccounts.SelectedRows)
            {
                row.Selected = false;
            }
            foreach (DataGridViewRow row in this.dgvCreditAccounts.SelectedRows)
            {
                row.Selected = false;
            }
            foreach (DataGridViewRow row in this.dgvBalances.SelectedRows)
            {
                row.Selected = false;
            }
        }

        private void NewAccount()
        {
            this.tslMain.Text = "";
            frmWebAddress _frmWebAddress = new frmWebAddress();
            if (_frmWebAddress.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Uri uri = new Uri(_frmWebAddress.tbWebsiteAddress.Text);
                    FrmWebDownload frmWebDownload = new FrmWebDownload();
                    frmWebDownload.wbWebDownload.Url = uri;
                    frmWebDownload.WindowState = FormWindowState.Maximized;
                    frmWebDownload.MdiParent = this;
                    frmWebDownload.Show();
                }
                catch
                {
                    MessageBox.Show("invalid url format");
                }
            }
        }

        private void RefreshMainForm()
        {
            this.Cursor = Cursors.WaitCursor;
            this.dgvBalances.Rows.Clear();
            this.dgvCashAccounts.Rows.Clear();
            this.dgvCreditAccounts.Rows.Clear();
            this.LoadGrids();
            this.Cursor = Cursors.Default;
        }

        private void tsbCategories_Click(object sender, EventArgs e)
        {
            this.tslMain.Text = "";
            FrmCategories frmCategory = new FrmCategories()
            {
                WindowState = FormWindowState.Maximized,
                MdiParent = this
            };
            frmCategory.Show();
        }

        //private void tsbDownload_Click(object sender, EventArgs e)
        //{
        //    this.tslMain.Text = "";
        //    FrmWebDownload frmWebDownload = new FrmWebDownload();
        //    string str = "";
        //    if (this.dgvCashAccounts.SelectedRows.Count > 0)
        //    {
        //        str = BankAccount.DownloadUri(Convert.ToInt32(this.dgvCashAccounts.CurrentRow.Cells["BankAccountID"].Value.ToString()));
        //    }
        //    if (this.dgvCreditAccounts.SelectedRows.Count > 0)
        //    {
        //        str = BankAccount.DownloadUri(Convert.ToInt32(this.dgvCreditAccounts.CurrentRow.Cells["BankAccountID"].Value.ToString()));
        //    }
        //    Uri uri = new Uri(str);
        //    frmWebDownload.wbWebDownload.Url = uri;
        //    frmWebDownload.WindowState = FormWindowState.Maximized;
        //    frmWebDownload.MdiParent = this;
        //    frmWebDownload.Show();
        //}

        private void tsbBusinesses_Click(object sender, EventArgs e)
        {
            this.tslMain.Text = "";
            FrmBusinesses frmBusiness = new FrmBusinesses()
            {
                WindowState = FormWindowState.Maximized,
                MdiParent = this
            };
            frmBusiness.Show();
        }

        private void tsbNewAccount_Click(object sender, EventArgs e)
        {
            this.NewAccount();
        }

        private void tsbReports_Click(object sender, EventArgs e)
        {
            this.tslMain.Text = "";
            FrmReports frmReport = new FrmReports()
            {
                WindowState = FormWindowState.Maximized,
                MdiParent = this
            };
            frmReport.Show();
            //this.tsbDownload.Enabled = true;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiNewAccount_Click(object sender, EventArgs e)
        {
            this.NewAccount();
        }

        private void tsmiSetPassword_Click(object sender, EventArgs e)
        {
            FrmSetPassword frmSetPassword = new FrmSetPassword();
            if (frmSetPassword.ShowDialog() == DialogResult.OK)
            {
                DatabaseProperties.SetPassword(frmSetPassword.tbCurrentPassword.Text, frmSetPassword.tbNewPassword.Text, frmSetPassword.tbConfirmPassword.Text);
            }
        }

        private delegate void MethodCallback(string[] args);

        public delegate void ProcessParametersDelegate(object sender, string[] args);

        private void tsbYearToDateOnly_Click(object sender, EventArgs e)
        {
            if (!this.tsbYearToDateOnly.Checked)
            {
                this.tsbYearToDateOnly.Checked = true;
            }
            else
            {
                this.tsbYearToDateOnly.Checked = false;
            }
        }
    }
}
