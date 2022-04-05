using BeanCounter.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BeanCounter
{
    public partial class FrmCategories : Form
    {
        public FrmCategories()
        {
            this.InitializeComponent();
        }

        private Category AddMonthlyAmounts(Category category)
        {
            if (!string.IsNullOrEmpty(this.tbJan.Text) && this.IsNumber(this.tbJan.Text))
            {
                category.C1 = Convert.ToDecimal(this.tbJan.Text);
            }
            if (!string.IsNullOrEmpty(this.tbFeb.Text) && this.IsNumber(this.tbFeb.Text))
            {
                category.C2 = Convert.ToDecimal(this.tbFeb.Text);
            }
            if (!string.IsNullOrEmpty(this.tbMar.Text) && this.IsNumber(this.tbMar.Text))
            {
                category.C3 = Convert.ToDecimal(this.tbMar.Text);
            }
            if (!string.IsNullOrEmpty(this.tbApr.Text) && this.IsNumber(this.tbApr.Text))
            {
                category.C4 = Convert.ToDecimal(this.tbApr.Text);
            }
            if (!string.IsNullOrEmpty(this.tbMay.Text) && this.IsNumber(this.tbMay.Text))
            {
                category.C5 = Convert.ToDecimal(this.tbMay.Text);
            }
            if (!string.IsNullOrEmpty(this.tbJun.Text) && this.IsNumber(this.tbJun.Text))
            {
                category.C6 = Convert.ToDecimal(this.tbJun.Text);
            }
            if (!string.IsNullOrEmpty(this.tbJul.Text) && this.IsNumber(this.tbJul.Text))
            {
                category.C7 = Convert.ToDecimal(this.tbJul.Text);
            }
            if (!string.IsNullOrEmpty(this.tbAug.Text) && this.IsNumber(this.tbAug.Text))
            {
                category.C8 = Convert.ToDecimal(this.tbAug.Text);
            }
            if (!string.IsNullOrEmpty(this.tbSep.Text) && this.IsNumber(this.tbSep.Text))
            {
                category.C9 = Convert.ToDecimal(this.tbSep.Text);
            }
            if (!string.IsNullOrEmpty(this.tbOct.Text) && this.IsNumber(this.tbOct.Text))
            {
                category.C10 = Convert.ToDecimal(this.tbOct.Text);
            }
            if (!string.IsNullOrEmpty(this.tbNov.Text) && this.IsNumber(this.tbNov.Text))
            {
                category.C11 = Convert.ToDecimal(this.tbNov.Text);
            }
            if (!string.IsNullOrEmpty(this.tbDec.Text) && this.IsNumber(this.tbDec.Text))
            {
                category.C12 = Convert.ToDecimal(this.tbDec.Text);
            }
            return category;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearMonthlyAmounts();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            this.tbJan.Text = this.tbFill.Text;
            this.tbFeb.Text = this.tbFill.Text;
            this.tbMar.Text = this.tbFill.Text;
            this.tbApr.Text = this.tbFill.Text;
            this.tbMar.Text = this.tbFill.Text;
            this.tbMay.Text = this.tbFill.Text;
            this.tbJun.Text = this.tbFill.Text;
            this.tbJul.Text = this.tbFill.Text;
            this.tbAug.Text = this.tbFill.Text;
            this.tbSep.Text = this.tbFill.Text;
            this.tbOct.Text = this.tbFill.Text;
            this.tbNov.Text = this.tbFill.Text;
            this.tbDec.Text = this.tbFill.Text;
            this.tbFill.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.btnSave.Enabled = false;
            base.Validate();
            this.SaveRow(0);
            this.btnSave.Enabled = true;
        }

        private string CategoryType()
        {
            string str = "";
            if (this.rbSpending.Checked)
            {
                str = "Expenses";
            }
            if (this.rbIncome.Checked)
            {
                str = "Income";
            }
            return str;
        }

        private void cbDayOfMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SaveRow(Convert.ToInt32(((ComboBox)sender).Text));
        }

        private void cbFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.CategoryType()) && !string.IsNullOrEmpty(this.Frequency()))
            {
                this.LoadCategories();
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.CategoryType()) && !string.IsNullOrEmpty(this.Frequency()))
            {
                this.LoadCategories();
            }
        }

        private DataGridViewCheckBoxColumn CheckboxColumn(string columnName, string headerText)
        {
            return new DataGridViewCheckBoxColumn()
            {
                Name = columnName,
                HeaderText = headerText
            };
        }

        private void chkByDate_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.CategoryType()) && !string.IsNullOrEmpty(this.Frequency()))
            {
                this.LoadCategories();
            }
        }

        private void ClearMonthlyAmounts()
        {
            this.tbJan.Text = "";
            this.tbFeb.Text = "";
            this.tbMar.Text = "";
            this.tbApr.Text = "";
            this.tbMay.Text = "";
            this.tbJun.Text = "";
            this.tbJul.Text = "";
            this.tbAug.Text = "";
            this.tbSep.Text = "";
            this.tbOct.Text = "";
            this.tbNov.Text = "";
            this.tbDec.Text = "";
        }

        private void ClearMonthlyValues()
        {
            this.tbJan.Text = "";
            this.tbFeb.Text = "";
            this.tbMar.Text = "";
            this.tbApr.Text = "";
            this.tbMay.Text = "";
            this.tbJun.Text = "";
            this.tbJul.Text = "";
            this.tbAug.Text = "";
            this.tbSep.Text = "";
            this.tbOct.Text = "";
            this.tbNov.Text = "";
            this.tbDec.Text = "";
        }

        private DataGridViewColumn ComboColumn(string name, string headerText, IEnumerable<string> categorynames)
        {
            DataGridViewComboBoxColumn dataGridViewComboBoxColumn = new DataGridViewComboBoxColumn()
            {
                DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            };
            foreach (string categoryname in categorynames)
            {
                dataGridViewComboBoxColumn.Items.Add(categoryname);
            }
            dataGridViewComboBoxColumn.Name = name;
            dataGridViewComboBoxColumn.HeaderText = headerText;
            dataGridViewComboBoxColumn.SortMode = DataGridViewColumnSortMode.Automatic;
            return dataGridViewComboBoxColumn;
        }

        private List<string> DaysOfMonth()
        {
            List<string> strs = new List<string>();
            for (int i = 1; i < 32; i++)
            {
                strs.Add(Convert.ToString(i));
            }
            return strs;
        }

        private void dgvCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvCategories.Columns[e.ColumnIndex].Name == "ExcludeFromBudget")
            {
                base.Validate();
                this.SaveRow(0);
            }
        }

        private void dgvCategories_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right && this.dgvCategories.CurrentRow.Cells["CategoryName"].Value != null)
            {
                base.Validate();
                this.dgvCategories.EndEdit();
                this.dgvCategories.CurrentRow.Selected = false;
                this.dgvCategories.CurrentCell = this.dgvCategories[e.ColumnIndex, e.RowIndex];
                this.dgvCategories.Rows[e.RowIndex].Selected = true;
                Rectangle cellDisplayRectangle = this.dgvCategories.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                this.cmsDelete.Show((Control)sender, cellDisplayRectangle.Left + e.X, cellDisplayRectangle.Top + e.Y);
            }
        }

        private void dgvCategories_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox control = e.Control as ComboBox;
            if (control != null)
            {
                control.SelectedIndexChanged -= new EventHandler(this.cbDayOfMonth_SelectedIndexChanged);
                control.SelectedIndexChanged += new EventHandler(this.cbDayOfMonth_SelectedIndexChanged);
            }
        }

        private void dgvCategories_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvCategories.Rows[e.RowIndex].Selected = true;
            if (this.dgvCategories.Rows[e.RowIndex].Cells["CategoryName"].Value != null)
            {
                this.LoadRow(Convert.ToInt32(this.dgvCategories.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString()));
            }
        }

        private void dgvCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                base.Validate();
                this.SaveRow(0);
            }
        }

        private void dgvCategories_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            this.ClearMonthlyAmounts();
        }

        private string Frequency()
        {
            string str = "";
            if (this.rbAnnually.Checked)
            {
                str = "Annually";
            }
            if (this.rbAnytime.Checked)
            {
                str = "Anytime";
            }
            if (this.rbBiWeekly.Checked)
            {
                str = "Bi-Weekly";
            }
            if (this.rbMonthly.Checked)
            {
                str = "Monthly";
            }
            if (this.rbOneTime.Checked)
            {
                str = "One Time";
            }
            if (this.rbWeekly.Checked)
            {
                str = "Weekly";
            }
            return str;
        }

        private bool IsDate(string date)
        {
            DateTime dateTime;
            bool flag;
            try
            {
                DateTime.TryParse(date, out dateTime);
                flag = (!(dateTime != DateTime.MinValue) || !(dateTime != DateTime.MaxValue) ? false : true);
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        private bool IsNumber(string text)
        {
            double num;
            text = text.Trim();
            return double.TryParse(text, out num);
        }

        private void LoadCategories()
        {
            this.ClearMonthlyValues();
            this.gbMonthlyAmounts.Enabled = false;
            this.FinishedLoading = false;
            this.dgvCategories.Rows.Clear();
            this.dgvCategories.Columns.Clear();
            this.dgvCategories.Columns.Add(this.TextColumn("CategoryID", "CategoryID", false));
            this.dgvCategories.Columns.Add(this.TextColumn("CategoryName", "Category Name", true));
            string str = this.Frequency();
            string str1 = str;
            if (str != null)
            {
                if (str1 == "Annually" || str1 == "One Time")
                {
                    this.dgvCategories.Columns.Add(this.StaticAmountColumn());
                    this.dgvCategories.Columns.Add(this.TextColumn("SpecificDate", "Date", true));
                    this.dgvCategories.Columns.Add(this.CheckboxColumn("ExcludeFromBudget", "Exclude from budget?"));
                    foreach (Category category in Category.Categories(this.CategoryType(), this.Frequency(), this.chkByDate.Checked))
                    {
                        DataGridViewRowCollection rows = this.dgvCategories.Rows;
                        object[] categoryID = new object[] { category.CategoryID, category.CategoryName, category.StaticAmount, category.SpecificDate.ToString("MM/dd/yyyy"), category.ExcludeFromBudget };
                        rows.Add(categoryID);
                    }
                }
                else if (str1 == "Anytime")
                {
                    this.gbMonthlyAmounts.Enabled = true;
                    this.dgvCategories.Columns.Add(this.CheckboxColumn("ExcludeFromBudget", "Exclude from budget?"));
                    foreach (Category category1 in Category.Categories(this.CategoryType(), this.Frequency(), this.chkByDate.Checked))
                    {
                        DataGridViewRowCollection dataGridViewRowCollections = this.dgvCategories.Rows;
                        object[] objArray = new object[] { category1.CategoryID, category1.CategoryName, category1.ExcludeFromBudget };
                        dataGridViewRowCollections.Add(objArray);
                    }
                }
                else if (str1 == "Bi-Weekly" || str1 == "Weekly")
                {
                    this.dgvCategories.Columns.Add(this.StaticAmountColumn());
                    this.dgvCategories.Columns.Add(this.TextColumn("NextOccurance", "Next Occurance", true));
                    this.dgvCategories.Columns.Add(this.TextColumn("EndDate", "End Date (Optional)", true));
                    this.dgvCategories.Columns.Add(this.CheckboxColumn("ExcludeFromBudget", "Exclude from budget?"));
                    foreach (Category category2 in Category.Categories(this.CategoryType(), this.Frequency(), this.chkByDate.Checked))
                    {
                        string str2 = "";
                        if (category2.EndDate != new DateTime())
                        {
                            str2 = Convert.ToString(category2.EndDate.ToString("MM/dd/yyy"));
                        }
                        DataGridViewRowCollection rows1 = this.dgvCategories.Rows;
                        object[] categoryID1 = new object[] { category2.CategoryID, category2.CategoryName, category2.StaticAmount, category2.NextOccurance.ToString("MM/dd/yyy"), str2, category2.ExcludeFromBudget };
                        rows1.Add(categoryID1);
                    }
                }
                else if (str1 == "Monthly")
                {
                    this.gbMonthlyAmounts.Enabled = true;
                    this.dgvCategories.Columns.Add(this.ComboColumn("DayOfMonth", "Day", this.DaysOfMonth()));
                    this.dgvCategories.Columns.Add(this.CheckboxColumn("ExcludeFromBudget", "Exclude from budget?"));
                    foreach (Category category3 in Category.Categories(this.CategoryType(), this.Frequency(), this.chkByDate.Checked))
                    {
                        DataGridViewRowCollection dataGridViewRowCollections1 = this.dgvCategories.Rows;
                        object[] objArray1 = new object[] { category3.CategoryID, category3.CategoryName, Convert.ToString(category3.DayOfMonth), category3.ExcludeFromBudget };
                        dataGridViewRowCollections1.Add(objArray1);
                    }
                }
            }
            this.FinishedLoading = true;
            if ((this.Frequency() == "Monthly") | (this.Frequency() == "Anytime") && this.dgvCategories.Rows[0].Cells["CategoryID"].Value != null)
            {
                Category category4 = Category.FindCategory(Convert.ToInt32(this.dgvCategories.Rows[0].Cells["CategoryID"].Value.ToString()));
                this.LoadMonthlyValues(category4);
            }
            if (this.dgvCategories.CurrentRow != null)
            {
                if (this.dgvCategories.CurrentRow.Cells["Categoryname"].Value != null)
                {
                    this.tsmiDeleteCategory.Enabled = true;
                    return;
                }
                this.tsmiDeleteCategory.Enabled = false;
            }
        }

        private void LoadMonthlyValues(Category category)
        {
            this.tbJan.Text = category.C1.ToString();
            this.tbFeb.Text = category.C2.ToString();
            this.tbMar.Text = category.C3.ToString();
            this.tbApr.Text = category.C4.ToString();
            this.tbMay.Text = category.C5.ToString();
            this.tbJun.Text = category.C6.ToString();
            this.tbJul.Text = category.C7.ToString();
            this.tbAug.Text = category.C8.ToString();
            this.tbSep.Text = category.C9.ToString();
            this.tbOct.Text = category.C10.ToString();
            this.tbNov.Text = category.C11.ToString();
            this.tbDec.Text = category.C12.ToString();
            if (this.tbJan.Text == "0.0000")
            {
                this.tbJan.Text = "0";
            }
            if (this.tbFeb.Text == "0.0000")
            {
                this.tbFeb.Text = "0";
            }
            if (this.tbMar.Text == "0.0000")
            {
                this.tbMar.Text = "0";
            }
            if (this.tbApr.Text == "0.0000")
            {
                this.tbApr.Text = "0";
            }
            if (this.tbMay.Text == "0.0000")
            {
                this.tbMay.Text = "0";
            }
            if (this.tbJun.Text == "0.0000")
            {
                this.tbJun.Text = "0";
            }
            if (this.tbJul.Text == "0.0000")
            {
                this.tbJul.Text = "0";
            }
            if (this.tbAug.Text == "0.0000")
            {
                this.tbAug.Text = "0";
            }
            if (this.tbSep.Text == "0.0000")
            {
                this.tbSep.Text = "0";
            }
            if (this.tbOct.Text == "0.0000")
            {
                this.tbOct.Text = "0";
            }
            if (this.tbNov.Text == "0.0000")
            {
                this.tbNov.Text = "0";
            }
            if (this.tbDec.Text == "0.0000")
            {
                this.tbDec.Text = "0";
            }
        }

        private void LoadRow(int categoryID)
        {
            if (this.FinishedLoading && this.dgvCategories.CurrentRow != null && this.dgvCategories.CurrentRow.Cells["CategoryName"].Value != null)
            {
                string str = this.Frequency();
                string str1 = str;
                if (str != null)
                {
                    if (str1 == "Anytime")
                    {
                        this.LoadMonthlyValues(Category.FindCategory(categoryID));
                        return;
                    }
                    if (str1 != "Monthly")
                    {
                        return;
                    }
                    this.LoadMonthlyValues(Category.FindCategory(categoryID));
                }
            }
        }

        private void rbAnnually_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.CategoryType()) && !string.IsNullOrEmpty(this.Frequency()))
            {
                this.LoadCategories();
            }
        }

        private void rbAnytime_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.CategoryType()) && !string.IsNullOrEmpty(this.Frequency()))
            {
                this.LoadCategories();
            }
        }

        private void rbBiWeekly_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.CategoryType()) && !string.IsNullOrEmpty(this.Frequency()))
            {
                this.LoadCategories();
            }
        }

        private void rbIncome_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.CategoryType()) && !string.IsNullOrEmpty(this.Frequency()))
            {
                this.LoadCategories();
            }
        }

        private void rbMonthly_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.rbMonthly.Checked)
            {
                this.chkByDate.Visible = false;
            }
            else
            {
                this.chkByDate.Visible = true;
            }
            if (!string.IsNullOrEmpty(this.CategoryType()) && !string.IsNullOrEmpty(this.Frequency()))
            {
                this.LoadCategories();
            }
        }

        private void rbOneTime_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.CategoryType()) && !string.IsNullOrEmpty(this.Frequency()))
            {
                this.LoadCategories();
            }
        }

        private void rbSpending_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.CategoryType()) && !string.IsNullOrEmpty(this.Frequency()))
            {
                this.LoadCategories();
            }
        }

        private void rbWeekly_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.CategoryType()) && !string.IsNullOrEmpty(this.Frequency()))
            {
                this.LoadCategories();
            }
        }

        private void SaveRow(int dayOfMonth = 0)
        {
            if (this.dgvCategories.CurrentRow != null && this.dgvCategories.CurrentRow.Cells["CategoryName"].Value != null)
            {
                Category category = new Category()
                {
                    CategoryName = this.dgvCategories.CurrentRow.Cells["CategoryName"].Value.ToString()
                };
                if (this.dgvCategories.CurrentRow.Cells["CategoryID"].Value != null)
                {
                    category.CategoryID = Convert.ToInt32(this.dgvCategories.CurrentRow.Cells["CategoryID"].Value.ToString());
                }
                bool flag = false;
                string str = this.Frequency();
                string str1 = str;
                if (str != null)
                {
                    if (str1 == "Annually" || str1 == "One Time")
                    {
                        if (!(this.dgvCategories.CurrentRow.Cells["StaticAmount"].Value == null | !this.IsNumber(this.dgvCategories.CurrentRow.Cells["StaticAmount"].Value.ToString().Replace("$", "")) | this.dgvCategories.CurrentRow.Cells["SpecificDate"].Value == null | !this.IsDate(this.dgvCategories.CurrentRow.Cells["SpecificDate"].Value.ToString())))
                        {
                            category.StaticAmount = Convert.ToDecimal(this.dgvCategories.CurrentRow.Cells["StaticAmount"].Value.ToString().Replace("$", ""));
                            category.SpecificDate = Convert.ToDateTime(this.dgvCategories.CurrentRow.Cells["SpecificDate"].Value.ToString());
                            if (this.Frequency() == "Annually" && Convert.ToDateTime(this.dgvCategories.CurrentRow.Cells["SpecificDate"].Value.ToString()).Month < DateTime.Now.Month && category.SpecificDate.Year <= DateTime.Now.Year)
                            {
                                DataGridViewCell item = this.dgvCategories.CurrentRow.Cells["SpecificDate"];
                                DateTime dateTime = category.SpecificDate.AddYears(1);
                                item.Value = dateTime.ToShortDateString();
                                category.SpecificDate = Convert.ToDateTime(this.dgvCategories.CurrentRow.Cells["SpecificDate"].Value.ToString());
                            }
                        }
                        else
                        {
                            flag = true;
                            MessageBox.Show("Please enter a valid date and transactionAmount", "Error");
                        }
                    }
                    else if (str1 == "Anytime")
                    {
                        category = this.AddMonthlyAmounts(category);
                    }
                    else if (str1 != "Bi-Weekly" && str1 != "Weekly")
                    {
                        if (str1 == "Monthly")
                        {
                            category = this.AddMonthlyAmounts(category);
                            if (dayOfMonth == 0 && this.dgvCategories.CurrentRow.Cells["DayOfMonth"].Value == null)
                            {
                                flag = true;
                                MessageBox.Show("Please enter a valid day of the month", "Error");
                            }
                            else if (dayOfMonth != 0)
                            {
                                category.DayOfMonth = dayOfMonth;
                            }
                            else
                            {
                                category.DayOfMonth = Convert.ToInt32(this.dgvCategories.CurrentRow.Cells["DayOfMonth"].Value.ToString());
                            }
                        }
                    }
                    else if (this.dgvCategories.CurrentRow.Cells["StaticAmount"].Value == null || !this.IsNumber(this.dgvCategories.CurrentRow.Cells["StaticAmount"].Value.ToString().Replace("$", "")) || this.dgvCategories.CurrentRow.Cells["NextOccurance"].Value == null || !this.IsDate(this.dgvCategories.CurrentRow.Cells["NextOccurance"].Value.ToString()))
                    {
                        flag = true;
                        MessageBox.Show("Please enter a valid transaction amount & date of next occurance", "Error");
                    }
                    else
                    {
                        category.StaticAmount = Convert.ToDecimal(this.dgvCategories.CurrentRow.Cells["StaticAmount"].Value.ToString().Replace("$", ""));
                        category.NextOccurance = Convert.ToDateTime(this.dgvCategories.CurrentRow.Cells["NextOccurance"].Value.ToString());
                        if (this.dgvCategories.CurrentRow.Cells["EndDate"].Value != null && this.IsDate(this.dgvCategories.CurrentRow.Cells["EndDate"].Value.ToString()))
                        {
                            category.EndDate = Convert.ToDateTime(this.dgvCategories.CurrentRow.Cells["EndDate"].Value.ToString());
                        }
                    }
                }
                if (!flag)
                {
                    if (this.dgvCategories.CurrentRow.Cells["ExcludeFromBudget"].Value != null)
                    {
                        category.ExcludeFromBudget = Convert.ToBoolean(this.dgvCategories.CurrentRow.Cells["ExcludeFromBudget"].Value.ToString());
                    }
                    category.Type = this.CategoryType();
                    category.Frequency = this.Frequency();
                    if (this.dgvCategories.CurrentRow.Cells["CategoryID"].Value == null)
                    {
                        this.dgvCategories.CurrentRow.Cells["CategoryID"].Value = Category.InsertCategory(category);
                        return;
                    }
                    Category.UpdateCategory(category);
                }
            }
        }

        private DataGridViewTextBoxColumn StaticAmountColumn()
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
            dataGridViewTextBoxColumn = this.TextColumn("StaticAmount", "Transaction Amount", true);
            dataGridViewCellStyle = new DataGridViewCellStyle()
            {
                Format = "C2"
            };
            dataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle;
            return dataGridViewTextBoxColumn;
        }

        private DataGridViewTextBoxCell textCell(string text)
        {
            return new DataGridViewTextBoxCell()
            {
                Value = text
            };
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

        private void tsmiDeleteCategory_Click(object sender, EventArgs e)
        {
            int index = this.dgvCategories.CurrentRow.Index;
            if (this.dgvCategories.CurrentRow.Cells["Categoryname"].Value != null && MessageBox.Show("Are you sure you want to delete this category?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (Category.IsUsed(this.dgvCategories.CurrentRow.Cells["CategoryName"].Value.ToString()) && Category.Categories(this.dgvCategories.CurrentRow.Cells["CategoryName"].Value.ToString()).Count < 2)
                {
                    MessageBox.Show("The current category is in use.  You must assign a new category to the transaction(s) first");
                    return;
                }
                Category.DeleteCategory(Convert.ToInt32(this.dgvCategories.CurrentRow.Cells["CategoryID"].Value.ToString()));
                this.dgvCategories.Rows.Remove(this.dgvCategories.CurrentRow);
            }
        }
    }
}