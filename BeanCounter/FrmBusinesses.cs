using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BeanCounter.BusinessLogic;

namespace BeanCounter
{
    public partial class FrmBusinesses : Form
    {
        public FrmBusinesses()
        {
            InitializeComponent();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dgvBusinesses.CurrentRow.Cells["BusinessName"].Value != null &&
                this.dgvBusinesses.CurrentRow.Cells["BusinessName"].Value.ToString() != "CHECK")
            {
                this.SaveRowData(((ComboBox)sender).Text);
            }
        }

        private void cbBusinessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvBusinesses.Rows.Clear();
            string text = this.cbBusinessType.Text;
            string str = text;
            if (text != null)
            {
                if (str == "Local Businesses *")
                {
                    this.lblBusinessType.Text = "* Needs to be a exact match in order to automatically categorize";
                    this.LocalBusinesses();
                    return;
                }
                if (str != "National Businesses *")
                {
                    return;
                }
                this.lblBusinessType.Text = "* Uses keywords to automatically categoize";
                this.NationalBusinesses();
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

        private void dgvBusinesses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = this.dgvBusinesses.Columns[e.ColumnIndex].Name;
            string str = name;
            if (name != null)
            {
                if (!(str == "AutoCategorize") && !(str == "LocalBusiness"))
                {
                    return;
                }
                base.Validate();
                this.SaveRow();
            }
        }

        private void dgvBusinesses_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right && this.dgvBusinesses.CurrentRow.Cells["BusinessID"].Value != null)
            {
                base.Validate();
                this.dgvBusinesses.EndEdit();
                this.dgvBusinesses.CurrentRow.Selected = false;
                this.dgvBusinesses.CurrentCell = this.dgvBusinesses[e.ColumnIndex, e.RowIndex];
                this.dgvBusinesses.Rows[e.RowIndex].Selected = true;
                Rectangle cellDisplayRectangle = this.dgvBusinesses.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                this.cmsDelete.Show((Control)sender, cellDisplayRectangle.Left + e.X, cellDisplayRectangle.Top + e.Y);
            }
        }

        private void dgvBusinesses_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox control = e.Control as ComboBox;
            if (control != null)
            {
                control.SelectedIndexChanged -= new EventHandler(this.cbCategory_SelectedIndexChanged);
                control.SelectedIndexChanged += new EventHandler(this.cbCategory_SelectedIndexChanged);
            }
        }

        private void dgvBusinesses_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvBusinesses.Rows[e.RowIndex].Selected = true;
        }

        private void dgvBusinesses_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            base.Validate();
            this.SaveRow();
        }

        private void LocalBusinesses()
        {
            foreach (Business Business in Business.Businesses(this.cbBusinessType.Text))
            {
                DataGridViewRowCollection rows = this.dgvBusinesses.Rows;
                object[] BusinessID = new object[] { Business.BusinessID, Business.BusinessName, Business.CategoryName, Business.AutoCategorize };
                rows.Add(BusinessID);
            }
        }

        private void Businesses_Load(object sender, EventArgs e)
        {
            this.dgvBusinesses.Columns.Add(TextColumn("BusinessID", "BusinessID", false));
            this.dgvBusinesses.Columns.Add(TextColumn("BusinessName", "Business Name", true));
            this.dgvBusinesses.Columns.Add(this.ComboColumn("CategoryName", "Category", Category.CategoryNames()));
            this.dgvBusinesses.Columns.Add(this.CheckboxColumn("AutoCategorize", "Auto Categorize"));
            this.LocalBusinesses();
        }

        private void NationalBusinesses()
        {
            foreach (Business Business in Business.Businesses(this.cbBusinessType.Text))
            {
                DataGridViewRowCollection rows = this.dgvBusinesses.Rows;
                object[] BusinessID = new object[] { Business.BusinessID, Business.BusinessName, Business.CategoryName, Business.AutoCategorize };
                rows.Add(BusinessID);
            }
        }

        private void SaveRow()
        {
            if (this.dgvBusinesses.CurrentRow != null)
            {
                if (this.dgvBusinesses.CurrentRow.Cells["BusinessName"].Value != null)
                {
                    this.SaveRowData(this.dgvBusinesses.CurrentRow.Cells["CategoryName"].Value.ToString());
                    return;
                }
                MessageBox.Show("Error", "You must enter the Business name & select the category");
            }
        }

        private void SaveRowData(string categoryName)
        {
            bool flag = false;
            string text = this.cbBusinessType.Text;
            string str = text;
            if (text != null)
            {
                if (str == "Local Businesses *")
                {
                    flag = true;
                }
                else if (str == "National Businesses *")
                {
                    flag = false;
                }
            }
            bool flag1 = false;
            if (this.dgvBusinesses.CurrentRow.Cells["AutoCategorize"].Value != null)
            {
                flag1 = Convert.ToBoolean(this.dgvBusinesses.CurrentRow.Cells["AutoCategorize"].Value.ToString());
            }
            if (this.dgvBusinesses.CurrentRow.Cells["BusinessID"].Value == null)
            {
                this.dgvBusinesses.CurrentRow.Cells["BusinessID"].Value = Business.InsertBusiness(this.dgvBusinesses.CurrentRow.Cells["BusinessName"].Value.ToString(), categoryName, flag1, flag);
                return;
            }
            Business.UpdateBusiness(Convert.ToInt32(this.dgvBusinesses.CurrentRow.Cells["BusinessID"].Value.ToString()), this.dgvBusinesses.CurrentRow.Cells["BusinessName"].Value.ToString(), categoryName, flag1, flag);
        }

        private static DataGridViewTextBoxColumn TextColumn(string name, string headerText, bool visible)
        {
            DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn()
            {
                Name = name,
                HeaderText = headerText,
                Visible = visible
            };
            return dataGridViewTextBoxColumn;
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            int count = this.dgvBusinesses.SelectedRows.Count;
            if (this.dgvBusinesses.CurrentRow.Cells["BusinessID"].Value != null && MessageBox.Show("Are you sure you want to delete this Business?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Business.DeleteBusiness(Convert.ToInt32(this.dgvBusinesses.CurrentRow.Cells["BusinessID"].Value.ToString()));
                this.dgvBusinesses.Rows.Remove(this.dgvBusinesses.CurrentRow);
            }
        }

    }
}
