using BeanCounter.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanCounter
{
    public partial class FrmNewBankAccount : Form
    {
        //public Basket Basket;
        public OpenFinancialExchange data;

        public FrmNewBankAccount(OpenFinancialExchange data)
        {
            this.InitializeComponent();
            this.data = data;
        }

        private void CheckBold()
        {
            if (string.IsNullOrEmpty(this.tbWebAddress.Text))
            {
                this.lblWebAddress.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            }
            else
            {
                this.lblWebAddress.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            }
            if (string.IsNullOrEmpty(this.tbNickname.Text))
            {
                this.lblNickName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
            }
            else
            {
                this.lblNickName.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
            }
            if (!this.rbColumnA.Checked && !this.rbColumnB.Checked)
            {
                this.lblColumnChoice.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold);
                return;
            }
            this.lblColumnChoice.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular);
        }

        private bool FormCompleted()
        {
            if (!string.IsNullOrEmpty(this.tbNickname.Text) && !string.IsNullOrEmpty(this.tbWebAddress.Text))
            {
                return true;
            }
            return false;
        }

        private void FrmNewBankAccount_Load(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Column A",
                Name = "ColumnA"
            };
            this.dgvTransactions.Columns.Add(dataGridViewTextBoxColumn);
            dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
            {
                HeaderText = "Column B",
                Name = "ColumnB"
            };
            this.dgvTransactions.Columns.Add(dataGridViewTextBoxColumn);
            foreach (Transaction transaction in this.data.Transactions)
            {
                DataGridViewRowCollection rows = this.dgvTransactions.Rows;
                object[] BusinessName = new object[] { transaction.BusinessName, transaction.BankMemo };
                rows.Add(BusinessName);
            }
            string bankName = this.data.BankAccount.BankName;
            FindKnownBanks(bankName);
            this.CheckBold();
        }

        private void FindKnownBanks(string bankName)
        {
            if (bankName != null && bankName == "U.S. Bank")
            {
                if ((this.data.BankAccount.AccountType.ToLower() == "checking") | (this.data.BankAccount.AccountType.ToLower() == "savings"))
                {
                    this.tbNickname.Text = this.data.BankAccount.AccountType == "CHECKING" ? "Checking" : "Savings";
                    this.tbWebAddress.Text = "www.usbank.com";
                    this.rbColumnA.Checked = false;
                    this.rbColumnB.Checked = true;
                    this.cbRemoveFromColumnA.Text = "[Everything]";
                    this.cbRemoveFromColumnB.Text = "Download from usbank.com.";
                    DisableOptions();
                }
                else if (this.data.BankAccount.AccountType.ToLower() == "credit")
                {
                    this.tbWebAddress.Text = "www.usbank.com";
                    this.rbColumnA.Checked = true;
                    this.rbColumnB.Checked = false;
                    this.cbRemoveFromColumnA.Text = "[Nothing]";
                    this.cbRemoveFromColumnB.Text = "[Everything]";
                    DisableOptions();
                }
            }
        }

        private void DisableOptions()
        {
            this.tbWebAddress.Enabled = false;
            this.rbColumnA.Enabled = false;
            this.rbColumnB.Enabled = false;
            this.cbRemoveFromColumnA.Enabled = false;
            this.cbRemoveFromColumnB.Enabled = false;
        }

        private void ResizeWindow()
        {
            Size size = base.MdiParent.Size;
            Size size1 = base.MdiParent.Size;
            base.Size = new Size(size.Width - 100, size1.Height - 230);
        }

        private void tbNickname_Leave(object sender, EventArgs e)
        {
            this.CheckBold();
        }

        private void tbWebAddress_Leave(object sender, EventArgs e)
        {
            this.CheckBold();
        }

    }
}
