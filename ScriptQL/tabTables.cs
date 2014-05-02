using System;
using System.Windows.Forms;

namespace ScriptQL
{
    public partial class Main
    {
        // ************** TABINDEX.1 "TABLES" ***********
        private void tabTables_Enter(object sender, EventArgs e)
        {
            _oDatabaseIndex = dgvDatabases.CurrentCell.RowIndex;
            _oDatabase = _oInstance.databasesCollection[_oDatabaseIndex];
            if (_oDatabase == null) // No db selected
            {
                MessageBox.Show(ERROR_NO_DATABASE);
                tabGroup.SelectedIndex = 0;
                return;
            }
            _oDatabase.listSchema.Clear();
            _oDatabase.BindData();
            cmbSchema.Text = string.Empty;
            cmbSchema.DataSource = _oDatabase.listSchema;
            cmbSchema.DisplayMember = "name";
            if (_oDatabase.status != "ONLINE")
            {
                MessageBox.Show("Database is not online.");
                tabGroup.SelectedIndex = 0;
                return;
            }
            if (_oDatabase.isBusy)
            {
                MessageBox.Show("Database is currently busy, please try later.");
                tabGroup.SelectedIndex = 0;
                return;
            }
            if (cmbSchema.SelectedIndex == -1) // Db has no schema; return to previous tab
            {
                MessageBox.Show("Database " + _oDatabase.name +
                                " has no data, please select another.");
                tabGroup.SelectedIndex = 0;
            }
        }

        private void cmbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTable.SelectedIndex == -1) return;
            var oTable = (SqlTable) cmbTable.SelectedItem;
            oTable.listColumn.Clear();
            oTable.BindData();
            cmbColumns.DataSource = oTable.listColumn;
            cmbColumns.DisplayMember = "name";
            btnUpdate.Enabled = true;
            rdbSortASC.Enabled = true;
            rdbSortDESC.Enabled = true;
            rdbSortASC.Checked = true;
        }

        private void cmbSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchema.SelectedIndex == -1) return;
            var oSchema = (SqlSchema) cmbSchema.SelectedItem;
            oSchema.listTables.Clear();
            oSchema.BindData();
            cmbTable.DataSource = oSchema.listTables;
            cmbTable.DisplayMember = "name";
        }

        // tab instance buttons
        private void btnTableRefresh_Click(object sender, EventArgs e)
        {
            string AscOrDesc;
            if (rdbSortASC.Checked) AscOrDesc = "ASC";
            else if (rdbSortDESC.Checked) AscOrDesc = "DESC";
            else AscOrDesc = "";

            var oTable = (SqlTable) cmbTable.SelectedItem;
            var now = DateTime.Now;
            var dt = oTable.SelectFromTable(int.Parse(txtRecordsNumber.Text), cmbColumns.Text, AscOrDesc, int.Parse(txtSearchTimeout.Text));
            if (dt == null) return;
            dgvMain_Rows.DataSource = dt;
            SetStatus("SELECT", _oDatabase, "END", "COMPLETED", dt.Rows.Count + " row/s retrieved in " + (DateTime.Now - now).Seconds + " seconds.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Function is not available yet.");
        }

        private void txtRecordsNumber_Leave(object sender, EventArgs e)
        {
            int number;
            var result = Int32.TryParse(txtRecordsNumber.Text, out number);
            if (result) return;
            MessageBox.Show("Please insert a valid integer.");
            txtRecordsNumber.Text = "100";
            txtRecordsNumber.Focus();
        }

        private void txtSearchTimeout_Leave(object sender, EventArgs e)
        {
            int number;
            var result = Int32.TryParse(txtRecordsNumber.Text, out number);
            if (result) return;
            MessageBox.Show("Please insert a valid integer.");
            txtSearchTimeout.Text = "0";
            txtSearchTimeout.Focus();
        }
    }
}
