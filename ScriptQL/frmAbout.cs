using System;
using System.Windows.Forms;

namespace ScriptQL
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
            CenterToParent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            Text = "About " + Owner.Text;
            Icon = Owner.Icon;
            lblTitle.Text = typeof (Program).Assembly.GetName().Name;
            lblVersionNumber.Text = typeof (Program).Assembly.GetName().Version.ToString();
            lblAuthorValue.Text = "Roberto Toso";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:roberto.toso80@gmail.com");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                

        }
    }
}
