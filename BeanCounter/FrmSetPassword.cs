using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeanCounter
{
    public partial class FrmSetPassword : Form
    {
        public FrmSetPassword()
        {
            InitializeComponent();
        }
        private void FrmSetPassword_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeanCounterDB"].ToString()))
            {
                sqlConnection.Open();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
        }
		
    }
}
