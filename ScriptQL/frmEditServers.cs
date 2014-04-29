using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ScriptQL
{
    public partial class FrmServers : Form
    {
        private CancellationTokenSource cts;
        private const sbyte maxInstances = 5;

        public FrmServers()
        {
            InitializeComponent();
            CenterToParent();
        }

        private Boolean ValidateSettings() // TODO:  with sql authentication the database property IsSysDb returns true
        {
            if (chkFrmEditServers_WinAuth.Checked)
            {
                if (txtEditServers_SqlInstance.Text.Length == 0)
                {
                    MessageBox.Show("Please insert an Sql Instance.", "Configuration error");
                    return false;
                }
                if (!Utils.IsStringValid(txtEditServers_SqlInstance.Text))
                {
                    MessageBox.Show("Instance name contains invalid characters, can't add.");
                    return false;
                }
                if (lstEditServers_serverList.Items.Count == maxInstances)
                {
                    MessageBox.Show("You can add a maximum of 5 Sql instances.");
                    return false;
                }
            }
            else
            {
                if (txtEditServers_User.Text.Length == 0 || txtEditServers_Password.Text.Length == 0)
                {
                    MessageBox.Show("Please insert Sql Login user and password.", "Configuration error");
                    return false;
                }
            }
           
            return true;

        }
        private void saveServers()
        {
            SqlInstance.listServers.Clear();
            foreach (SqlInstance server in lstEditServers_serverList.Items)
            {
                SqlInstance.listServers.Add(server);
            }
        }
        private void mnuQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void chkWinAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFrmEditServers_WinAuth.Checked)
            {
                txtEditServers_User.Enabled = false;
                txtEditServers_Password.Enabled = false;
            }
            else
            {
                txtEditServers_User.Enabled = true;
                txtEditServers_Password.Enabled = true;
            }
        }
        private async void btnTest_Click(object sender, EventArgs e)
        {
            var oServer = new SqlInstance(txtEditServers_SqlInstance.Text.Trim(),
                                                    txtEditServers_User.Text,
                                                    txtEditServers_Password.Text,
                                                    chkFrmEditServers_WinAuth.Checked,
                                                    true);
            if (!ValidateSettings()) return;

            btnFrmEditServers_Test.Enabled = false;
            btnFrmEditServers_add.Enabled = false;
            btnFrmEditServers_Delete.Enabled = false;

            btnCancel.Show();
            lblEditServers_Status.ForeColor = Color.Black;
            lblEditServers_Status.Text = string.Format("Pinging {0} ...", txtEditServers_SqlInstance.Text.Trim());

            cts = new CancellationTokenSource();
            var token = cts.Token;

            try
            {
                await oServer.TestConnection(token);
            }
            catch (OperationCanceledException)
            {
                lblEditServers_Status.ForeColor = Color.Black;
                lblEditServers_Status.Text = "User canceled.";
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (oServer.isOnline == true)
            {
                lblEditServers_Status.Text = "Connection OK to " + txtEditServers_SqlInstance.Text;
                lblEditServers_Status.ForeColor = Color.Green;
            }
            else
            {
                lblEditServers_Status.Text = txtEditServers_SqlInstance.Text + " not connected";
                lblEditServers_Status.ForeColor = Color.Red;
            }
                
            btnFrmEditServers_Test.Enabled = true;
            btnFrmEditServers_add.Enabled = true;
            btnFrmEditServers_Delete.Enabled = true;
            btnCancel.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateSettings()) return;

            var oSqlServer = new SqlInstance(txtEditServers_SqlInstance.Text.Trim(),txtEditServers_User.Text,
                txtEditServers_Password.Text, chkFrmEditServers_WinAuth.Checked, true);
            if (SqlInstance.listServers.Contains(oSqlServer))
            {
                MessageBox.Show(oSqlServer + " exists yet.");
                lblEditServers_Status.ForeColor = Color.Red;
                lblEditServers_Status.Text = oSqlServer + " not added.";
                return;
            }
            lstEditServers_serverList.Items.Add(oSqlServer);
            SqlInstance.listServers.Add(oSqlServer);
            lblEditServers_Status.ForeColor = Color.Green;
            lblEditServers_Status.Text = oSqlServer + " added.";
        }

        private void lstEditServers_serverList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFrmEditServers_Delete.Enabled = lstEditServers_serverList.SelectedIndex != -1;
        }

        private void btnFrmEditServers_Delete_Click(object sender, EventArgs e)
        {
            if (lstEditServers_serverList.SelectedItem == null)

            {
                MessageBox.Show("Please select an instance.");
                
            }
            else
            {
                var server = (SqlInstance)lstEditServers_serverList.SelectedItem;
                lblEditServers_Status.ForeColor = Color.Green;
                lblEditServers_Status.Text = lstEditServers_serverList.SelectedItem + " deleted.";
                lstEditServers_serverList.Items.Remove(lstEditServers_serverList.SelectedItem);
                SqlInstance.listServers.Remove(server);
            }
            
        }

        private void frmServers_Load(object sender, EventArgs e)
        {
            ActiveControl = txtEditServers_SqlInstance;
            if (SqlInstance.listServers.Count <= 0) return;
            foreach (var server in SqlInstance.listServers)
            {
                lstEditServers_serverList.Items.Add(server);
            }
        }

        private void mnuSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var t in tblUserInput.Controls.OfType<TextBox>())
            {
                t.Clear();
            }
        }

        private void addServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
        }

        private void deleteServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFrmEditServers_Delete_Click(sender, e);
        }

        private void saveSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstEditServers_serverList.Items.Count == 0)
            {
                MessageBox.Show("Add a server first.");
                return;
            }
            try
            {
                Utils.SerializeBinary(SqlInstance.listServers);
                lblEditServers_Status.Text = "Settings saved to " + Utils.appPath;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                lblEditServers_Status.Text = "Error saving settings to disk.";
            }
        }

        private void btnFrmEditServers_SaveAndClose_Click(object sender, EventArgs e)
        {
            saveServers();
            Dispose();
        }

        private void txtEditServers_SqlInstance_TextChanged(object sender, EventArgs e)
        {
            btnFrmEditServers_Test.Enabled = false;
            btnFrmEditServers_add.Enabled = false;

            if(txtEditServers_SqlInstance.Text.Trim().Length > 0)
            {
                if (chkFrmEditServers_WinAuth.Checked || (txtEditServers_User.Text.Length > 0 && txtEditServers_Password.Text.Length > 0))
                {
                    btnFrmEditServers_Test.Enabled = true;
                    btnFrmEditServers_add.Enabled = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
        }

        private void btnFrmEditServers_Test_EnabledChanged(object sender, EventArgs e)
        {
            btnCancel.Visible = !btnFrmEditServers_Test.Enabled;
        }
    }
}
