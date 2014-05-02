namespace ScriptQL
{
    partial class FrmServers
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
            // temporary
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServers));
            this.lblEditServers_SqlInstance = new System.Windows.Forms.Label();
            this.lblEditServers_User = new System.Windows.Forms.Label();
            this.lblEditServers_Password = new System.Windows.Forms.Label();
            this.txtEditServers_SqlInstance = new System.Windows.Forms.TextBox();
            this.txtEditServers_User = new System.Windows.Forms.TextBox();
            this.txtEditServers_Password = new System.Windows.Forms.TextBox();
            this.chkFrmEditServers_WinAuth = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuEditServers_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.lstEditServers_serverList = new System.Windows.Forms.ListBox();
            this.btnFrmEditServers_SaveAndClose = new System.Windows.Forms.Button();
            this.btnFrmEditServers_Delete = new System.Windows.Forms.Button();
            this.btnFrmEditServers_add = new System.Windows.Forms.Button();
            this.lblEditServers_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.tblUserInput = new System.Windows.Forms.TableLayoutPanel();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnFrmEditServers_Test = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tblUserInput.SuspendLayout();
            this.tblButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEditServers_SqlInstance
            // 
            this.lblEditServers_SqlInstance.AutoSize = true;
            this.lblEditServers_SqlInstance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEditServers_SqlInstance.Location = new System.Drawing.Point(3, 0);
            this.lblEditServers_SqlInstance.Name = "lblEditServers_SqlInstance";
            this.lblEditServers_SqlInstance.Size = new System.Drawing.Size(65, 33);
            this.lblEditServers_SqlInstance.TabIndex = 0;
            this.lblEditServers_SqlInstance.Text = "SqlInstance";
            this.lblEditServers_SqlInstance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEditServers_User
            // 
            this.lblEditServers_User.AutoSize = true;
            this.lblEditServers_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEditServers_User.Location = new System.Drawing.Point(3, 33);
            this.lblEditServers_User.Name = "lblEditServers_User";
            this.lblEditServers_User.Size = new System.Drawing.Size(65, 33);
            this.lblEditServers_User.TabIndex = 1;
            this.lblEditServers_User.Text = "User";
            this.lblEditServers_User.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEditServers_Password
            // 
            this.lblEditServers_Password.AutoSize = true;
            this.lblEditServers_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEditServers_Password.Location = new System.Drawing.Point(3, 66);
            this.lblEditServers_Password.Name = "lblEditServers_Password";
            this.lblEditServers_Password.Size = new System.Drawing.Size(65, 34);
            this.lblEditServers_Password.TabIndex = 2;
            this.lblEditServers_Password.Text = "Password";
            this.lblEditServers_Password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtEditServers_SqlInstance
            // 
            this.txtEditServers_SqlInstance.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtEditServers_SqlInstance.Location = new System.Drawing.Point(74, 3);
            this.txtEditServers_SqlInstance.Name = "txtEditServers_SqlInstance";
            this.txtEditServers_SqlInstance.Size = new System.Drawing.Size(184, 20);
            this.txtEditServers_SqlInstance.TabIndex = 5;
            this.txtEditServers_SqlInstance.TextChanged += new System.EventHandler(this.txtEditServers_SqlInstance_TextChanged);
            // 
            // txtEditServers_User
            // 
            this.txtEditServers_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEditServers_User.Enabled = false;
            this.txtEditServers_User.Location = new System.Drawing.Point(74, 36);
            this.txtEditServers_User.Name = "txtEditServers_User";
            this.txtEditServers_User.Size = new System.Drawing.Size(184, 20);
            this.txtEditServers_User.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtEditServers_User, "Sql login name");
            this.txtEditServers_User.TextChanged += new System.EventHandler(this.txtEditServers_User_TextChanged);
            // 
            // txtEditServers_Password
            // 
            this.txtEditServers_Password.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEditServers_Password.Enabled = false;
            this.txtEditServers_Password.Location = new System.Drawing.Point(74, 69);
            this.txtEditServers_Password.Name = "txtEditServers_Password";
            this.txtEditServers_Password.PasswordChar = '*';
            this.txtEditServers_Password.Size = new System.Drawing.Size(184, 20);
            this.txtEditServers_Password.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtEditServers_Password, "Sql login password");
            this.txtEditServers_Password.TextChanged += new System.EventHandler(this.txtEditServers_Password_TextChanged);
            // 
            // chkFrmEditServers_WinAuth
            // 
            this.chkFrmEditServers_WinAuth.AutoSize = true;
            this.chkFrmEditServers_WinAuth.Checked = true;
            this.chkFrmEditServers_WinAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFrmEditServers_WinAuth.Location = new System.Drawing.Point(281, 66);
            this.chkFrmEditServers_WinAuth.Name = "chkFrmEditServers_WinAuth";
            this.chkFrmEditServers_WinAuth.Size = new System.Drawing.Size(70, 17);
            this.chkFrmEditServers_WinAuth.TabIndex = 10;
            this.chkFrmEditServers_WinAuth.Text = "Win Auth";
            this.toolTip1.SetToolTip(this.chkFrmEditServers_WinAuth, "Flag to enable Integrated Security (Windows Authentication)");
            this.chkFrmEditServers_WinAuth.UseVisualStyleBackColor = true;
            this.chkFrmEditServers_WinAuth.CheckedChanged += new System.EventHandler(this.chkWinAuth_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditServers_Open});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(352, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuEditServers_Open
            // 
            this.mnuEditServers_Open.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettingsToolStripMenuItem,
            this.addServerToolStripMenuItem,
            this.deleteServerToolStripMenuItem,
            this.saveSettingsToolStripMenuItem,
            this.mnuQuit});
            this.mnuEditServers_Open.Name = "mnuEditServers_Open";
            this.mnuEditServers_Open.Size = new System.Drawing.Size(39, 20);
            this.mnuEditServers_Open.Text = "Edit";
            // 
            // mnuSettingsToolStripMenuItem
            // 
            this.mnuSettingsToolStripMenuItem.Name = "mnuSettingsToolStripMenuItem";
            this.mnuSettingsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.mnuSettingsToolStripMenuItem.Text = "Reset Fields";
            this.mnuSettingsToolStripMenuItem.ToolTipText = "Reset the fields";
            this.mnuSettingsToolStripMenuItem.Click += new System.EventHandler(this.mnuSettingsToolStripMenuItem_Click);
            // 
            // addServerToolStripMenuItem
            // 
            this.addServerToolStripMenuItem.Image = global::ScriptQL.Properties.Resources._112_Plus_Green_24x24_72;
            this.addServerToolStripMenuItem.Name = "addServerToolStripMenuItem";
            this.addServerToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addServerToolStripMenuItem.Text = "Add Server";
            this.addServerToolStripMenuItem.Click += new System.EventHandler(this.addServerToolStripMenuItem_Click);
            // 
            // deleteServerToolStripMenuItem
            // 
            this.deleteServerToolStripMenuItem.Image = global::ScriptQL.Properties.Resources._112_Minus_Green_24x24_72;
            this.deleteServerToolStripMenuItem.Name = "deleteServerToolStripMenuItem";
            this.deleteServerToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteServerToolStripMenuItem.Text = "Delete Server";
            this.deleteServerToolStripMenuItem.Click += new System.EventHandler(this.deleteServerToolStripMenuItem_Click);
            // 
            // saveSettingsToolStripMenuItem
            // 
            this.saveSettingsToolStripMenuItem.Image = global::ScriptQL.Properties.Resources.document_save_2;
            this.saveSettingsToolStripMenuItem.Name = "saveSettingsToolStripMenuItem";
            this.saveSettingsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveSettingsToolStripMenuItem.Text = "Save list to disk";
            this.saveSettingsToolStripMenuItem.ToolTipText = "Save the list to disk (it is automatically saved when the program closes)";
            this.saveSettingsToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToolStripMenuItem_Click);
            // 
            // mnuQuit
            // 
            this.mnuQuit.Name = "mnuQuit";
            this.mnuQuit.Size = new System.Drawing.Size(154, 22);
            this.mnuQuit.Text = "Close";
            this.mnuQuit.ToolTipText = "Close without saving";
            this.mnuQuit.Click += new System.EventHandler(this.mnuQuit_Click);
            // 
            // lstEditServers_serverList
            // 
            this.lstEditServers_serverList.BackColor = System.Drawing.SystemColors.Window;
            this.lstEditServers_serverList.DisplayMember = "instance";
            this.lstEditServers_serverList.FormattingEnabled = true;
            this.lstEditServers_serverList.Location = new System.Drawing.Point(12, 144);
            this.lstEditServers_serverList.Name = "lstEditServers_serverList";
            this.lstEditServers_serverList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstEditServers_serverList.Size = new System.Drawing.Size(261, 134);
            this.lstEditServers_serverList.Sorted = true;
            this.lstEditServers_serverList.TabIndex = 19;
            this.lstEditServers_serverList.SelectedIndexChanged += new System.EventHandler(this.lstEditServers_serverList_SelectedIndexChanged);
            // 
            // btnFrmEditServers_SaveAndClose
            // 
            this.btnFrmEditServers_SaveAndClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFrmEditServers_SaveAndClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFrmEditServers_SaveAndClose.Image = global::ScriptQL.Properties.Resources.document_save_2;
            this.btnFrmEditServers_SaveAndClose.Location = new System.Drawing.Point(11, 95);
            this.btnFrmEditServers_SaveAndClose.Name = "btnFrmEditServers_SaveAndClose";
            this.btnFrmEditServers_SaveAndClose.Size = new System.Drawing.Size(33, 35);
            this.btnFrmEditServers_SaveAndClose.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btnFrmEditServers_SaveAndClose, "Save the list and exit");
            this.btnFrmEditServers_SaveAndClose.UseVisualStyleBackColor = true;
            this.btnFrmEditServers_SaveAndClose.Click += new System.EventHandler(this.btnFrmEditServers_SaveAndClose_Click);
            // 
            // btnFrmEditServers_Delete
            // 
            this.btnFrmEditServers_Delete.BackColor = System.Drawing.SystemColors.Control;
            this.btnFrmEditServers_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFrmEditServers_Delete.Enabled = false;
            this.btnFrmEditServers_Delete.Image = global::ScriptQL.Properties.Resources._112_Minus_Green_24x24_72;
            this.btnFrmEditServers_Delete.Location = new System.Drawing.Point(11, 53);
            this.btnFrmEditServers_Delete.Name = "btnFrmEditServers_Delete";
            this.btnFrmEditServers_Delete.Size = new System.Drawing.Size(33, 33);
            this.btnFrmEditServers_Delete.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnFrmEditServers_Delete, "Delete the instance from the list");
            this.btnFrmEditServers_Delete.UseVisualStyleBackColor = false;
            this.btnFrmEditServers_Delete.Click += new System.EventHandler(this.btnFrmEditServers_Delete_Click);
            // 
            // btnFrmEditServers_add
            // 
            this.btnFrmEditServers_add.BackColor = System.Drawing.SystemColors.Control;
            this.btnFrmEditServers_add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFrmEditServers_add.Enabled = false;
            this.btnFrmEditServers_add.Image = global::ScriptQL.Properties.Resources._112_Plus_Green_24x24_72;
            this.btnFrmEditServers_add.Location = new System.Drawing.Point(11, 11);
            this.btnFrmEditServers_add.Name = "btnFrmEditServers_add";
            this.btnFrmEditServers_add.Size = new System.Drawing.Size(33, 33);
            this.btnFrmEditServers_add.TabIndex = 17;
            this.toolTip1.SetToolTip(this.btnFrmEditServers_add, "Add the instance to the list");
            this.btnFrmEditServers_add.UseVisualStyleBackColor = false;
            this.btnFrmEditServers_add.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblEditServers_Status
            // 
            this.lblEditServers_Status.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEditServers_Status.Name = "lblEditServers_Status";
            this.lblEditServers_Status.Size = new System.Drawing.Size(146, 21);
            this.lblEditServers_Status.Text = "Please add a server.";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEditServers_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 287);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(5);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(352, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDelete,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(220, 134);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(81, 25);
            this.toolStrip1.TabIndex = 23;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "toolStripButton1";
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "toolStripButton2";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton3";
            // 
            // tblUserInput
            // 
            this.tblUserInput.ColumnCount = 2;
            this.tblUserInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.20307F));
            this.tblUserInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.79694F));
            this.tblUserInput.Controls.Add(this.lblEditServers_Password, 0, 2);
            this.tblUserInput.Controls.Add(this.lblEditServers_User, 0, 1);
            this.tblUserInput.Controls.Add(this.txtEditServers_SqlInstance, 1, 0);
            this.tblUserInput.Controls.Add(this.txtEditServers_User, 1, 1);
            this.tblUserInput.Controls.Add(this.txtEditServers_Password, 1, 2);
            this.tblUserInput.Controls.Add(this.lblEditServers_SqlInstance, 0, 0);
            this.tblUserInput.Location = new System.Drawing.Point(12, 27);
            this.tblUserInput.Name = "tblUserInput";
            this.tblUserInput.RowCount = 3;
            this.tblUserInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblUserInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblUserInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblUserInput.Size = new System.Drawing.Size(261, 100);
            this.tblUserInput.TabIndex = 24;
            // 
            // tblButtons
            // 
            this.tblButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblButtons.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tblButtons.ColumnCount = 1;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtons.Controls.Add(this.btnFrmEditServers_add, 0, 0);
            this.tblButtons.Controls.Add(this.btnFrmEditServers_SaveAndClose, 0, 2);
            this.tblButtons.Controls.Add(this.btnFrmEditServers_Delete, 0, 1);
            this.tblButtons.Location = new System.Drawing.Point(290, 144);
            this.tblButtons.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.tblButtons.Name = "tblButtons";
            this.tblButtons.Padding = new System.Windows.Forms.Padding(5);
            this.tblButtons.RowCount = 3;
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.Size = new System.Drawing.Size(55, 141);
            this.tblButtons.TabIndex = 25;
            // 
            // btnFrmEditServers_Test
            // 
            this.btnFrmEditServers_Test.BackColor = System.Drawing.SystemColors.Control;
            this.btnFrmEditServers_Test.Enabled = false;
            this.btnFrmEditServers_Test.Image = ((System.Drawing.Image)(resources.GetObject("btnFrmEditServers_Test.Image")));
            this.btnFrmEditServers_Test.Location = new System.Drawing.Point(281, 24);
            this.btnFrmEditServers_Test.Name = "btnFrmEditServers_Test";
            this.btnFrmEditServers_Test.Size = new System.Drawing.Size(30, 30);
            this.btnFrmEditServers_Test.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnFrmEditServers_Test, "Test connection");
            this.btnFrmEditServers_Test.UseVisualStyleBackColor = false;
            this.btnFrmEditServers_Test.EnabledChanged += new System.EventHandler(this.btnFrmEditServers_Test_EnabledChanged);
            this.btnFrmEditServers_Test.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Image = global::ScriptQL.Properties.Resources.Error_red_21x20_exp;
            this.btnCancel.Location = new System.Drawing.Point(316, 24);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(28, 28);
            this.btnCancel.TabIndex = 26;
            this.toolTip1.SetToolTip(this.btnCancel, "Cancel connection");
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmServers
            // 
            this.AcceptButton = this.btnFrmEditServers_add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnFrmEditServers_SaveAndClose;
            this.ClientSize = new System.Drawing.Size(352, 313);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tblButtons);
            this.Controls.Add(this.tblUserInput);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnFrmEditServers_Test);
            this.Controls.Add(this.chkFrmEditServers_WinAuth);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lstEditServers_serverList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmServers";
            this.Text = "Edit Servers";
            this.Load += new System.EventHandler(this.frmServers_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tblUserInput.ResumeLayout(false);
            this.tblUserInput.PerformLayout();
            this.tblButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEditServers_SqlInstance;
        private System.Windows.Forms.Label lblEditServers_User;
        private System.Windows.Forms.Label lblEditServers_Password;
        private System.Windows.Forms.TextBox txtEditServers_SqlInstance;
        private System.Windows.Forms.TextBox txtEditServers_User;
        private System.Windows.Forms.TextBox txtEditServers_Password;
        private System.Windows.Forms.CheckBox chkFrmEditServers_WinAuth;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuEditServers_Open;
        private System.Windows.Forms.ToolStripMenuItem mnuSettingsToolStripMenuItem;
        private System.Windows.Forms.Button btnFrmEditServers_Test;
        private System.Windows.Forms.ToolStripMenuItem deleteServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuQuit;
        private System.Windows.Forms.ToolStripMenuItem addServerToolStripMenuItem;
        private System.Windows.Forms.ListBox lstEditServers_serverList;
        private System.Windows.Forms.Button btnFrmEditServers_SaveAndClose;
        private System.Windows.Forms.Button btnFrmEditServers_Delete;
        private System.Windows.Forms.Button btnFrmEditServers_add;
        private System.Windows.Forms.ToolStripStatusLabel lblEditServers_Status;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.TableLayoutPanel tblUserInput;
        private System.Windows.Forms.TableLayoutPanel tblButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

