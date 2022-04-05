using BeanCounter.BusinessLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    public partial class FrmRegister : Form
    {
        private int BankAccountID;

        private string AccountName;

        public FrmRegister(int bankAccountID, string accountName)
        {
            this.InitializeComponent();
            this.BankAccountID = bankAccountID;
            this.AccountName = accountName;
            this.Text = accountName;
        }

        private void AddColumnsToGrid()
        {
            this.dgvRegister.Columns.Add(this.TextColumn("Date", true, "Date"));
            this.dgvRegister.Columns.Add(this.TextColumn("BusinessName", true, "Business Name"));
            this.dgvRegister.Columns.Add(this.ComboColumn("CategoryName", "Category", Category.CategoryNames()));
            this.dgvRegister.Columns.Add(this.CheckBoxColumn("Verified", "Verified"));
            this.dgvRegister.Columns.Add(this.TextColumn("StaticAmount", true, "TransactionAmount"));
            this.dgvRegister.Columns.Add(this.TextColumn("BankMemo", true, "BankMemo"));
            this.dgvRegister.Columns.Add(this.TextColumn("TransactionType", true, "Type"));
            this.dgvRegister.Columns.Add(this.TextColumn("UserMemo", true, "UserMemo"));
            this.dgvRegister.Columns.Add(this.TextColumn("CheckNumber", true, "Num"));
            this.dgvRegister.Columns.Add(this.TextColumn("OriginalTransactionID", false, ""));
        }

        private void AddTransactions(string orderBy)
        {
            bool flag = false;
            if (this.tsmiShowUnverifiedTransactionsOnly.Checked)
            {
                flag = true;
            }
            foreach (Transaction transaction in Transaction.Transactions(this.BankAccountID, flag, orderBy))
            {
                DataGridViewRowCollection rows = this.dgvRegister.Rows;
                object[] row = new object[] {
                    transaction.DatePosted.ToString("yyyy-MM-dd"),
                    transaction.BusinessName,
                    transaction.CategoryName,
                    transaction.Verified,
                    transaction.TransactionAmount,
                    transaction.BankMemo,
                    transaction.TransactionType,
                    transaction.UserMemo,
                    transaction.CheckNumber,
                    transaction.OriginalTransactionID
                };

                rows.Add(row);
            }
            if (this.dgvRegister.Rows.Count > 0)
            {
                this.dgvRegister.UpdateRowHeightInfo(0, true);
            }
            this.dgvRegister.Refresh();
        }

        private void AddTransactionSorted()
        {
            if (this.tsmiByCategoryBusinessName.Checked)
            {
                this.AddTransactions(this.ByCategoryBusiness());
                this.AddTransactions(this.ByChecks());
                this.AddTransactions(this.UnCategorized());
            }
            else if (this.tsmiByDate.Checked)
            {
                this.AddTransactions(this.ByDate());
            }
            if (this.dgvRegister.Rows.Count > 0)
            {
                ToolStripStatusLabel toolStripStatusLabel = this.tsslTransactionCount;
                int count = this.dgvRegister.Rows.Count;
                toolStripStatusLabel.Text = string.Concat("Number of transaction being displayed: ", count.ToString());
            }
        }

        private string ByCategoryBusiness()
        {
            string empty = string.Empty;
            if (this.tsmiYearToDateOnly.Checked)
            {
                object[] year = new object[] { empty, " and DatePosted >= '01/01/", null, null };
                year[2] = DateTime.Now.Year;
                year[3] = "'";
                empty = string.Concat(year);
            }
            empty = string.Concat(empty, " and CategoryName is not null ORDER BY CategoryName, Business");
            return empty;
        }

        private string ByChecks()
        {
            string empty = string.Empty;
            if (this.tsmiYearToDateOnly.Checked)
            {
                object[] year = new object[] { empty, " and DatePosted >= '01/01/", null, null };
                year[2] = DateTime.Now.Year;
                year[3] = "'";
                empty = string.Concat(year);
            }
            empty = string.Concat(empty, " and (CategoryName is null) and (TransactionType = 'CHECK') order by DatePosted DESC");
            return empty;
        }

        private string ByDate()
        {
            string empty = string.Empty;
            if (this.tsmiYearToDateOnly.Checked)
            {
                object[] year = new object[] { empty, " and OriginalTransaction.DatePosted >= '01/01/", null, null };
                year[2] = DateTime.Now.Year;
                year[3] = "'";
                empty = string.Concat(year);
            }
            empty = string.Concat(empty, " ORDER BY OriginalTransaction.DatePosted DESC, OriginalTransaction.TransactionAmount");
            return empty;
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = ((ComboBox)sender).Text;
            string importedBusinessName = this.dgvRegister.CurrentRow.Cells["BusinessName"].Value.ToString();
            string checkNumber = this.dgvRegister.CurrentRow.Cells["CheckNumber"].Value.ToString();
            Transaction.UpdateTransactionCategory(selectedCategory, Convert.ToInt32(this.dgvRegister.CurrentRow.Cells["OriginalTransactionID"].Value.ToString()));
            if (selectedCategory != "[Multiple Categories]")
            {
                var categoryName = Business.GetCategoryName(importedBusinessName, Business.NationalBusinesses());
                if (!string.IsNullOrEmpty(selectedCategory) && checkNumber != null && categoryName == "" && Business.LocalBusiness(importedBusinessName, false) == "" && !string.IsNullOrEmpty(importedBusinessName) && importedBusinessName != "?")
                {
                    Business.InsertBusiness(importedBusinessName, selectedCategory, true, true);
                    foreach (DataGridViewRow row in (IEnumerable)this.dgvRegister.Rows)
                    {
                        if (row.Cells["BusinessName"].Value.ToString() != importedBusinessName)
                        {
                            continue;
                        }
                        row.Cells["CategoryName"].Value = selectedCategory;
                    }
                    this.dgvRegister.Refresh();
                }
                return;
            }
            Transaction transaction = new Transaction()
            {
                OriginalTransactionID = Convert.ToInt32(this.dgvRegister.CurrentRow.Cells["OriginalTransactionID"].Value.ToString()),
                BusinessName = importedBusinessName,
                DatePosted = Convert.ToDateTime(this.dgvRegister.CurrentRow.Cells["Date"].Value.ToString()),
                TransactionAmount = Convert.ToDecimal(this.dgvRegister.CurrentRow.Cells["StaticAmount"].Value.ToString()),
                BankMemo = this.dgvRegister.CurrentRow.Cells["BankMemo"].Value.ToString()
            };
            FrmSplitTransaction frmSplitTransaction = new FrmSplitTransaction(transaction, this.BankAccountID);
            if (frmSplitTransaction.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Error", "All categories and amounts need to be filled in properly");
                return;
            }
            decimal num = new decimal(0);
            for (int i = 0; i < frmSplitTransaction.dgvSplitTransaction.Rows.Count - 1; i++)
            {
                decimal num1 = new decimal(0);
                if (frmSplitTransaction.dgvSplitTransaction.Rows[i].Cells["TransactionAmount"].Value != null)
                {
                    num1 = Convert.ToDecimal(frmSplitTransaction.dgvSplitTransaction.Rows[i].Cells["TransactionAmount"].Value.ToString().Replace("($", "-").Replace("$", "").Replace(")", ""));
                }
                num += num1;
            }
            if (num != Convert.ToDecimal(this.dgvRegister.CurrentRow.Cells["StaticAmount"].Value.ToString()))
            {
                MessageBox.Show("Error", string.Concat("Total split transactions amount must equal the total transaction amount (", this.dgvRegister.CurrentRow.Cells["StaticAmount"].Value.ToString()));
                return;
            }
            for (int j = 0; j < frmSplitTransaction.dgvSplitTransaction.Rows.Count - 1; j++)
            {
                string str1 = "";
                if (frmSplitTransaction.dgvSplitTransaction.Rows[j].Cells["UserMemo"].Value != null)
                {
                    str1 = frmSplitTransaction.dgvSplitTransaction.Rows[j].Cells["UserMemo"].Value.ToString();
                }
                if (frmSplitTransaction.dgvSplitTransaction.Rows[j].Cells["SplitTransactionID"].Value != null)
                {
                    SplitTransaction.UpdateSplitTransaction(frmSplitTransaction.dgvSplitTransaction.Rows[j].Cells["CategoryName"].Value.ToString(), str1, Convert.ToDecimal(frmSplitTransaction.dgvSplitTransaction.Rows[j].Cells["TransactionAmount"].Value.ToString().Replace("($", "-").Replace("$", "").Replace(")", "")), Convert.ToInt32(frmSplitTransaction.dgvSplitTransaction.Rows[j].Cells["SplitTransactionID"].Value.ToString()));
                }
                else
                {
                    SplitTransaction.InsertTransaction(frmSplitTransaction.dgvSplitTransaction.Rows[j].Cells["CategoryName"].Value.ToString(), str1, Convert.ToDecimal(frmSplitTransaction.dgvSplitTransaction.Rows[j].Cells["TransactionAmount"].Value.ToString()), Convert.ToInt32(this.dgvRegister.CurrentRow.Cells["OriginalTransactionID"].Value.ToString()));
                }
            }
        }

        private DataGridViewColumn CheckBoxColumn(string name, string headerText)
        {
            return new DataGridViewCheckBoxColumn()
            {
                Name = "Verified",
                HeaderText = "Verified"
            };
        }

        private DataGridViewColumn ComboColumn(string name, string headerText, IEnumerable<string> categoryNames)
        {
            DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn()
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            };
            dataGridViewComboBoxColumn.Items.Add("");
            foreach (string categoryName in categoryNames)
            {
                dataGridViewComboBoxColumn.Items.Add(categoryName);
            }
            dataGridViewComboBoxColumn.Name = name;
            dataGridViewComboBoxColumn.HeaderText = headerText;
            dataGridViewComboBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            return dataGridViewComboBoxColumn;
        }

        private void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvRegister.Columns[e.ColumnIndex].Name == "Verified")
            {
                base.Validate();
                this.SaveRow();
                if (Convert.ToBoolean(this.dgvRegister.CurrentRow.Cells[e.ColumnIndex].Value.ToString()) && this.tsmiShowUnverifiedTransactionsOnly.Checked)
                {
                    this.dgvRegister.Rows.Remove(this.dgvRegister.CurrentRow);
                }
            }
        }

        private void dgvRegister_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            string name = this.dgvRegister.Columns[e.ColumnIndex].Name;
            string str = name;
            if (name != null)
            {
                if (!(str == "BusinessName") && !(str == "UserMemo"))
                {
                    return;
                }
                base.Validate();
                this.SaveRow();
            }
        }

        private void dgvRegister_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox control = e.Control as ComboBox;
            if (control != null)
            {
                control.SelectedIndexChanged -= new EventHandler(this.cbCategory_SelectedIndexChanged);
                control.SelectedIndexChanged += new EventHandler(this.cbCategory_SelectedIndexChanged);
            }
        }

        private void dgvRegister_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.Validate();
            this.SaveRow();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            this.AddColumnsToGrid();
            this.AddTransactionSorted();
        }

        private bool IsNumber(string text)
        {
            double num;
            text = text.Trim();
            return double.TryParse(text, out num);
        }

        private void markCategorizedTransactionsAsVerifiedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Transaction.MarkVerified();
            if (this.tsmiShowUnverifiedTransactionsOnly.Checked)
            {
                foreach (DataGridViewRow row in (IEnumerable)this.dgvRegister.Rows)
                {
                    if (row.Cells["Categoryname"].Value == null || string.IsNullOrEmpty(row.Cells["Categoryname"].Value.ToString()))
                    {
                        continue;
                    }
                    this.dgvRegister.Rows.Remove(row);
                }
            }
            this.dgvRegister.Rows.Clear();
            this.AddTransactionSorted();
            this.Cursor = Cursors.Default;
        }

        private void SaveRow()
        {
            Transaction.UpdateTransaction(Convert.ToBoolean(this.dgvRegister.CurrentRow.Cells["Verified"].Value.ToString()), this.dgvRegister.CurrentRow.Cells["BusinessName"].Value.ToString(), this.dgvRegister.CurrentRow.Cells["UserMemo"].Value.ToString(), this.dgvRegister.CurrentRow.Cells["OriginalTransactionID"].Value.ToString());
        }

        private DataGridViewTextBoxColumn TextColumn(string columnName, bool visable, string headerText)
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            string str = columnName;
            string str1 = str;
            if (str != null)
            {
                if (str1 == "StaticAmount")
                {
                    DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle()
                    {
                        Format = "C2",
                        NullValue = null
                    };
                    dataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle;
                    dataGridViewTextBoxColumn.ReadOnly = true;
                    dataGridViewTextBoxColumn.Name = columnName;
                    dataGridViewTextBoxColumn.HeaderText = headerText;
                    dataGridViewTextBoxColumn.Visible = visable;
                    return dataGridViewTextBoxColumn;
                }
                else
                {
                    if (!(str1 == "Date") && !(str1 == "TransactionType") && !(str1 == "CheckNumber") && !(str1 == "BankMemo"))
                    {
                        dataGridViewTextBoxColumn.ReadOnly = false;
                        dataGridViewTextBoxColumn.Name = columnName;
                        dataGridViewTextBoxColumn.HeaderText = headerText;
                        dataGridViewTextBoxColumn.Visible = visable;
                        return dataGridViewTextBoxColumn;
                    }
                    dataGridViewTextBoxColumn.ReadOnly = true;
                    dataGridViewTextBoxColumn.Name = columnName;
                    dataGridViewTextBoxColumn.HeaderText = headerText;
                    dataGridViewTextBoxColumn.Visible = visable;
                    return dataGridViewTextBoxColumn;
                }
            }
            dataGridViewTextBoxColumn.ReadOnly = false;
            dataGridViewTextBoxColumn.Name = columnName;
            dataGridViewTextBoxColumn.HeaderText = headerText;
            dataGridViewTextBoxColumn.Visible = visable;
            return dataGridViewTextBoxColumn;
        }

        private void tsmiByCategoryBusinessName_Click(object sender, EventArgs e)
        {
            this.tsmiByDate.Checked = false;
            this.tsmiByCategoryBusinessName.Checked = true;
            this.dgvRegister.Rows.Clear();
            this.AddTransactions(this.ByCategoryBusiness());
            this.AddTransactions(this.UnCategorized());
        }

        private void tsmiByDate_Click(object sender, EventArgs e)
        {
            this.tsmiByDate.Checked = true;
            this.tsmiByCategoryBusinessName.Checked = false;
            this.dgvRegister.Rows.Clear();
            this.AddTransactions(this.ByDate());
        }

        private void tsmiShowAllTransactions_Click(object sender, EventArgs e)
        {
            this.tsmiShowAllTransactions.Checked = true;
            this.tsmiShowUnverifiedTransactionsOnly.Checked = false;
            this.dgvRegister.Rows.Clear();
            this.AddTransactionSorted();
        }

        private void tsmiShowUnverifiedTransactionsOnly_Click(object sender, EventArgs e)
        {
            this.tsmiShowUnverifiedTransactionsOnly.Checked = true;
            this.tsmiShowAllTransactions.Checked = false;
            this.dgvRegister.Rows.Clear();
            this.AddTransactions(this.ByDate());
        }

        private void tsmiYearToDateOnly_Click(object sender, EventArgs e)
        {
            if (!this.tsmiYearToDateOnly.Checked)
            {
                this.tsmiYearToDateOnly.Checked = true;
            }
            else
            {
                this.tsmiYearToDateOnly.Checked = false;
            }
            //ConfigurationManager.AppSettings.Remove("YearToDateOnly");
            //ConfigurationManager.AppSettings.Set("YearToDateOnly", this.tsmiYearToDateOnly.Checked.ToString());
            this.dgvRegister.Rows.Clear();
            this.AddTransactionSorted();
        }

        private string UnCategorized()
        {
            string empty = string.Empty;
            if (this.tsmiYearToDateOnly.Checked)
            {
                object[] year = new object[] { empty, " and DatePosted >= '01/01/", null, null };
                year[2] = DateTime.Now.Year;
                year[3] = "'";
                empty = string.Concat(year);
            }
            empty = string.Concat(empty, " and (CategoryName is null) and (TransactionType <> 'CHECK') ORDER BY TransactionType, Business");
            return empty;
        }
    }
}