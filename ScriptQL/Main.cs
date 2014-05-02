using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScriptQL.Properties;

namespace ScriptQL
{
    public partial class Main : Form
    {
        private const string ERROR_NO_SERVER = "Please select a instance";
        private const string ERROR_NO_DATABASE = "Please select a database";
        private const string WARNING_IS_BUSY = " has operation pending, please wait for them to finish";
        private const string USER_CANCELED = "Operation canceled by the user";
        private const string RETRY_CONFIRMATION = " failed. Do you want to forcibly close open connections?";
        private const string NO_USER_DATABASES = "No user database are present. Maybe you want to enable the System ones ?";
        private const string WRONG_DATABASE_STATE = "Database is in an incompatible state ";
        private const string ERROR_CANCEL = "Sorry, can't cancel this operation";
        private const string CANCEL_SYSDB = "Can't perform this operation on a system database";

        private SqlDatabase _oDatabase;
        private int _oDatabaseIndex;
        private SqlInstance _oInstance;
        private int _oServerIndex = -1;

        private BindingList<SqlDatabase> _databaseCollectionBindingList;

        private List<PictureBox> _icons;
        private List<ProgressBar> _progressBars;
        private List<CancellationTokenSource> _cancellationTokenSources;

        internal Main()
        {
            InitializeComponent();
            tabServer.Select();
            InitializeCustom();
        }

        private void InitializeCustom()
        {
            var ctsCancel0 = new CancellationTokenSource();
            var ctsCancel1 = new CancellationTokenSource();
            var ctsCancel2 = new CancellationTokenSource();
            var ctsCancel3 = new CancellationTokenSource();
            var ctsCancel4 = new CancellationTokenSource();
            _cancellationTokenSources = new List<CancellationTokenSource> {ctsCancel0, ctsCancel1, ctsCancel2, ctsCancel3, ctsCancel4};
            _icons = new List<PictureBox> {pctServer0, pctServer1, pctServer2, pctServer3, pctServer4};
            _progressBars = new List<ProgressBar> {prgServer0, prgServer1, prgServer2, prgServer3, prgServer4};
        }

        private CancellationToken GetCancellationToken(int index)
        {
            _cancellationTokenSources[index] = new CancellationTokenSource();
            var token = _cancellationTokenSources[index].Token;
            return token;
        }

        private void SetStatus(object sender, object obj, string progress, string state, string message = "")
        {
            var time = DateTime.Now.ToString("HH:mm:ss.fff");
            var source = new StringBuilder();
            var database = obj as SqlDatabase;
            var foreColor = new Color();
            var backColor = new Color();

            if (database != null)
            {
                source.Append("[@instance>@database]");
                source.Replace("@database", database.Name);
                source.Replace("@instance", database.Parent.ToString());
            }
            else
            {
                source.Append("[@instance] ");
                source.Replace("@instance", (obj).ToString());
            }

            switch (state)
            {
                case "CANCEL":
                    backColor = Color.White;
                    foreColor = Color.DodgerBlue;
                    message = USER_CANCELED;
                    break;
                case "COMPLETED":
                    backColor = Color.White;
                    foreColor = Color.Green;
                    if (message.Length == 0) message = sender.ToString().ToUpper() + " completed.";
                    break;
                case "ERROR":
                    backColor = Color.White;
                    foreColor = Color.Red;
                    break;
                case "TIMEOUT":
                    backColor = Color.White;
                    foreColor = Color.DarkOrange;
                    break;
                case "SKIPPED":
                    backColor = Color.White;
                    foreColor = Color.MediumOrchid;
                    break;
                case "INFO":
                    if (progress == "BEGIN" || progress == "END")
                    {
                        backColor = Color.Black;
                        foreColor = Color.White;
                    }
                    else
                    {
                        backColor = Color.Gray;
                        foreColor = Color.White;
                    }
                    break;
            }
            var item = new ListViewItem(new[] {time, source.ToString(), progress, sender.ToString().ToUpper(), state, message})
            {ForeColor = foreColor, BackColor = backColor};
            lsv_log.Items.Add(item);
            tlsClearLog.Enabled = true;
        }

        private void UISelectObject(object obj)
        {
            if (obj == null)
            {
                return;
            }
            if (obj is SqlInstance)
            {
                if (lstMain_Servers.Items.Count == 0)
                {
                    dgvDatabases.DataSource = null;
                    prpServers.SelectedObject = null;
                    ButtonDisable();
                    return;
                }

                if (lstMain_Servers.Items.Count == 1)
                {
                    lstMain_Servers.SetSelected(0, true);
                    return;
                }
                if (_oServerIndex != -1)
                {
                    if (lstMain_Servers.Items.Count >= _oServerIndex + 1)
                    {
                        lstMain_Servers.SetSelected(_oServerIndex, true);
                    }
                }
            }
            var database = obj as SqlDatabase;
            if (database != null)
            {
                database.GetDatabaseProperties();
            }
        }

        private void UIconnectingStarted(SqlInstance instance)
        {
            if (instance.isBusy || instance.isConnecting) return;
            var index = SqlInstance.listServers.IndexOf(instance);
            ButtonDisable();

            _progressBars[index].Value = 0;
            _progressBars[index].Show();
            _progressBars[index].Style = ProgressBarStyle.Marquee;
            _progressBars[index].Update();
        }

        private void UIconnectingEnded(SqlInstance instance)
        {
            if (instance.isBusy) return;
            var index = SqlInstance.listServers.IndexOf(instance);
            if (lstMain_Servers.SelectedItem !=null && lstMain_Servers.SelectedItem.Equals(instance)) EnableButtons(instance, null);
            _progressBars[index].Hide();
            _progressBars[index].Style = ProgressBarStyle.Blocks;
        }

        private void UIOperationStarted(object sender, SqlDatabase database, string message = "")
        {
            SetStatus(sender, database, "BEGIN", "INFO", message);
            var index = SqlInstance.listServers.IndexOf(database.Parent);

            ButtonDisable();
            _progressBars[index].Style = ProgressBarStyle.Marquee;
            _progressBars[index].Show();
            _progressBars[index].Update();
            database.IsBusy = true;
        }

        private void UIOperationStarted(object sender, SqlInstance instance, int totalOperations, string message = "")
        {
            SetStatus(sender, instance, "BEGIN", "INFO", message);
            var index = SqlInstance.listServers.IndexOf(instance);
            ButtonDisable();
            instance.isBusy = true;
            _progressBars[index].Value = 0;
            _progressBars[index].Show();
            if (totalOperations == 0)
            {
                _progressBars[index].Style = ProgressBarStyle.Marquee;
                _progressBars[index].Update();
            }
            else
            {
                _progressBars[index].Style = ProgressBarStyle.Blocks;
                _progressBars[index].Maximum = totalOperations;
            }
        }

        private void UIOperationClosed(object sender, SqlInstance instance, bool batchOperation = false, string message = "")
        {
            Thread.Sleep(1); // avoids that the last operation is logged before this
            if (batchOperation) SetStatus(sender, instance, "END", "INFO", message); // only logs instance operations
            var serverIndex = SqlInstance.listServers.IndexOf(instance);
            if (instance != null) instance.isBusy = false;
            EnableButtons(instance, null);
            _progressBars[serverIndex].Hide();
            _progressBars[serverIndex].Style = ProgressBarStyle.Blocks;
            UISelectObject(instance);
            if (SqlInstance.listServers.Count > 0)
            {
                dgvDatabases.ClearSelection();
                dgvDatabases.Refresh();
            }
        }

        private void UIOperationClosed(object sender, SqlDatabase database, bool batchOperation = false)
        {
            if (batchOperation) SetStatus(sender, database, "END", "INFO"); // only logs instance operations
            var serverIndex = SqlInstance.listServers.IndexOf(database.Parent);
            if (_oDatabase != null) database.IsBusy = false;
            _progressBars[serverIndex].Style = ProgressBarStyle.Blocks;
            _progressBars[serverIndex].Hide();
            UISelectObject(database);
            if (SqlInstance.listServers.Count > 0)
            {
                dgvDatabases.ClearSelection();
                dgvDatabases.Refresh();
            }
        }

