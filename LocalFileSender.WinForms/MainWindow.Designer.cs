namespace LocalFileSender.WinForms
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            MainSplitContainer = new SplitContainer();
            TotalByteSizeLabel = new Label();
            TotalLabel = new Label();
            UncheckAllButton = new Button();
            CheckAllButton = new Button();
            StoredFileTreeView = new TreeViewFixed();
            HierarchyImageList = new ImageList(components);
            ClientToolStrip = new ToolStrip();
            DownloadProgressBar = new ToolStripProgressBar();
            NotifyMessageImage = new ToolStripButton();
            NotifyMessageLabel = new ToolStripLabel();
            DownloadButton = new Button();
            SaveDirectoryControl = new TextBox();
            HostnameControl = new TextBox();
            HostPortControl = new NumericUpDown();
            PollButton = new Button();
            ClientLabel = new Label();
            FileServiceStartStopButton = new Button();
            SharedDirectoryControl = new TextBox();
            DirectoryLabel = new Label();
            FileServicePortLabel = new Label();
            FileServiceLabel = new Label();
            FileServicePortControl = new NumericUpDown();
            ServerLabel = new Label();
            GlobalTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).BeginInit();
            MainSplitContainer.Panel1.SuspendLayout();
            MainSplitContainer.Panel2.SuspendLayout();
            MainSplitContainer.SuspendLayout();
            ClientToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HostPortControl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FileServicePortControl).BeginInit();
            SuspendLayout();
            // 
            // MainSplitContainer
            // 
            MainSplitContainer.Dock = DockStyle.Fill;
            MainSplitContainer.IsSplitterFixed = true;
            MainSplitContainer.Location = new Point(0, 0);
            MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            MainSplitContainer.Panel1.Controls.Add(TotalByteSizeLabel);
            MainSplitContainer.Panel1.Controls.Add(TotalLabel);
            MainSplitContainer.Panel1.Controls.Add(UncheckAllButton);
            MainSplitContainer.Panel1.Controls.Add(CheckAllButton);
            MainSplitContainer.Panel1.Controls.Add(StoredFileTreeView);
            MainSplitContainer.Panel1.Controls.Add(ClientToolStrip);
            MainSplitContainer.Panel1.Controls.Add(DownloadButton);
            MainSplitContainer.Panel1.Controls.Add(SaveDirectoryControl);
            MainSplitContainer.Panel1.Controls.Add(HostnameControl);
            MainSplitContainer.Panel1.Controls.Add(HostPortControl);
            MainSplitContainer.Panel1.Controls.Add(PollButton);
            MainSplitContainer.Panel1.Controls.Add(ClientLabel);
            // 
            // MainSplitContainer.Panel2
            // 
            MainSplitContainer.Panel2.Controls.Add(FileServiceStartStopButton);
            MainSplitContainer.Panel2.Controls.Add(SharedDirectoryControl);
            MainSplitContainer.Panel2.Controls.Add(DirectoryLabel);
            MainSplitContainer.Panel2.Controls.Add(FileServicePortLabel);
            MainSplitContainer.Panel2.Controls.Add(FileServiceLabel);
            MainSplitContainer.Panel2.Controls.Add(FileServicePortControl);
            MainSplitContainer.Panel2.Controls.Add(ServerLabel);
            MainSplitContainer.Size = new Size(800, 459);
            MainSplitContainer.SplitterDistance = 400;
            MainSplitContainer.TabIndex = 0;
            // 
            // TotalByteSizeLabel
            // 
            TotalByteSizeLabel.AutoSize = true;
            TotalByteSizeLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TotalByteSizeLabel.Location = new Point(303, 366);
            TotalByteSizeLabel.Name = "TotalByteSizeLabel";
            TotalByteSizeLabel.Size = new Size(31, 20);
            TotalByteSizeLabel.TabIndex = 17;
            TotalByteSizeLabel.Text = "0 B";
            // 
            // TotalLabel
            // 
            TotalLabel.AutoSize = true;
            TotalLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            TotalLabel.Location = new Point(249, 366);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(47, 20);
            TotalLabel.TabIndex = 6;
            TotalLabel.Text = "Total:";
            // 
            // UncheckAllButton
            // 
            UncheckAllButton.Location = new Point(112, 363);
            UncheckAllButton.Name = "UncheckAllButton";
            UncheckAllButton.Size = new Size(94, 29);
            UncheckAllButton.TabIndex = 16;
            UncheckAllButton.Text = "Uncheck All";
            UncheckAllButton.UseVisualStyleBackColor = true;
            UncheckAllButton.Click += UncheckAllButton_Click;
            // 
            // CheckAllButton
            // 
            CheckAllButton.Location = new Point(12, 363);
            CheckAllButton.Name = "CheckAllButton";
            CheckAllButton.Size = new Size(94, 29);
            CheckAllButton.TabIndex = 15;
            CheckAllButton.Text = "Check All";
            CheckAllButton.UseVisualStyleBackColor = true;
            CheckAllButton.Click += CheckAllButton_Click;
            // 
            // StoredFileTreeView
            // 
            StoredFileTreeView.CheckBoxes = true;
            StoredFileTreeView.Location = new Point(12, 68);
            StoredFileTreeView.Name = "StoredFileTreeView";
            StoredFileTreeView.ShowNodeToolTips = true;
            StoredFileTreeView.Size = new Size(373, 289);
            StoredFileTreeView.TabIndex = 14;
            StoredFileTreeView.AfterCheck += StoredFileTreeView_AfterCheck;
            // 
            // HierarchyImageList
            // 
            HierarchyImageList.ColorDepth = ColorDepth.Depth8Bit;
            HierarchyImageList.ImageStream = (ImageListStreamer)resources.GetObject("HierarchyImageList.ImageStream");
            HierarchyImageList.TransparentColor = Color.Transparent;
            HierarchyImageList.Images.SetKeyName(0, "Folder.png");
            HierarchyImageList.Images.SetKeyName(1, "FileDefault.png");
            // 
            // ClientToolStrip
            // 
            ClientToolStrip.Dock = DockStyle.Bottom;
            ClientToolStrip.ImageScalingSize = new Size(20, 20);
            ClientToolStrip.Items.AddRange(new ToolStripItem[] { DownloadProgressBar, NotifyMessageImage, NotifyMessageLabel });
            ClientToolStrip.Location = new Point(0, 432);
            ClientToolStrip.Name = "ClientToolStrip";
            ClientToolStrip.Size = new Size(400, 27);
            ClientToolStrip.TabIndex = 13;
            ClientToolStrip.Text = "ToolStrip";
            // 
            // DownloadProgressBar
            // 
            DownloadProgressBar.Name = "DownloadProgressBar";
            DownloadProgressBar.Size = new Size(100, 24);
            // 
            // NotifyMessageImage
            // 
            NotifyMessageImage.DisplayStyle = ToolStripItemDisplayStyle.Image;
            NotifyMessageImage.Image = (Image)resources.GetObject("NotifyMessageImage.Image");
            NotifyMessageImage.ImageTransparentColor = Color.Magenta;
            NotifyMessageImage.Name = "NotifyMessageImage";
            NotifyMessageImage.Size = new Size(29, 24);
            // 
            // NotifyMessageLabel
            // 
            NotifyMessageLabel.Name = "NotifyMessageLabel";
            NotifyMessageLabel.Size = new Size(45, 24);
            NotifyMessageLabel.Text = "______";
            // 
            // DownloadButton
            // 
            DownloadButton.Location = new Point(291, 396);
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new Size(94, 29);
            DownloadButton.TabIndex = 11;
            DownloadButton.Text = "Download";
            DownloadButton.UseVisualStyleBackColor = true;
            DownloadButton.Click += DownloadButton_Click;
            // 
            // SaveDirectoryControl
            // 
            SaveDirectoryControl.Location = new Point(12, 398);
            SaveDirectoryControl.Name = "SaveDirectoryControl";
            SaveDirectoryControl.PlaceholderText = "Directory";
            SaveDirectoryControl.ReadOnly = true;
            SaveDirectoryControl.Size = new Size(273, 27);
            SaveDirectoryControl.TabIndex = 10;
            SaveDirectoryControl.Click += SaveDirectoryControl_Click;
            SaveDirectoryControl.TextChanged += SaveDirectoryControl_TextChanged;
            // 
            // HostnameControl
            // 
            HostnameControl.Location = new Point(12, 35);
            HostnameControl.Name = "HostnameControl";
            HostnameControl.PlaceholderText = "Hostname";
            HostnameControl.Size = new Size(164, 27);
            HostnameControl.TabIndex = 7;
            HostnameControl.TextChanged += HostnameControl_TextChanged;
            // 
            // HostPortControl
            // 
            HostPortControl.Location = new Point(182, 35);
            HostPortControl.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            HostPortControl.Name = "HostPortControl";
            HostPortControl.Size = new Size(103, 27);
            HostPortControl.TabIndex = 6;
            HostPortControl.ValueChanged += HostPortControl_ValueChanged;
            // 
            // PollButton
            // 
            PollButton.Location = new Point(291, 33);
            PollButton.Name = "PollButton";
            PollButton.Size = new Size(94, 29);
            PollButton.TabIndex = 6;
            PollButton.Text = "Poll";
            PollButton.UseVisualStyleBackColor = true;
            PollButton.Click += PollButton_Click;
            // 
            // ClientLabel
            // 
            ClientLabel.AutoSize = true;
            ClientLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ClientLabel.Location = new Point(173, 9);
            ClientLabel.Name = "ClientLabel";
            ClientLabel.Size = new Size(52, 20);
            ClientLabel.TabIndex = 1;
            ClientLabel.Text = "Client";
            // 
            // FileServiceStartStopButton
            // 
            FileServiceStartStopButton.Location = new Point(290, 32);
            FileServiceStartStopButton.Name = "FileServiceStartStopButton";
            FileServiceStartStopButton.Size = new Size(94, 29);
            FileServiceStartStopButton.TabIndex = 1;
            FileServiceStartStopButton.Text = "Start";
            FileServiceStartStopButton.UseVisualStyleBackColor = true;
            FileServiceStartStopButton.Click += FileServiceStartStopButton_Click;
            // 
            // SharedDirectoryControl
            // 
            SharedDirectoryControl.Location = new Point(135, 116);
            SharedDirectoryControl.Name = "SharedDirectoryControl";
            SharedDirectoryControl.PlaceholderText = "Directory";
            SharedDirectoryControl.ReadOnly = true;
            SharedDirectoryControl.Size = new Size(249, 27);
            SharedDirectoryControl.TabIndex = 5;
            SharedDirectoryControl.Click += DirectoryControl_Click;
            SharedDirectoryControl.TextChanged += DirectoryControl_TextChanged;
            // 
            // DirectoryLabel
            // 
            DirectoryLabel.AutoSize = true;
            DirectoryLabel.Location = new Point(12, 119);
            DirectoryLabel.Name = "DirectoryLabel";
            DirectoryLabel.Size = new Size(70, 20);
            DirectoryLabel.TabIndex = 4;
            DirectoryLabel.Text = "Directory";
            // 
            // FileServicePortLabel
            // 
            FileServicePortLabel.AutoSize = true;
            FileServicePortLabel.Location = new Point(12, 80);
            FileServicePortLabel.Name = "FileServicePortLabel";
            FileServicePortLabel.Size = new Size(35, 20);
            FileServicePortLabel.TabIndex = 3;
            FileServicePortLabel.Text = "Port";
            // 
            // FileServiceLabel
            // 
            FileServiceLabel.AutoSize = true;
            FileServiceLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FileServiceLabel.Location = new Point(12, 35);
            FileServiceLabel.Name = "FileServiceLabel";
            FileServiceLabel.Size = new Size(87, 20);
            FileServiceLabel.TabIndex = 2;
            FileServiceLabel.Text = "File Service";
            // 
            // FileServicePortControl
            // 
            FileServicePortControl.Location = new Point(135, 78);
            FileServicePortControl.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            FileServicePortControl.Name = "FileServicePortControl";
            FileServicePortControl.Size = new Size(249, 27);
            FileServicePortControl.TabIndex = 1;
            FileServicePortControl.ValueChanged += FileServicePortControl_ValueChanged;
            // 
            // ServerLabel
            // 
            ServerLabel.AutoSize = true;
            ServerLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            ServerLabel.Location = new Point(176, 9);
            ServerLabel.Name = "ServerLabel";
            ServerLabel.Size = new Size(53, 20);
            ServerLabel.TabIndex = 0;
            ServerLabel.Text = "Server";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 459);
            Controls.Add(MainSplitContainer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Local File Sender";
            MainSplitContainer.Panel1.ResumeLayout(false);
            MainSplitContainer.Panel1.PerformLayout();
            MainSplitContainer.Panel2.ResumeLayout(false);
            MainSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)MainSplitContainer).EndInit();
            MainSplitContainer.ResumeLayout(false);
            ClientToolStrip.ResumeLayout(false);
            ClientToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HostPortControl).EndInit();
            ((System.ComponentModel.ISupportInitialize)FileServicePortControl).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer MainSplitContainer;
        private Label ClientLabel;
        private TextBox SharedDirectoryControl;
        private Label DirectoryLabel;
        private Label FileServicePortLabel;
        private Label FileServiceLabel;
        private NumericUpDown FileServicePortControl;
        private Label ServerLabel;
        private Button FileServiceStartStopButton;
        private Button PollButton;
        private TextBox HostnameControl;
        private NumericUpDown HostPortControl;
        private Button DownloadButton;
        private TextBox SaveDirectoryControl;
        private TextBox RH_;
        private ToolStrip ClientToolStrip;
        private ToolStripButton NotifyMessageImage;
        private ToolStripLabel NotifyMessageLabel;
        private System.Windows.Forms.Timer GlobalTimer;
        private ToolStripProgressBar DownloadProgressBar;
        private TreeViewFixed StoredFileTreeView;
        private Label TotalByteSizeLabel;
        private Label TotalLabel;
        private Button UncheckAllButton;
        private Button CheckAllButton;
        private ImageList HierarchyImageList;
    }
}