using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlTest1
{
    public partial class frmServers : Form
    {
        public frmServers()
        {
            InitializeComponent();
            utils.WriteLog(this.Name + " opened.");
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkWinAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWinAuth.Checked)
            {
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Boolean connection;
            SqlServer localhostSql = new SqlServer(txtSqlInstance.Text,
                                                    txtUser.Text,
                                                    txtPassword.Text,
                                                    chkWinAuth.Checked);
            btnConnect.Enabled = false;
            connection = localhostSql.TestConnection();
            if (connection)
            {
                lblStatus.Text = "Connection OK.";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.Text = "Not connected.";
                lblStatus.ForeColor = Color.Red;
            }
            btnConnect.Enabled = true;    
        }

        private void btnList_Click(object sender, EventArgs e)
        {

        SqlServer localhostSql = new SqlServer(txtSqlInstance.Text,
                                                    txtUser.Text,
                                                    txtPassword.Text,
                                                    chkWinAuth.Checked);
        string query = @"select * from sys.databases";
        List<string> resultList = null;
        resultList = localhostSql.DoQuery(query);
        txtInfo.Clear();

        if (resultList != null)
        {
            foreach (string s in resultList)
            {
                txtInfo.AppendText(s.ToString() + "\n");
            }
        }
      }

        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            utils.OpenLog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            utils.createSettings();
        }

    }
}
