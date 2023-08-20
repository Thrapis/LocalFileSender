using LocalFileSender.WinForms.Controls;

namespace LocalFileSender.WinForms.Views
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            TabPanel = new TabControl();
            ClientTab = new TabPage();
            TotalLabel = new Label();
            SelectSaveDirectoryButton = new Button();
            SaveDirectoryLabel = new Label();
            SaveDirectoryControl = new TextBox();
            DownloadButton = new Button();
            button2 = new Button();
            button1 = new Button();
            TotalByteSizeLabel = new Label();
            label2 = new Label();
            label1 = new Label();
            StoredFileTreeView = new TreeViewFixed();
            FileSystemIconList = new ImageList(components);
            HostnameControl = new TextBox();
            HostportControl = new NumericUpDown();
            PollButton = new Button();
            ServerTab = new TabPage();
            ServerLoggerRichBox = new RichTextBox();
            SelectSharedDirectoryButton = new Button();
            SharedDirectoryLabel = new Label();
            SharedDirectoryControl = new TextBox();
            FileServicePortLabel = new Label();
            FileServiceStartStopButton = new Button();
            FileServicePortControl = new NumericUpDown();
            GlobalTimer = new System.Windows.Forms.Timer(components);
            TabPanel.SuspendLayout();
            ClientTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HostportControl).BeginInit();
            ServerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FileServicePortControl).BeginInit();
            SuspendLayout();
            // 
            // TabPanel
            // 
            TabPanel.Controls.Add(ClientTab);
            TabPanel.Controls.Add(ServerTab);
            TabPanel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            TabPanel.Location = new Point(10, 9);
            TabPanel.Margin = new Padding(3, 2, 3, 2);
            TabPanel.Name = "TabPanel";
            TabPanel.SelectedIndex = 0;
            TabPanel.Size = new Size(681, 361);
            TabPanel.TabIndex = 0;
            // 
            // ClientTab
            // 
            ClientTab.Controls.Add(TotalLabel);
            ClientTab.Controls.Add(SelectSaveDirectoryButton);
            ClientTab.Controls.Add(SaveDirectoryLabel);
            ClientTab.Controls.Add(SaveDirectoryControl);
            ClientTab.Controls.Add(DownloadButton);
            ClientTab.Controls.Add(button2);
            ClientTab.Controls.Add(button1);
            ClientTab.Controls.Add(TotalByteSizeLabel);
            ClientTab.Controls.Add(label2);
            ClientTab.Controls.Add(label1);
            ClientTab.Controls.Add(StoredFileTreeView);
            ClientTab.Controls.Add(HostnameControl);
            ClientTab.Controls.Add(HostportControl);
            ClientTab.Controls.Add(PollButton);
            ClientTab.Location = new Point(4, 28);
            ClientTab.Margin = new Padding(3, 2, 3, 2);
            ClientTab.Name = "ClientTab";
            ClientTab.Padding = new Padding(3, 2, 3, 2);
            ClientTab.Size = new Size(673, 329);
            ClientTab.TabIndex = 0;
            ClientTab.Text = "Client";
            ClientTab.UseVisualStyleBackColor = true;
            // 
            // TotalLabel
            // 
            TotalLabel.AutoSize = true;
            TotalLabel.Location = new Point(212, 261);
            TotalLabel.Margin = new Padding(10, 9, 10, 9);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(43, 19);
            TotalLabel.TabIndex = 30;
            TotalLabel.Text = "Total:";
            // 
            // SelectSaveDirectoryButton
            // 
            SelectSaveDirectoryButton.Location = new Point(391, 294);
            SelectSaveDirectoryButton.Margin = new Padding(10, 9, 10, 9);
            SelectSaveDirectoryButton.Name = "SelectSaveDirectoryButton";
            SelectSaveDirectoryButton.Size = new Size(88, 28);
            SelectSaveDirectoryButton.TabIndex = 29;
            SelectSaveDirectoryButton.Text = "Choose";
            SelectSaveDirectoryButton.UseVisualStyleBackColor = true;
            // 
            // SaveDirectoryLabel
            // 
            SaveDirectoryLabel.AutoSize = true;
            SaveDirectoryLabel.Location = new Point(13, 299);
            SaveDirectoryLabel.Margin = new Padding(10, 9, 5, 9);
            SaveDirectoryLabel.Name = "SaveDirectoryLabel";
            SaveDirectoryLabel.Size = new Size(101, 19);
            SaveDirectoryLabel.TabIndex = 27;
            SaveDirectoryLabel.Text = "Save Directory";
            // 
            // SaveDirectoryControl
            // 
            SaveDirectoryControl.Location = new Point(130, 296);
            SaveDirectoryControl.Margin = new Padding(5, 9, 5, 9);
            SaveDirectoryControl.Name = "SaveDirectoryControl";
            SaveDirectoryControl.PlaceholderText = "Directory";
            SaveDirectoryControl.ReadOnly = true;
            SaveDirectoryControl.Size = new Size(246, 26);
            SaveDirectoryControl.TabIndex = 28;
            // 
            // DownloadButton
            // 
            DownloadButton.Location = new Point(537, 294);
            DownloadButton.Margin = new Padding(10, 9, 10, 9);
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new Size(124, 28);
            DownloadButton.TabIndex = 26;
            DownloadButton.Text = "Download";
            DownloadButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(98, 257);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(101, 28);
            button2.TabIndex = 25;
            button2.Text = "Uncheck All";
            button2.UseVisualStyleBackColor = true;
            button2.Click += UncheckAllButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(10, 257);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 28);
            button1.TabIndex = 24;
            button1.Text = "Check All";
            button1.UseVisualStyleBackColor = true;
            button1.Click += CheckAllButton_Click;
            // 
            // TotalByteSizeLabel
            // 
            TotalByteSizeLabel.AutoSize = true;
            TotalByteSizeLabel.Location = new Point(259, 261);
            TotalByteSizeLabel.Margin = new Padding(10, 9, 10, 9);
            TotalByteSizeLabel.Name = "TotalByteSizeLabel";
            TotalByteSizeLabel.Size = new Size(29, 19);
            TotalByteSizeLabel.TabIndex = 23;
            TotalByteSizeLabel.Text = "0 B";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 11);
            label2.Margin = new Padding(10, 9, 5, 9);
            label2.Name = "label2";
            label2.Size = new Size(72, 19);
            label2.TabIndex = 22;
            label2.Text = "Hostname";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(261, 11);
            label1.Margin = new Padding(10, 9, 5, 9);
            label1.Name = "label1";
            label1.Size = new Size(35, 19);
            label1.TabIndex = 21;
            label1.Text = "Port";
            // 
            // StoredFileTreeView
            // 
            StoredFileTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StoredFileTreeView.CheckBoxes = true;
            StoredFileTreeView.ImageKey = "FileDefault.png";
            StoredFileTreeView.ImageList = FileSystemIconList;
            StoredFileTreeView.ItemHeight = 34;
            StoredFileTreeView.Location = new Point(10, 40);
            StoredFileTreeView.Margin = new Padding(10, 9, 10, 9);
            StoredFileTreeView.Name = "StoredFileTreeView";
            StoredFileTreeView.SelectedImageKey = "FileDefault.png";
            StoredFileTreeView.ShowNodeToolTips = true;
            StoredFileTreeView.Size = new Size(651, 211);
            StoredFileTreeView.TabIndex = 20;
            StoredFileTreeView.AfterCheck += StoredFileTreeView_AfterCheck;
            // 
            // FileSystemIconList
            // 
            FileSystemIconList.ColorDepth = ColorDepth.Depth32Bit;
            FileSystemIconList.ImageStream = (ImageListStreamer)resources.GetObject("FileSystemIconList.ImageStream");
            FileSystemIconList.TransparentColor = Color.Transparent;
            FileSystemIconList.Images.SetKeyName(0, "FolderDefault.png");
            FileSystemIconList.Images.SetKeyName(1, "FileDefault.png");
            FileSystemIconList.Images.SetKeyName(2, "File3DS.png");
            FileSystemIconList.Images.SetKeyName(3, "FileAAC.png");
            FileSystemIconList.Images.SetKeyName(4, "FileAI.png");
            FileSystemIconList.Images.SetKeyName(5, "FileAVI.png");
            FileSystemIconList.Images.SetKeyName(6, "FileBMP.png");
            FileSystemIconList.Images.SetKeyName(7, "FileCAD.png");
            FileSystemIconList.Images.SetKeyName(8, "FileCDR.png");
            FileSystemIconList.Images.SetKeyName(9, "FileCSS.png");
            FileSystemIconList.Images.SetKeyName(10, "FileDAT.png");
            FileSystemIconList.Images.SetKeyName(11, "FileDLL.png");
            FileSystemIconList.Images.SetKeyName(12, "FileDMG.png");
            FileSystemIconList.Images.SetKeyName(13, "FileDOC.png");
            FileSystemIconList.Images.SetKeyName(14, "FileEPS.png");
            FileSystemIconList.Images.SetKeyName(15, "FileFLA.png");
            FileSystemIconList.Images.SetKeyName(16, "FileFLV.png");
            FileSystemIconList.Images.SetKeyName(17, "FileGIF.png");
            FileSystemIconList.Images.SetKeyName(18, "FileHTML.png");
            FileSystemIconList.Images.SetKeyName(19, "FileINDD.png");
            FileSystemIconList.Images.SetKeyName(20, "FileISO.png");
            FileSystemIconList.Images.SetKeyName(21, "FileJPEG.png");
            FileSystemIconList.Images.SetKeyName(22, "FileJPG.png");
            FileSystemIconList.Images.SetKeyName(23, "FileJS.png");
            FileSystemIconList.Images.SetKeyName(24, "FileMIDI.png");
            FileSystemIconList.Images.SetKeyName(25, "FileMOV.png");
            FileSystemIconList.Images.SetKeyName(26, "FileMP3.png");
            FileSystemIconList.Images.SetKeyName(27, "FileMPG.png");
            FileSystemIconList.Images.SetKeyName(28, "FilePDF.png");
            FileSystemIconList.Images.SetKeyName(29, "FilePHP.png");
            FileSystemIconList.Images.SetKeyName(30, "FilePNG.png");
            FileSystemIconList.Images.SetKeyName(31, "FilePPT.png");
            FileSystemIconList.Images.SetKeyName(32, "FilePS.png");
            FileSystemIconList.Images.SetKeyName(33, "FilePSD.png");
            FileSystemIconList.Images.SetKeyName(34, "FileRAW.png");
            FileSystemIconList.Images.SetKeyName(35, "FileSQL.png");
            FileSystemIconList.Images.SetKeyName(36, "FileSVG.png");
            FileSystemIconList.Images.SetKeyName(37, "FileTIF.png");
            FileSystemIconList.Images.SetKeyName(38, "FileTXT.png");
            FileSystemIconList.Images.SetKeyName(39, "FileWMV.png");
            FileSystemIconList.Images.SetKeyName(40, "FileXLS.png");
            FileSystemIconList.Images.SetKeyName(41, "FileXML.png");
            FileSystemIconList.Images.SetKeyName(42, "FileZIP.png");
            // 
            // HostnameControl
            // 
            HostnameControl.Location = new Point(102, 9);
            HostnameControl.Margin = new Padding(5, 9, 5, 9);
            HostnameControl.Name = "HostnameControl";
            HostnameControl.PlaceholderText = "Hostname";
            HostnameControl.Size = new Size(144, 26);
            HostnameControl.TabIndex = 18;
            // 
            // HostportControl
            // 
            HostportControl.Location = new Point(307, 9);
            HostportControl.Margin = new Padding(5, 9, 5, 9);
            HostportControl.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            HostportControl.Name = "HostportControl";
            HostportControl.Size = new Size(97, 26);
            HostportControl.TabIndex = 16;
            // 
            // PollButton
            // 
            PollButton.Location = new Point(579, 7);
            PollButton.Margin = new Padding(10, 9, 10, 9);
            PollButton.Name = "PollButton";
            PollButton.Size = new Size(82, 28);
            PollButton.TabIndex = 17;
            PollButton.Text = "Poll";
            PollButton.UseVisualStyleBackColor = true;
            // 
            // ServerTab
            // 
            ServerTab.Controls.Add(ServerLoggerRichBox);
            ServerTab.Controls.Add(SelectSharedDirectoryButton);
            ServerTab.Controls.Add(SharedDirectoryLabel);
            ServerTab.Controls.Add(SharedDirectoryControl);
            ServerTab.Controls.Add(FileServicePortLabel);
            ServerTab.Controls.Add(FileServiceStartStopButton);
            ServerTab.Controls.Add(FileServicePortControl);
            ServerTab.Location = new Point(4, 28);
            ServerTab.Margin = new Padding(3, 2, 3, 2);
            ServerTab.Name = "ServerTab";
            ServerTab.Padding = new Padding(3, 2, 3, 2);
            ServerTab.Size = new Size(673, 329);
            ServerTab.TabIndex = 1;
            ServerTab.Text = "Server";
            ServerTab.UseVisualStyleBackColor = true;
            // 
            // ServerLoggerRichBox
            // 
            ServerLoggerRichBox.Location = new Point(13, 47);
            ServerLoggerRichBox.Margin = new Padding(10, 9, 10, 9);
            ServerLoggerRichBox.Name = "ServerLoggerRichBox";
            ServerLoggerRichBox.ReadOnly = true;
            ServerLoggerRichBox.Size = new Size(648, 271);
            ServerLoggerRichBox.TabIndex = 31;
            ServerLoggerRichBox.Text = "";
            ServerLoggerRichBox.TextChanged += ServerLoggerRichBox_TextChanged;
            // 
            // SelectSharedDirectoryButton
            // 
            SelectSharedDirectoryButton.Location = new Point(331, 11);
            SelectSharedDirectoryButton.Margin = new Padding(10, 9, 5, 9);
            SelectSharedDirectoryButton.Name = "SelectSharedDirectoryButton";
            SelectSharedDirectoryButton.Size = new Size(82, 28);
            SelectSharedDirectoryButton.TabIndex = 30;
            SelectSharedDirectoryButton.Text = "Choose";
            SelectSharedDirectoryButton.UseVisualStyleBackColor = true;
            // 
            // SharedDirectoryLabel
            // 
            SharedDirectoryLabel.AutoSize = true;
            SharedDirectoryLabel.Location = new Point(13, 12);
            SharedDirectoryLabel.Margin = new Padding(10, 9, 5, 9);
            SharedDirectoryLabel.Name = "SharedDirectoryLabel";
            SharedDirectoryLabel.Size = new Size(115, 19);
            SharedDirectoryLabel.TabIndex = 17;
            SharedDirectoryLabel.Text = "Shared Directory";
            // 
            // SharedDirectoryControl
            // 
            SharedDirectoryControl.Location = new Point(145, 11);
            SharedDirectoryControl.Margin = new Padding(5, 9, 5, 9);
            SharedDirectoryControl.Name = "SharedDirectoryControl";
            SharedDirectoryControl.PlaceholderText = "Directory";
            SharedDirectoryControl.ReadOnly = true;
            SharedDirectoryControl.Size = new Size(171, 26);
            SharedDirectoryControl.TabIndex = 18;
            // 
            // FileServicePortLabel
            // 
            FileServicePortLabel.AutoSize = true;
            FileServicePortLabel.Location = new Point(424, 14);
            FileServicePortLabel.Margin = new Padding(5, 9, 5, 9);
            FileServicePortLabel.Name = "FileServicePortLabel";
            FileServicePortLabel.Size = new Size(35, 19);
            FileServicePortLabel.TabIndex = 16;
            FileServicePortLabel.Text = "Port";
            // 
            // FileServiceStartStopButton
            // 
            FileServiceStartStopButton.Location = new Point(579, 11);
            FileServiceStartStopButton.Margin = new Padding(10, 9, 10, 9);
            FileServiceStartStopButton.Name = "FileServiceStartStopButton";
            FileServiceStartStopButton.Size = new Size(82, 28);
            FileServiceStartStopButton.TabIndex = 13;
            FileServiceStartStopButton.Text = "start_stop";
            FileServiceStartStopButton.UseVisualStyleBackColor = true;
            // 
            // FileServicePortControl
            // 
            FileServicePortControl.Location = new Point(469, 12);
            FileServicePortControl.Margin = new Padding(5, 9, 5, 9);
            FileServicePortControl.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            FileServicePortControl.Name = "FileServicePortControl";
            FileServicePortControl.Size = new Size(90, 26);
            FileServicePortControl.TabIndex = 14;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 381);
            Controls.Add(TabPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(720, 420);
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Local File Sender";
            TabPanel.ResumeLayout(false);
            ClientTab.ResumeLayout(false);
            ClientTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HostportControl).EndInit();
            ServerTab.ResumeLayout(false);
            ServerTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FileServicePortControl).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox RH_;
        private TabControl TabPanel;
        private TabPage ClientTab;
        private TreeViewFixed StoredFileTreeView;
        private ImageList FileSystemIconList;
        private TextBox HostnameControl;
        private NumericUpDown HostportControl;
        private Button PollButton;
        private TabPage ServerTab;
        private System.Windows.Forms.Timer GlobalTimer;
        private Label label2;
        private Label label1;
        private Button FileServiceStartStopButton;
        private TextBox SharedDirectoryControl;
        private Label SharedDirectoryLabel;
        private Label FileServicePortLabel;
        private NumericUpDown FileServicePortControl;
        private Label TotalByteSizeLabel;
        private Button button2;
        private Button button1;
        private Button DownloadButton;
        private Label SaveDirectoryLabel;
        private TextBox SaveDirectoryControl;
        private Button SelectSaveDirectoryButton;
        private Button SelectSharedDirectoryButton;
        private Label TotalLabel;
        private RichTextBox ServerLoggerRichBox;
    }
}