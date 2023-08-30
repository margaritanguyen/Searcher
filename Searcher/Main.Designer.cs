namespace Searcher
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
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.directoryBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lblDirectoryPath = new System.Windows.Forms.Label();
            this.tbMask = new System.Windows.Forms.TextBox();
            this.numericThreadCount = new System.Windows.Forms.NumericUpDown();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFoundFilesCount = new System.Windows.Forms.Label();
            this.btnCollapseAll = new System.Windows.Forms.Button();
            this.btnExpandAll = new System.Windows.Forms.Button();
            this.lblThreadCountTitle = new System.Windows.Forms.Label();
            this.lblMaskTitle = new System.Windows.Forms.Label();
            this.lblDirectoryPathTitle = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeViewFiles = new Searcher.SearcherTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.numericThreadCount)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lblDirectoryPath
            // 
            this.lblDirectoryPath.BackColor = System.Drawing.Color.White;
            this.lblDirectoryPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDirectoryPath.Location = new System.Drawing.Point(12, 39);
            this.lblDirectoryPath.Name = "lblDirectoryPath";
            this.lblDirectoryPath.Size = new System.Drawing.Size(217, 20);
            this.lblDirectoryPath.TabIndex = 2;
            this.lblDirectoryPath.Text = "C:\\";
            this.lblDirectoryPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDirectoryPath.Click += new System.EventHandler(this.lblDirectoryPath_Click);
            // 
            // tbMask
            // 
            this.tbMask.Location = new System.Drawing.Point(235, 39);
            this.tbMask.Name = "tbMask";
            this.tbMask.Size = new System.Drawing.Size(200, 20);
            this.tbMask.TabIndex = 4;
            this.tbMask.Text = "*";
            // 
            // numericThreadCount
            // 
            this.numericThreadCount.Location = new System.Drawing.Point(441, 39);
            this.numericThreadCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericThreadCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericThreadCount.Name = "numericThreadCount";
            this.numericThreadCount.Size = new System.Drawing.Size(120, 20);
            this.numericThreadCount.TabIndex = 5;
            this.numericThreadCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(567, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 20);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(648, 39);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 20);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Остановить поиск";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lblThreadCountTitle);
            this.panel1.Controls.Add(this.lblMaskTitle);
            this.panel1.Controls.Add(this.lblDirectoryPathTitle);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.lblDirectoryPath);
            this.panel1.Controls.Add(this.tbMask);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.numericThreadCount);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 98);
            this.panel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lblFoundFilesCount);
            this.panel3.Controls.Add(this.btnCollapseAll);
            this.panel3.Controls.Add(this.btnExpandAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(775, 23);
            this.panel3.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Найдено: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFoundFilesCount
            // 
            this.lblFoundFilesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFoundFilesCount.Location = new System.Drawing.Point(63, 0);
            this.lblFoundFilesCount.Name = "lblFoundFilesCount";
            this.lblFoundFilesCount.Size = new System.Drawing.Size(77, 23);
            this.lblFoundFilesCount.TabIndex = 15;
            this.lblFoundFilesCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCollapseAll.FlatAppearance.BorderSize = 0;
            this.btnCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapseAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCollapseAll.Location = new System.Drawing.Point(589, 0);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(90, 23);
            this.btnCollapseAll.TabIndex = 8;
            this.btnCollapseAll.Text = "Свернуть все";
            this.btnCollapseAll.UseVisualStyleBackColor = true;
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExpandAll.FlatAppearance.BorderSize = 0;
            this.btnExpandAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExpandAll.Location = new System.Drawing.Point(679, 0);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(96, 23);
            this.btnExpandAll.TabIndex = 9;
            this.btnExpandAll.Text = "Развернуть все";
            this.btnExpandAll.UseVisualStyleBackColor = true;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // lblThreadCountTitle
            // 
            this.lblThreadCountTitle.AutoSize = true;
            this.lblThreadCountTitle.Location = new System.Drawing.Point(441, 24);
            this.lblThreadCountTitle.Name = "lblThreadCountTitle";
            this.lblThreadCountTitle.Size = new System.Drawing.Size(110, 13);
            this.lblThreadCountTitle.TabIndex = 13;
            this.lblThreadCountTitle.Text = "Количество потоков";
            // 
            // lblMaskTitle
            // 
            this.lblMaskTitle.AutoSize = true;
            this.lblMaskTitle.Location = new System.Drawing.Point(235, 24);
            this.lblMaskTitle.Name = "lblMaskTitle";
            this.lblMaskTitle.Size = new System.Drawing.Size(40, 13);
            this.lblMaskTitle.TabIndex = 12;
            this.lblMaskTitle.Text = "Маска";
            // 
            // lblDirectoryPathTitle
            // 
            this.lblDirectoryPathTitle.AutoSize = true;
            this.lblDirectoryPathTitle.Location = new System.Drawing.Point(12, 24);
            this.lblDirectoryPathTitle.Name = "lblDirectoryPathTitle";
            this.lblDirectoryPathTitle.Size = new System.Drawing.Size(69, 13);
            this.lblDirectoryPathTitle.TabIndex = 11;
            this.lblDirectoryPathTitle.Text = "Директория";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.LightGray;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.Enabled = false;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(775, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.treeViewFiles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 432);
            this.panel2.TabIndex = 10;
            // 
            // treeViewFiles
            // 
            this.treeViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFiles.ImageIndex = 0;
            this.treeViewFiles.ImageList = this.imageList;
            this.treeViewFiles.Location = new System.Drawing.Point(0, 0);
            this.treeViewFiles.Name = "treeViewFiles";
            this.treeViewFiles.SelectedImageIndex = 0;
            this.treeViewFiles.Size = new System.Drawing.Size(775, 432);
            this.treeViewFiles.TabIndex = 1;
            this.treeViewFiles.NodeMouseDoubleClick += treeViewFiles_NodeMouseDoubleClick;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 530);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(790, 39);
            this.Name = "Main";
            this.Text = "Searcher";
            ((System.ComponentModel.ISupportInitialize)(this.numericThreadCount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void TreeViewFiles_NodeMouseDoubleClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog directoryBrowserDialog;
        private System.Windows.Forms.Label lblDirectoryPath;
        private System.Windows.Forms.TextBox tbMask;
        private System.Windows.Forms.NumericUpDown numericThreadCount;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExpandAll;
        private System.Windows.Forms.Button btnCollapseAll;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblDirectoryPathTitle;
        private System.Windows.Forms.Label lblThreadCountTitle;
        private System.Windows.Forms.Label lblMaskTitle;
        private System.Windows.Forms.Label lblFoundFilesCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private SearcherTreeView treeViewFiles;
    }
}

