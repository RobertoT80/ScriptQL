using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScriptQL
{
    public partial class FrmCreateDb : Form
    {
        readonly SqlInstance _instance;

        public FrmCreateDb(SqlInstance instance)
        {
            
            InitializeComponent();
            CenterToParent();
            _instance = instance;
            ckbCreate.SetItemChecked(1, true); // AUTO_CREATE_STATISTICS
            ckbCreate.SetItemChecked(2, true); // AUTO_UPDATE_STATISTICS
            ckbCreate.SetItemChecked(5, true); // ENABLE_BROKER
            ckbCreate.Enabled = false;
            cmbRecovery.Enabled = false;
            cmbRecovery.SelectedIndex = 0;
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            var dbname = txtName.Text;
            if (! Utils.IsStringValid(dbname))
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = dbname + " is not a valid name.";
                txtName.Focus();
                return;
            }
            if (_instance.databasesCollection.FirstOrDefault(s => s.Name == dbname) != null)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = dbname + " exists yet.";
                txtName.Focus();
                return;
            }
            btnCreate.Enabled = false;

            var sbCreate = new StringBuilder("CREATE DATABASE [@dbname];");
            sbCreate.Append("ALTER DATABASE [@dbname] SET RECOVERY @recovery;");

            if (ckbCreate.GetItemChecked(0))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET AUTO_CLOSE ON;");
            }
            else if (!ckbCreate.GetItemChecked(0))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET AUTO_CLOSE OFF;");
            }
            if (ckbCreate.GetItemChecked(1))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET AUTO_CREATE_STATISTICS ON;");
            }
            else if (!ckbCreate.GetItemChecked(1))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET AUTO_CREATE_STATISTICS OFF;");
            }
            if (ckbCreate.GetItemChecked(2))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET AUTO_UPDATE_STATISTICS ON;");
            }
            else if (!ckbCreate.GetItemChecked(2))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET AUTO_UPDATE_STATISTICS OFF;");
            }
            if (ckbCreate.GetItemChecked(3))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET AUTO_UPDATE_STATISTICS_ASYNC ON;");
            }
            else if (!ckbCreate.GetItemChecked(3))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET AUTO_UPDATE_STATISTICS_ASYNC OFF;");
            }
            if (ckbCreate.GetItemChecked(4))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET AUTO_SHRINK ON;");
            }
            else if (!ckbCreate.GetItemChecked(4))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET AUTO_SHRINK OFF;");
            }
            if (ckbCreate.GetItemChecked(5))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET ENABLE_BROKER;");
            }
            else if (!ckbCreate.GetItemChecked(5))
            {
                sbCreate.Append("ALTER DATABASE [@dbname] SET DISABLE_BROKER;");
            }

            sbCreate.Replace("@dbname", txtName.Text);
            sbCreate.Replace("@recovery", cmbRecovery.SelectedItem.ToString());

            var result = Task.Run(() => _instance.ExecuteNonQueryAsync(sbCreate.ToString()));
            try
            {
                await result;
                Utils.WriteLog("result is::: " + result.Result);
                if (result.Result)
                {
                    lblStatus.ForeColor = Color.Green;
                    lblStatus.Text = dbname + " created!";
                    var oDatabase = new SqlDatabase(_instance, dbname, "ONLINE", 0);
                    _instance.databasesCollection.Add(oDatabase);
                }
            }
            catch (Exception)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = string.Format("{0} not created, check the log.", txtName.Text);
                txtName.Focus();
                return;
            }
        btnCreate.Enabled = true;
        }
        
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.TextLength > 0)
            {
                btnCreate.Enabled = true;
                ckbCreate.Enabled = true;
                cmbRecovery.Enabled = true;
                lblStatus.Text = "";
            }
            else
            {
                btnCreate.Enabled = false;
                ckbCreate.Enabled = false;
                cmbRecovery.Enabled = false;
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = "Please enter a name.";

            }
        }

        private void FrmCreateDb_Load(object sender, EventArgs e)
        {
            Text = Owner.Text + " Create Database";
            Icon = Owner.Icon;
        }
    }
}
