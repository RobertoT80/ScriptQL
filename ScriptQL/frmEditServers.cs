using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptQL
{
    public partial class FrmServers : Form
    {
        private CancellationTokenSource _cts;
        private const sbyte MAXINSTANCES = 5;
        private const string DATA_REQUIRED = "Please compile all the fields.";

        public FrmServers()
        {
            InitializeComponent();
            CenterToParent();
            SetStatus(DATA_REQUIRED, Color.Black);
        }

        private void SetStatus(string text, Color color)
        {
            lblEditServers_Status.ForeColor = color;
            lblEditServers_Status.Text = text;
        }

        private Boolean ValidateSettings()
        {
            SetButtons(false);
 
            if (txtEditServers_SqlInstance.Text.Length == 0)
            {
                SetStatus(DATA_REQUIRED, Color.Black);
                return false;
            }
            if (!Utils.IsStringValid(txtEditServers_SqlInstance.Text))
            {
                SetStatus("Instance name has invalid characters", Color.Red);
                return false;
            }
            if (lstEditServers_serverList.Items.Count >= MAXINSTANCES)
            {
                SetStatus(DATA_REQUIRED, Color.Black);
                return false;
            }

            if(!chkFrmEditServers_WinAuth.Checked)
            {
                if (txtEditServers_User.Text.Length == 0 || txtEditServers_Password.Text.Length == 0)
                {
                    SetStatus(DATA_REQUIRED, Color.Black);
                    return false;
                }
            }
            SetStatus("Press + to add the instance", Color.Black);
            SetButtons(true);
            return true;

        }
        private void SaveServers()
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
            ValidateSettings();
        }

        private void SetButtons(bool state)
        {
            btnFrmEditServers_Test.Enabled = state;
            btnFrmEditServers_add.Enabled = state;
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            var oServer = new SqlInstance(txtEditServers_SqlInstance.Text.Trim(),
                                                    txtEditServers_User.Text,
                                                    txtEditServers_Password.Text,
                                                    chkFrmEditServers_WinAuth.Checked,
                                                    true);
            if (!ValidateSettings()) return;

            SetButtons(false);
            SetStatus(string.Format("Pinging {0} ...", txtEditServers_SqlInstance.Text.Trim()), Color.Black);

            _cts = new CancellationTokenSource();
            var token = _cts.Token;
            var connection = Task.Run(() => oServer.TestConnection(token));

            try
            {
                btnCancel.Show();
                await connection;
                if (_cts.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                if (oServer.isOnline == true)
                {
                    SetStatus("Connection OK to " + txtEditServers_SqlInstance.Text, Color.Green);
                }
                else
                {
                    SetStatus(txtEditServers_SqlInstance.Text + " not connected", Color.Red);
                }
            }
            catch (OperationCanceledException)
            {
                SetStatus("User canceled.", Color.Blue);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnCancel.Hide();
            }

            
            SetButtons(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Utils.IsStringValid(txtEditServers_SqlInstance.Text))
            {
                MessageBox.Show("Instance name has invalid characters", "Invalid data");
                return;
            }
            if (!ValidateSettings()) return;

            var oSqlServer = new SqlInstance(txtEditServers_SqlInstance.Text.Trim(),txtEditServers_User.Text,
                txtEditServers_Password.Text, chkFrmEditServers_WinAuth.Checked, true);
            if (SqlInstance.listServers.Contains(oSqlServer))
            {
                SetStatus(oSqlServer + " exists yet.", Color.Red);
                return;
            }
            lstEditServers_serverList.Items.Add(oSqlServer);
            SqlInstance.listServers.Add(oSqlServer);
            SetStatus(oSqlServer + " added.", Color.Green);
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
                SetStatus(lstEditServers_serverList.SelectedItem + " deleted.", Color.Green);
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
                SetStatus(lblEditServers_Status.Text = "Settings saved to " + Utils.appPath, Color.Black);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                SetStatus("Error saving settings to disk.", Color.Red);
            }
        }

        private void btnFrmEditServers_SaveAndClose_Click(object sender, EventArgs e)
        {
            SaveServers();
            Dispose();
        }

        private void txtEditServers_SqlInstance_TextChanged(object sender, EventArgs e)
        {
            ValidateSettings();
        }

        private void txtEditServers_Password_TextChanged(object sender, EventArgs e)
        {
            ValidateSettings();
        }

        private void txtEditServers_User_TextChanged(object sender, EventArgs e)
        {
            ValidateSettings();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
            }
        }
    }
}
