namespace ScriptQL
{
    partial class FrmDiscoverDetached
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used
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
            this.GrpPaths = new System.Windows.Forms.GroupBox();
            this.lstPaths = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpLdf = new System.Windows.Forms.GroupBox();
            this.lstLdf = new System.Windows.Forms.ListBox();
            this.grpNdf = new System.Windows.Forms.GroupBox();
            this.lstNdf = new System.Windows.Forms.ListBox();
            this.grpMdf = new System.Windows.Forms.GroupBox();
            this.lstMdf = new System.Windows.Forms.ListBox();
            this.grpFiles = new System.Windows.Forms.GroupBox();
            this.btnAttach = new System.Windows.Forms.Button();
            this.txtDbname = new System.Windows.Forms.TextBox();
            this.lblDbname = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GrpPaths.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpLdf.SuspendLayout();
            this.grpNdf.SuspendLayout();
            this.grpMdf.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpPaths
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.GrpPaths, 5);
            this.GrpPaths.Controls.Add(this.lstPaths);
            this.GrpPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpPaths.Location = new System.Drawing.Point(3, 3);
            this.GrpPaths.Name = "GrpPaths";
            this.GrpPaths.Size = new System.Drawing.Size(423, 113);
            this.GrpPaths.TabIndex = 0;
            this.GrpPaths.TabStop = false;
            this.GrpPaths.Text = "Paths to be searched";
            // 
            // lstPaths
            // 
            this.lstPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPaths.FormattingEnabled = true;
            this.lstPaths.Location = new System.Drawing.Point(3, 16);
            this.lstPaths.Name = "lstPaths";
            this.lstPaths.Size = new System.Drawing.Size(417, 94);
            this.lstPaths.TabIndex = 0;
            this.lstPaths.SelectedIndexChanged += new System.EventHandler(this.lstPaths_SelectedIndexChanged);
            this.lstPaths.SelectedValueChanged += new System.EventHandler(this.lstPaths_SelectedValueChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(3, 122);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(79, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add ...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemove.Enabled = false;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(88, 122);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(79, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(173, 122);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(79, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Yellow;
            this.tableLayoutPanel1.SetColumnSpan(this.btnSearch, 2);
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.Enabled = false;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(258, 122);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(168, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 548);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(447, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(156, 17);
            this.lblStatus.Text = "No master data file selected.";
            // 
            // grpLdf
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grpLdf, 5);
            this.grpLdf.Controls.Add(this.lstLdf);
            this.grpLdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLdf.Location = new System.Drawing.Point(3, 270);
            this.grpLdf.Name = "grpLdf";
            this.grpLdf.Size = new System.Drawing.Size(423, 113);
            this.grpLdf.TabIndex = 6;
            this.grpLdf.TabStop = false;
            this.grpLdf.Text = "Log Data Files";
            // 
            // lstLdf
            // 
            this.lstLdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLdf.FormattingEnabled = true;
            this.lstLdf.Location = new System.Drawing.Point(3, 16);
            this.lstLdf.Name = "lstLdf";
            this.lstLdf.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstLdf.Size = new System.Drawing.Size(417, 94);
            this.lstLdf.TabIndex = 0;
            // 
            // grpNdf
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grpNdf, 5);
            this.grpNdf.Controls.Add(this.lstNdf);
            this.grpNdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNdf.Location = new System.Drawing.Point(3, 389);
            this.grpNdf.Name = "grpNdf";
            this.grpNdf.Size = new System.Drawing.Size(423, 113);
            this.grpNdf.TabIndex = 7;
            this.grpNdf.TabStop = false;
            this.grpNdf.Text = "Secondary Data Files";
            // 
            // lstNdf
            // 
            this.lstNdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNdf.FormattingEnabled = true;
            this.lstNdf.Location = new System.Drawing.Point(3, 16);
            this.lstNdf.Name = "lstNdf";
            this.lstNdf.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstNdf.Size = new System.Drawing.Size(417, 94);
            this.lstNdf.TabIndex = 0;
            // 
            // grpMdf
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grpMdf, 5);
            this.grpMdf.Controls.Add(this.lstMdf);
            this.grpMdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMdf.Location = new System.Drawing.Point(3, 151);
            this.grpMdf.Name = "grpMdf";
            this.grpMdf.Size = new System.Drawing.Size(423, 113);
            this.grpMdf.TabIndex = 5;
            this.grpMdf.TabStop = false;
            this.grpMdf.Text = "Master Data Files";
            // 
            // lstMdf
            // 
            this.lstMdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMdf.FormattingEnabled = true;
            this.lstMdf.Location = new System.Drawing.Point(3, 16);
            this.lstMdf.Name = "lstMdf";
            this.lstMdf.Size = new System.Drawing.Size(417, 94);
            this.lstMdf.TabIndex = 0;
            this.lstMdf.SelectedValueChanged += new System.EventHandler(this.lstMdf_SelectedValueChanged);
            // 
            // grpFiles
            // 
            this.grpFiles.Location = new System.Drawing.Point(635, 301);
            this.grpFiles.Name = "grpFiles";
            this.grpFiles.Size = new System.Drawing.Size(408, 296);
            this.grpFiles.TabIndex = 8;
            this.grpFiles.TabStop = false;
            // 
            // btnAttach
            // 
            this.btnAttach.BackColor = System.Drawing.Color.Lime;
            this.tableLayoutPanel1.SetColumnSpan(this.btnAttach, 2);
            this.btnAttach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAttach.Enabled = false;
            this.btnAttach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttach.Location = new System.Drawing.Point(258, 508);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(168, 29);
            this.btnAttach.TabIndex = 9;
            this.btnAttach.Text = "ATTACH";
            this.btnAttach.UseVisualStyleBackColor = false;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // txtDbname
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDbname, 2);
            this.txtDbname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDbname.Enabled = false;
            this.txtDbname.Location = new System.Drawing.Point(88, 508);
            this.txtDbname.Name = "txtDbname";
            this.txtDbname.Size = new System.Drawing.Size(164, 20);
            this.txtDbname.TabIndex = 10;
            // 
            // lblDbname
            // 
            this.lblDbname.AutoSize = true;
            this.lblDbname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDbname.Location = new System.Drawing.Point(3, 505);
            this.lblDbname.Name = "lblDbname";
            this.lblDbname.Size = new System.Drawing.Size(79, 35);
            this.lblDbname.TabIndex = 11;
            this.lblDbname.Text = "Dbname";
            this.lblDbname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnAttach, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.grpLdf, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSearch, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpMdf, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grpNdf, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDbname, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnReset, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDbname, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnRemove, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.GrpPaths, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(429, 540);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // FrmDiscoverDetached
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 570);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpFiles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmDiscoverDetached";
            this.Text = "Discovery detached databases";
            this.Load += new System.EventHandler(this.frmDiscoverDetached_Load);
            this.GrpPaths.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpLdf.ResumeLayout(false);
            this.grpNdf.ResumeLayout(false);
            this.grpMdf.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpPaths;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lstPaths;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.GroupBox grpLdf;
        private System.Windows.Forms.ListBox lstLdf;
        private System.Windows.Forms.GroupBox grpNdf;
        private System.Windows.Forms.ListBox lstNdf;
        private System.Windows.Forms.GroupBox grpMdf;
        private System.Windows.Forms.ListBox lstMdf;
        private System.Windows.Forms.GroupBox grpFiles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.TextBox txtDbname;
        private System.Windows.Forms.Label lblDbname;
    }
}