using System;
using System.Drawing;
using System.Linq;
using System.Text;
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
            if (_instance.databasesCollection.FirstOrDefault(s => s.name == dbname) != null)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = dbname + " exists yet.";
                txtName.Focus();
                return;
            }
            btnCreate.Enabled = false;

            var result = Task.Run(() => _instance.CreateDatabase(dbname));
            try
            {
                await result;
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = string.Format("{0} not created, check the log.", txtName.Text);
                txtName.Focus();
                return;
            }
            
            var sbAlter = new StringBuilder();
            sbAlter.Append("ALTER DATABASE [@dbname] SET RECOVERY @recovery;");

            if (ckbCreate.GetItemChecked(0))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET AUTO_CLOSE ON;");
            }
            else if (!ckbCreate.GetItemChecked(0))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET AUTO_CLOSE OFF;");
            }
            if (ckbCreate.GetItemChecked(1))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET AUTO_CREATE_STATISTICS ON;");
            }
            else if (!ckbCreate.GetItemChecked(1))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET AUTO_CREATE_STATISTICS OFF;");
            }
            if (ckbCreate.GetItemChecked(2))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET AUTO_UPDATE_STATISTICS ON;");
            }
            else if (!ckbCreate.GetItemChecked(2))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET AUTO_UPDATE_STATISTICS OFF;");
            }
            if (ckbCreate.GetItemChecked(3))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET AUTO_UPDATE_STATISTICS_ASYNC ON;");
            }
            else if (!ckbCreate.GetItemChecked(3))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET AUTO_UPDATE_STATISTICS_ASYNC OFF;");
            }
            if (ckbCreate.GetItemChecked(4))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET AUTO_SHRINK ON;");
            }
            else if (!ckbCreate.GetItemChecked(4))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET AUTO_SHRINK OFF;");
            }
            if (ckbCreate.GetItemChecked(5))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET ENABLE_BROKER;");
            }
            else if (!ckbCreate.GetItemChecked(5))
            {
                sbAlter.Append("ALTER DATABASE [@dbname] SET DISABLE_BROKER;");
            }

            sbAlter.Replace("@dbname", txtName.Text);
            sbAlter.Replace("@recovery", cmbRecovery.SelectedItem.ToString());

            try
            {
            await _instance.ExecuteNonQueryAsync(sbAlter.ToString());
            lblStatus.ForeColor = Color.Green;
            lblStatus.Text = String.Format("{0} created!", txtName.Text);
            }
            catch(Exception ex)
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = ex.Message;
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