        private static bool CanContinue(SqlDatabase database)
        {
            if (database == null)
            {
                MessageBox.Show(ERROR_NO_DATABASE);
                return false;
            }
            if (database.IsBusy)
            {
                MessageBox.Show(database.Name + WARNING_IS_BUSY);
                return false;
            }
            if (database.Parent.isBusy)
            {
                MessageBox.Show(database.Parent + WARNING_IS_BUSY);
                return false;
            }
            return true;
        }

        private static bool CanContinue(SqlInstance instance)
        {
            if (instance == null)
            {
                MessageBox.Show(ERROR_NO_SERVER);
                return false;
            }
            if (instance.isOnline == false)
            {
                MessageBox.Show(string.Format("instance {0} is not online.", instance));
                return false;
            }
            if (instance.isBusy)
            {
                MessageBox.Show(instance + WARNING_IS_BUSY);
                return false;
            }
            return true;
        }

        private void LoadSettings()
        {
            var list = Utils.DeserializeBinary();
            if (list == null) return;
            foreach (var s in list)
            {
                lstMain_Servers.Items.Add(s);
            }
            SqlInstance.listServers = list;
        }

        private void editConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tlsEditConfig_Click(this, null);
        }

        private static void OpenLog()
        {
            try
            {
                Process.Start(Utils.logTxt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabGroup.SelectTab(0);
            Close();
        }

        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLog();
        }

        private void ButtonDisable()
        {
            // disables menu strips
            foreach (ToolStripMenuItem i in mnuServer.DropDown.Items)
            {
                i.Enabled = false;
            }
            foreach (var c in tbxMain.Items.OfType<ToolStripButton>().Where(c => (string) c.Tag != "AlwaysOn"))
            {
                c.Enabled = false;
            }
            tlsBackupAll.Enabled = false;

            foreach (ToolStripMenuItem i in mnuDatabase.DropDown.Items)
            {
                i.Enabled = false;
            }

            foreach (var c in tbxDatabase.Items.OfType<ToolStripButton>())
            {
                c.Enabled = false;
            }
            tlsDatabase_BackupWith.Enabled = false;
            txtDatabase_Rename.Enabled = false;
            mnuTools_OpenBackupFolder.Enabled = false;
            tlsOpenBackupFolder.Enabled = false;
        }

        private void EnableButtons(SqlInstance instance, SqlDatabase database)
        {
            tlsEditConfig.Enabled = true;
            tlsEnableSystemDbs.Enabled = true;
            // instance unreachable, connecting or busy
            if (instance.isOnline == null || instance.isConnecting || instance.isBusy)
            {
                return;
            }
            if (instance.isOnline != true) return;

            foreach (ToolStripMenuItem i in mnuServer.DropDown.Items)
            {
                i.Enabled = true;
            }
            foreach (var c in tbxMain.Items.OfType<ToolStripButton>().Where(c => c.Name != "tlsClearLog" && c.Name != "tlsTools_CancelAll"))
            {
                c.Enabled = true;
            }
            tlsBackupAll.Enabled = true;

            foreach (var i in tbxDatabase.Items.OfType<ToolStripButton>().Where(i => (string) i.Tag == "server"))
            {
                i.Enabled = true;
            }
            txtDatabase_Rename.Enabled = true;
            foreach (ToolStripMenuItem i in mnuDatabase.DropDown.Items.OfType<ToolStripMenuItem>().Where(i => (string)i.Tag == "server"))
            {

                i.Enabled = true;

            }

            // Database busy or null
            if (database == null || database.IsBusy) return;

            if(database is SqlSystemDatabase)
            {
                foreach (var i in tbxDatabase.Items.OfType<ToolStripButton>().Where(i => (string) i.Tag == "sysdb"))
                {
                    i.Enabled = true;
                }
                tlsDatabase_BackupWith.Enabled = true;
                mnuDatabase_Check.Enabled = true;
                mnuDatabase_Backup.Enabled = true;
                return;
            }

            switch (database.Status)
            {
                    // Database offline (Control.Tag == "offline")
                case "OFFLINE":
                    foreach (var i in tbxDatabase.Items.OfType<ToolStripButton>().Where(i => (string) i.Tag == "offline"))
                    {
                        i.Enabled = true;
                    }
                    foreach (ToolStripMenuItem i in mnuDatabase.DropDown.Items)
                    {
                        if ((string) i.Tag == "offline")
                        {
                            i.Enabled = true;
                        }
                    }
                    //mnuDatabase_BackupWith.Enabled = true; // 
                    break;
                    // Database online
                case "ONLINE":
                    foreach (var i in tbxDatabase.Items.OfType<ToolStripButton>())
                    {
                        i.Enabled = true;
                    }
                    tlsDatabase_BackupWith.Enabled = true;
                    tlsDatabase_Online.Enabled = false;
                    foreach (ToolStripMenuItem i in mnuDatabase.DropDown.Items)
                    {
                        i.Enabled = true;
                    }
                    // Online single user
                    if (database.Access == "multi")
                    {
                        tlsDatabase_Multi.Enabled = false;
                    }
                        // Online Multi User
                    else
                    {
                        tlsDatabase_Single.Enabled = false;
                    }
                    break;
                default:
                    tlsDatabase_Drop.Enabled = true;
                    break;

            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Utils.CreateLocalSettings();
            Utils.WriteLog("++++++++++ Program Started ++++++++++");
            LoadSettings();
        }

        private async void AlterDatabase(object sender, string command, sbyte commandTimeout = 5, bool withRollbackImmediate = false)
        {
            if (!CanContinue(_oDatabase)) return;
            var database = _oDatabase;
            if (database.Status == "RESTORING")
            {
                MessageBox.Show(WRONG_DATABASE_STATE + "(" + database.Status + ")");
                return;
            }
            UIOperationStarted(sender, database.Parent, 0);

            var token = GetCancellationToken(_oServerIndex);
            var alterDatabase = Task.Run(() => database.Alter(command, token, commandTimeout));
            try
            {
                await alterDatabase;
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }
                if (alterDatabase.Result)
                {
                    SetStatus(sender, database, "END", "COMPLETED", String.Format("{0} {1}", database.Name, command));
                    UIOperationClosed(sender, database.Parent);
                    return;
                }
                

            }
            catch (OperationCanceledException)
            {
                SetStatus(sender, database, "END", "CANCEL");
                return;
            }
            catch (SqlTimeoutException ex)
            {
                SetStatus(sender, database, "END", "TIMEOUT", ex.Message);
            }
            catch (SqlException ex)
            {
                SetStatus(sender, database, "END", "ERROR", ex.Message);
            }
            catch (Exception ex)
            {
                SetStatus(sender, database, "END", "EXCEPTION", ex.Message);
            }
            
            var confirmation = MessageBox.Show(command + RETRY_CONFIRMATION, "Confirmation", MessageBoxButtons.YesNo);
            if (!confirmation.Equals(DialogResult.Yes))
            {
                SetStatus(sender, database, "END", "CANCEL");
            }
            else
            {
                UIOperationStarted(sender, database.Parent, 0);
                alterDatabase = Task.Run(() => database.Alter(command, token, commandTimeout, null, true));
                try
                {
                    await alterDatabase;
                    if (alterDatabase.Result)
                    {
                        SetStatus(sender, database, "END", "COMPLETED", String.Format("{0} {1}", database.Name, command));
                    }
                    else
                    {
                        SetStatus(sender, database, "END", "ERROR", "Could not " + command + database.Name);
                    }
                }
                catch (Exception ex)
                {
                    Utils.WriteLog(ex.Message);
                    SetStatus(sender, database, "END", "ERROR", ex.Message);
                }
            }
            
            UIOperationClosed(sender, database.Parent);
        }

        private async void Database_Backup(object sender, EventArgsFactory.BackupEventArgs e)
        {
            if (!CanContinue(_oDatabase)) return;
            if (_oDatabase.Status != "ONLINE")
            {
                SetStatus(sender, _oDatabase, "END", "SKIPPED", WRONG_DATABASE_STATE + string.Format("({0})", _oDatabase.Status));
                return;
            }
            var database = _oDatabase;
            var now = DateTime.Now;
            var par = new List<string>();
            if (e != null)
            {
                if (e.compress) par.Add("COMPRESSION");
                if (e.format) par.Add("FORMAT");
            }


            UIOperationStarted(sender, database);
            try
            {
                var token = GetCancellationToken(SqlInstance.listServers.IndexOf(database.Parent));
                var backup = Task.Run(() => database.BackupAsync(par, token));
                await backup;
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }

                SetStatus(sender, database, "END", "COMPLETED", string.Format("Database {0} backed up in {1} seconds", database.Name,
                    ((DateTime.Now - now).Seconds)));
            }
            catch (OperationCanceledException)
            {
                SetStatus(sender, database, "END", "CANCEL");
            }
            catch (SqlException ex)
            {
                SetStatus(sender, database, "END", "ERROR", ex.Message);
            }
            catch (Exception ex)
            {
                SetStatus(sender, database, "END", "EXCEPTION", ex.Message);
            }
            UIOperationClosed(sender, database);
        }

