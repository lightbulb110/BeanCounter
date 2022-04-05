using BeanCounter.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    public partial class FrmSplitTransaction : Form
    {

        public FrmSplitTransaction(Transaction transaction, int bankAccountID)
        {
            this.Transaction = transaction;
            this.BankAccountID = bankAccountID;
            this.InitializeComponent();
        }

        private void AddColumns()
        {
            this.dgvSplitTransaction.Columns.Add(this.ComboColumn("CategoryName", "Category Name", Category.CategoryNames()));
            this.dgvSplitTransaction.Columns.Add(this.CurrencyColumn());
            this.dgvSplitTransaction.Columns.Add(this.TextColumn("UserMemo", "UserMemo", true));
            this.dgvSplitTransaction.Columns.Add(this.TextColumn("SplitTransactionID", "SplitTransactionID", false));
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

        private DataGridViewTextBoxColumn CurrencyColumn()
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            dataGridViewTextBoxColumn = this.TextColumn("TransactionAmount", "TransactionAmount", true);
            dataGridViewCellStyle = new DataGridViewCellStyle()
            {
                Format = "C2"
            };
            dataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle;
            return dataGridViewTextBoxColumn;
        }

        private void FrmSplitTransaction_Load(object sender, EventArgs e)
        {
            this.tbBusinessName.Text = this.Transaction.BusinessName;
            this.tbDate.Text = Convert.ToString(this.Transaction.DatePosted);
            this.tbFullAmount.Text = Convert.ToString(this.Transaction.TransactionAmount);
            this.tbBankMemo.Text = this.Transaction.BankMemo;
            this.AddColumns();
            foreach (SplitTransaction splitTransaction in SplitTransaction.SplitTransactions(this.Transaction.OriginalTransactionID))
            {
                DataGridViewRowCollection rows = this.dgvSplitTransaction.Rows;
                object[] categoryName = new object[] { splitTransaction.CategoryName, splitTransaction.TransactionAmount, splitTransaction.UserMemo, splitTransaction.SplitTransactionID };
                rows.Add(categoryName);
            }
        }

        private DataGridViewTextBoxColumn TextColumn(string columnName, string headerText, bool visible)
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            if (columnName == "TransactionAmount")
            {
                DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle()
                {
                    Format = "C2",
                    NullValue = null
                };
                dataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle;
            }
            dataGridViewTextBoxColumn.Name = columnName;
            dataGridViewTextBoxColumn.HeaderText = headerText;
            dataGridViewTextBoxColumn.Visible = visible;
            return dataGridViewTextBoxColumn;
        }
    }
}