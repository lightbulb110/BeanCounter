using BeanCounter.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    public partial class FrmReports : Form
    {

        public FrmReports()
        {
            this.InitializeComponent();
        }

        private void AddAllCategoriesColumns()
        {
            this.dgvReports.Columns.Add(this.TextColumn("CategoryName", "Category Name", true));
            this.dgvReports.Columns.Add(this.CurrencyColumn("Total", "Total", true));
            this.dgvReports.Columns.Add(this.CurrencyColumn("Average", "Average amount per transaction", true));
            this.dgvReports.Columns.Add(this.CurrencyColumn("Monthly Average", "Monthly average", true));
            this.dgvReports.Columns.Add(this.TextColumn("Count", "Number of transactions", true));
        }

        private void AddByCategoryColumns()
        {
            this.dgvReports.Columns.Add(this.TextColumn("DatePosted", "Date", true));
            this.dgvReports.Columns.Add(this.TextColumn("Business", "Business", true));
            this.dgvReports.Columns.Add(this.CurrencyColumn("StaticAmount", "TransactionAmount", false));
            this.dgvReports.Columns.Add(this.TextColumn("BankMemo", "BankMemo", true));
            this.dgvReports.Columns.Add(this.TextColumn("UserMemo", "UserMemo", true));
            this.dgvReports.Columns.Add(this.TextColumn("CheckNumber", "CheckNumber", true));
            this.dgvReports.Columns.Add(this.TextColumn("TransactionType", "TransactionType", true));
        }

        private void AddCashForecastColumns()
        {
            this.dgvReports.Columns.Clear();
            this.dgvReports.Columns.Add(this.TextColumn("Date", "Date", true));
            this.dgvReports.Columns.Add(this.TextColumn("Income", "Income", true));
            this.dgvReports.Columns.Add(this.TextColumn("Spending", "Spending", true));
            this.dgvReports.Columns.Add(this.TextColumn("Gain", "Gain", true));
            this.dgvReports.Columns.Add(this.TextColumn("Balance", "Balance on the 1st", true));
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            this.tsslAverage.Text = "";
            this.tsslMonthly.Text = "";
            this.tsslRows.Text = "";
            this.tsslTotal.Text = "";
            this.EnableForm(false);
            this.dgvReports.Columns.Clear();
            string text = this.cbReportType.Text;
            string str = text;
            if (text != null)
            {
                if (str == "All Categories")
                {
                    this.LoadAllCategories();
                    this.EnableForm(true);
                    return;
                }
                if (str == "By Category")
                {
                    this.LoadByCategory();
                    this.EnableForm(true);
                    return;
                }
                if (str == "Cash Forecast")
                {
                    this.LoadCashForecast();
                }
                else if (str != "Items Due")
                {
                    return;
                }
            }
        }

        private void bwBuildCashForecast_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = CashForecast.BuildCashForecast(e.Argument as Options);
        }

        private void bwBuildCashForecast_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.AddCashForecastColumns();
            CashForecast result = e.Result as CashForecast;
            int year = DateTime.Today.Year;
            bool flag = false;
            if (DateTime.Today.Month != 1)
            {
                year++;
                DataGridViewRowCollection rows = this.dgvReports.Rows;
                object[] objArray = new object[] { string.Concat("Jan ", year.ToString()), result._IncomeForecast.C1.ToString("$','"), result._SpendingForecast.C1.ToString("$','"), result._GainForecast.C1.ToString("$','"), result._BalanceForecast.C1.ToString("$','") };
                rows.Add(objArray);
            }
            else
            {
                DataGridViewRowCollection dataGridViewRowCollections = this.dgvReports.Rows;
                object[] objArray1 = new object[] { string.Concat("Jan ", year.ToString()), result._IncomeForecast.C1.ToString("$','"), result._SpendingForecast.C1.ToString("$','"), result._GainForecast.C1.ToString("$','") };
                dataGridViewRowCollections.Add(objArray1);
            }
            if (DateTime.Today.Month <= 2 && !flag)
            {
                year--;
                flag = true;
            }
            DataGridViewRowCollection rows1 = this.dgvReports.Rows;
            object[] objArray2 = new object[] { string.Concat("Feb ", year.ToString()), result._IncomeForecast.C2.ToString("$','"), result._SpendingForecast.C2.ToString("$','"), result._GainForecast.C2.ToString("$','"), result._BalanceForecast.C2.ToString("$','") };
            rows1.Add(objArray2);
            if (DateTime.Today.Month <= 3 && !flag)
            {
                year--;
                flag = true;
            }
            DataGridViewRowCollection dataGridViewRowCollections1 = this.dgvReports.Rows;
            object[] objArray3 = new object[] { string.Concat("Mar ", year.ToString()), result._IncomeForecast.C3.ToString("$','"), result._SpendingForecast.C3.ToString("$','"), result._GainForecast.C3.ToString("$','"), result._BalanceForecast.C3.ToString("$','") };
            dataGridViewRowCollections1.Add(objArray3);
            if (DateTime.Today.Month <= 4 && !flag)
            {
                year--;
                flag = true;
            }
            DataGridViewRowCollection rows2 = this.dgvReports.Rows;
            object[] objArray4 = new object[] { string.Concat("Apr ", year.ToString()), result._IncomeForecast.C4.ToString("$','"), result._SpendingForecast.C4.ToString("$','"), result._GainForecast.C4.ToString("$','"), result._BalanceForecast.C4.ToString("$','") };
            rows2.Add(objArray4);
            if (DateTime.Today.Month <= 5 && !flag)
            {
                year--;
                flag = true;
            }
            DataGridViewRowCollection dataGridViewRowCollections2 = this.dgvReports.Rows;
            object[] objArray5 = new object[] { string.Concat("May ", year.ToString()), result._IncomeForecast.C5.ToString("$','"), result._SpendingForecast.C5.ToString("$','"), result._GainForecast.C5.ToString("$','"), result._BalanceForecast.C5.ToString("$','") };
            dataGridViewRowCollections2.Add(objArray5);
            if (DateTime.Today.Month <= 6 && !flag)
            {
                year--;
                flag = true;
            }
            DataGridViewRowCollection rows3 = this.dgvReports.Rows;
            object[] objArray6 = new object[] { string.Concat("Jun ", year.ToString()), result._IncomeForecast.C6.ToString("$','"), result._SpendingForecast.C6.ToString("$','"), result._GainForecast.C6.ToString("$','"), result._BalanceForecast.C6.ToString("$','") };
            rows3.Add(objArray6);
            if (DateTime.Today.Month <= 7 && !flag)
            {
                year--;
                flag = true;
            }
            DataGridViewRowCollection dataGridViewRowCollections3 = this.dgvReports.Rows;
            object[] objArray7 = new object[] { string.Concat("Jul ", year.ToString()), result._IncomeForecast.C7.ToString("$','"), result._SpendingForecast.C7.ToString("$','"), result._GainForecast.C7.ToString("$','"), result._BalanceForecast.C7.ToString("$','") };
            dataGridViewRowCollections3.Add(objArray7);
            if (DateTime.Today.Month <= 8 && !flag)
            {
                year--;
                flag = true;
            }
            DataGridViewRowCollection rows4 = this.dgvReports.Rows;
            object[] objArray8 = new object[] { string.Concat("Aug ", year.ToString()), result._IncomeForecast.C8.ToString("$','"), result._SpendingForecast.C8.ToString("$','"), result._GainForecast.C8.ToString("$','"), result._BalanceForecast.C8.ToString("$','") };
            rows4.Add(objArray8);
            if (DateTime.Today.Month <= 9 && !flag)
            {
                year--;
                flag = true;
            }
            DataGridViewRowCollection dataGridViewRowCollections4 = this.dgvReports.Rows;
            object[] objArray9 = new object[] { string.Concat("Sep ", year.ToString()), result._IncomeForecast.C9.ToString("$','"), result._SpendingForecast.C9.ToString("$','"), result._GainForecast.C9.ToString("$','"), result._BalanceForecast.C9.ToString("$','") };
            dataGridViewRowCollections4.Add(objArray9);
            if (DateTime.Today.Month <= 10 && !flag)
            {
                year--;
                flag = true;
            }
            DataGridViewRowCollection rows5 = this.dgvReports.Rows;
            object[] objArray10 = new object[] { string.Concat("Oct ", year.ToString()), result._IncomeForecast.C10.ToString("$','"), result._SpendingForecast.C10.ToString("$','"), result._GainForecast.C10.ToString("$','"), result._BalanceForecast.C10.ToString("$','") };
            rows5.Add(objArray10);
            if (DateTime.Today.Month <= 11 && !flag)
            {
                year--;
                flag = true;
            }
            DataGridViewRowCollection dataGridViewRowCollections5 = this.dgvReports.Rows;
            object[] objArray11 = new object[] { string.Concat("Nov ", year.ToString()), result._IncomeForecast.C11.ToString("$','"), result._SpendingForecast.C11.ToString("$','"), result._GainForecast.C11.ToString("$','"), result._BalanceForecast.C11.ToString("$','") };
            dataGridViewRowCollections5.Add(objArray11);
            if (DateTime.Today.Month <= 12 && !flag)
            {
                year--;
                flag = true;
            }
            DataGridViewRowCollection rows6 = this.dgvReports.Rows;
            object[] objArray12 = new object[] { string.Concat("Dec ", year.ToString()), result._IncomeForecast.C12.ToString("$','"), result._SpendingForecast.C12.ToString("$','"), result._GainForecast.C12.ToString("$','"), result._BalanceForecast.C12.ToString("$','") };
            rows6.Add(objArray12);
            this.dgvReports.Rows.Add();
            DataGridViewRowCollection dataGridViewRowCollections6 = this.dgvReports.Rows;
            object[] str = new object[] { "Totals", result._IncomeForecast.Total.ToString("$','"), result._SpendingForecast.Total.ToString("$','"), result._GainForecast.Total.ToString("$','") };
            dataGridViewRowCollections6.Add(str);
            DataGridViewRowCollection rows7 = this.dgvReports.Rows;
            object[] str1 = new object[] { "Average", result._IncomeForecast.Average.ToString("$','"), result._SpendingForecast.Average.ToString("$','"), result._GainForecast.Average.ToString("$','") };
            rows7.Add(str1);
            this.EnableForm(true);
        }

        private DataGridViewRow CashForecastList(string type, CashForecast cashforecast)
        {
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            DataGridViewTextBoxCell dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = type
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C1
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C2
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C3
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C4
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C5
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C6
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C7
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C8
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C9
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C10
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C11
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
            {
                Value = cashforecast.C12
            };
            dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            if (type != "Balance")
            {
                dataGridViewTextBoxCell = new DataGridViewTextBoxCell()
                {
                    Value = cashforecast.Average
                };
                dataGridViewRow.Cells.Add(dataGridViewTextBoxCell);
            }
            return dataGridViewRow;
        }

        private void cbCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cbDateRange.Text) && !string.IsNullOrEmpty(this.cbCategoryName.Text))
            {
                this.btnLoadReport.Enabled = true;
            }
        }

        private void cbDateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.cbDateRange.Text) && !string.IsNullOrEmpty(this.cbCategoryName.Text))
            {
                this.btnLoadReport.Enabled = true;
            }
            if (!string.IsNullOrEmpty(this.cbDateRange.Text) && this.cbReportType.Text == "All Categories")
            {
                this.btnLoadReport.Enabled = true;
            }
        }

        private void cbOverages_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbOverages.Checked)
            {
                this.nudOverages.Enabled = false;
                return;
            }
            this.nudOverages.Enabled = true;
        }

        private void cbOverrideBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbOverrideBalance.Checked)
            {
                this.tbOverrideBalance.Enabled = true;
                return;
            }
            this.tbOverrideBalance.Enabled = false;
        }

        private void cbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbDateRange.Text = "";
            this.cbCategoryName.Text = "";
            this.btnLoadReport.Enabled = false;
            this.cbDateRange.Enabled = false;
            this.cbCategoryName.Enabled = false;
            this.gbForecaseOptions.Enabled = false;
            string text = this.cbReportType.Text;
            string str = text;
            if (text != null)
            {
                if (str == "All Categories")
                {
                    this.cbDateRange.Enabled = true;
                    return;
                }
                if (str == "By Category")
                {
                    if (!string.IsNullOrEmpty(this.cbReportType.Text))
                    {
                        this.cbDateRange.Enabled = true;
                        this.cbCategoryName.Enabled = true;
                        this.LoadCategories();
                        return;
                    }
                }
                else if (str != "Cash Forecast")
                {
                    if (str != "Items Due")
                    {
                        return;
                    }
                }
                else if (!string.IsNullOrEmpty(this.cbReportType.Text))
                {
                    this.btnLoadReport.Enabled = true;
                    this.gbForecaseOptions.Enabled = true;
                }
            }
        }

        private DataGridViewTextBoxColumn CurrencyColumn(string name, string headerText, bool roundOff)
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            dataGridViewTextBoxColumn = this.TextColumn(name, headerText, true);
            dataGridViewCellStyle = new DataGridViewCellStyle();
            if (!roundOff)
            {
                dataGridViewCellStyle.Format = "C";
            }
            else
            {
                dataGridViewCellStyle.Format = "C0";
            }
            dataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle;
            return dataGridViewTextBoxColumn;
        }

        private void EnableForm(bool enabled)
        {
            this.btnLoadReport.Enabled = enabled;
            this.scMain.Enabled = enabled;
            this.gbForecaseOptions.Enabled = enabled;
        }

      
        private static bool IsNumber(string text)
        {
            double num;
            text = text.Trim();
            return double.TryParse(text, out num);
        }

        private void LoadAllCategories()
        {
            this.AddAllCategoriesColumns();
            foreach (string str in Transaction.Categories(this.cbDateRange.Text))
            {
                CategoryTotal categoryTotal = Transaction.CategoryTotal(str, this.cbDateRange.Text);
                if (categoryTotal.Count <= 0)
                {
                    continue;
                }
                DataGridViewRowCollection rows = this.dgvReports.Rows;
                object[] transactionAmount = new object[] { str, categoryTotal.TransactionAmount, Math.Round(categoryTotal.TransactionAmount / categoryTotal.Count), Transaction.MonthlyAverage(categoryTotal.TransactionAmount, this.cbDateRange.Text), categoryTotal.Count };
                rows.Add(transactionAmount);
            }
        }

        private void LoadByCategory()
        {
            List<Transaction> transactions = Transaction.TransactionsByCategory(this.cbCategoryName.Text, this.cbDateRange.Text);
            this.AddByCategoryColumns();
            decimal num = new decimal(0);
            foreach (Transaction transaction in transactions)
            {
                DataGridViewRowCollection rows = this.dgvReports.Rows;
                object[] str = new object[] { transaction.DatePosted.ToString("MM/dd/yyyy"), transaction.BusinessName, transaction.TransactionAmount, transaction.BankMemo, transaction.UserMemo, transaction.CheckNumber, transaction.TransactionType };
                rows.Add(str);
                num += transaction.TransactionAmount;
            }
            this.tsslRows.Text = string.Concat("Number of transactions: ", Convert.ToString(transactions.Count));
            decimal num1 = new decimal(0);
            if (num != new decimal(0) && transactions.Count > 0)
            {
                num1 = Math.Round(num / transactions.Count);
            }
            this.tsslAverage.Text = string.Concat("Average amount per transaction: $", Convert.ToString(num1));
            this.tsslMonthly.Text = string.Concat("Monthly average: $", Transaction.MonthlyAverage(num, this.cbDateRange.Text));
            this.tsslTotal.Text = string.Concat("Total: $", Convert.ToString(num));
        }

        private void LoadCashForecast()
        {
            decimal num = new decimal(0);
            if (!string.IsNullOrEmpty(this.tbOverrideBalance.Text) && FrmReports.IsNumber(this.tbOverrideBalance.Text))
            {
                num = Convert.ToDecimal(this.tbOverrideBalance.Text);
            }
            this.bwBuildCashForecast.RunWorkerAsync(new Options(this.cbOverrideBalance.Checked, num, this.cbOverages.Checked, Convert.ToInt32(this.nudOverages.Value)));
        }

        private void LoadCategories()
        {
            this.cbCategoryName.Items.Clear();
            this.cbCategoryName.Items.Add("");
            foreach (string str in Category.CategoryNames())
            {
                this.cbCategoryName.Items.Add(str);
            }
        }

        private DataGridViewTextBoxColumn TextColumn(string name, string headerText, bool visable)
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
            {
                Name = name,
                HeaderText = headerText,
                Visible = visable
            };
            return dataGridViewTextBoxColumn;
        }
    }
}