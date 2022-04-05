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
    public partial class FrmEnterPassword : Form
    {
		private bool cancelClose;
		
        public FrmEnterPassword()
        {
            InitializeComponent();
        }
		
		private void frmEnterPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.cancelClose)
            {
                e.Cancel = true;
            }
        }
		
		private void btnOk_Click(object sender, EventArgs e)
        {
            if (!DatabaseProperties.PasswordIsCorrect(this.tbPassword.Text))
            {
                this.cancelClose = true;
            }
        }
		
        private void frmEnterPassword_Load(object sender, EventArgs e)
        {
        }
		
    }
}