        private async void tlsServer_BackupAll(object sender, EventArgsFactory.BackupEventArgs e)
        {
            if (!CanContinue(_oInstance)) return;
            var server = _oInstance;
            // Ask to activate sys dbs if no user dbs are available
            if (server.databasesCollection.Count == 0)
            {
                var dr = MessageBox.Show(NO_USER_DATABASES, "No user databases", MessageBoxButtons.YesNo);
                if (!dr.Equals(DialogResult.Yes)) return;
                tlsEnableSystemDbs.PerformClick();
                return;
            }
            // I need a copy in case the collection changes during the async operations          
            var listDatabases = new List<SqlDatabase>(server.databasesCollection);
            var checkedOk = 0;
            UIOperationStarted(sender, server, listDatabases.Count);
            foreach (var database in listDatabases)
            {
                var status = String.Format("({0}/{1})", listDatabases.IndexOf(database) + 1, listDatabases.Count);
                if (database.Status != "ONLINE")
                {
                    SetStatus(sender, database, status, "SKIPPED", WRONG_DATABASE_STATE + string.Format("({0})", database.Status));
                    continue;
                }
                var par = new List<string>();
                if (e == null) e = new EventArgsFactory.BackupEventArgs();
                if (e.compress) par.Add("COMPRESSION");
                if (e.format) par.Add("FORMAT");

                var token = GetCancellationToken(SqlInstance.listServers.IndexOf(server));
                var db = database;
                var backup = Task.Run(() => db.BackupAsync(par, token));
                try
                {
                    await backup; // TODO: fix EXCEPTION if in single user
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    SetStatus(sender, db, status, "COMPLETED", database.Name + " backed up.");
                    checkedOk++;
                }
                catch (OperationCanceledException)
                {
                    SetStatus(sender, db, status, "CANCEL");
                    break;
                }
                catch (SqlException ex)
                {
                    SetStatus(sender, db, status, "ERROR", ex.Message);
                }
                catch (Exception ex)
                {
                    SetStatus(sender, db, status, "EXCEPTION", ex.Message);
                }
                finally
                {
                    _progressBars[SqlInstance.listServers.IndexOf(server)].Increment(1);
                    //dgvDatabases.Refresh();
                }
            }
            UIOperationClosed(sender, server, true, String.Format("Backed up successfully: {0}/{1}", checkedOk, listDatabases.Count));
        }

        private void tabServer_Enter(object sender, EventArgs e)
        {
            if (_oServerIndex != -1) lstMain_Servers.SelectedItem = _oServerIndex;
        }

        private void mnuServer_DiscoverDetached_Click(object sender, EventArgs e)
        {
            tlsDiscoverDetached_Click(this, null);
        }

        private void mnuServer_Restore_Click(object sender, EventArgs e)
        {
            tlsRestoreAllFromCustomFolder_Click(sender, null);
        }

        private void mnuServer_backup_Click(object sender, EventArgs e)
        {
            tlsServer_BackupAll(sender, null);
        }

        private void mnuServer_backupWithCompress_Click(object sender, EventArgs e)
        {
            var arg = new EventArgsFactory.BackupEventArgs {compress = true};
            tlsServer_BackupAll(this, arg);
        }

        private void mnuServer_backupWithInit_Click(object sender, EventArgs e)
        {
            var arg = new EventArgsFactory.BackupEventArgs {format = true};
            tlsServer_BackupAll(this, arg);
        }

        private void mnuServer_backupWithCompressAndInit_Click(object sender, EventArgs e)
        {
            var arg = new EventArgsFactory.BackupEventArgs {compress = true, format = true};
            tlsServer_BackupAll(this, arg);
        }

        private void mnuServer_Check_Click(object sender, EventArgs e)
        {
            tlsCheckAll_Click(sender, null);
        }

        private void mnuDatabase_Create_Click(object sender, EventArgs e)
        {
            tlsDatabase_Create_Click(sender, null);
        }

        private void tlsDatabase_Create_Click(object sender, EventArgs e)
        {
            if (lstMain_Servers.SelectedItem == null) MessageBox.Show(ERROR_NO_SERVER);
            else
            {
                var frmCreateDb = new FrmCreateDb((SqlInstance) lstMain_Servers.SelectedItem);
                frmCreateDb.ShowDialog(this);
                frmCreateDb.Dispose();
            }
        }

