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
    }
}
