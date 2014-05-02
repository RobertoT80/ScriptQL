using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ScriptQL
{
    public partial class FrmDiscoverDetached : Form
    {
        readonly SqlInstance _oInstance;
        protected const string ERROR_NO_PATH = "Please select a path.";
        protected const string USER_CANCELED = "User has canceled the operation.";

        public FrmDiscoverDetached(SqlInstance _oInstance)
        {
            InitializeComponent();
            CenterToParent();
            this._oInstance = _oInstance;
        }

        private void frmDiscoverDetached_Load(object sender, EventArgs e)
        {
            loadDefaultPaths();
            if (lstPaths.Items.Count > 0) btnSearch.Enabled = true;
        }

        private void clearListBoxes()
        {
            lstMdf.Items.Clear();
            lstNdf.Items.Clear();
            lstLdf.Items.Clear();
        }

        private void loadDefaultPaths()
        {
            lstPaths.Items.Clear();
            lstPaths.Items.Add(_oInstance.PathBackup);
            lstPaths.Items.Add(_oInstance.PathData);
            lstPaths.Items.Add(_oInstance.PathLog);
            clearListBoxes();
        }

        private void lstPaths_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = (lstPaths.SelectedIndex != -1);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            loadDefaultPaths();
            lblStatus.Text = "Paths reset.";
            btnAttach.Enabled = false;
            txtDbname.Text = "";
            txtDbname.Enabled = false;
        }

        private void lstPaths_SelectedValueChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = (lstPaths.Items.Count != 0);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstPaths.SelectedIndex == -1)
            {
                MessageBox.Show(ERROR_NO_PATH);
            }
            else
            {
                lstPaths.Items.Remove(lstPaths.SelectedItem);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dlg = new FolderBrowserDialog {Description = "Select the path to be added."};
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                lblStatus.Text = USER_CANCELED;
                return;
            }
            lstPaths.Items.Add(dlg.SelectedPath);
            if (lstPaths.Items.Count > 0)
            {
                btnSearch.Enabled = true;
            }
        }

        private void lstMdf_SelectedValueChanged(object sender, EventArgs e)
        {
            

            if (lstMdf.SelectedItem != null)
            {
                btnAttach.Enabled = true;
                txtDbname.Enabled = true;
                var f = new FileInfo(lstMdf.SelectedItem.ToString());
                var dbname = f.Name.Remove(f.Name.IndexOf(f.Extension, StringComparison.Ordinal));
                txtDbname.Text = dbname;
            }
            else
            {
                btnAttach.Enabled = false;
                txtDbname.Enabled = false;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstMdf.Items.Clear();
            lstNdf.Items.Clear();
            lstLdf.Items.Clear();
            txtDbname.Clear();
            txtDbname.Enabled = false;

            var now = DateTime.Now;

            const string extensions = "*.mdf, *.ndf, *.ldf";
            var discoveredFiles = 0;
            var physicalFiles = _oInstance.GetPhysicalFiles().ToArray();

            foreach (string folder in lstPaths.Items)
            {
                Utils.WriteLog("Scanning folder: " + folder);
                try
                {
                    var fileArray = Directory.GetFiles(folder, "*.*", SearchOption.TopDirectoryOnly).Where(s =>
                    {
                        var extension = Path.GetExtension(s);
                        return extension != null && extensions.Contains(extension.ToLower());}).ToArray();

                    foreach (var file in fileArray)
                    {
                        lblStatus.Text = string.Format("Searching {0} ...", folder);
                        if (physicalFiles.Contains(file)) continue;
                        if (file.EndsWith(".mdf"))
                        {
                            lstMdf.Items.Add(file);
                            discoveredFiles++;
                        }
                        else if (file.EndsWith(".ndf"))
                        {
                            lstNdf.Items.Add(file);
                            discoveredFiles++;

                        }
                        else if (file.EndsWith(".ldf"))
                        {
                            lstLdf.Items.Add(file);
                            discoveredFiles++;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("You do not have permissions to scan " + folder);
                }
            }
            lblStatus.ForeColor = Color.Black;
            lblStatus.Text = string.Format("Search ended in {0} seconds, {1} files discovered.", DateTime.Now - now, discoveredFiles);
        }

        private async void btnAttach_Click(object sender, EventArgs e)
        {
            if (lstMdf.SelectedItem == null)
            {
                MessageBox.Show("No mdf selected.");
            }
            else
            {
                var mdf = lstMdf.SelectedItem.ToString();
                var ndfArray = new string[] { };
                var ldfArray = new string[] { };

                if (lstNdf.SelectedItems.Count > 0)
                {
                    ndfArray = lstNdf.SelectedItems.OfType<string>().ToArray();
                   
                }
                if (lstLdf.SelectedItems.Count > 0)
                {
                    Utils.WriteLog("ldf count is: " + lstLdf.SelectedItems.Count);
                    ldfArray = lstLdf.SelectedItems.OfType<string>().ToArray();
                }

                lblStatus.Text = "Attaching database " + txtDbname.Text + " ...";
                btnAttach.Enabled = false;

                try
                {
                    var result = await _oInstance.CreateDatabase(txtDbname.Text, mdf, ndfArray, ldfArray);
                    if (!result)
                    {
                        lblStatus.ForeColor = Color.Red;
                        lblStatus.Text = "Database " + txtDbname.Text + " not attached.";
                    }
                    else
                    {
                        lblStatus.ForeColor = Color.Green;
                        lblStatus.Text = "Database " + txtDbname.Text + " attached.";
                        lstMdf.Items.Remove(lstMdf.SelectedItem);

                        if (lstLdf.SelectedItems.Count > 0)
                        {
                            for (var x = lstLdf.SelectedItems.Count - 1; x >= 0; x--)
                            {
                                var itemIndex = lstLdf.SelectedIndices[x];
                                lstLdf.Items.RemoveAt(itemIndex);
                            }

                        }
                        if (lstNdf.SelectedItems.Count > 0)
                        {
                            foreach (ListViewItem item in lstNdf.SelectedItems)
                            {
                                lstNdf.Items.Remove(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Can't attach" + txtDbname.Text;
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    btnAttach.Enabled = true;
                }
            }
        }

    }
}