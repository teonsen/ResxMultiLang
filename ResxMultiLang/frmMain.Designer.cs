namespace ResxMultiLang
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile_OpenResx = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFile_OpenRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFile_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpTranslate = new System.Windows.Forms.GroupBox();
            this.radioFromEnglish = new System.Windows.Forms.RadioButton();
            this.radioFromJapanese = new System.Windows.Forms.RadioButton();
            this.radioFromChinese = new System.Windows.Forms.RadioButton();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.txtToTranslate = new System.Windows.Forms.TextBox();
            this.reoGrid = new unvell.ReoGrid.ReoGridControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpTranslate.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1154, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile_OpenResx,
            this.tsmiFile_OpenRecent,
            this.toolStripSeparator1,
            this.tsmiFile_Save,
            this.toolStripSeparator3,
            this.tsmiFile_Export,
            this.toolStripSeparator2,
            this.tsmiFile_Exit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "File";
            // 
            // tsmiFile_OpenResx
            // 
            this.tsmiFile_OpenResx.Name = "tsmiFile_OpenResx";
            this.tsmiFile_OpenResx.Size = new System.Drawing.Size(166, 22);
            this.tsmiFile_OpenResx.Text = "Open (from .resx)";
            this.tsmiFile_OpenResx.Click += new System.EventHandler(this.tsmiFile_OpenResx_Click);
            // 
            // tsmiFile_OpenRecent
            // 
            this.tsmiFile_OpenRecent.Name = "tsmiFile_OpenRecent";
            this.tsmiFile_OpenRecent.Size = new System.Drawing.Size(166, 22);
            this.tsmiFile_OpenRecent.Text = "Open Recent";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // tsmiFile_Save
            // 
            this.tsmiFile_Save.Enabled = false;
            this.tsmiFile_Save.Name = "tsmiFile_Save";
            this.tsmiFile_Save.Size = new System.Drawing.Size(166, 22);
            this.tsmiFile_Save.Text = "Save (to .resx)";
            this.tsmiFile_Save.Click += new System.EventHandler(this.tsmiFile_Save_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(163, 6);
            // 
            // tsmiFile_Export
            // 
            this.tsmiFile_Export.Enabled = false;
            this.tsmiFile_Export.Name = "tsmiFile_Export";
            this.tsmiFile_Export.Size = new System.Drawing.Size(166, 22);
            this.tsmiFile_Export.Text = "Export (to .xlsx)";
            this.tsmiFile_Export.Click += new System.EventHandler(this.tsmiFile_Export_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // tsmiFile_Exit
            // 
            this.tsmiFile_Exit.Name = "tsmiFile_Exit";
            this.tsmiFile_Exit.Size = new System.Drawing.Size(166, 22);
            this.tsmiFile_Exit.Text = "Exit";
            this.tsmiFile_Exit.Click += new System.EventHandler(this.tsmiFile_Exit_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            this.splitContainer1.Panel1.Controls.Add(this.grpTranslate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reoGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1154, 594);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(970, 41);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(138, 60);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save to .resx";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpTranslate
            // 
            this.grpTranslate.Controls.Add(this.radioFromEnglish);
            this.grpTranslate.Controls.Add(this.radioFromJapanese);
            this.grpTranslate.Controls.Add(this.radioFromChinese);
            this.grpTranslate.Controls.Add(this.btnTranslate);
            this.grpTranslate.Controls.Add(this.txtToTranslate);
            this.grpTranslate.Enabled = false;
            this.grpTranslate.Location = new System.Drawing.Point(21, 12);
            this.grpTranslate.Name = "grpTranslate";
            this.grpTranslate.Size = new System.Drawing.Size(724, 110);
            this.grpTranslate.TabIndex = 25;
            this.grpTranslate.TabStop = false;
            this.grpTranslate.Text = "Translate";
            // 
            // radioFromEnglish
            // 
            this.radioFromEnglish.AutoSize = true;
            this.radioFromEnglish.Location = new System.Drawing.Point(24, 73);
            this.radioFromEnglish.Name = "radioFromEnglish";
            this.radioFromEnglish.Size = new System.Drawing.Size(90, 16);
            this.radioFromEnglish.TabIndex = 28;
            this.radioFromEnglish.Text = "From English";
            this.radioFromEnglish.UseVisualStyleBackColor = true;
            // 
            // radioFromJapanese
            // 
            this.radioFromJapanese.AutoSize = true;
            this.radioFromJapanese.Location = new System.Drawing.Point(24, 51);
            this.radioFromJapanese.Name = "radioFromJapanese";
            this.radioFromJapanese.Size = new System.Drawing.Size(102, 16);
            this.radioFromJapanese.TabIndex = 27;
            this.radioFromJapanese.Text = "From Japanese";
            this.radioFromJapanese.UseVisualStyleBackColor = true;
            // 
            // radioFromChinese
            // 
            this.radioFromChinese.AutoSize = true;
            this.radioFromChinese.Checked = true;
            this.radioFromChinese.Location = new System.Drawing.Point(24, 29);
            this.radioFromChinese.Name = "radioFromChinese";
            this.radioFromChinese.Size = new System.Drawing.Size(94, 16);
            this.radioFromChinese.TabIndex = 26;
            this.radioFromChinese.TabStop = true;
            this.radioFromChinese.Text = "From Chinese";
            this.radioFromChinese.UseVisualStyleBackColor = true;
            // 
            // btnTranslate
            // 
            this.btnTranslate.Location = new System.Drawing.Point(565, 29);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(142, 60);
            this.btnTranslate.TabIndex = 25;
            this.btnTranslate.Text = "Translate it by Google";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // txtToTranslate
            // 
            this.txtToTranslate.Location = new System.Drawing.Point(149, 29);
            this.txtToTranslate.Multiline = true;
            this.txtToTranslate.Name = "txtToTranslate";
            this.txtToTranslate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtToTranslate.Size = new System.Drawing.Size(390, 60);
            this.txtToTranslate.TabIndex = 23;
            // 
            // reoGrid
            // 
            this.reoGrid.BackColor = System.Drawing.Color.White;
            this.reoGrid.ColumnHeaderContextMenuStrip = null;
            this.reoGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reoGrid.Enabled = false;
            this.reoGrid.LeadHeaderContextMenuStrip = null;
            this.reoGrid.Location = new System.Drawing.Point(0, 0);
            this.reoGrid.Name = "reoGrid";
            this.reoGrid.RowHeaderContextMenuStrip = null;
            this.reoGrid.Script = null;
            this.reoGrid.SheetTabContextMenuStrip = null;
            this.reoGrid.SheetTabNewButtonVisible = true;
            this.reoGrid.SheetTabVisible = true;
            this.reoGrid.SheetTabWidth = 60;
            this.reoGrid.ShowScrollEndSpacing = true;
            this.reoGrid.Size = new System.Drawing.Size(1154, 440);
            this.reoGrid.TabIndex = 1;
            this.reoGrid.Text = "reoGridControl1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 618);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "ResxMultiLang";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpTranslate.ResumeLayout(false);
            this.grpTranslate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_OpenResx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_Export;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_Exit;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile_OpenRecent;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpTranslate;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.TextBox txtToTranslate;
        private unvell.ReoGrid.ReoGridControl reoGrid;
        private System.Windows.Forms.RadioButton radioFromEnglish;
        private System.Windows.Forms.RadioButton radioFromJapanese;
        private System.Windows.Forms.RadioButton radioFromChinese;
        private System.Windows.Forms.Button btnSave;
    }
}

