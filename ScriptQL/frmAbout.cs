using System;
using System.Windows.Forms;

namespace ScriptQL
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            CenterToParent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            Text = "About " + Owner.Text;
            Icon = Owner.Icon;
        }


    }
}
