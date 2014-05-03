using System.Windows.Forms;

namespace ScriptQL
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.editConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServer_DiscoverDetached = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVerifyBakCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServer_RestoreAllDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServer_RestoreAllCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServer_backup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServer_backupWith = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServer_backupWithCompress = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServer_backupWithInit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServer_backupWithCompressAndInit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServer_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_Create = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_Drop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_Check = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_Attach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_Detach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_Offline = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_Online = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_SingleUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_MultiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_Restore = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_Backup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_BackupWith = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_BackupWithCompress = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_BackupWithOverwrite = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatabase_BackupWithCompressOverwrite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools_ClearLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools_OpenBackupFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMain_Tables = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxMain = new System.Windows.Forms.ToolStrip();
            this.tlsEditConfig = new System.Windows.Forms.ToolStripButton();
            this.tlsEnableSystemDbs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsDiscoverDetached = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsServer_VerifyBackupsCustomFolder = new System.Windows.Forms.ToolStripButton();
            this.tlsServer_VerifyBackupsDefaultFolder = new System.Windows.Forms.ToolStripButton();
            this.tlsRestoreAllFromCustomFolder = new System.Windows.Forms.ToolStripButton();
            this.tlsRestoreAllFromDefaultFolder = new System.Windows.Forms.ToolStripButton();
            this.tlsBackupAll = new System.Windows.Forms.ToolStripSplitButton();
            this.tlsBackupAllWithCompression = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsBackupAllWithOverwrite = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsBackupAllWithCompressionOverwrite = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsCheckAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsOpenBackupFolder = new System.Windows.Forms.ToolStripButton();
            this.tlsClearLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsAllOnline = new System.Windows.Forms.ToolStripButton();
            this.tlsAllOffline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsAllMulti = new System.Windows.Forms.ToolStripButton();
            this.tlsAllSingle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.grpMainServers = new System.Windows.Forms.GroupBox();
            this.tblServers = new System.Windows.Forms.TableLayoutPanel();
            this.tblPictures = new System.Windows.Forms.TableLayoutPanel();
            this.pctServer4 = new System.Windows.Forms.PictureBox();
            this.pctServer3 = new System.Windows.Forms.PictureBox();
            this.pctServer2 = new System.Windows.Forms.PictureBox();
            this.pctServer1 = new System.Windows.Forms.PictureBox();
            this.pctServer0 = new System.Windows.Forms.PictureBox();
            this.tblCancel = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel4 = new System.Windows.Forms.Button();
            this.btnCancel0 = new System.Windows.Forms.Button();
            this.btnCancel3 = new System.Windows.Forms.Button();
            this.btnCancel1 = new System.Windows.Forms.Button();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.lstMain_Servers = new System.Windows.Forms.ListBox();
            this.tblProgressBars = new System.Windows.Forms.TableLayoutPanel();
            this.prgServer0 = new System.Windows.Forms.ProgressBar();
            this.prgServer1 = new System.Windows.Forms.ProgressBar();
            this.prgServer4 = new System.Windows.Forms.ProgressBar();
            this.prgServer2 = new System.Windows.Forms.ProgressBar();
            this.prgServer3 = new System.Windows.Forms.ProgressBar();
            this.prpServers = new System.Windows.Forms.PropertyGrid();
            this.tbxDatabase = new System.Windows.Forms.ToolStrip();
            this.tlsDatabase_Create = new System.Windows.Forms.ToolStripButton();
            this.tlsDatabase_Drop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsDatabase_Check = new System.Windows.Forms.ToolStripButton();
            this.tlsDatabase_KillConnections = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsDatabase_Attach = new System.Windows.Forms.ToolStripButton();
            this.tlsDatabase_Detach = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsDatabase_Online = new System.Windows.Forms.ToolStripButton();
            this.tlsDatabase_Offline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsDatabase_Multi = new System.Windows.Forms.ToolStripButton();
            this.tlsDatabase_Single = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsDatabase_Restore = new System.Windows.Forms.ToolStripButton();
            this.tlsDatabase_BackupWith = new System.Windows.Forms.ToolStripSplitButton();
            this.tlsDatabase_BackupWithCompression = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsDatabase_BackupWithOverwrite = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsDatabase_BackupWithCompressionOverwrite = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsDatabase_Rename = new System.Windows.Forms.ToolStripButton();
            this.txtDatabase_Rename = new System.Windows.Forms.ToolStripTextBox();
            this.grpMainDatabases = new System.Windows.Forms.GroupBox();
            this.dgvDatabases = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tooltipMainInfo = new System.Windows.Forms.ToolTip(this.components);
            this.lsv_log = new System.Windows.Forms.ListView();
            this.log_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.log_source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.log_progress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.log_command = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.log_state = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.log_message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitSubMain = new System.Windows.Forms.SplitContainer();
            this.panelToolbarServer = new System.Windows.Forms.SplitContainer();
            this.splitServerControls1 = new System.Windows.Forms.SplitContainer();
            this.panelToolbarDatabase = new System.Windows.Forms.SplitContainer();
            this.tabTables = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSchema = new System.Windows.Forms.Label();
            this.txtSearchTimeout = new System.Windows.Forms.TextBox();
            this.dgvMain_Rows = new System.Windows.Forms.DataGridView();
            this.cmbSchema = new System.Windows.Forms.ComboBox();
            this.btnTableRefresh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRecordsNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTable = new System.Windows.Forms.ComboBox();
            this.lblRecordNumber = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rdbSortDESC = new System.Windows.Forms.RadioButton();
            this.cmbColumns = new System.Windows.Forms.ComboBox();
            this.rdbSortASC = new System.Windows.Forms.RadioButton();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbView = new System.Windows.Forms.ComboBox();
            this.tabServer = new System.Windows.Forms.TabPage();
            this.tabGroup = new System.Windows.Forms.TabControl();
            this.lblTablesStatus = new System.Windows.Forms.Label();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.tbxMain.SuspendLayout();
            this.grpMainServers.SuspendLayout();
            this.tblServers.SuspendLayout();
            this.tblPictures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctServer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctServer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctServer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctServer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctServer0)).BeginInit();
            this.tblCancel.SuspendLayout();
            this.tblProgressBars.SuspendLayout();
            this.tbxDatabase.SuspendLayout();
            this.grpMainDatabases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabases)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitSubMain)).BeginInit();
            this.splitSubMain.Panel1.SuspendLayout();
            this.splitSubMain.Panel2.SuspendLayout();
            this.splitSubMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelToolbarServer)).BeginInit();
            this.panelToolbarServer.Panel1.SuspendLayout();
            this.panelToolbarServer.Panel2.SuspendLayout();
            this.panelToolbarServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitServerControls1)).BeginInit();
            this.splitServerControls1.Panel1.SuspendLayout();
            this.splitServerControls1.Panel2.SuspendLayout();
            this.splitServerControls1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelToolbarDatabase)).BeginInit();
            this.panelToolbarDatabase.Panel1.SuspendLayout();
            this.panelToolbarDatabase.Panel2.SuspendLayout();
            this.panelToolbarDatabase.SuspendLayout();
            this.tabTables.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Rows)).BeginInit();
            this.tabServer.SuspendLayout();
            this.tabGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuServer,
            this.mnuDatabase,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1309, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editConfigToolStripMenuItem,
            this.openLogToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(62, 20);
            this.mnuFile.Text = "Manage";
            // 
            // editConfigToolStripMenuItem
            // 
            this.editConfigToolStripMenuItem.Image = global::ScriptQL.Properties.Resources.settings;
            this.editConfigToolStripMenuItem.Name = "editConfigToolStripMenuItem";
            this.editConfigToolStripMenuItem.ShortcutKeyDisplayString = "CTRL+E";
            this.editConfigToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.editConfigToolStripMenuItem.Text = "Edit Config....";
            this.editConfigToolStripMenuItem.ToolTipText = "Add or remove servers";
            this.editConfigToolStripMenuItem.Click += new System.EventHandler(this.editConfigToolStripMenuItem_Click);
            // 
            // openLogToolStripMenuItem
            // 
            this.openLogToolStripMenuItem.Image = global::ScriptQL.Properties.Resources.TextFile;
            this.openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            this.openLogToolStripMenuItem.ShortcutKeyDisplayString = "CTRL+L";
            this.openLogToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.openLogToolStripMenuItem.Text = "Open Log";
            this.openLogToolStripMenuItem.ToolTipText = "Open the system log";
            this.openLogToolStripMenuItem.Click += new System.EventHandler(this.openLogToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Image = global::ScriptQL.Properties.Resources.quit;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeyDisplayString = "ESC";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.ToolTipText = "Close the program";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // mnuServer
            // 
            this.mnuServer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServer_DiscoverDetached,
            this.mnuVerifyBakCollection,
            this.mnuServer_RestoreAllDefault,
            this.mnuServer_RestoreAllCustom,
            this.mnuServer_backup,
            this.mnuServer_backupWith,
            this.mnuServer_Check});
            this.mnuServer.Name = "mnuServer";
            this.mnuServer.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.mnuServer.Size = new System.Drawing.Size(51, 20);
            this.mnuServer.Text = "Server";
            // 
            // mnuServer_DiscoverDetached
            // 
            this.mnuServer_DiscoverDetached.Enabled = false;
            this.mnuServer_DiscoverDetached.Image = global::ScriptQL.Properties.Resources.search;
            this.mnuServer_DiscoverDetached.Name = "mnuServer_DiscoverDetached";
            this.mnuServer_DiscoverDetached.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.mnuServer_DiscoverDetached.Size = new System.Drawing.Size(336, 22);
            this.mnuServer_DiscoverDetached.Text = "Discover detached databases...";
            this.mnuServer_DiscoverDetached.ToolTipText = "Discover detached databases...";
            this.mnuServer_DiscoverDetached.Click += new System.EventHandler(this.mnuServer_DiscoverDetached_Click);
            // 
            // mnuVerifyBakCollection
            // 
            this.mnuVerifyBakCollection.Enabled = false;
            this.mnuVerifyBakCollection.Image = global::ScriptQL.Properties.Resources.verify;
            this.mnuVerifyBakCollection.Name = "mnuVerifyBakCollection";
            this.mnuVerifyBakCollection.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.mnuVerifyBakCollection.Size = new System.Drawing.Size(336, 22);
            this.mnuVerifyBakCollection.Text = "Verify bak collection...";
            this.mnuVerifyBakCollection.ToolTipText = "Verify backups in a folder";
            this.mnuVerifyBakCollection.Click += new System.EventHandler(this.mnuVerifyBakCollection_Click);
            // 
            // mnuServer_RestoreAllDefault
            // 
            this.mnuServer_RestoreAllDefault.Enabled = false;
            this.mnuServer_RestoreAllDefault.Image = global::ScriptQL.Properties.Resources.undo_16;
            this.mnuServer_RestoreAllDefault.Name = "mnuServer_RestoreAllDefault";
            this.mnuServer_RestoreAllDefault.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.mnuServer_RestoreAllDefault.Size = new System.Drawing.Size(336, 22);
            this.mnuServer_RestoreAllDefault.Text = "Restore backups from default folder";
            this.mnuServer_RestoreAllDefault.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.mnuServer_RestoreAllDefault.ToolTipText = "Restore all .bak files from the default backup folder";
            this.mnuServer_RestoreAllDefault.Click += new System.EventHandler(this.mnuServer_RestoreAllDefault_Click);
            // 
            // mnuServer_RestoreAllCustom
            // 
            this.mnuServer_RestoreAllCustom.Enabled = false;
            this.mnuServer_RestoreAllCustom.Image = global::ScriptQL.Properties.Resources.restorefromfolder;
            this.mnuServer_RestoreAllCustom.Name = "mnuServer_RestoreAllCustom";
            this.mnuServer_RestoreAllCustom.Size = new System.Drawing.Size(336, 22);
            this.mnuServer_RestoreAllCustom.Text = "Restore bak collection...";
            this.mnuServer_RestoreAllCustom.ToolTipText = "Restore all .bak files from a folder";
            this.mnuServer_RestoreAllCustom.Click += new System.EventHandler(this.mnuServer_Restore_Click);
            // 
            // mnuServer_backup
            // 
            this.mnuServer_backup.Enabled = false;
            this.mnuServer_backup.Image = global::ScriptQL.Properties.Resources.backup;
            this.mnuServer_backup.Name = "mnuServer_backup";
            this.mnuServer_backup.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.mnuServer_backup.Size = new System.Drawing.Size(336, 22);
            this.mnuServer_backup.Text = "Backup all ";
            this.mnuServer_backup.ToolTipText = "Backup all databases to the default folder (appending to the current set)";
            this.mnuServer_backup.Click += new System.EventHandler(this.mnuServer_backup_Click);
            // 
            // mnuServer_backupWith
            // 
            this.mnuServer_backupWith.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServer_backupWithCompress,
            this.mnuServer_backupWithInit,
            this.mnuServer_backupWithCompressAndInit});
            this.mnuServer_backupWith.Enabled = false;
            this.mnuServer_backupWith.Image = global::ScriptQL.Properties.Resources.backup;
            this.mnuServer_backupWith.Name = "mnuServer_backupWith";
            this.mnuServer_backupWith.Size = new System.Drawing.Size(336, 22);
            this.mnuServer_backupWith.Text = "Backup all with ...";
            // 
            // mnuServer_backupWithCompress
            // 
            this.mnuServer_backupWithCompress.Name = "mnuServer_backupWithCompress";
            this.mnuServer_backupWithCompress.Size = new System.Drawing.Size(167, 22);
            this.mnuServer_backupWithCompress.Text = "Backup all +C";
            this.mnuServer_backupWithCompress.ToolTipText = "Backup all databases with compression (appending to the current set)";
            this.mnuServer_backupWithCompress.Click += new System.EventHandler(this.mnuServer_backupWithCompress_Click);
            // 
            // mnuServer_backupWithInit
            // 
            this.mnuServer_backupWithInit.Name = "mnuServer_backupWithInit";
            this.mnuServer_backupWithInit.Size = new System.Drawing.Size(167, 22);
            this.mnuServer_backupWithInit.Text = "Backup all +O";
            this.mnuServer_backupWithInit.ToolTipText = "Backup all databases overwriting the current set (format)";
            this.mnuServer_backupWithInit.Click += new System.EventHandler(this.mnuServer_backupWithInit_Click);
            // 
            // mnuServer_backupWithCompressAndInit
            // 
            this.mnuServer_backupWithCompressAndInit.Name = "mnuServer_backupWithCompressAndInit";
            this.mnuServer_backupWithCompressAndInit.Size = new System.Drawing.Size(167, 22);
            this.mnuServer_backupWithCompressAndInit.Text = "Backup all +C +O";
            this.mnuServer_backupWithCompressAndInit.ToolTipText = "Backup all databases with compression overwriting the current set (format)";
            this.mnuServer_backupWithCompressAndInit.Click += new System.EventHandler(this.mnuServer_backupWithCompressAndInit_Click);
            // 
            // mnuServer_Check
            // 
            this.mnuServer_Check.Enabled = false;
            this.mnuServer_Check.Image = global::ScriptQL.Properties.Resources._109_AllAnnotations_Complete_16x16_72;
            this.mnuServer_Check.Name = "mnuServer_Check";
            this.mnuServer_Check.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.mnuServer_Check.Size = new System.Drawing.Size(336, 22);
            this.mnuServer_Check.Text = "Check all";
            this.mnuServer_Check.ToolTipText = "Check all databases for consistency";
            this.mnuServer_Check.Click += new System.EventHandler(this.mnuServer_Check_Click);
            // 
            // mnuDatabase
            // 
            this.mnuDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDatabase_Create,
            this.mnuDatabase_Drop,
            this.mnuDatabase_Rename,
            this.mnuDatabase_Check,
            this.mnuDatabase_Attach,
            this.mnuDatabase_Detach,
            this.mnuDatabase_Offline,
            this.mnuDatabase_Online,
            this.mnuDatabase_SingleUser,
            this.mnuDatabase_MultiUser,
            this.mnuDatabase_Restore,
            this.mnuDatabase_Backup,
            this.mnuDatabase_BackupWith});
            this.mnuDatabase.Name = "mnuDatabase";
            this.mnuDatabase.Size = new System.Drawing.Size(67, 20);
            this.mnuDatabase.Text = "Database";
            // 
            // mnuDatabase_Create
            // 
            this.mnuDatabase_Create.Enabled = false;
            this.mnuDatabase_Create.Image = global::ScriptQL.Properties.Resources.new_db;
            this.mnuDatabase_Create.Name = "mnuDatabase_Create";
            this.mnuDatabase_Create.ShortcutKeyDisplayString = "INS";
            this.mnuDatabase_Create.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.mnuDatabase_Create.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_Create.Tag = "server";
            this.mnuDatabase_Create.Text = "Create";
            this.mnuDatabase_Create.ToolTipText = "Create a new database";
            this.mnuDatabase_Create.Click += new System.EventHandler(this.mnuDatabase_Create_Click);
            // 
            // mnuDatabase_Drop
            // 
            this.mnuDatabase_Drop.Enabled = false;
            this.mnuDatabase_Drop.Image = global::ScriptQL.Properties.Resources.drop_db;
            this.mnuDatabase_Drop.Name = "mnuDatabase_Drop";
            this.mnuDatabase_Drop.ShortcutKeyDisplayString = "DEL";
            this.mnuDatabase_Drop.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuDatabase_Drop.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_Drop.Tag = "offline";
            this.mnuDatabase_Drop.Text = "Drop";
            this.mnuDatabase_Drop.ToolTipText = "Drop database";
            this.mnuDatabase_Drop.Click += new System.EventHandler(this.mnuDatabase_Drop_Click);
            // 
            // mnuDatabase_Rename
            // 
            this.mnuDatabase_Rename.Enabled = false;
            this.mnuDatabase_Rename.Image = global::ScriptQL.Properties.Resources.rename;
            this.mnuDatabase_Rename.Name = "mnuDatabase_Rename";
            this.mnuDatabase_Rename.ShortcutKeyDisplayString = "CTRL +N";
            this.mnuDatabase_Rename.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuDatabase_Rename.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_Rename.Text = "Rename";
            this.mnuDatabase_Rename.ToolTipText = "Rename database";
            this.mnuDatabase_Rename.Click += new System.EventHandler(this.mnuDatabase_Rename_Click);
            // 
            // mnuDatabase_Check
            // 
            this.mnuDatabase_Check.Enabled = false;
            this.mnuDatabase_Check.Image = global::ScriptQL.Properties.Resources.db_check;
            this.mnuDatabase_Check.Name = "mnuDatabase_Check";
            this.mnuDatabase_Check.ShortcutKeyDisplayString = "CTRL+C";
            this.mnuDatabase_Check.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuDatabase_Check.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_Check.Tag = "sysdb";
            this.mnuDatabase_Check.Text = "Check";
            this.mnuDatabase_Check.ToolTipText = "Check database";
            this.mnuDatabase_Check.Click += new System.EventHandler(this.mnuDatabase_Check_Click);
            // 
            // mnuDatabase_Attach
            // 
            this.mnuDatabase_Attach.Enabled = false;
            this.mnuDatabase_Attach.Image = global::ScriptQL.Properties.Resources.dbattach;
            this.mnuDatabase_Attach.Name = "mnuDatabase_Attach";
            this.mnuDatabase_Attach.ShortcutKeyDisplayString = "CTRL+A";
            this.mnuDatabase_Attach.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuDatabase_Attach.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_Attach.Tag = "server";
            this.mnuDatabase_Attach.Text = "Attach";
            this.mnuDatabase_Attach.ToolTipText = "Attach database";
            this.mnuDatabase_Attach.Click += new System.EventHandler(this.mnuDatabase_Attach_Click);
            // 
            // mnuDatabase_Detach
            // 
            this.mnuDatabase_Detach.Enabled = false;
            this.mnuDatabase_Detach.Image = global::ScriptQL.Properties.Resources.dbdetach;
            this.mnuDatabase_Detach.Name = "mnuDatabase_Detach";
            this.mnuDatabase_Detach.ShortcutKeyDisplayString = "CTRL +D";
            this.mnuDatabase_Detach.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mnuDatabase_Detach.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_Detach.Tag = "";
            this.mnuDatabase_Detach.Text = "Detach";
            this.mnuDatabase_Detach.ToolTipText = "Detach database";
            this.mnuDatabase_Detach.Click += new System.EventHandler(this.mnuDatabase_Detach_Click);
            // 
            // mnuDatabase_Offline
            // 
            this.mnuDatabase_Offline.Enabled = false;
            this.mnuDatabase_Offline.Image = global::ScriptQL.Properties.Resources.offline;
            this.mnuDatabase_Offline.Name = "mnuDatabase_Offline";
            this.mnuDatabase_Offline.ShortcutKeyDisplayString = "CTRL+DOWN";
            this.mnuDatabase_Offline.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.mnuDatabase_Offline.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_Offline.Text = "Set offline";
            this.mnuDatabase_Offline.ToolTipText = "Switch the database offline";
            this.mnuDatabase_Offline.Click += new System.EventHandler(this.mnuDatabase_Offline_Click);
            // 
            // mnuDatabase_Online
            // 
            this.mnuDatabase_Online.Enabled = false;
            this.mnuDatabase_Online.Image = global::ScriptQL.Properties.Resources.online;
            this.mnuDatabase_Online.Name = "mnuDatabase_Online";
            this.mnuDatabase_Online.ShortcutKeyDisplayString = "CTRL+UP";
            this.mnuDatabase_Online.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.mnuDatabase_Online.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_Online.Tag = "offline";
            this.mnuDatabase_Online.Text = "Set online";
            this.mnuDatabase_Online.ToolTipText = "Switch the database online";
            this.mnuDatabase_Online.Click += new System.EventHandler(this.mnuDatabase_Online_Click);
            // 
            // mnuDatabase_SingleUser
            // 
            this.mnuDatabase_SingleUser.Enabled = false;
            this.mnuDatabase_SingleUser.Image = global::ScriptQL.Properties.Resources.single_user;
            this.mnuDatabase_SingleUser.Name = "mnuDatabase_SingleUser";
            this.mnuDatabase_SingleUser.ShortcutKeyDisplayString = "CTRL+LEFT";
            this.mnuDatabase_SingleUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
            this.mnuDatabase_SingleUser.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_SingleUser.Text = "Set to single user";
            this.mnuDatabase_SingleUser.ToolTipText = "Set the database to single user mode";
            this.mnuDatabase_SingleUser.Click += new System.EventHandler(this.mnuDatabase_SingleUser_Click);
            // 
            // mnuDatabase_MultiUser
            // 
            this.mnuDatabase_MultiUser.Enabled = false;
            this.mnuDatabase_MultiUser.Image = global::ScriptQL.Properties.Resources.multi_user;
            this.mnuDatabase_MultiUser.Name = "mnuDatabase_MultiUser";
            this.mnuDatabase_MultiUser.ShortcutKeyDisplayString = "CTRL+RIGHT";
            this.mnuDatabase_MultiUser.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
            this.mnuDatabase_MultiUser.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_MultiUser.Text = "Set to multi user";
            this.mnuDatabase_MultiUser.ToolTipText = "Set the database to multi user mode";
            this.mnuDatabase_MultiUser.Click += new System.EventHandler(this.mnuDatabase_MultiUser_Click);
            // 
            // mnuDatabase_Restore
            // 
            this.mnuDatabase_Restore.Enabled = false;
            this.mnuDatabase_Restore.Image = global::ScriptQL.Properties.Resources.restore;
            this.mnuDatabase_Restore.Name = "mnuDatabase_Restore";
            this.mnuDatabase_Restore.ShortcutKeyDisplayString = "CTRL +R";
            this.mnuDatabase_Restore.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuDatabase_Restore.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_Restore.Tag = "offline";
            this.mnuDatabase_Restore.Text = "Restore...";
            this.mnuDatabase_Restore.ToolTipText = "Restore database from file";
            this.mnuDatabase_Restore.Click += new System.EventHandler(this.mnuDatabase_Restore_Click);
            // 
            // mnuDatabase_Backup
            // 
            this.mnuDatabase_Backup.Enabled = false;
            this.mnuDatabase_Backup.Image = global::ScriptQL.Properties.Resources.backup;
            this.mnuDatabase_Backup.Name = "mnuDatabase_Backup";
            this.mnuDatabase_Backup.ShortcutKeyDisplayString = "CTRL+B";
            this.mnuDatabase_Backup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.mnuDatabase_Backup.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_Backup.Tag = "offline";
            this.mnuDatabase_Backup.Text = "Backup";
            this.mnuDatabase_Backup.ToolTipText = "Backup database to the default folder (appending to the current set)";
            // 
            // mnuDatabase_BackupWith
            // 
            this.mnuDatabase_BackupWith.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDatabase_BackupWithCompress,
            this.mnuDatabase_BackupWithOverwrite,
            this.mnuDatabase_BackupWithCompressOverwrite});
            this.mnuDatabase_BackupWith.Enabled = false;
            this.mnuDatabase_BackupWith.Image = global::ScriptQL.Properties.Resources.backup;
            this.mnuDatabase_BackupWith.Name = "mnuDatabase_BackupWith";
            this.mnuDatabase_BackupWith.Size = new System.Drawing.Size(237, 22);
            this.mnuDatabase_BackupWith.Tag = "sysdb";
            this.mnuDatabase_BackupWith.Text = "Backup with...";
            // 
            // mnuDatabase_BackupWithCompress
            // 
            this.mnuDatabase_BackupWithCompress.Name = "mnuDatabase_BackupWithCompress";
            this.mnuDatabase_BackupWithCompress.Size = new System.Drawing.Size(200, 22);
            this.mnuDatabase_BackupWithCompress.Text = "compress";
            this.mnuDatabase_BackupWithCompress.ToolTipText = "Backup with compression (appending to the current set)";
            // 
            // mnuDatabase_BackupWithOverwrite
            // 
            this.mnuDatabase_BackupWithOverwrite.Name = "mnuDatabase_BackupWithOverwrite";
            this.mnuDatabase_BackupWithOverwrite.Size = new System.Drawing.Size(200, 22);
            this.mnuDatabase_BackupWithOverwrite.Text = "overwrite";
            this.mnuDatabase_BackupWithOverwrite.ToolTipText = "Backup overwriting the current set (format)";
            // 
            // mnuDatabase_BackupWithCompressOverwrite
            // 
            this.mnuDatabase_BackupWithCompressOverwrite.Name = "mnuDatabase_BackupWithCompressOverwrite";
            this.mnuDatabase_BackupWithCompressOverwrite.Size = new System.Drawing.Size(200, 22);
            this.mnuDatabase_BackupWithCompressOverwrite.Text = "compress and overwrite";
            this.mnuDatabase_BackupWithCompressOverwrite.ToolTipText = "Backup with compression overwriting the current set (format)";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTools_ClearLog,
            this.mnuTools_OpenBackupFolder});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // mnuTools_ClearLog
            // 
            this.mnuTools_ClearLog.Enabled = false;
            this.mnuTools_ClearLog.Image = global::ScriptQL.Properties.Resources.NewCardHS;
            this.mnuTools_ClearLog.Name = "mnuTools_ClearLog";
            this.mnuTools_ClearLog.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.mnuTools_ClearLog.Size = new System.Drawing.Size(219, 22);
            this.mnuTools_ClearLog.Text = "Clear Log";
            this.mnuTools_ClearLog.Click += new System.EventHandler(this.mnuTools_ClearLog_Click);
            // 
            // mnuTools_OpenBackupFolder
            // 
            this.mnuTools_OpenBackupFolder.Enabled = false;
            this.mnuTools_OpenBackupFolder.Image = global::ScriptQL.Properties.Resources.folder;
            this.mnuTools_OpenBackupFolder.Name = "mnuTools_OpenBackupFolder";
            this.mnuTools_OpenBackupFolder.Size = new System.Drawing.Size(219, 22);
            this.mnuTools_OpenBackupFolder.Text = "Open default backup folder";
            this.mnuTools_OpenBackupFolder.Click += new System.EventHandler(this.mnuTools_OpenBackupFolder_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lblMain_Tables
            // 
            this.lblMain_Tables.AutoSize = true;
            this.lblMain_Tables.Location = new System.Drawing.Point(760, 339);
            this.lblMain_Tables.Name = "lblMain_Tables";
            this.lblMain_Tables.Size = new System.Drawing.Size(39, 13);
            this.lblMain_Tables.TabIndex = 9;
            this.lblMain_Tables.Text = "Tables";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(441, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Rows";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(441, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Rows";
            // 
            // tbxMain
            // 
            this.tbxMain.BackColor = System.Drawing.SystemColors.Control;
            this.tbxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsEditConfig,
            this.tlsEnableSystemDbs,
            this.toolStripSeparator7,
            this.tlsDiscoverDetached,
            this.toolStripSeparator8,
            this.tlsServer_VerifyBackupsCustomFolder,
            this.tlsServer_VerifyBackupsDefaultFolder,
            this.tlsRestoreAllFromCustomFolder,
            this.tlsRestoreAllFromDefaultFolder,
            this.tlsBackupAll,
            this.tlsCheckAll,
            this.toolStripSeparator10,
            this.tlsOpenBackupFolder,
            this.tlsClearLog,
            this.toolStripSeparator9,
            this.tlsAllOnline,
            this.tlsAllOffline,
            this.toolStripSeparator11,
            this.tlsAllMulti,
            this.tlsAllSingle,
            this.toolStripSeparator12,
            this.btnDeleteAll,
            this.toolStripSeparator13});
            this.tbxMain.Location = new System.Drawing.Point(0, 0);
            this.tbxMain.MaximumSize = new System.Drawing.Size(0, 32);
            this.tbxMain.MinimumSize = new System.Drawing.Size(0, 26);
            this.tbxMain.Name = "tbxMain";
            this.tbxMain.Size = new System.Drawing.Size(478, 26);
            this.tbxMain.TabIndex = 1;
            this.tbxMain.Text = "toolStrip1";
            // 
            // tlsEditConfig
            // 
            this.tlsEditConfig.AutoSize = false;
            this.tlsEditConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsEditConfig.Image = global::ScriptQL.Properties.Resources.settings;
            this.tlsEditConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsEditConfig.Name = "tlsEditConfig";
            this.tlsEditConfig.Size = new System.Drawing.Size(26, 26);
            this.tlsEditConfig.Tag = "AlwaysOn";
            this.tlsEditConfig.Text = "Edit Server List...";
            this.tlsEditConfig.Click += new System.EventHandler(this.tlsEditConfig_Click);
            // 
            // tlsEnableSystemDbs
            // 
            this.tlsEnableSystemDbs.AutoSize = false;
            this.tlsEnableSystemDbs.BackColor = System.Drawing.Color.Transparent;
            this.tlsEnableSystemDbs.CheckOnClick = true;
            this.tlsEnableSystemDbs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsEnableSystemDbs.Image = ((System.Drawing.Image)(resources.GetObject("tlsEnableSystemDbs.Image")));
            this.tlsEnableSystemDbs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsEnableSystemDbs.Name = "tlsEnableSystemDbs";
            this.tlsEnableSystemDbs.Size = new System.Drawing.Size(26, 26);
            this.tlsEnableSystemDbs.Tag = "AlwaysOn";
            this.tlsEnableSystemDbs.Text = "Enable system databases";
            this.tlsEnableSystemDbs.Click += new System.EventHandler(this.tlsEnableSystemDbs_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 26);
            // 
            // tlsDiscoverDetached
            // 
            this.tlsDiscoverDetached.AutoSize = false;
            this.tlsDiscoverDetached.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDiscoverDetached.Enabled = false;
            this.tlsDiscoverDetached.Image = global::ScriptQL.Properties.Resources.search;
            this.tlsDiscoverDetached.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDiscoverDetached.Name = "tlsDiscoverDetached";
            this.tlsDiscoverDetached.Size = new System.Drawing.Size(26, 26);
            this.tlsDiscoverDetached.Text = "Discover detached databases...";
            this.tlsDiscoverDetached.ToolTipText = "Discover detached databases (only local instances)";
            this.tlsDiscoverDetached.Click += new System.EventHandler(this.tlsDiscoverDetached_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 26);
            // 
            // tlsServer_VerifyBackupsCustomFolder
            // 
            this.tlsServer_VerifyBackupsCustomFolder.AutoSize = false;
            this.tlsServer_VerifyBackupsCustomFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsServer_VerifyBackupsCustomFolder.Enabled = false;
            this.tlsServer_VerifyBackupsCustomFolder.Image = global::ScriptQL.Properties.Resources.verify;
            this.tlsServer_VerifyBackupsCustomFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsServer_VerifyBackupsCustomFolder.Name = "tlsServer_VerifyBackupsCustomFolder";
            this.tlsServer_VerifyBackupsCustomFolder.Size = new System.Drawing.Size(26, 26);
            this.tlsServer_VerifyBackupsCustomFolder.Text = "Verify backups custom";
            this.tlsServer_VerifyBackupsCustomFolder.ToolTipText = "Verify backups in a user-specified folder(Local instances only)";
            this.tlsServer_VerifyBackupsCustomFolder.Click += new System.EventHandler(this.tlsServer_VerifyBackupsCustomFolder_Click);
            // 
            // tlsServer_VerifyBackupsDefaultFolder
            // 
            this.tlsServer_VerifyBackupsDefaultFolder.AutoSize = false;
            this.tlsServer_VerifyBackupsDefaultFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsServer_VerifyBackupsDefaultFolder.Enabled = false;
            this.tlsServer_VerifyBackupsDefaultFolder.Image = ((System.Drawing.Image)(resources.GetObject("tlsServer_VerifyBackupsDefaultFolder.Image")));
            this.tlsServer_VerifyBackupsDefaultFolder.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tlsServer_VerifyBackupsDefaultFolder.Name = "tlsServer_VerifyBackupsDefaultFolder";
            this.tlsServer_VerifyBackupsDefaultFolder.Size = new System.Drawing.Size(26, 26);
            this.tlsServer_VerifyBackupsDefaultFolder.Text = "verify backups default";
            this.tlsServer_VerifyBackupsDefaultFolder.ToolTipText = "Verify backups in the default backup folder";
            this.tlsServer_VerifyBackupsDefaultFolder.Click += new System.EventHandler(this.tlsServer_VerifyBackupsDefaultFolder_Click);
            // 
            // tlsRestoreAllFromCustomFolder
            // 
            this.tlsRestoreAllFromCustomFolder.AutoSize = false;
            this.tlsRestoreAllFromCustomFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsRestoreAllFromCustomFolder.Enabled = false;
            this.tlsRestoreAllFromCustomFolder.Image = global::ScriptQL.Properties.Resources.restorefromfolder;
            this.tlsRestoreAllFromCustomFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsRestoreAllFromCustomFolder.Name = "tlsRestoreAllFromCustomFolder";
            this.tlsRestoreAllFromCustomFolder.Size = new System.Drawing.Size(26, 26);
            this.tlsRestoreAllFromCustomFolder.Text = "Restore all custom";
            this.tlsRestoreAllFromCustomFolder.ToolTipText = "Restore all .bak files from a user-specified folder (only from local instances)";
            this.tlsRestoreAllFromCustomFolder.Click += new System.EventHandler(this.tlsRestoreAllFromCustomFolder_Click);
            // 
            // tlsRestoreAllFromDefaultFolder
            // 
            this.tlsRestoreAllFromDefaultFolder.AutoSize = false;
            this.tlsRestoreAllFromDefaultFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsRestoreAllFromDefaultFolder.Enabled = false;
            this.tlsRestoreAllFromDefaultFolder.Image = global::ScriptQL.Properties.Resources.restore;
            this.tlsRestoreAllFromDefaultFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsRestoreAllFromDefaultFolder.Name = "tlsRestoreAllFromDefaultFolder";
            this.tlsRestoreAllFromDefaultFolder.Size = new System.Drawing.Size(26, 26);
            this.tlsRestoreAllFromDefaultFolder.Text = "restore all default";
            this.tlsRestoreAllFromDefaultFolder.ToolTipText = "Restore all .bak files from the default backup folder";
            this.tlsRestoreAllFromDefaultFolder.Click += new System.EventHandler(this.tlsRestoreAllFromDefaultFolder_Click);
            this.tlsRestoreAllFromDefaultFolder.EnabledChanged += new System.EventHandler(this.tlsRestoreAllFromDefaultFolder_EnabledChanged);
            // 
            // tlsBackupAll
            // 
            this.tlsBackupAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsBackupAll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsBackupAllWithCompression,
            this.tlsBackupAllWithOverwrite,
            this.tlsBackupAllWithCompressionOverwrite});
            this.tlsBackupAll.Enabled = false;
            this.tlsBackupAll.Image = global::ScriptQL.Properties.Resources.backup;
            this.tlsBackupAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsBackupAll.Margin = new System.Windows.Forms.Padding(0);
            this.tlsBackupAll.Name = "tlsBackupAll";
            this.tlsBackupAll.Size = new System.Drawing.Size(32, 26);
            this.tlsBackupAll.Text = "Backup all";
            this.tlsBackupAll.ToolTipText = "Backup all databases to the default folder (appending to the current set)";
            this.tlsBackupAll.ButtonClick += new System.EventHandler(this.tlsBackupAll_ButtonClick);
            // 
            // tlsBackupAllWithCompression
            // 
            this.tlsBackupAllWithCompression.Name = "tlsBackupAllWithCompression";
            this.tlsBackupAllWithCompression.Size = new System.Drawing.Size(167, 22);
            this.tlsBackupAllWithCompression.Text = "Backup all +C";
            this.tlsBackupAllWithCompression.ToolTipText = "Backup all databases with compression (appending to the current set)";
            this.tlsBackupAllWithCompression.Click += new System.EventHandler(this.tlsBackupAllWithCompression_Click);
            // 
            // tlsBackupAllWithOverwrite
            // 
            this.tlsBackupAllWithOverwrite.Name = "tlsBackupAllWithOverwrite";
            this.tlsBackupAllWithOverwrite.Size = new System.Drawing.Size(167, 22);
            this.tlsBackupAllWithOverwrite.Text = "Backup all +O";
            this.tlsBackupAllWithOverwrite.ToolTipText = "Backup all databases overwriting the current set (format)";
            this.tlsBackupAllWithOverwrite.Click += new System.EventHandler(this.tlsBackupAllWithOverwrite_Click);
            // 
            // tlsBackupAllWithCompressionOverwrite
            // 
            this.tlsBackupAllWithCompressionOverwrite.Name = "tlsBackupAllWithCompressionOverwrite";
            this.tlsBackupAllWithCompressionOverwrite.Size = new System.Drawing.Size(167, 22);
            this.tlsBackupAllWithCompressionOverwrite.Text = "Backup all +C +O";
            this.tlsBackupAllWithCompressionOverwrite.ToolTipText = "Backup all databases with compression overwriting the current set (format)";
            this.tlsBackupAllWithCompressionOverwrite.Click += new System.EventHandler(this.tlsBackupAllWithCompressionOverwrite_Click);
            // 
            // tlsCheckAll
            // 
            this.tlsCheckAll.AutoSize = false;
            this.tlsCheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsCheckAll.Enabled = false;
            this.tlsCheckAll.Image = ((System.Drawing.Image)(resources.GetObject("tlsCheckAll.Image")));
            this.tlsCheckAll.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tlsCheckAll.Name = "tlsCheckAll";
            this.tlsCheckAll.Size = new System.Drawing.Size(26, 26);
            this.tlsCheckAll.Text = "Check all";
            this.tlsCheckAll.ToolTipText = "Check all databases for consistency";
            this.tlsCheckAll.Click += new System.EventHandler(this.tlsCheckAll_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 26);
            // 
            // tlsOpenBackupFolder
            // 
            this.tlsOpenBackupFolder.AutoSize = false;
            this.tlsOpenBackupFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsOpenBackupFolder.Enabled = false;
            this.tlsOpenBackupFolder.Image = global::ScriptQL.Properties.Resources.folder;
            this.tlsOpenBackupFolder.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tlsOpenBackupFolder.Name = "tlsOpenBackupFolder";
            this.tlsOpenBackupFolder.Size = new System.Drawing.Size(26, 26);
            this.tlsOpenBackupFolder.Text = "Open default backup folder";
            this.tlsOpenBackupFolder.Click += new System.EventHandler(this.tlsOpenBackupFolder_Click);
            this.tlsOpenBackupFolder.EnabledChanged += new System.EventHandler(this.tlsOpenBackupFolder_EnabledChanged);
            // 
            // tlsClearLog
            // 
            this.tlsClearLog.AutoSize = false;
            this.tlsClearLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsClearLog.Enabled = false;
            this.tlsClearLog.Image = ((System.Drawing.Image)(resources.GetObject("tlsClearLog.Image")));
            this.tlsClearLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsClearLog.Name = "tlsClearLog";
            this.tlsClearLog.Size = new System.Drawing.Size(26, 26);
            this.tlsClearLog.Tag = "AlwaysOn";
            this.tlsClearLog.Text = "Clear log";
            this.tlsClearLog.ToolTipText = "Clear the log window";
            this.tlsClearLog.Click += new System.EventHandler(this.tlsClearLog_Click);
            this.tlsClearLog.EnabledChanged += new System.EventHandler(this.tlsClearLog_EnabledChanged);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 26);
            // 
            // tlsAllOnline
            // 
            this.tlsAllOnline.AutoSize = false;
            this.tlsAllOnline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsAllOnline.Enabled = false;
            this.tlsAllOnline.Image = global::ScriptQL.Properties.Resources.online;
            this.tlsAllOnline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsAllOnline.Name = "tlsAllOnline";
            this.tlsAllOnline.Size = new System.Drawing.Size(26, 26);
            this.tlsAllOnline.Text = "ALL ONLINE";
            this.tlsAllOnline.ToolTipText = "Switch all databases online";
            this.tlsAllOnline.Click += new System.EventHandler(this.tlsAllOnline_Click);
            // 
            // tlsAllOffline
            // 
            this.tlsAllOffline.AutoSize = false;
            this.tlsAllOffline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsAllOffline.Enabled = false;
            this.tlsAllOffline.Image = global::ScriptQL.Properties.Resources.offline;
            this.tlsAllOffline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsAllOffline.Name = "tlsAllOffline";
            this.tlsAllOffline.Size = new System.Drawing.Size(26, 26);
            this.tlsAllOffline.Text = "ALL OFFLINE";
            this.tlsAllOffline.ToolTipText = "Switch all databases offline";
            this.tlsAllOffline.Click += new System.EventHandler(this.tlsAllOffline_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 26);
            // 
            // tlsAllMulti
            // 
            this.tlsAllMulti.AutoSize = false;
            this.tlsAllMulti.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsAllMulti.Enabled = false;
            this.tlsAllMulti.Image = global::ScriptQL.Properties.Resources.multi_user;
            this.tlsAllMulti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsAllMulti.Name = "tlsAllMulti";
            this.tlsAllMulti.Size = new System.Drawing.Size(26, 26);
            this.tlsAllMulti.Text = "ALL MULTI";
            this.tlsAllMulti.ToolTipText = "Switch all databases multi user";
            this.tlsAllMulti.Click += new System.EventHandler(this.tlsAllMulti_Click);
            // 
            // tlsAllSingle
            // 
            this.tlsAllSingle.AutoSize = false;
            this.tlsAllSingle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsAllSingle.Enabled = false;
            this.tlsAllSingle.Image = global::ScriptQL.Properties.Resources.single_user;
            this.tlsAllSingle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsAllSingle.Name = "tlsAllSingle";
            this.tlsAllSingle.Size = new System.Drawing.Size(26, 26);
            this.tlsAllSingle.Text = "ALL SINGLE";
            this.tlsAllSingle.ToolTipText = "Switch all databases single user";
            this.tlsAllSingle.Click += new System.EventHandler(this.tlsAllSingle_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 26);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.AutoSize = false;
            this.btnDeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteAll.Enabled = false;
            this.btnDeleteAll.Image = global::ScriptQL.Properties.Resources.Deleteall;
            this.btnDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(26, 26);
            this.btnDeleteAll.Tag = "";
            this.btnDeleteAll.Text = "DROP ALL";
            this.btnDeleteAll.ToolTipText = "Drop all databases (DANGEROUS)";
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(6, 26);
            // 
            // grpMainServers
            // 
            this.grpMainServers.BackColor = System.Drawing.SystemColors.Control;
            this.grpMainServers.Controls.Add(this.tblServers);
            this.grpMainServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMainServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMainServers.Location = new System.Drawing.Point(0, 0);
            this.grpMainServers.Margin = new System.Windows.Forms.Padding(0);
            this.grpMainServers.MaximumSize = new System.Drawing.Size(0, 115);
            this.grpMainServers.MinimumSize = new System.Drawing.Size(0, 100);
            this.grpMainServers.Name = "grpMainServers";
            this.grpMainServers.Padding = new System.Windows.Forms.Padding(1);
            this.grpMainServers.Size = new System.Drawing.Size(478, 115);
            this.grpMainServers.TabIndex = 30;
            this.grpMainServers.TabStop = false;
            this.grpMainServers.Text = "  SERVERS";
            // 
            // tblServers
            // 
            this.tblServers.BackColor = System.Drawing.Color.Black;
            this.tblServers.ColumnCount = 4;
            this.tblServers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblServers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.31674F));
            this.tblServers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.68326F));
            this.tblServers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblServers.Controls.Add(this.tblPictures, 0, 0);
            this.tblServers.Controls.Add(this.tblCancel, 3, 0);
            this.tblServers.Controls.Add(this.lstMain_Servers, 1, 0);
            this.tblServers.Controls.Add(this.tblProgressBars, 2, 0);
            this.tblServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblServers.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tblServers.Location = new System.Drawing.Point(1, 14);
            this.tblServers.Margin = new System.Windows.Forms.Padding(0);
            this.tblServers.MaximumSize = new System.Drawing.Size(0, 100);
            this.tblServers.MinimumSize = new System.Drawing.Size(0, 100);
            this.tblServers.Name = "tblServers";
            this.tblServers.RowCount = 1;
            this.tblServers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.60241F));
            this.tblServers.Size = new System.Drawing.Size(476, 100);
            this.tblServers.TabIndex = 41;
            // 
            // tblPictures
            // 
            this.tblPictures.ColumnCount = 1;
            this.tblPictures.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblPictures.Controls.Add(this.pctServer4, 0, 4);
            this.tblPictures.Controls.Add(this.pctServer3, 0, 3);
            this.tblPictures.Controls.Add(this.pctServer2, 0, 2);
            this.tblPictures.Controls.Add(this.pctServer1, 0, 1);
            this.tblPictures.Controls.Add(this.pctServer0, 0, 0);
            this.tblPictures.Location = new System.Drawing.Point(0, 0);
            this.tblPictures.Margin = new System.Windows.Forms.Padding(0);
            this.tblPictures.Name = "tblPictures";
            this.tblPictures.RowCount = 5;
            this.tblPictures.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPictures.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPictures.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPictures.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPictures.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblPictures.Size = new System.Drawing.Size(20, 100);
            this.tblPictures.TabIndex = 40;
            // 
            // pctServer4
            // 
            this.pctServer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctServer4.Enabled = false;
            this.pctServer4.ErrorImage = null;
            this.pctServer4.InitialImage = null;
            this.pctServer4.Location = new System.Drawing.Point(0, 80);
            this.pctServer4.Margin = new System.Windows.Forms.Padding(0);
            this.pctServer4.Name = "pctServer4";
            this.pctServer4.Size = new System.Drawing.Size(20, 20);
            this.pctServer4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctServer4.TabIndex = 46;
            this.pctServer4.TabStop = false;
            this.pctServer4.Visible = false;
            // 
            // pctServer3
            // 
            this.pctServer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctServer3.Enabled = false;
            this.pctServer3.InitialImage = null;
            this.pctServer3.Location = new System.Drawing.Point(0, 60);
            this.pctServer3.Margin = new System.Windows.Forms.Padding(0);
            this.pctServer3.Name = "pctServer3";
            this.pctServer3.Size = new System.Drawing.Size(20, 20);
            this.pctServer3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctServer3.TabIndex = 45;
            this.pctServer3.TabStop = false;
            this.pctServer3.Visible = false;
            // 
            // pctServer2
            // 
            this.pctServer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctServer2.Enabled = false;
            this.pctServer2.InitialImage = null;
            this.pctServer2.Location = new System.Drawing.Point(0, 40);
            this.pctServer2.Margin = new System.Windows.Forms.Padding(0);
            this.pctServer2.Name = "pctServer2";
            this.pctServer2.Size = new System.Drawing.Size(20, 20);
            this.pctServer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctServer2.TabIndex = 44;
            this.pctServer2.TabStop = false;
            this.pctServer2.Visible = false;
            // 
            // pctServer1
            // 
            this.pctServer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctServer1.Enabled = false;
            this.pctServer1.InitialImage = null;
            this.pctServer1.Location = new System.Drawing.Point(0, 20);
            this.pctServer1.Margin = new System.Windows.Forms.Padding(0);
            this.pctServer1.Name = "pctServer1";
            this.pctServer1.Size = new System.Drawing.Size(20, 20);
            this.pctServer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctServer1.TabIndex = 43;
            this.pctServer1.TabStop = false;
            this.pctServer1.Visible = false;
            // 
            // pctServer0
            // 
            this.pctServer0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctServer0.ErrorImage = null;
            this.pctServer0.InitialImage = null;
            this.pctServer0.Location = new System.Drawing.Point(0, 0);
            this.pctServer0.Margin = new System.Windows.Forms.Padding(0);
            this.pctServer0.Name = "pctServer0";
            this.pctServer0.Size = new System.Drawing.Size(20, 20);
            this.pctServer0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctServer0.TabIndex = 42;
            this.pctServer0.TabStop = false;
            this.pctServer0.Visible = false;
            // 
            // tblCancel
            // 
            this.tblCancel.ColumnCount = 1;
            this.tblCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblCancel.Controls.Add(this.btnCancel4, 0, 4);
            this.tblCancel.Controls.Add(this.btnCancel0, 0, 0);
            this.tblCancel.Controls.Add(this.btnCancel3, 0, 3);
            this.tblCancel.Controls.Add(this.btnCancel1, 0, 1);
            this.tblCancel.Controls.Add(this.btnCancel2, 0, 2);
            this.tblCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tblCancel.Location = new System.Drawing.Point(449, 0);
            this.tblCancel.Margin = new System.Windows.Forms.Padding(0);
            this.tblCancel.Name = "tblCancel";
            this.tblCancel.RowCount = 5;
            this.tblCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblCancel.Size = new System.Drawing.Size(23, 100);
            this.tblCancel.TabIndex = 39;
            // 
            // btnCancel4
            // 
            this.btnCancel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel4.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel4.Image")));
            this.btnCancel4.Location = new System.Drawing.Point(0, 80);
            this.btnCancel4.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel4.Name = "btnCancel4";
            this.btnCancel4.Size = new System.Drawing.Size(23, 20);
            this.btnCancel4.TabIndex = 42;
            this.tooltipMainInfo.SetToolTip(this.btnCancel4, "Cancel the operation");
            this.btnCancel4.UseVisualStyleBackColor = true;
            this.btnCancel4.Visible = false;
            this.btnCancel4.Click += new System.EventHandler(this.btnCancel4_Click);
            // 
            // btnCancel0
            // 
            this.btnCancel0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel0.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel0.Image")));
            this.btnCancel0.Location = new System.Drawing.Point(0, 0);
            this.btnCancel0.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel0.Name = "btnCancel0";
            this.btnCancel0.Size = new System.Drawing.Size(23, 20);
            this.btnCancel0.TabIndex = 38;
            this.tooltipMainInfo.SetToolTip(this.btnCancel0, "Cancel the operation");
            this.btnCancel0.UseVisualStyleBackColor = true;
            this.btnCancel0.Visible = false;
            this.btnCancel0.Click += new System.EventHandler(this.btnCancel0_Click);
            // 
            // btnCancel3
            // 
            this.btnCancel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel3.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel3.Image")));
            this.btnCancel3.Location = new System.Drawing.Point(0, 60);
            this.btnCancel3.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel3.Name = "btnCancel3";
            this.btnCancel3.Size = new System.Drawing.Size(23, 20);
            this.btnCancel3.TabIndex = 41;
            this.tooltipMainInfo.SetToolTip(this.btnCancel3, "Cancel the operation");
            this.btnCancel3.UseVisualStyleBackColor = true;
            this.btnCancel3.Visible = false;
            this.btnCancel3.Click += new System.EventHandler(this.btnCancel3_Click);
            // 
            // btnCancel1
            // 
            this.btnCancel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel1.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel1.Image")));
            this.btnCancel1.Location = new System.Drawing.Point(0, 20);
            this.btnCancel1.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel1.Name = "btnCancel1";
            this.btnCancel1.Size = new System.Drawing.Size(23, 20);
            this.btnCancel1.TabIndex = 39;
            this.tooltipMainInfo.SetToolTip(this.btnCancel1, "Cancel the operation");
            this.btnCancel1.UseVisualStyleBackColor = true;
            this.btnCancel1.Visible = false;
            this.btnCancel1.Click += new System.EventHandler(this.btnCancel1_Click);
            // 
            // btnCancel2
            // 
            this.btnCancel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel2.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel2.Image")));
            this.btnCancel2.Location = new System.Drawing.Point(0, 40);
            this.btnCancel2.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(23, 20);
            this.btnCancel2.TabIndex = 40;
            this.tooltipMainInfo.SetToolTip(this.btnCancel2, "Cancel the operation");
            this.btnCancel2.UseVisualStyleBackColor = true;
            this.btnCancel2.Visible = false;
            this.btnCancel2.Click += new System.EventHandler(this.btnCancel2_Click);
            // 
            // lstMain_Servers
            // 
            this.lstMain_Servers.BackColor = System.Drawing.Color.Black;
            this.lstMain_Servers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstMain_Servers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMain_Servers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.lstMain_Servers.ForeColor = System.Drawing.Color.Yellow;
            this.lstMain_Servers.FormattingEnabled = true;
            this.lstMain_Servers.ItemHeight = 20;
            this.lstMain_Servers.Location = new System.Drawing.Point(20, 0);
            this.lstMain_Servers.Margin = new System.Windows.Forms.Padding(0);
            this.lstMain_Servers.MaximumSize = new System.Drawing.Size(0, 100);
            this.lstMain_Servers.MinimumSize = new System.Drawing.Size(300, 100);
            this.lstMain_Servers.Name = "lstMain_Servers";
            this.lstMain_Servers.Size = new System.Drawing.Size(345, 100);
            this.lstMain_Servers.TabIndex = 2;
            this.lstMain_Servers.SelectedIndexChanged += new System.EventHandler(this.lstMain_Servers_SelectedIndexChanged);
            this.lstMain_Servers.SelectedValueChanged += new System.EventHandler(this.lstMain_Servers_SelectedValueChanged);
            // 
            // tblProgressBars
            // 
            this.tblProgressBars.AutoSize = true;
            this.tblProgressBars.ColumnCount = 1;
            this.tblProgressBars.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblProgressBars.Controls.Add(this.prgServer0, 0, 0);
            this.tblProgressBars.Controls.Add(this.prgServer1, 0, 1);
            this.tblProgressBars.Controls.Add(this.prgServer4, 0, 4);
            this.tblProgressBars.Controls.Add(this.prgServer2, 0, 2);
            this.tblProgressBars.Controls.Add(this.prgServer3, 0, 3);
            this.tblProgressBars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblProgressBars.Location = new System.Drawing.Point(365, 0);
            this.tblProgressBars.Margin = new System.Windows.Forms.Padding(0);
            this.tblProgressBars.Name = "tblProgressBars";
            this.tblProgressBars.RowCount = 5;
            this.tblProgressBars.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblProgressBars.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblProgressBars.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblProgressBars.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblProgressBars.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblProgressBars.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblProgressBars.Size = new System.Drawing.Size(84, 100);
            this.tblProgressBars.TabIndex = 41;
            // 
            // prgServer0
            // 
            this.prgServer0.BackColor = System.Drawing.SystemColors.ControlLight;
            this.prgServer0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgServer0.Location = new System.Drawing.Point(2, 2);
            this.prgServer0.Margin = new System.Windows.Forms.Padding(2);
            this.prgServer0.Name = "prgServer0";
            this.prgServer0.Size = new System.Drawing.Size(80, 16);
            this.prgServer0.TabIndex = 28;
            this.prgServer0.Visible = false;
            this.prgServer0.VisibleChanged += new System.EventHandler(this.prgServer0_VisibleChanged);
            // 
            // prgServer1
            // 
            this.prgServer1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.prgServer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgServer1.Location = new System.Drawing.Point(2, 22);
            this.prgServer1.Margin = new System.Windows.Forms.Padding(2);
            this.prgServer1.Name = "prgServer1";
            this.prgServer1.Size = new System.Drawing.Size(80, 16);
            this.prgServer1.TabIndex = 29;
            this.prgServer1.Visible = false;
            this.prgServer1.VisibleChanged += new System.EventHandler(this.prgServer1_VisibleChanged);
            // 
            // prgServer4
            // 
            this.prgServer4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.prgServer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgServer4.Location = new System.Drawing.Point(2, 82);
            this.prgServer4.Margin = new System.Windows.Forms.Padding(2);
            this.prgServer4.Name = "prgServer4";
            this.prgServer4.Size = new System.Drawing.Size(80, 16);
            this.prgServer4.TabIndex = 32;
            this.prgServer4.Visible = false;
            this.prgServer4.VisibleChanged += new System.EventHandler(this.prgServer4_VisibleChanged);
            // 
            // prgServer2
            // 
            this.prgServer2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.prgServer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgServer2.Location = new System.Drawing.Point(2, 42);
            this.prgServer2.Margin = new System.Windows.Forms.Padding(2);
            this.prgServer2.Name = "prgServer2";
            this.prgServer2.Size = new System.Drawing.Size(80, 16);
            this.prgServer2.TabIndex = 30;
            this.prgServer2.Visible = false;
            this.prgServer2.VisibleChanged += new System.EventHandler(this.prgServer2_VisibleChanged);
            // 
            // prgServer3
            // 
            this.prgServer3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.prgServer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgServer3.Location = new System.Drawing.Point(2, 62);
            this.prgServer3.Margin = new System.Windows.Forms.Padding(2);
            this.prgServer3.Name = "prgServer3";
            this.prgServer3.Size = new System.Drawing.Size(80, 16);
            this.prgServer3.TabIndex = 31;
            this.prgServer3.Visible = false;
            this.prgServer3.VisibleChanged += new System.EventHandler(this.prgServer3_VisibleChanged);
            // 
            // prpServers
            // 
            this.prpServers.BackColor = System.Drawing.Color.White;
            this.prpServers.DisabledItemForeColor = System.Drawing.SystemColors.Desktop;
            this.prpServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prpServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prpServers.HelpVisible = false;
            this.prpServers.Location = new System.Drawing.Point(0, 0);
            this.prpServers.Margin = new System.Windows.Forms.Padding(2);
            this.prpServers.Name = "prpServers";
            this.prpServers.Size = new System.Drawing.Size(478, 329);
            this.prpServers.TabIndex = 27;
            this.prpServers.ToolbarVisible = false;
            this.prpServers.ViewBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // tbxDatabase
            // 
            this.tbxDatabase.BackColor = System.Drawing.SystemColors.Control;
            this.tbxDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsDatabase_Create,
            this.tlsDatabase_Drop,
            this.toolStripSeparator5,
            this.tlsDatabase_Check,
            this.tlsDatabase_KillConnections,
            this.toolStripSeparator6,
            this.tlsDatabase_Attach,
            this.tlsDatabase_Detach,
            this.toolStripSeparator4,
            this.tlsDatabase_Online,
            this.tlsDatabase_Offline,
            this.toolStripSeparator2,
            this.tlsDatabase_Multi,
            this.tlsDatabase_Single,
            this.toolStripSeparator3,
            this.tlsDatabase_Restore,
            this.tlsDatabase_BackupWith,
            this.toolStripSeparator1,
            this.tlsDatabase_Rename,
            this.txtDatabase_Rename});
            this.tbxDatabase.Location = new System.Drawing.Point(0, 0);
            this.tbxDatabase.MaximumSize = new System.Drawing.Size(0, 32);
            this.tbxDatabase.MinimumSize = new System.Drawing.Size(0, 26);
            this.tbxDatabase.Name = "tbxDatabase";
            this.tbxDatabase.Size = new System.Drawing.Size(819, 26);
            this.tbxDatabase.TabIndex = 0;
            this.tbxDatabase.Text = "toolStrip1";
            // 
            // tlsDatabase_Create
            // 
            this.tlsDatabase_Create.AutoSize = false;
            this.tlsDatabase_Create.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_Create.Enabled = false;
            this.tlsDatabase_Create.Image = global::ScriptQL.Properties.Resources.new_db;
            this.tlsDatabase_Create.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_Create.Name = "tlsDatabase_Create";
            this.tlsDatabase_Create.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_Create.Tag = "server";
            this.tlsDatabase_Create.Text = "Create";
            this.tlsDatabase_Create.ToolTipText = "Create a new database...";
            this.tlsDatabase_Create.Click += new System.EventHandler(this.tlsDatabase_Create_Click);
            // 
            // tlsDatabase_Drop
            // 
            this.tlsDatabase_Drop.AutoSize = false;
            this.tlsDatabase_Drop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_Drop.Enabled = false;
            this.tlsDatabase_Drop.Image = global::ScriptQL.Properties.Resources.drop_db;
            this.tlsDatabase_Drop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_Drop.Name = "tlsDatabase_Drop";
            this.tlsDatabase_Drop.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_Drop.Tag = "offline";
            this.tlsDatabase_Drop.Text = "Drop";
            this.tlsDatabase_Drop.ToolTipText = "Drop database";
            this.tlsDatabase_Drop.Click += new System.EventHandler(this.tlsDatabase_Drop_Click);
            this.tlsDatabase_Drop.EnabledChanged += new System.EventHandler(this.tlsDatabase_Drop_EnabledChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 26);
            // 
            // tlsDatabase_Check
            // 
            this.tlsDatabase_Check.AutoSize = false;
            this.tlsDatabase_Check.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_Check.Enabled = false;
            this.tlsDatabase_Check.Image = global::ScriptQL.Properties.Resources.db_check;
            this.tlsDatabase_Check.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_Check.Name = "tlsDatabase_Check";
            this.tlsDatabase_Check.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_Check.Tag = "sysdb";
            this.tlsDatabase_Check.Text = "Check";
            this.tlsDatabase_Check.ToolTipText = "Check database";
            this.tlsDatabase_Check.Click += new System.EventHandler(this.tlsDatabase_Check_Click);
            // 
            // tlsDatabase_KillConnections
            // 
            this.tlsDatabase_KillConnections.AutoSize = false;
            this.tlsDatabase_KillConnections.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_KillConnections.Enabled = false;
            this.tlsDatabase_KillConnections.Image = ((System.Drawing.Image)(resources.GetObject("tlsDatabase_KillConnections.Image")));
            this.tlsDatabase_KillConnections.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_KillConnections.Name = "tlsDatabase_KillConnections";
            this.tlsDatabase_KillConnections.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_KillConnections.Text = "Kill connections";
            this.tlsDatabase_KillConnections.ToolTipText = "Forcibly close all current connections to the database";
            this.tlsDatabase_KillConnections.Click += new System.EventHandler(this.tlsDatabase_KillConnections_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 26);
            // 
            // tlsDatabase_Attach
            // 
            this.tlsDatabase_Attach.AutoSize = false;
            this.tlsDatabase_Attach.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_Attach.Enabled = false;
            this.tlsDatabase_Attach.Image = global::ScriptQL.Properties.Resources.dbattach;
            this.tlsDatabase_Attach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_Attach.Name = "tlsDatabase_Attach";
            this.tlsDatabase_Attach.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_Attach.Tag = "server";
            this.tlsDatabase_Attach.Text = "Attach";
            this.tlsDatabase_Attach.ToolTipText = "Attach database";
            this.tlsDatabase_Attach.Click += new System.EventHandler(this.tlsDatabase_Attach_Click);
            // 
            // tlsDatabase_Detach
            // 
            this.tlsDatabase_Detach.AutoSize = false;
            this.tlsDatabase_Detach.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_Detach.Enabled = false;
            this.tlsDatabase_Detach.Image = global::ScriptQL.Properties.Resources.dbdetach;
            this.tlsDatabase_Detach.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_Detach.Name = "tlsDatabase_Detach";
            this.tlsDatabase_Detach.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_Detach.Tag = "offline";
            this.tlsDatabase_Detach.Text = "Detach";
            this.tlsDatabase_Detach.ToolTipText = "Detach database";
            this.tlsDatabase_Detach.Click += new System.EventHandler(this.tlsDatabase_Detach_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 26);
            // 
            // tlsDatabase_Online
            // 
            this.tlsDatabase_Online.AutoSize = false;
            this.tlsDatabase_Online.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_Online.Enabled = false;
            this.tlsDatabase_Online.Image = global::ScriptQL.Properties.Resources.online;
            this.tlsDatabase_Online.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_Online.Name = "tlsDatabase_Online";
            this.tlsDatabase_Online.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_Online.Tag = "offline";
            this.tlsDatabase_Online.Text = "Online";
            this.tlsDatabase_Online.ToolTipText = "Switch database online";
            this.tlsDatabase_Online.Click += new System.EventHandler(this.tlsDatabase_Online_Click);
            this.tlsDatabase_Online.EnabledChanged += new System.EventHandler(this.tlsDatabase_Online_EnabledChanged);
            // 
            // tlsDatabase_Offline
            // 
            this.tlsDatabase_Offline.AutoSize = false;
            this.tlsDatabase_Offline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_Offline.Enabled = false;
            this.tlsDatabase_Offline.Image = global::ScriptQL.Properties.Resources.offline;
            this.tlsDatabase_Offline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_Offline.Name = "tlsDatabase_Offline";
            this.tlsDatabase_Offline.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_Offline.Text = "Offline";
            this.tlsDatabase_Offline.ToolTipText = "Switch database offline";
            this.tlsDatabase_Offline.Click += new System.EventHandler(this.tlsDatabase_Offline_Click);
            this.tlsDatabase_Offline.EnabledChanged += new System.EventHandler(this.tlsDatabase_Offline_EnabledChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // tlsDatabase_Multi
            // 
            this.tlsDatabase_Multi.AutoSize = false;
            this.tlsDatabase_Multi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_Multi.Enabled = false;
            this.tlsDatabase_Multi.Image = global::ScriptQL.Properties.Resources.multi_user;
            this.tlsDatabase_Multi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_Multi.Name = "tlsDatabase_Multi";
            this.tlsDatabase_Multi.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_Multi.Text = "Multi user";
            this.tlsDatabase_Multi.ToolTipText = "Set the database to multi user mode";
            this.tlsDatabase_Multi.Click += new System.EventHandler(this.tlsDatabase_Multi_Click);
            this.tlsDatabase_Multi.EnabledChanged += new System.EventHandler(this.tlsDatabase_Multi_EnabledChanged);
            // 
            // tlsDatabase_Single
            // 
            this.tlsDatabase_Single.AutoSize = false;
            this.tlsDatabase_Single.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_Single.Enabled = false;
            this.tlsDatabase_Single.Image = global::ScriptQL.Properties.Resources.single_user;
            this.tlsDatabase_Single.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_Single.Name = "tlsDatabase_Single";
            this.tlsDatabase_Single.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_Single.Text = "Single user";
            this.tlsDatabase_Single.ToolTipText = "Set the database to single user mode";
            this.tlsDatabase_Single.Click += new System.EventHandler(this.tlsDatabase_Single_Click);
            this.tlsDatabase_Single.EnabledChanged += new System.EventHandler(this.tlsDatabase_Single_EnabledChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // tlsDatabase_Restore
            // 
            this.tlsDatabase_Restore.AutoSize = false;
            this.tlsDatabase_Restore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_Restore.Enabled = false;
            this.tlsDatabase_Restore.Image = global::ScriptQL.Properties.Resources.restore;
            this.tlsDatabase_Restore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_Restore.Name = "tlsDatabase_Restore";
            this.tlsDatabase_Restore.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_Restore.Tag = "offline";
            this.tlsDatabase_Restore.Text = "Restore";
            this.tlsDatabase_Restore.ToolTipText = "Restore database from file";
            this.tlsDatabase_Restore.Click += new System.EventHandler(this.tlsDatabase_Restore_Click);
            // 
            // tlsDatabase_BackupWith
            // 
            this.tlsDatabase_BackupWith.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_BackupWith.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsDatabase_BackupWithCompression,
            this.tlsDatabase_BackupWithOverwrite,
            this.tlsDatabase_BackupWithCompressionOverwrite});
            this.tlsDatabase_BackupWith.Enabled = false;
            this.tlsDatabase_BackupWith.Image = global::ScriptQL.Properties.Resources.backup;
            this.tlsDatabase_BackupWith.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_BackupWith.Name = "tlsDatabase_BackupWith";
            this.tlsDatabase_BackupWith.Size = new System.Drawing.Size(32, 23);
            this.tlsDatabase_BackupWith.Tag = "sysdb";
            this.tlsDatabase_BackupWith.Text = "Backup";
            this.tlsDatabase_BackupWith.ToolTipText = "Backup database to the default folder (appending to the current set)";
            this.tlsDatabase_BackupWith.ButtonClick += new System.EventHandler(this.tlsDatabase_Backup_ButtonClick);
            this.tlsDatabase_BackupWith.EnabledChanged += new System.EventHandler(this.tlsDatabase_BackupWith_EnabledChanged);
            // 
            // tlsDatabase_BackupWithCompression
            // 
            this.tlsDatabase_BackupWithCompression.Name = "tlsDatabase_BackupWithCompression";
            this.tlsDatabase_BackupWithCompression.Size = new System.Drawing.Size(152, 22);
            this.tlsDatabase_BackupWithCompression.Text = "Backup +C";
            this.tlsDatabase_BackupWithCompression.ToolTipText = "Backup with compression (appending to the current set)";
            this.tlsDatabase_BackupWithCompression.Click += new System.EventHandler(this.tlsDatabase_BackupWithCompression_Click);
            // 
            // tlsDatabase_BackupWithOverwrite
            // 
            this.tlsDatabase_BackupWithOverwrite.Name = "tlsDatabase_BackupWithOverwrite";
            this.tlsDatabase_BackupWithOverwrite.Size = new System.Drawing.Size(152, 22);
            this.tlsDatabase_BackupWithOverwrite.Text = "Backup +O";
            this.tlsDatabase_BackupWithOverwrite.ToolTipText = "Backup overwriting the current set (format)";
            this.tlsDatabase_BackupWithOverwrite.Click += new System.EventHandler(this.tlsDatabase_BackupWithOverwrite_Click);
            // 
            // tlsDatabase_BackupWithCompressionOverwrite
            // 
            this.tlsDatabase_BackupWithCompressionOverwrite.Name = "tlsDatabase_BackupWithCompressionOverwrite";
            this.tlsDatabase_BackupWithCompressionOverwrite.Size = new System.Drawing.Size(152, 22);
            this.tlsDatabase_BackupWithCompressionOverwrite.Text = "Backup +C +O";
            this.tlsDatabase_BackupWithCompressionOverwrite.ToolTipText = "Backup with compression overwriting the current set (format)";
            this.tlsDatabase_BackupWithCompressionOverwrite.Click += new System.EventHandler(this.tlsDatabase_BackupWithCompressionOverwrite_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // tlsDatabase_Rename
            // 
            this.tlsDatabase_Rename.AutoSize = false;
            this.tlsDatabase_Rename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsDatabase_Rename.Enabled = false;
            this.tlsDatabase_Rename.Image = global::ScriptQL.Properties.Resources.rename;
            this.tlsDatabase_Rename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDatabase_Rename.Name = "tlsDatabase_Rename";
            this.tlsDatabase_Rename.Size = new System.Drawing.Size(26, 26);
            this.tlsDatabase_Rename.Text = "Rename";
            this.tlsDatabase_Rename.ToolTipText = "Rename database";
            this.tlsDatabase_Rename.Click += new System.EventHandler(this.tlsDatabase_Rename_Click);
            // 
            // txtDatabase_Rename
            // 
            this.txtDatabase_Rename.Enabled = false;
            this.txtDatabase_Rename.Name = "txtDatabase_Rename";
            this.txtDatabase_Rename.Size = new System.Drawing.Size(145, 26);
            this.txtDatabase_Rename.ToolTipText = "Rename database to...";
            // 
            // grpMainDatabases
            // 
            this.grpMainDatabases.BackColor = System.Drawing.SystemColors.Control;
            this.grpMainDatabases.Controls.Add(this.dgvDatabases);
            this.grpMainDatabases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMainDatabases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpMainDatabases.Location = new System.Drawing.Point(0, 0);
            this.grpMainDatabases.Margin = new System.Windows.Forms.Padding(0);
            this.grpMainDatabases.Name = "grpMainDatabases";
            this.grpMainDatabases.Padding = new System.Windows.Forms.Padding(1);
            this.grpMainDatabases.Size = new System.Drawing.Size(819, 448);
            this.grpMainDatabases.TabIndex = 31;
            this.grpMainDatabases.TabStop = false;
            this.grpMainDatabases.Text = "DATABASES";
            // 
            // dgvDatabases
            // 
            this.dgvDatabases.AllowUserToAddRows = false;
            this.dgvDatabases.AllowUserToDeleteRows = false;
            this.dgvDatabases.AllowUserToOrderColumns = true;
            this.dgvDatabases.AllowUserToResizeRows = false;
            this.dgvDatabases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDatabases.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatabases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatabases.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatabases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatabases.ColumnHeadersHeight = 20;
            this.dgvDatabases.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatabases.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatabases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatabases.Location = new System.Drawing.Point(1, 14);
            this.dgvDatabases.MultiSelect = false;
            this.dgvDatabases.Name = "dgvDatabases";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatabases.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatabases.RowHeadersVisible = false;
            this.dgvDatabases.RowTemplate.Height = 30;
            this.dgvDatabases.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatabases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatabases.Size = new System.Drawing.Size(817, 433);
            this.dgvDatabases.TabIndex = 27;
            this.dgvDatabases.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDatabases_CellFormatting);
            this.dgvDatabases.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDatabases_DataBindingComplete);
            this.dgvDatabases.Click += new System.EventHandler(this.dgvDatabases_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.toolStripMenuItem1.Text = "Delete Server";
            // 
            // tooltipMainInfo
            // 
            this.tooltipMainInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // lsv_log
            // 
            this.lsv_log.BackColor = System.Drawing.SystemColors.Control;
            this.lsv_log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.log_time,
            this.log_source,
            this.log_progress,
            this.log_command,
            this.log_state,
            this.log_message});
            this.lsv_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsv_log.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_log.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lsv_log.FullRowSelect = true;
            this.lsv_log.GridLines = true;
            this.lsv_log.HideSelection = false;
            this.lsv_log.Location = new System.Drawing.Point(0, 0);
            this.lsv_log.MultiSelect = false;
            this.lsv_log.Name = "lsv_log";
            this.lsv_log.Size = new System.Drawing.Size(1301, 167);
            this.lsv_log.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lsv_log.TabIndex = 34;
            this.lsv_log.UseCompatibleStateImageBehavior = false;
            this.lsv_log.View = System.Windows.Forms.View.Details;
            // 
            // log_time
            // 
            this.log_time.Text = "time";
            this.log_time.Width = 80;
            // 
            // log_source
            // 
            this.log_source.Text = "source";
            this.log_source.Width = 140;
            // 
            // log_progress
            // 
            this.log_progress.Text = "progress";
            this.log_progress.Width = 65;
            // 
            // log_command
            // 
            this.log_command.Text = "command";
            this.log_command.Width = 120;
            // 
            // log_state
            // 
            this.log_state.Text = "state";
            this.log_state.Width = 72;
            // 
            // log_message
            // 
            this.log_message.Text = "message";
            this.log_message.Width = 1600;
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.AutoScroll = true;
            this.splitMain.Panel1.Controls.Add(this.splitSubMain);
            this.splitMain.Panel1MinSize = 300;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.lsv_log);
            this.splitMain.Size = new System.Drawing.Size(1301, 649);
            this.splitMain.SplitterDistance = 478;
            this.splitMain.TabIndex = 35;
            // 
            // splitSubMain
            // 
            this.splitSubMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitSubMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitSubMain.Location = new System.Drawing.Point(0, 0);
            this.splitSubMain.Name = "splitSubMain";
            // 
            // splitSubMain.Panel1
            // 
            this.splitSubMain.Panel1.Controls.Add(this.panelToolbarServer);
            this.splitSubMain.Panel1MinSize = 100;
            // 
            // splitSubMain.Panel2
            // 
            this.splitSubMain.Panel2.Controls.Add(this.panelToolbarDatabase);
            this.splitSubMain.Size = new System.Drawing.Size(1301, 478);
            this.splitSubMain.SplitterDistance = 478;
            this.splitSubMain.TabIndex = 0;
            // 
            // panelToolbarServer
            // 
            this.panelToolbarServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToolbarServer.IsSplitterFixed = true;
            this.panelToolbarServer.Location = new System.Drawing.Point(0, 0);
            this.panelToolbarServer.Name = "panelToolbarServer";
            this.panelToolbarServer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelToolbarServer.Panel1
            // 
            this.panelToolbarServer.Panel1.Controls.Add(this.tbxMain);
            // 
            // panelToolbarServer.Panel2
            // 
            this.panelToolbarServer.Panel2.Controls.Add(this.splitServerControls1);
            this.panelToolbarServer.Size = new System.Drawing.Size(478, 478);
            this.panelToolbarServer.SplitterDistance = 26;
            this.panelToolbarServer.TabIndex = 0;
            // 
            // splitServerControls1
            // 
            this.splitServerControls1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitServerControls1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitServerControls1.IsSplitterFixed = true;
            this.splitServerControls1.Location = new System.Drawing.Point(0, 0);
            this.splitServerControls1.MinimumSize = new System.Drawing.Size(0, 300);
            this.splitServerControls1.Name = "splitServerControls1";
            this.splitServerControls1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitServerControls1.Panel1
            // 
            this.splitServerControls1.Panel1.Controls.Add(this.grpMainServers);
            this.splitServerControls1.Panel1MinSize = 110;
            // 
            // splitServerControls1.Panel2
            // 
            this.splitServerControls1.Panel2.Controls.Add(this.prpServers);
            this.splitServerControls1.Panel2MinSize = 100;
            this.splitServerControls1.Size = new System.Drawing.Size(478, 448);
            this.splitServerControls1.SplitterDistance = 115;
            this.splitServerControls1.TabIndex = 0;
            // 
            // panelToolbarDatabase
            // 
            this.panelToolbarDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToolbarDatabase.IsSplitterFixed = true;
            this.panelToolbarDatabase.Location = new System.Drawing.Point(0, 0);
            this.panelToolbarDatabase.Name = "panelToolbarDatabase";
            this.panelToolbarDatabase.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelToolbarDatabase.Panel1
            // 
            this.panelToolbarDatabase.Panel1.Controls.Add(this.tbxDatabase);
            // 
            // panelToolbarDatabase.Panel2
            // 
            this.panelToolbarDatabase.Panel2.Controls.Add(this.grpMainDatabases);
            this.panelToolbarDatabase.Size = new System.Drawing.Size(819, 478);
            this.panelToolbarDatabase.SplitterDistance = 26;
            this.panelToolbarDatabase.TabIndex = 0;
            // 
            // tabTables
            // 
            this.tabTables.Controls.Add(this.tableLayoutPanel1);
            this.tabTables.Controls.Add(this.btnUpdate);
            this.tabTables.Controls.Add(this.label3);
            this.tabTables.Controls.Add(this.cmbView);
            this.tabTables.Location = new System.Drawing.Point(4, 20);
            this.tabTables.Name = "tabTables";
            this.tabTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabTables.Size = new System.Drawing.Size(1301, 649);
            this.tabTables.TabIndex = 0;
            this.tabTables.Text = "Tables ";
            this.tabTables.UseVisualStyleBackColor = true;
            this.tabTables.Enter += new System.EventHandler(this.tabTables_Enter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DimGray;
            this.tableLayoutPanel1.ColumnCount = 13;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.064398F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.156195F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.064398F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.156195F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.064398F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.156195F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.42039F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.365382F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.478316F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.754796F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.087573F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.439928F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.71596F));
            this.tableLayoutPanel1.Controls.Add(this.lblSchema, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSearchTimeout, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvMain_Rows, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbSchema, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTableRefresh, 12, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 10, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtRecordsNumber, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbTable, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRecordNumber, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdbSortDESC, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbColumns, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdbSortASC, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1295, 643);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // lblSchema
            // 
            this.lblSchema.AutoSize = true;
            this.lblSchema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSchema.ForeColor = System.Drawing.SystemColors.Control;
            this.lblSchema.Location = new System.Drawing.Point(3, 0);
            this.lblSchema.Name = "lblSchema";
            this.lblSchema.Size = new System.Drawing.Size(59, 30);
            this.lblSchema.TabIndex = 19;
            this.lblSchema.Text = "Schema";
            this.lblSchema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearchTimeout
            // 
            this.txtSearchTimeout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchTimeout.Location = new System.Drawing.Point(1133, 3);
            this.txtSearchTimeout.Name = "txtSearchTimeout";
            this.txtSearchTimeout.Size = new System.Drawing.Size(64, 20);
            this.txtSearchTimeout.TabIndex = 29;
            this.txtSearchTimeout.Text = "0";
            this.txtSearchTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSearchTimeout.Leave += new System.EventHandler(this.txtSearchTimeout_Leave);
            // 
            // dgvMain_Rows
            // 
            this.dgvMain_Rows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMain_Rows.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvMain_Rows.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain_Rows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain_Rows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvMain_Rows, 14);
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain_Rows.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMain_Rows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain_Rows.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvMain_Rows.Location = new System.Drawing.Point(5, 35);
            this.dgvMain_Rows.Margin = new System.Windows.Forms.Padding(5);
            this.dgvMain_Rows.Name = "dgvMain_Rows";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain_Rows.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMain_Rows.Size = new System.Drawing.Size(1285, 603);
            this.dgvMain_Rows.TabIndex = 17;
            // 
            // cmbSchema
            // 
            this.cmbSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchema.FormattingEnabled = true;
            this.cmbSchema.Location = new System.Drawing.Point(68, 3);
            this.cmbSchema.Name = "cmbSchema";
            this.cmbSchema.Size = new System.Drawing.Size(103, 21);
            this.cmbSchema.TabIndex = 1;
            this.cmbSchema.SelectedIndexChanged += new System.EventHandler(this.cmbSchema_SelectedIndexChanged);
            // 
            // btnTableRefresh
            // 
            this.btnTableRefresh.BackColor = System.Drawing.Color.LimeGreen;
            this.btnTableRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTableRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTableRefresh.FlatAppearance.BorderSize = 5;
            this.btnTableRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTableRefresh.ForeColor = System.Drawing.Color.Navy;
            this.btnTableRefresh.Location = new System.Drawing.Point(1203, 3);
            this.btnTableRefresh.Name = "btnTableRefresh";
            this.btnTableRefresh.Size = new System.Drawing.Size(89, 24);
            this.btnTableRefresh.TabIndex = 7;
            this.btnTableRefresh.Text = "SELECT";
            this.btnTableRefresh.UseVisualStyleBackColor = false;
            this.btnTableRefresh.Click += new System.EventHandler(this.btnTableRefresh_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(1068, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 30);
            this.label8.TabIndex = 30;
            this.label8.Text = "Timeout";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRecordsNumber
            // 
            this.txtRecordsNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRecordsNumber.Location = new System.Drawing.Point(994, 3);
            this.txtRecordsNumber.Name = "txtRecordsNumber";
            this.txtRecordsNumber.Size = new System.Drawing.Size(68, 20);
            this.txtRecordsNumber.TabIndex = 6;
            this.txtRecordsNumber.Text = "100";
            this.txtRecordsNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRecordsNumber.Leave += new System.EventHandler(this.txtRecordsNumber_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(186, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 30);
            this.label4.TabIndex = 21;
            this.label4.Text = "Table";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbTable
            // 
            this.cmbTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTable.FormattingEnabled = true;
            this.cmbTable.Location = new System.Drawing.Point(251, 3);
            this.cmbTable.Name = "cmbTable";
            this.cmbTable.Size = new System.Drawing.Size(103, 21);
            this.cmbTable.TabIndex = 2;
            this.cmbTable.SelectedIndexChanged += new System.EventHandler(this.cmbTable_SelectedIndexChanged);
            // 
            // lblRecordNumber
            // 
            this.lblRecordNumber.AutoSize = true;
            this.lblRecordNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecordNumber.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRecordNumber.Location = new System.Drawing.Point(924, 0);
            this.lblRecordNumber.Name = "lblRecordNumber";
            this.lblRecordNumber.Size = new System.Drawing.Size(64, 30);
            this.lblRecordNumber.TabIndex = 23;
            this.lblRecordNumber.Text = "Records";
            this.lblRecordNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(369, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 30);
            this.label6.TabIndex = 27;
            this.label6.Text = "Order by";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdbSortDESC
            // 
            this.rdbSortDESC.AutoSize = true;
            this.rdbSortDESC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbSortDESC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbSortDESC.Enabled = false;
            this.rdbSortDESC.ForeColor = System.Drawing.SystemColors.Control;
            this.rdbSortDESC.Location = new System.Drawing.Point(855, 3);
            this.rdbSortDESC.Name = "rdbSortDESC";
            this.rdbSortDESC.Size = new System.Drawing.Size(63, 24);
            this.rdbSortDESC.TabIndex = 5;
            this.rdbSortDESC.Text = "DESC";
            this.rdbSortDESC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbSortDESC.UseVisualStyleBackColor = true;
            // 
            // cmbColumns
            // 
            this.cmbColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColumns.FormattingEnabled = true;
            this.cmbColumns.Location = new System.Drawing.Point(434, 3);
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.Size = new System.Drawing.Size(103, 21);
            this.cmbColumns.TabIndex = 3;
            // 
            // rdbSortASC
            // 
            this.rdbSortASC.AutoSize = true;
            this.rdbSortASC.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbSortASC.Cursor = System.Windows.Forms.Cursors.Default;
            this.rdbSortASC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdbSortASC.Enabled = false;
            this.rdbSortASC.ForeColor = System.Drawing.SystemColors.Control;
            this.rdbSortASC.Location = new System.Drawing.Point(552, 3);
            this.rdbSortASC.Name = "rdbSortASC";
            this.rdbSortASC.Size = new System.Drawing.Size(297, 24);
            this.rdbSortASC.TabIndex = 4;
            this.rdbSortASC.Text = "ASC";
            this.rdbSortASC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rdbSortASC.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Gray;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.BorderSize = 5;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Lime;
            this.btnUpdate.Location = new System.Drawing.Point(1046, 17);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(70, 29);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "View";
            this.label3.Visible = false;
            // 
            // cmbView
            // 
            this.cmbView.FormattingEnabled = true;
            this.cmbView.Location = new System.Drawing.Point(486, 13);
            this.cmbView.Name = "cmbView";
            this.cmbView.Size = new System.Drawing.Size(23, 21);
            this.cmbView.TabIndex = 24;
            this.cmbView.Visible = false;
            // 
            // tabServer
            // 
            this.tabServer.BackColor = System.Drawing.SystemColors.Control;
            this.tabServer.Controls.Add(this.splitMain);
            this.tabServer.Location = new System.Drawing.Point(4, 20);
            this.tabServer.Name = "tabServer";
            this.tabServer.Size = new System.Drawing.Size(1301, 649);
            this.tabServer.TabIndex = 1;
            this.tabServer.Text = "Servers and Databases  ";
            this.tabServer.Enter += new System.EventHandler(this.tabServer_Enter);
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.tabServer);
            this.tabGroup.Controls.Add(this.tabTables);
            this.tabGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabGroup.Location = new System.Drawing.Point(0, 24);
            this.tabGroup.Margin = new System.Windows.Forms.Padding(1);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Drawing.Point(1, 1);
            this.tabGroup.SelectedIndex = 0;
            this.tabGroup.ShowToolTips = true;
            this.tabGroup.Size = new System.Drawing.Size(1309, 673);
            this.tabGroup.TabIndex = 23;
            // 
            // lblTablesStatus
            // 
            this.lblTablesStatus.AutoSize = true;
            this.lblTablesStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTablesStatus.Location = new System.Drawing.Point(677, 549);
            this.lblTablesStatus.Name = "lblTablesStatus";
            this.lblTablesStatus.Size = new System.Drawing.Size(0, 18);
            this.lblTablesStatus.TabIndex = 26;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // Main
            // 
            this.AcceptButton = this.btnTableRefresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1309, 697);
            this.Controls.Add(this.lblTablesStatus);
            this.Controls.Add(this.tabGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMain_Tables);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "ScriptQL";
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbxMain.ResumeLayout(false);
            this.tbxMain.PerformLayout();
            this.grpMainServers.ResumeLayout(false);
            this.tblServers.ResumeLayout(false);
            this.tblServers.PerformLayout();
            this.tblPictures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctServer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctServer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctServer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctServer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctServer0)).EndInit();
            this.tblCancel.ResumeLayout(false);
            this.tblProgressBars.ResumeLayout(false);
            this.tbxDatabase.ResumeLayout(false);
            this.tbxDatabase.PerformLayout();
            this.grpMainDatabases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabases)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitSubMain.Panel1.ResumeLayout(false);
            this.splitSubMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitSubMain)).EndInit();
            this.splitSubMain.ResumeLayout(false);
            this.panelToolbarServer.Panel1.ResumeLayout(false);
            this.panelToolbarServer.Panel1.PerformLayout();
            this.panelToolbarServer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelToolbarServer)).EndInit();
            this.panelToolbarServer.ResumeLayout(false);
            this.splitServerControls1.Panel1.ResumeLayout(false);
            this.splitServerControls1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitServerControls1)).EndInit();
            this.splitServerControls1.ResumeLayout(false);
            this.panelToolbarDatabase.Panel1.ResumeLayout(false);
            this.panelToolbarDatabase.Panel1.PerformLayout();
            this.panelToolbarDatabase.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelToolbarDatabase)).EndInit();
            this.panelToolbarDatabase.ResumeLayout(false);
            this.tabTables.ResumeLayout(false);
            this.tabTables.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain_Rows)).EndInit();
            this.tabServer.ResumeLayout(false);
            this.tabGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem editConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Label lblMain_Tables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuServer;
        private System.Windows.Forms.ToolStripMenuItem mnuServer_DiscoverDetached;
        private System.Windows.Forms.ToolStripMenuItem mnuServer_RestoreAllCustom;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase;
        private System.Windows.Forms.ToolStripMenuItem mnuServer_backup;
        private System.Windows.Forms.ToolStripMenuItem mnuServer_backupWith;
        private System.Windows.Forms.ToolStripMenuItem mnuServer_backupWithCompress;
        private System.Windows.Forms.ToolStripMenuItem mnuServer_backupWithInit;
        private System.Windows.Forms.ToolStripMenuItem mnuServer_backupWithCompressAndInit;
        private System.Windows.Forms.ToolStripMenuItem mnuServer_Check;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_Create;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_Rename;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_Check;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_Attach;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_Detach;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_Offline;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_Online;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_SingleUser;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_MultiUser;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_Restore;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_Backup;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_BackupWith;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_BackupWithCompress;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_BackupWithOverwrite;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_BackupWithCompressOverwrite;
        private System.Windows.Forms.GroupBox grpMainServers;
        private System.Windows.Forms.PropertyGrid prpServers;
        private System.Windows.Forms.ListBox lstMain_Servers;
        private System.Windows.Forms.ToolStrip tbxMain;
        private System.Windows.Forms.ToolStripButton tlsEditConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tlsDiscoverDetached;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton tlsRestoreAllFromCustomFolder;
        private System.Windows.Forms.ToolStripSplitButton tlsBackupAll;
        private System.Windows.Forms.ToolStripMenuItem tlsBackupAllWithCompression;
        private System.Windows.Forms.ToolStripMenuItem tlsBackupAllWithOverwrite;
        private System.Windows.Forms.ToolStripMenuItem tlsBackupAllWithCompressionOverwrite;
        private System.Windows.Forms.ToolStripButton tlsOpenBackupFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tlsCheckAll;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTools_ClearLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolTip tooltipMainInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuDatabase_Drop;
        private System.Windows.Forms.ToolStrip tbxDatabase;
        private System.Windows.Forms.ToolStripButton tlsDatabase_Create;
        private System.Windows.Forms.ToolStripButton tlsDatabase_Drop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlsDatabase_Check;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tlsDatabase_Attach;
        private System.Windows.Forms.ToolStripButton tlsDatabase_Detach;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlsDatabase_Online;
        private System.Windows.Forms.ToolStripButton tlsDatabase_Offline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlsDatabase_Single;
        private System.Windows.Forms.ToolStripButton tlsDatabase_Multi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlsDatabase_Restore;
        private System.Windows.Forms.ToolStripSplitButton tlsDatabase_BackupWith;
        private System.Windows.Forms.ToolStripMenuItem tlsDatabase_BackupWithCompression;
        private System.Windows.Forms.ToolStripMenuItem tlsDatabase_BackupWithOverwrite;
        private System.Windows.Forms.ToolStripMenuItem tlsDatabase_BackupWithCompressionOverwrite;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlsDatabase_Rename;
        private System.Windows.Forms.ToolStripTextBox txtDatabase_Rename;
        private System.Windows.Forms.GroupBox grpMainDatabases;
        private System.Windows.Forms.ToolStripButton tlsEnableSystemDbs;
        private System.Windows.Forms.ToolStripButton tlsServer_VerifyBackupsCustomFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuVerifyBakCollection;
        private System.Windows.Forms.ProgressBar prgServer0;
        private System.Windows.Forms.ProgressBar prgServer1;
        private System.Windows.Forms.ProgressBar prgServer2;
        private System.Windows.Forms.ProgressBar prgServer3;
        private System.Windows.Forms.ProgressBar prgServer4;
        private ToolStripButton tlsClearLog;
        private ToolStripButton btnDeleteAll;
        private TableLayoutPanel tblPictures;
        private TableLayoutPanel tblServers;
        private PictureBox pctServer4;
        private PictureBox pctServer3;
        private PictureBox pctServer2;
        private PictureBox pctServer1;
        private PictureBox pctServer0;
        private TableLayoutPanel tblProgressBars;
        private ToolStripMenuItem mnuTools_OpenBackupFolder;
        private ToolStripButton tlsRestoreAllFromDefaultFolder;
        private ToolStripMenuItem mnuServer_RestoreAllDefault;
        private ToolStripButton tlsServer_VerifyBackupsDefaultFolder;
        private DataGridView dgvDatabases;
        private ToolStripButton tlsAllOnline;
        private ToolStripButton tlsAllOffline;
        private ToolStripButton tlsAllMulti;
        private ToolStripButton tlsAllSingle;
        private ToolStripButton tlsDatabase_KillConnections;
        private ListView lsv_log;
        private ColumnHeader log_time;
        private ColumnHeader log_source;
        private ColumnHeader log_progress;
        private ColumnHeader log_command;
        private ColumnHeader log_state;
        private ColumnHeader log_message;
        private ToolStripSeparator toolStripSeparator11;
        private TableLayoutPanel tblCancel;
        private Button btnCancel4;
        private Button btnCancel0;
        private Button btnCancel3;
        private Button btnCancel1;
        private Button btnCancel2;
        private SplitContainer splitMain;
        private TabPage tabTables;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblSchema;
        private TextBox txtSearchTimeout;
        private DataGridView dgvMain_Rows;
        private ComboBox cmbSchema;
        private Button btnTableRefresh;
        private Label label8;
        private TextBox txtRecordsNumber;
        private Label label4;
        private ComboBox cmbTable;
        private Label lblRecordNumber;
        private Label label6;
        private RadioButton rdbSortDESC;
        private ComboBox cmbColumns;
        private RadioButton rdbSortASC;
        private Button btnUpdate;
        private Label label3;
        private ComboBox cmbView;
        private TabPage tabServer;
        private TabControl tabGroup;
        private Label lblTablesStatus;
        private SplitContainer splitSubMain;
        private SplitContainer panelToolbarServer;
        private SplitContainer splitServerControls1;
        private SplitContainer panelToolbarDatabase;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripButton toolStripButton1;
    }
}