        private async void tlsDatabase_Drop_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oDatabase)) return;
            var database = _oDatabase;
            var dropConfirmation = MessageBox.Show("Database " + database.Name + " will be deleted permanently. \nDo you want to continue?",
                "Drop Confirmation", MessageBoxButtons.YesNo);
            if (!dropConfirmation.Equals(DialogResult.Yes))
            {
                SetStatus(sender, database, "END", "CANCEL");
                return;
            }


            if (database.Status != "ONLINE")
            {
                var statusConfirmation = MessageBox.Show("Database status is " + database.Status + ", Physical files won't likely be deleted. \nDo you want to continue?",
                    "Database status warning", MessageBoxButtons.YesNo);
                if (!statusConfirmation.Equals(DialogResult.Yes))
                {
                    SetStatus(sender, database, "END", "CANCEL");
                    return;
                }

            }
            var server = database.Parent;
            UIOperationStarted(sender, server, 0);

            var token = GetCancellationToken(_oServerIndex);
            var result = false;
            try
            {
                result = await database.Parent.Drop(database.Name, token);
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }
            }
            catch (OperationCanceledException)
            {
                SetStatus(sender, server, "END", "CANCEL");
                UIOperationClosed(sender, server);
                return;
            }
            catch (SqlTimeoutException ex)
            {
                SetStatus(sender, server, "END", "TIMEOUT", ex.Message);
            }
            catch (SqlException ex)
            {
                SetStatus(sender, server, "END", "ERROR", ex.Message);
            }
            catch (IOException ex)
            {
                SetStatus(sender, server, "END", "ERROR", ex.Message);
            }
            catch (Exception ex)
            {
                SetStatus(sender, server, "END", "EXCEPTION", ex.Message);
            }


            if (result || database.Status == "RESTORING")
            {
                goto End;
            }

            var retryConfirmation = MessageBox.Show("drop " + RETRY_CONFIRMATION, "Confirmation", MessageBoxButtons.YesNo);
            if (!retryConfirmation.Equals(DialogResult.Yes))
            {
                SetStatus(sender, server, "END", "CANCEL");
            }
            else
            {
                UIOperationStarted(sender, server, 0);

                try
                {
                    await database.Alter("SET OFFLINE", token, 10, null, true);
                    result = await database.Parent.Drop(database.Name, token);

                }
                catch (Exception ex)
                {
                    Utils.WriteLog(ex.Message);
                }
            }
            End:
            if (result)
            {
                SetStatus(sender, server, "END", "COMPLETED", String.Format("{0} {1}", database.Name, "dropped"));
            }
            else
            {
                SetStatus(sender, server, "END", "ERROR", "Could not drop " + database.Name);
            }
            UIOperationClosed(sender, server);
        }

        private void mnuDatabase_Drop_Click(object sender, EventArgs e)
        {
            tlsDatabase_Drop_Click(sender, null);
        }

        private async void tlsDatabase_Check_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oDatabase)) return;
            var database = _oDatabase;
            UIOperationStarted(sender, database);
            var token = GetCancellationToken(SqlInstance.listServers.IndexOf(database.Parent));
            var check = Task.Run(() => database.Check(token));

            try
            {
                await check;
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }
                SetStatus(sender, database, "END", "COMPLETED", "No errors detected.");
            }
            catch (OperationCanceledException)
            {
                SetStatus(sender, database, "END", "CANCEL");
            }
            catch (SqlTimeoutException)
            {
                SetStatus(sender, database, "END", "TIMEOUT");
            }
            catch (SqlException ex)
            {
                SetStatus(sender, database, "END", "ERROR", ex.Message);
            }
            //catch (Exception ex)
            //{
            //    SetStatus(sender, database, "END", "EXCEPTION", ex.Message);
            //}
            UIOperationClosed(sender, database);

        }

        private void mnuDatabase_Check_Click(object sender, EventArgs e)
        {
            tlsDatabase_Check_Click(sender, null);
        }

        private void tlsEditConfig_Click(object sender, EventArgs e)
        {
            if (SqlInstance.listServers.Any(server => server.isConnecting || server.isBusy))
            {
                MessageBox.Show("At least one instance " + WARNING_IS_BUSY);
                return;
            }
            var ofrmServers = new FrmServers();
            ofrmServers.ShowDialog();
        }

        private void tlsOpenBackupFolder_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(@"C:\windows\explorer.exe", _oInstance.pathBackup);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void tlsDatabase_Attach_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oInstance)) return;
            var dlg = new OpenFileDialog {Title = "Please select the master data file. (required)"};

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                SetStatus(sender, _oDatabase, "END", "CANCEL");
                return;
            }
            var mdf = new FileInfo(dlg.FileName);
            if (!mdf.Exists)
            {
                MessageBox.Show("Can't access " + mdf.FullName);
                return;
            }
            if (mdf.Extension != ".mdf")
            {
                MessageBox.Show("File is not an .mdf, try another one.");
                return;
            }
            if (mdf.Length == 0)
            {
                MessageBox.Show("File is zero byte.");
                return;
            }
            var dbname = mdf.Name.Remove(mdf.Name.IndexOf(mdf.Extension, StringComparison.Ordinal));
            if (!Utils.IsStringValid(dbname))
            {
                MessageBox.Show(dbname + " is not a valid name.");
                return;
            }
            if (_oInstance == null || _oInstance.databasesCollection == null) return;

            if (_oInstance.databasesCollection.Any(x => x.Name == dbname))
            {
                MessageBox.Show(dbname + " esists yet on " + _oInstance);
                return;
            }
            // select log now
            dlg.Title = "Please select the log data file. (optional)";
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var ldf = new FileInfo(dlg.FileName);
            if (!ldf.Exists)
            {
                MessageBox.Show("Can't access " + ldf.FullName);
                return;
            }
            if (ldf.Extension != ".ldf")
            {
                MessageBox.Show("File is not an .ldf, try another one.");
                return;
            }
            if (ldf.Length == 0)
            {
                MessageBox.Show("File is zero byte.");
                return;
            }

            UIOperationStarted(sender, _oInstance, 0);
            try
            {
                await _oInstance.CreateDatabase(dbname, mdf, ldf);
                SetStatus(sender, _oInstance, "END", "COMPLETED", dbname + " has been attached");
            }
            catch (SqlException ex)
            {
                SetStatus(sender, _oInstance, "END", "ERROR", ex.Message);
            }
            catch (Exception ex)
            {
                SetStatus(sender, _oInstance, "END", "FAILED", ex.Message);
            }
            finally
            {
                UIOperationClosed(sender, _oInstance);
            }
        }

        private void mnuDatabase_Attach_Click(object sender, EventArgs e)
        {
            tlsDatabase_Attach_Click(sender, null);
        }

        private async void tlsDatabase_Detach_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oDatabase)) return;
            var database = _oDatabase;
            UIOperationStarted(sender, database.Parent, 0);

            var token = GetCancellationToken(SqlInstance.listServers.IndexOf(database.Parent));
            var detach = Task.Run(() => database.Detach(token));

            try
            {
                await detach;
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException();
                }
                SetStatus(sender, database, "END", "COMPLETED", database.Name + " has been detached");
            }
            catch (OperationCanceledException)
            {
                SetStatus(sender, database, "END", "CANCEL");
                UIOperationClosed(sender, database.Parent);
                return;
            }
            catch (SqlException ex)
            {
                SetStatus(sender, database, "END", "ERROR", ex.Message);
            }
            catch (Exception ex)
            {
                SetStatus(sender, database, "END", "ERROR", ex.Message);
            }
            UIOperationClosed(sender, database.Parent);
        }

        private void mnuDatabase_Detach_Click(object sender, EventArgs e)
        {
            tlsDatabase_Detach_Click(sender, null);
        }

        private async void tlsDatabase_Restore_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oDatabase)) return;

            var dlg = new OpenFileDialog {Title = "Select backup file", Filter = "bak files (*.bak) | *.bak"};
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                SetStatus(sender, _oDatabase, "END", "CANCEL");
                return;
            }
            if (!File.Exists(dlg.FileName))
            {
                SetStatus(sender, _oDatabase, "END", "FAILED", dlg.FileName + " does not exist");
                return;
            }
            lstMain_Servers.SetSelected(_oServerIndex, true);

            UIOperationStarted(sender, _oDatabase);

            var token = GetCancellationToken(SqlInstance.listServers.IndexOf(_oDatabase.Parent));
            var restore = Task.Run(() => _oDatabase.RestoreAsync(dlg.FileName, token));

            try
            {
                await restore;
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                SetStatus(sender, _oDatabase, "END", "COMPLETED");
            }
            catch (OperationCanceledException)
            {
                SetStatus(sender, _oDatabase, "END", "CANCEL");
            }
            catch (SqlException ex)
            {
                SetStatus(sender, _oDatabase, "END", "ERROR", ex.Message);
            }
            catch (Exception ex)
            {
                SetStatus(sender, _oDatabase, "END", "ERROR", ex.Message);
            }
            UIOperationClosed(sender, _oDatabase);
        }

        private void tlsDiscoverDetached_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oInstance)) return;
            var server = _oInstance;
            var oFrmDiscover = new FrmDiscoverDetached(server);
            oFrmDiscover.ShowDialog(this);
            oFrmDiscover.Dispose();
        }

        private void tlsServer_VerifyBackupsDefaultFolder_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oInstance)) return;
            var server = _oInstance;
            ValidateRestoreFolder(sender, server, server.pathBackup);
        }

        private void tlsRestoreAllFromCustomFolder_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oInstance)) return;
            var server = _oInstance;

            var dlg = new FolderBrowserDialog {Description = "Select Directory"};
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                SetStatus(sender, server, "END", "CANCEL");
                return;
            }
            ValidateRestoreFolder(sender, server, dlg.SelectedPath);
        }

        private void tlsRestoreAllFromDefaultFolder_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oInstance)) return;
            var server = _oInstance;
            ValidateRestoreFolder(sender, server, server.pathBackup);
        }

        private void ValidateRestoreFolder(object sender, SqlInstance instance, string folder)
        {
            string[] backupArray;
            try
            {
                backupArray = Directory.GetFiles(folder, "*.bak");
            }
            catch(UnauthorizedAccessException)
            {
                MessageBox.Show("You do not have permission to access " + folder);
                return;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (backupArray.Length == 0)
            {
                MessageBox.Show(folder + " does not contain backups");
                return;
            }

            var size = backupArray.Select(f => new FileInfo(f)).Select(file => file.Length).Sum();
            var message = new StringBuilder();
            message.Append("Number of backups: " + backupArray.Length + "\n");
            foreach (var s in backupArray)
            {
                message.AppendLine(string.Format("{0} - File: {1}\n      Database: {2}",
                    Array.IndexOf(backupArray, s) + 1, s, Path.GetFileNameWithoutExtension(s)));
            }
            message.Append("\nTotal size: " + Math.Round((size/(Math.Pow(1024, 3))), 2) + " GB\n\n");

            var confirmation = MessageBox.Show(string.Format(message + "Do you confirm restoring them all?",
                backupArray.Length, size), "Confirmation", MessageBoxButtons.YesNo);
            if (!confirmation.Equals(DialogResult.Yes))
            {
                SetStatus(sender, instance, "END", "CANCEL");
                return;
            }
            RestoreFromFolder(sender, instance, folder, backupArray);
        }

        private async void RestoreFromFolder(object sender, SqlInstance instance, string folder, string[] backupArray)
        {

            var count = 0;
            var restored = 0;
            var backupsFailed = new List<string>();
            UIOperationStarted(sender, instance, backupArray.Length, sender + " " + folder);
            foreach (var s in backupArray)
            {
                count++;
                var status = String.Format("({0}/{1})", count, backupArray.Length);
                var f = new FileInfo(s);
                var dbname = Path.GetFileNameWithoutExtension(s);
                if (dbname == null) break;
                if (SqlInstance.systemNames.Any(dbname.Contains) || dbname.StartsWith("ReportServer"))
                {
                    SetStatus(sender, instance, status, "SKIPPED", dbname + " is a system db: skipping");
                    continue;
                }
                var overwrite = false;
                if (instance != null && instance.databasesCollection != null)
                {
                    if (instance.databasesCollection.Any(x => x.Name == dbname))
                    {
                        var dr = MessageBox.Show("Database " + dbname + " exists yet, do you want to overwrite it?", "Confirmation", MessageBoxButtons.YesNoCancel);
                        if (dr == DialogResult.Cancel)
                        {
                            SetStatus(sender, instance, status, "INFO", USER_CANCELED);
                            break;
                        }

                        if (dr == DialogResult.Yes)
                        {
                            SetStatus(sender, instance, status, "INFO", "User chose to overwrite database " + dbname);
                            overwrite = true;
                        }
                        else
                        {
                            SetStatus(sender, instance, status, "INFO", "User chose not to overwrite database " + dbname);
                            Utils.WriteLog("User chose not to overwrite database " + dbname + " from " + f.FullName);
                            continue;
                        }
                    }
                }

                if (!Utils.IsStringValid(dbname))
                {
                    SetStatus(sender, instance, "END", "ERROR", dbname + " is not valid, restore cannot continue");
                    continue;
                }

                if (!overwrite)
                {
                    if (instance != null)
                    {
                        try
                        {
                            instance.CreateDatabaseSync(dbname);
                            //SetStatus(sender, instance, status, "COMPLETED", dbname + " created");
                        }
                        catch (SqlTimeoutException ex)
                        {
                            SetStatus(sender, instance, status, "TIMEOUT", ex.Message);
                            _progressBars[SqlInstance.listServers.IndexOf(instance)].Increment(1);
                            continue;
                        }
                        catch (SqlException ex)
                        {
                            SetStatus(sender, instance, status, "ERROR", ex.Message);
                            _progressBars[SqlInstance.listServers.IndexOf(instance)].Increment(1);
                            continue;
                        }
                        catch (Exception ex)
                        {
                            SetStatus(sender, instance, status, "EXCEPTION", ex.Message);
                            _progressBars[SqlInstance.listServers.IndexOf(instance)].Increment(1);
                            continue;
                        }
                    }
                }

                if (instance == null || instance.databasesCollection == null) return;
                var database = instance.databasesCollection.Find(x => x.Name == dbname);
                database.GetDatabaseProperties();
                var token = GetCancellationToken(SqlInstance.listServers.IndexOf(instance));
                var restore = Task.Run(() => database.RestoreAsync(f.FullName, token));
                try
                {
                    await restore;
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    SetStatus(sender, instance, status, "COMPLETED", database.Name + " restored");
                    restored++; //TODO: drop database if restored unsuccessful (and if !overwrite)  
                }
                catch (OperationCanceledException)
                {
                    SetStatus(sender, instance, status, "CANCEL", USER_CANCELED);
                    break;
                }
                catch (SqlException ex)
                {
                    SetStatus(sender, instance, status, "ERROR", ex.Message);
                }
                catch (Exception ex)
                {
                    SetStatus(sender, instance, status, "EXCEPTION", ex.Message);
                }
                finally
                {
                    _progressBars[SqlInstance.listServers.IndexOf(instance)].Increment(1);
                }
                if (restore.IsFaulted && !overwrite)
                {
                    backupsFailed.Add(database.Name);
                }
            }
            UIOperationClosed(sender, instance, true, String.Format("Restored successfully: {0}/{1}", restored, backupArray.Length));
            // TODO: FIX connection state is connecting
            //if (backupsFailed.Count > 0)
            //{
            //    CleanUp(instance, backupsFailed); 
            //}
        }

        private async void tlsCheckAll_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oInstance)) return;
            var server = _oInstance;

            if (server.databasesCollection.Count == 0)
            {
                var dr = MessageBox.Show(NO_USER_DATABASES, "No user databases", MessageBoxButtons.YesNo);
                if (!dr.Equals(DialogResult.Yes)) return;
                tlsEnableSystemDbs.PerformClick();
                return;
            }
            // I need a copy in case the collection changes during the async operations
            var listDatabases = new List<SqlDatabase>(server.databasesCollection);
            var checkedOk = 0;

            UIOperationStarted(sender, server, listDatabases.Count);
            foreach (var database in listDatabases)
            {
                var status = String.Format("({0}/{1})", listDatabases.IndexOf(database) + 1, listDatabases.Count);
                if (database.Status != "ONLINE")
                {
                    SetStatus(sender, database, status, "SKIPPED", WRONG_DATABASE_STATE + string.Format("({0})", database.Status));
                    continue;
                }
                var token = GetCancellationToken(SqlInstance.listServers.IndexOf(server));
                var db = database;
                var check = Task.Run(() => db.Check(token));
                try
                {
                    await check;
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    SetStatus(sender, database, status, "COMPLETED", database.Name + " checked OK");
                    checkedOk++;
                }

                catch (OperationCanceledException)
                {
                    SetStatus(sender, database, status, "CANCEL");
                    break;
                }
                catch (SqlException ex)
                {
                    SetStatus(sender, database, status, "ERROR", ex.Message);
                }
                catch (Exception ex)
                {
                    SetStatus(sender, database, status, "EXCEPTION", ex.Message);
                }
                finally
                {
                    _progressBars[SqlInstance.listServers.IndexOf(server)].Increment(1);
                    dgvDatabases.Refresh();
                }
            }
            UIOperationClosed(sender, server, true, String.Format("Checked with no errors: {0}/{1}", checkedOk, listDatabases.Count));
        }

        private void tlsBackupAll_ButtonClick(object sender, EventArgs e)
        {
            tlsServer_BackupAll(sender, null);
        }

        private void tlsBackupAllWithCompression_Click(object sender, EventArgs e)
        {
            var arg = new EventArgsFactory.BackupEventArgs {compress = true};
            tlsServer_BackupAll(sender, arg);
        }

        private void tlsBackupAllWithOverwrite_Click(object sender, EventArgs e)
        {
            var arg = new EventArgsFactory.BackupEventArgs {format = true};
            tlsServer_BackupAll(sender, arg);
        }

        private void tlsBackupAllWithCompressionOverwrite_Click(object sender, EventArgs e)
        {
            var arg = new EventArgsFactory.BackupEventArgs {compress = true, format = true};
            tlsServer_BackupAll(sender, arg);
        }

        private void tlsDatabase_Online_Click(object sender, EventArgs e)
        {
            AlterDatabase(sender, "SET ONLINE");
        }

        private void mnuDatabase_Online_Click(object sender, EventArgs e)
        {
            tlsDatabase_Online_Click(sender, null);
        }

        private void tlsDatabase_Offline_Click(object sender, EventArgs e)
        {
            AlterDatabase(sender, "SET OFFLINE");
        }

        private void mnuDatabase_Offline_Click(object sender, EventArgs e)
        {
            tlsDatabase_Offline_Click(sender, null);
        }

        private void tlsDatabase_Single_Click(object sender, EventArgs e)
        {
            AlterDatabase(sender, "SET SINGLE_USER");
        }

        private void mnuDatabase_SingleUser_Click(object sender, EventArgs e)
        {
            tlsDatabase_Single_Click(sender, null);
        }

        private void tlsDatabase_Multi_Click(object sender, EventArgs e)
        {
            AlterDatabase(sender, "SET MULTI_USER");
        }

        private void mnuDatabase_MultiUser_Click(object sender, EventArgs e)
        {
            tlsDatabase_Multi_Click(sender, null);
        }

        private async void tlsDatabase_Rename_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oDatabase)) return;
            var database = _oDatabase;
            var newdbname = txtDatabase_Rename.Text;

            if (txtDatabase_Rename.Text.Length == 0)
            {
                MessageBox.Show("Please enter the new name for the database.");
                txtDatabase_Rename.Focus();
                return;
            }
            if (!Utils.IsStringValid(newdbname))
            {
                MessageBox.Show(newdbname + " is not a valid name.");
                txtDatabase_Rename.Focus();
                return;
            }
            if (_oInstance.databasesCollection.Any(x => x.Name == newdbname))
            {
                MessageBox.Show(newdbname + " esists yet on " + _oInstance);
                txtDatabase_Rename.Focus();
                return;
            }
            var sqlParams = new List<string[]> {new[] {"@newname", newdbname}};

            UIOperationStarted(sender, database.Parent, 0);
            try
            {
                var token = GetCancellationToken(_oServerIndex);
                await database.Alter("MODIFY NAME = [@newname] ", token, 5, sqlParams);
                SetStatus(sender, database, "END", "COMPLETED", string.Format("{0} renamed to {1}.", database.Name, newdbname));
                txtDatabase_Rename.Clear();
            }
            catch (Exception ex)
            {
                SetStatus(sender, database, "END", "ERROR", ex.Message);
            }
            UIOperationClosed(sender, database.Parent);
        }

        private void mnuDatabase_Rename_Click(object sender, EventArgs e)
        {
            tlsDatabase_Rename_Click(sender, null);
        }

        private void mnuDatabase_Restore_Click(object sender, EventArgs e)
        {
            tlsDatabase_Restore_Click(sender, null);
        }

        private void tlsDatabase_Backup_ButtonClick(object sender, EventArgs e)
        {
            Database_Backup(sender, null);
        }

        private void tlsDatabase_BackupWithCompression_Click(object sender, EventArgs e)
        {
            var arg = new EventArgsFactory.BackupEventArgs {compress = true};
            Database_Backup(sender, arg);
        }

        private void tlsDatabase_BackupWithOverwrite_Click(object sender, EventArgs e)
        {
            var arg = new EventArgsFactory.BackupEventArgs {format = true};
            Database_Backup(sender, arg);
        }

        private void tlsDatabase_BackupWithCompressionOverwrite_Click(object sender, EventArgs e)
        {
            var arg = new EventArgsFactory.BackupEventArgs {compress = true, format = true};
            Database_Backup(sender, arg);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oFrmAbout = new frmAbout();
            oFrmAbout.ShowDialog(this);
            oFrmAbout.Dispose();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.SerializeBinary(SqlInstance.listServers);
            Utils.WriteLog("---------- Program Closed ----------");
        }

        private void tlsEnableSystemDbs_Click(object sender, EventArgs e)
        {
            var server = _oInstance;
            if (server.isBusy)
            {
                MessageBox.Show("At least one instance " + WARNING_IS_BUSY);
                return;
            }
            if (tlsEnableSystemDbs.Checked)
            {
                tlsEnableSystemDbs.BackColor = Color.Yellow; //TODO: doesn't underline
                tlsEnableSystemDbs.ToolTipText = "Disable system databases";
            }
            else
            {
                tlsEnableSystemDbs.BackColor = Color.Transparent;
                tlsEnableSystemDbs.ToolTipText = "Enable system databases";
            }

            if (lstMain_Servers.SelectedItem == null || server.isOnline != true) return;
            lstMain_Servers.SetSelected(lstMain_Servers.SelectedIndex, true);

            // Refresh properties
            _oInstance.totalLogSize = 0;
            _oInstance.totalDataSize = 0;
            foreach (var database in _oInstance.databasesCollection)
            {
                if (database.Status != "OFFLINE") database.GetDatabaseProperties();
                _oInstance.totalDataSize += (database.RowsSize/1024);
                _oInstance.totalLogSize += (database.LogSize/1024);
            }
        }

        private void tlsServer_VerifyBackupsCustomFolder_Click(object sender, EventArgs e)
        {
            if (!CanContinue(_oInstance)) return;
            var server = _oInstance;

            var dlg = new FolderBrowserDialog {Description = "Select Directory"};
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                SetStatus(sender, server, "END", "CANCEL");
                return;
            }
            var backupArray = Directory.GetFiles(dlg.SelectedPath, "*.bak");
            if (backupArray.Length == 0)
            {
                MessageBox.Show(dlg.SelectedPath + " does not contain backups.");
                return;
            }
            VerifyCollection(sender, server, backupArray);
        }

        private async void VerifyCollection(object sender, SqlInstance instance, string[] folder)
        {
            var checkedOk = 0;
            UIOperationStarted(sender, instance, folder.Length);
            foreach (var s in folder)
            {
                var status = String.Format("({0}/{1})", Array.IndexOf(folder, s) + 1, folder.Length);
                var f = new FileInfo(s);
                var token = GetCancellationToken(SqlInstance.listServers.IndexOf(instance));
                var verify = Task.Run(() => SqlDatabase.VerifyBackup(instance, f.FullName, token));

                try
                {
                    await verify;
                    SetStatus(sender, instance, status, "COMPLETED", f.FullName + " is valid");
                    checkedOk++;
                }
                catch (OperationCanceledException)
                {
                    SetStatus(sender, _oDatabase, "END", "CANCEL");
                    break;
                }
                catch (SqlException ex)
                {
                    SetStatus(sender, _oDatabase, "END", "ERROR", ex.Message);
                }
                catch (Exception ex)
                {
                    SetStatus(sender, _oDatabase, "END", "EXCEPTION", ex.Message);
                }
                finally
                {
                    _progressBars[SqlInstance.listServers.IndexOf(instance)].Increment(1);
                }
            }
            UIOperationClosed(sender, instance, true, String.Format("Verified successfully: {0}/{1}", checkedOk, folder.Length));
        }

        private void mnuVerifyBakCollection_Click(object sender, EventArgs e)
        {
            tlsServer_VerifyBackupsCustomFolder_Click(sender, null);
        }

        private void ProcessImages(SqlInstance s)
        {
            var index = SqlInstance.listServers.IndexOf(s);
            if (s.isBusy)
            {
                _icons[index].Image = Resources.StatusAnnotations_Play_16xLG_color; _icons[index].Visible = true;
            }
            else
                switch (s.isOnline)
                {
                    case true:
                        _icons[index].Image = Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
                        _icons[index].Visible = true;
                        break;
                    case false:
                        _icons[index].Image = Resources.StatusAnnotations_Critical_16xLG_color;
                        _icons[index].Visible = true;
                        break;
                    case null:
                        _icons[index].Image = Resources.StatusAnnotations_Help_and_inconclusive_16xLG_color;
                        _icons[index].Visible = true;
                        break;
                }
        }

        private void ProcessImages()
        {
            for (var i = 0; i < 5; i++)
            {
                _icons[i].Visible = false;
                _icons[i].ImageLocation = null;
            }
            foreach (var s in SqlInstance.listServers)
            {
                var index = SqlInstance.listServers.IndexOf(s);
                if (s.isBusy)
                {
                    _icons[index].Image = Resources.StatusAnnotations_Play_16xLG_color;
                    _icons[index].Visible = true;
                }
                else
                    switch (s.isOnline)
                    {
                        case true:
                            _icons[index].Image = Resources.StatusAnnotations_Complete_and_ok_16xLG_color;
                            _icons[index].Visible = true;
                            break;
                        case false:
                            _icons[index].Image = Resources.StatusAnnotations_Critical_16xLG_color;
                            _icons[index].Visible = true;
                            break;
                        case null:
                            _icons[index].Image = Resources.StatusAnnotations_Help_and_inconclusive_16xLG_color;
                            _icons[index].Visible = true;
                            break;
                    }
            }
        }

        private void btnCancel0_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSources[0] == null) MessageBox.Show(ERROR_CANCEL);
            else _cancellationTokenSources[0].Cancel();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSources[1] == null) MessageBox.Show(ERROR_CANCEL);
            else _cancellationTokenSources[1].Cancel();
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSources[2] == null) MessageBox.Show(ERROR_CANCEL);
            else _cancellationTokenSources[2].Cancel();

        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSources[3] == null) MessageBox.Show(ERROR_CANCEL);
            else _cancellationTokenSources[3].Cancel();
        }

        private void btnCancel4_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSources[4] == null) MessageBox.Show(ERROR_CANCEL);
            else _cancellationTokenSources[4].Cancel();
        }

        private void lstMain_Servers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _oServerIndex = lstMain_Servers.SelectedIndex;
        }

        private void tlsClearLog_Click(object sender, EventArgs e)
        {
            lsv_log.Items.Clear();
            tlsClearLog.Enabled = false;
        }

        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("ARE YOU REALLY SURE you want to delete all user databases?", "Delete All Confirmation", MessageBoxButtons.YesNo);
            if (!confirmation.Equals(DialogResult.Yes))
            {
                SetStatus(sender, _oInstance, "END", "CANCEL");
            }
            else
            {
                confirmation = MessageBox.Show("Pressing YES you will delete ALL USER DATABASES.", "Delete All Confirmation", MessageBoxButtons.YesNo);
                if (!confirmation.Equals(DialogResult.Yes))
                {
                    SetStatus(sender, _oInstance, "END", "CANCEL");
                }
                else
                {
                    var instance = _oInstance;
                    var listDatabases = new List<SqlDatabase>(instance.databasesCollection);
                    var deleted = 0;

                    UIOperationStarted(sender, instance, listDatabases.Count);
                    foreach (var database in listDatabases)
                    {
                        var status = String.Format("({0}/{1})", listDatabases.IndexOf(database) + 1, listDatabases.Count);
                        if (database is SqlSystemDatabase)
                        {
                            SetStatus(sender, database, status, "SKIPPED", CANCEL_SYSDB);
                            continue;
                        }
                        if (database.Status != "ONLINE")
                        {
                            SetStatus(sender, database, status, "SKIPPED", WRONG_DATABASE_STATE + string.Format("({0})", database.Status));
                            continue;
                        }
                        if (database.Name.StartsWith("ReportServer"))
                        {
                            SetStatus(sender, database, status, "SKIPPED", "Reporting Service databases must be deleted individually");
                            continue;
                        }
                        
                        var token = GetCancellationToken(SqlInstance.listServers.IndexOf(instance));
                        var db = database;
                        var drop = Task.Run(() => instance.Drop(db.Name));
                        try
                        {
                            await drop;
                            if (token.IsCancellationRequested)
                            {
                                token.ThrowIfCancellationRequested();
                            }
                            SetStatus(sender, database, status, "COMPLETED", database.Name + " dropped");
                            deleted++;
                        }

                        catch (OperationCanceledException)
                        {
                            SetStatus(sender, database, status, "CANCEL");
                            break;
                        }
                        catch (SqlException ex)
                        {
                            SetStatus(sender, database, status, "ERROR", ex.Message);
                        }
                        catch (Exception ex)
                        {
                            SetStatus(sender, database, status, "EXCEPTION", ex.Message);
                        }
                        finally
                        {
                            _progressBars[SqlInstance.listServers.IndexOf(instance)].Increment(1);
                            dgvDatabases.Refresh();
                        }
                    }
                    UIOperationClosed(sender, instance, true, String.Format("Databases dropped: {0}/{1}", deleted, listDatabases.Count));
        
                }
            }
        }

        private void mnuTools_ClearLog_Click(object sender, EventArgs e)
        {
            tlsClearLog.PerformClick();
        }

        private void mnuTools_OpenBackupFolder_Click(object sender, EventArgs e)
        {
            tlsOpenBackupFolder.PerformClick();
        }

        private void tlsClearLog_EnabledChanged(object sender, EventArgs e)
        {
            mnuTools_ClearLog.Enabled = tlsClearLog.Enabled;
        }

        private void tlsOpenBackupFolder_EnabledChanged(object sender, EventArgs e)
        {
            mnuTools_OpenBackupFolder.Enabled = tlsOpenBackupFolder.Enabled;
        }

        private void prgServer0_VisibleChanged(object sender, EventArgs e)
        {
            btnCancel0.Visible = prgServer0.Visible;
            ProcessImages((SqlInstance) lstMain_Servers.Items[0]);
        }

        private void prgServer1_VisibleChanged(object sender, EventArgs e)
        {
            btnCancel1.Visible = prgServer1.Visible;
            ProcessImages((SqlInstance) lstMain_Servers.Items[1]);
        }

        private void prgServer2_VisibleChanged(object sender, EventArgs e)
        {
            btnCancel2.Visible = prgServer2.Visible;
            ProcessImages((SqlInstance) lstMain_Servers.Items[2]);
        }

        private void prgServer3_VisibleChanged(object sender, EventArgs e)
        {
            btnCancel3.Visible = prgServer3.Visible;
            ProcessImages((SqlInstance) lstMain_Servers.Items[3]);
        }

        private void prgServer4_VisibleChanged(object sender, EventArgs e)
        {
            btnCancel4.Visible = prgServer4.Visible;
            ProcessImages((SqlInstance) lstMain_Servers.Items[4]);
        }

        private void tlsDatabase_Drop_EnabledChanged(object sender, EventArgs e)
        {
            mnuDatabase_Drop.Enabled = tlsDatabase_Drop.Enabled;
        }

        private void tlsDatabase_Single_EnabledChanged(object sender, EventArgs e)
        {
            mnuDatabase_SingleUser.Enabled = tlsDatabase_Single.Enabled;
        }

        private void tlsDatabase_Multi_EnabledChanged(object sender, EventArgs e)
        {
            mnuDatabase_MultiUser.Enabled = tlsDatabase_Multi.Enabled;
        }

        private void tlsDatabase_Online_EnabledChanged(object sender, EventArgs e)
        {
            mnuDatabase_Online.Enabled = tlsDatabase_Online.Enabled;
        }

        private void tlsDatabase_Offline_EnabledChanged(object sender, EventArgs e)
        {
            mnuDatabase_Offline.Enabled = tlsDatabase_Offline.Enabled;
        }

        private void tlsDatabase_BackupWith_EnabledChanged(object sender, EventArgs e)
        {
            mnuDatabase_BackupWith.Enabled = tlsDatabase_BackupWith.Enabled;
        }

        private void Main_Activated(object sender, EventArgs e)
        {
            lstMain_Servers.Items.Clear();
            ButtonDisable();
            prpServers.SelectedObject = null;
            foreach (var v in _icons)
            {
                v.Enabled = false;
            }
            ProcessImages();

            foreach (var server in SqlInstance.listServers)
            {
                if (!lstMain_Servers.Items.Contains(server))
                {
                    lstMain_Servers.Items.Add(server);
                }
            }
            if(_oServerIndex != -1 && (lstMain_Servers.Items.Count > _oServerIndex + 1)) lstMain_Servers.SetSelected(_oServerIndex, true);
        }


        private async void lstMain_Servers_SelectedValueChanged(object sender, EventArgs e)
        {
            var server = (SqlInstance) lstMain_Servers.SelectedItem; // need a copy to handle another instance while this is connecting
            _oInstance = server;
            Debug.Assert(server != null);
            var serverIndex = lstMain_Servers.SelectedIndex;
            if (server.isBusy == true)
            {
                prpServers.SelectedObject = server;
                _databaseCollectionBindingList = new BindingList<SqlDatabase>(server.databasesCollection);
                dgvDatabases.DataSource = _databaseCollectionBindingList;
            }

            if (server.isBusy == false && server.isConnecting == false)
            {
                prpServers.SelectedObject = null;
                ButtonDisable();
                dgvDatabases.DataSource = null;
                try
                {
                    UIconnectingStarted(server);
                    var token = GetCancellationToken(serverIndex);
                    await server.TestConnection(token);
                    if (token.IsCancellationRequested)
                    {
                        throw new OperationCanceledException();
                    }

                    if (server.isOnline != false)
                    {
                        prpServers.SelectedObject = server;
                        server.GetPaths();
                        server.GetProperties();
                        server.GetDbList(tlsEnableSystemDbs.Checked);

                        // reset size values
                        server.totalDataSize = 0;
                        server.totalLogSize = 0;

                        foreach (var database in server.databasesCollection)
                        {
                            if (database.Status == "ONLINE") database.GetDatabaseProperties();
                            server.totalDataSize += database.RowsSize/1024;
                            server.totalLogSize += database.LogSize/1024;
                        }
                        _databaseCollectionBindingList = new BindingList<SqlDatabase>(server.databasesCollection);
                        dgvDatabases.DataSource = _databaseCollectionBindingList;

                        server.totalDataSize = Math.Round(server.totalDataSize, 2);
                        server.totalLogSize = Math.Round(server.totalLogSize, 2);
                    }
                }
                catch (OperationCanceledException ex)
                {
                    SetStatus("CONNECTION", server, "END", "CANCEL", ex.Message);
                }
                catch (Exception ex)
                {
                    SetStatus("CONNECTION", server, "END", "ERROR", ex.Message);
                }
                UIconnectingEnded(server);

            }
            if (lstMain_Servers.Items.Count <= 0) return;
            try
            {
                ButtonDisable();
                EnableButtons(server, null);
            }
            catch
            {
                // debug

            }
        }

        private void mnuServer_RestoreAllDefault_Click(object sender, EventArgs e)
        {
            tlsRestoreAllFromDefaultFolder.PerformClick();
        }

        private void tlsRestoreAllFromDefaultFolder_EnabledChanged(object sender, EventArgs e)
        {
            mnuServer_RestoreAllDefault.Enabled = tlsRestoreAllFromDefaultFolder.Enabled;
        }

        private void dgvDatabases_Click(object sender, EventArgs e)
        {
            dgvDatabases.Refresh();
            if (_databaseCollectionBindingList == null || _databaseCollectionBindingList.Count == 0)
            {
                return;
            }
            _oDatabaseIndex = dgvDatabases.CurrentCell.RowIndex;
            _oDatabase = _oInstance.databasesCollection[_oDatabaseIndex];
            Utils.WriteLog(string.Format("Connected to {0}@{1}", _oDatabase.Name, lstMain_Servers.SelectedItem));
            ButtonDisable();
            EnableButtons(_oDatabase.Parent, _oDatabase);
        }

        private void dgvDatabases_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvDatabases.ClearSelection();
        }

        private void dgvDatabases_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            switch (dgvDatabases.Columns[e.ColumnIndex].Name)
            {        
                case "Status":
                    switch ((string) e.Value)
                    {
                        case "ONLINE":
                            e.CellStyle.BackColor = Color.PaleGreen;
                            break;
                        case "OFFLINE":
                            e.CellStyle.BackColor = Color.LightCoral;
                            break;
                        default:
                            e.CellStyle.BackColor = Color.Violet;
                            break;
                    }
                    break;
                case "Access":
                {
                    if ((string) e.Value == "multi")
                    {
                        e.CellStyle.BackColor = Color.PaleTurquoise;
                    }
                    else if ((string) e.Value == "single")
                    {
                        e.CellStyle.BackColor = Color.Silver;
                    }
                }
                    break;
                case "Name":
                    if (SqlInstance.systemNames.Contains(e.Value))
                    {
                        e.CellStyle.BackColor = Color.BurlyWood;
                    }
                    else if (e.Value.ToString().StartsWith("ReportServer"))
                    {
                        e.CellStyle.BackColor = Color.NavajoWhite;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.PapayaWhip;
                    }
                    break;
            }
        }

        private void tlsAllOnline_Click(object sender, EventArgs e)
        {
            SwitchAll(sender, "ONLINE");
        }

        private void tlsAllOffline_Click(object sender, EventArgs e)
        {
            SwitchAll(sender, "OFFLINE");
        }

        private void tlsAllMulti_Click(object sender, EventArgs e)
        {
            SwitchAll(sender, "MULTI_USER");
        }

        private void tlsAllSingle_Click(object sender, EventArgs e)
        {
            SwitchAll(sender, "SINGLE_USER");
        }

        private async void SwitchAll(object sender, string mode)
        {
            if (!CanContinue(_oInstance)) return;
            var server = _oInstance;

            if (server.databasesCollection.Count == 0)
            {
                MessageBox.Show(NO_USER_DATABASES, "No user databases");
                return;
            }
            // I need a copy in case the collection changes during the async operations
            var listDatabases = new List<SqlDatabase>(server.databasesCollection);
            var switched = 0;

            UIOperationStarted(sender, server, listDatabases.Count);
            foreach (var database in listDatabases)
            {
                var status = String.Format("({0}/{1})", listDatabases.IndexOf(database) + 1, listDatabases.Count);
                if (database is SqlSystemDatabase)
                {
                    SetStatus(sender, database, status, "SKIPPED", CANCEL_SYSDB);
                    continue;
                }

                if (mode == "OFFLINE")
                    if (database.Status == "OFFLINE")
                    {
                        SetStatus(sender, database, status, "SKIPPED", WRONG_DATABASE_STATE + string.Format("({0})", database.Status));
                        continue;
                    }
                if (mode == "ONLINE")
                    if (database.Status == "ONLINE")
                    {
                        SetStatus(sender, database, status, "SKIPPED", WRONG_DATABASE_STATE + string.Format("({0})", database.Status));
                        continue;
                    }
                if (mode == "MULTI_USER")
                    if (database.Access == "multi")
                    {
                        SetStatus(sender, database, status, "SKIPPED", WRONG_DATABASE_STATE + string.Format("({0})", database.Access));
                        continue;
                    }
                if (mode == "SINGLE_USER")
                {
                    if (database.Status == "single")
                    {
                        SetStatus(sender, database, status, "SKIPPED", WRONG_DATABASE_STATE + string.Format("({0})", database.Access));
                        continue;
                    }
                }
                var token = GetCancellationToken(SqlInstance.listServers.IndexOf(server));
                var db = database;
                var switchAll = Task.Run(() => db.Alter("SET " + mode, token, 10, null, true));
                try
                {
                    await switchAll;
                    if (token.IsCancellationRequested)
                    {
                        token.ThrowIfCancellationRequested();
                    }
                    if (switchAll.Result)
                    {
                        SetStatus(sender, database, status, "COMPLETED", database.Name + " set " + mode);
                        switched++;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (OperationCanceledException)
                {
                    SetStatus(sender, database, status, "CANCEL");
                    break;
                }
                catch (SqlException ex)
                {
                    SetStatus(sender, database, status, "ERROR", ex.Message);
                }
                //catch (Exception ex)
                //{
                //    SetStatus(sender, database, status, "EXCEPTION", ex.Message);
                //}
                finally
                {
                    _progressBars[SqlInstance.listServers.IndexOf(server)].Increment(1);
                    dgvDatabases.Refresh();
                }
            }
            UIOperationClosed(sender, server, true, String.Format("Switched {0}: {1}/{2}", mode, switched, listDatabases.Count));
        }


        private async void tlsDatabase_KillConnections_Click(object sender, EventArgs e)
        {
            if (_oDatabase == null) return;
            var database = _oDatabase;

            
            UIOperationStarted(sender, database.Parent, 0, "Killing connections to database: " + database.Name);
            try
            {
                await _oInstance.KillAllConnections(database.Name);
                SetStatus(sender, database, "END", "COMPLETED", database.Name + " has no open connections now");
            }
            catch (Exception ex)
            {
                SetStatus(sender, database, "END", "ERROR", ex.Message);
            }         
            UIOperationClosed(sender, database.Parent);
        }

        private void lstMain_Servers_MouseHover(object sender, EventArgs e)
        {
            if (lstMain_Servers.Items.Count == 0)
            {
                lstMain_Servers.Text = "(no server configured)";
            }

        }

        }
    }







