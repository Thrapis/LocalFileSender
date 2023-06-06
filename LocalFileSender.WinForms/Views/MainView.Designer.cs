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
            TabPanel.Location = new Point(12, 12);
            TabPanel.Name = "TabPanel";
            TabPanel.SelectedIndex = 0;
            TabPanel.Size = new Size(778, 429);
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
            ClientTab.Location = new Point(4, 32);
            ClientTab.Name = "ClientTab";
            ClientTab.Padding = new Padding(3);
            ClientTab.Size = new Size(770, 393);
            ClientTab.TabIndex = 0;
            ClientTab.Text = "Client";
            ClientTab.UseVisualStyleBackColor = true;
            // 
            // TotalLabel
            // 
            TotalLabel.AutoSize = true;
            TotalLabel.Location = new Point(242, 296);
            TotalLabel.Margin = new Padding(12);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(50, 23);
            TotalLabel.TabIndex = 30;
            TotalLabel.Text = "Total:";
            // 
            // SelectSaveDirectoryButton
            // 
            SelectSaveDirectoryButton.Location = new Point(447, 351);
            SelectSaveDirectoryButton.Margin = new Padding(12);
            SelectSaveDirectoryButton.Name = "SelectSaveDirectoryButton";
            SelectSaveDirectoryButton.Size = new Size(100, 30);
            SelectSaveDirectoryButton.TabIndex = 29;
            SelectSaveDirectoryButton.Text = "Choose";
            SelectSaveDirectoryButton.UseVisualStyleBackColor = true;
            // 
            // SaveDirectoryLabel
            // 
            SaveDirectoryLabel.AutoSize = true;
            SaveDirectoryLabel.Location = new Point(15, 354);
            SaveDirectoryLabel.Margin = new Padding(12, 12, 6, 12);
            SaveDirectoryLabel.Name = "SaveDirectoryLabel";
            SaveDirectoryLabel.Size = new Size(122, 23);
            SaveDirectoryLabel.TabIndex = 27;
            SaveDirectoryLabel.Text = "Save Directory";
            // 
            // SaveDirectoryControl
            // 
            SaveDirectoryControl.Location = new Point(149, 351);
            SaveDirectoryControl.Margin = new Padding(6, 12, 6, 12);
            SaveDirectoryControl.Name = "SaveDirectoryControl";
            SaveDirectoryControl.PlaceholderText = "Directory";
            SaveDirectoryControl.ReadOnly = true;
            SaveDirectoryControl.Size = new Size(280, 30);
            SaveDirectoryControl.TabIndex = 28;
            // 
            // DownloadButton
            // 
            DownloadButton.Location = new Point(613, 351);
            DownloadButton.Margin = new Padding(12);
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new Size(142, 30);
            DownloadButton.TabIndex = 26;
            DownloadButton.Text = "Download";
            DownloadButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(112, 293);
            button2.Name = "button2";
            button2.Size = new Size(115, 29);
            button2.TabIndex = 25;
            button2.Text = "Uncheck All";
            button2.UseVisualStyleBackColor = true;
            button2.Click += UncheckAllButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 293);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 24;
            button1.Text = "Check All";
            button1.UseVisualStyleBackColor = true;
            button1.Click += CheckAllButton_Click;
            // 
            // TotalByteSizeLabel
            // 
            TotalByteSizeLabel.AutoSize = true;
            TotalByteSizeLabel.Location = new Point(296, 296);
            TotalByteSizeLabel.Margin = new Padding(12);
            TotalByteSizeLabel.Name = "TotalByteSizeLabel";
            TotalByteSizeLabel.Size = new Size(34, 23);
            TotalByteSizeLabel.TabIndex = 23;
            TotalByteSizeLabel.Text = "0 B";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 15);
            label2.Margin = new Padding(12, 12, 6, 12);
            label2.Name = "label2";
            label2.Size = new Size(89, 23);
            label2.TabIndex = 22;
            label2.Text = "Hostname";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(298, 15);
            label1.Margin = new Padding(12, 12, 6, 12);
            label1.Name = "label1";
            label1.Size = new Size(41, 23);
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
            StoredFileTreeView.Location = new Point(12, 53);
            StoredFileTreeView.Margin = new Padding(12);
            StoredFileTreeView.Name = "StoredFileTreeView";
            StoredFileTreeView.SelectedImageKey = "FileDefault.png";
            StoredFileTreeView.ShowNodeToolTips = true;
            StoredFileTreeView.Size = new Size(743, 228);
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
            HostnameControl.Location = new Point(116, 12);
            HostnameControl.Margin = new Padding(6, 12, 6, 12);
            HostnameControl.Name = "HostnameControl";
            HostnameControl.PlaceholderText = "Hostname";
            HostnameControl.Size = new Size(164, 30);
            HostnameControl.TabIndex = 18;
            // 
            // HostportControl
            // 
            HostportControl.Location = new Point(351, 12);
            HostportControl.Margin = new Padding(6, 12, 6, 12);
            HostportControl.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            HostportControl.Name = "HostportControl";
            HostportControl.Size = new Size(111, 30);
            HostportControl.TabIndex = 16;
            // 
            // PollButton
            // 
            PollButton.Location = new Point(661, 12);
            PollButton.Margin = new Padding(12);
            PollButton.Name = "PollButton";
            PollButton.Size = new Size(94, 30);
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
            ServerTab.Location = new Point(4, 32);
            ServerTab.Name = "ServerTab";
            ServerTab.Padding = new Padding(3);
            ServerTab.Size = new Size(770, 393);
            ServerTab.TabIndex = 1;
            ServerTab.Text = "Server";
            ServerTab.UseVisualStyleBackColor = true;
            // 
            // ServerLoggerRichBox
            // 
            ServerLoggerRichBox.Location = new Point(15, 63);
            ServerLoggerRichBox.Margin = new Padding(12);
            ServerLoggerRichBox.Name = "ServerLoggerRichBox";
            ServerLoggerRichBox.ReadOnly = true;
            ServerLoggerRichBox.Size = new Size(740, 315);
            ServerLoggerRichBox.TabIndex = 31;
            ServerLoggerRichBox.Text = "";
            ServerLoggerRichBox.TextChanged += ServerLoggerRichBox_TextChanged;
            // 
            // SelectSharedDirectoryButton
            // 
            SelectSharedDirectoryButton.Location = new Point(379, 15);
            SelectSharedDirectoryButton.Margin = new Padding(12, 12, 6, 12);
            SelectSharedDirectoryButton.Name = "SelectSharedDirectoryButton";
            SelectSharedDirectoryButton.Size = new Size(94, 30);
            SelectSharedDirectoryButton.TabIndex = 30;
            SelectSharedDirectoryButton.Text = "Choose";
            SelectSharedDirectoryButton.UseVisualStyleBackColor = true;
            // 
            // SharedDirectoryLabel
            // 
            SharedDirectoryLabel.AutoSize = true;
            SharedDirectoryLabel.Location = new Point(15, 16);
            SharedDirectoryLabel.Margin = new Padding(12, 12, 6, 12);
            SharedDirectoryLabel.Name = "SharedDirectoryLabel";
            SharedDirectoryLabel.Size = new Size(139, 23);
            SharedDirectoryLabel.TabIndex = 17;
            SharedDirectoryLabel.Text = "Shared Directory";
            // 
            // SharedDirectoryControl
            // 
            SharedDirectoryControl.Location = new Point(166, 15);
            SharedDirectoryControl.Margin = new Padding(6, 12, 6, 12);
            SharedDirectoryControl.Name = "SharedDirectoryControl";
            SharedDirectoryControl.PlaceholderText = "Directory";
            SharedDirectoryControl.ReadOnly = true;
            SharedDirectoryControl.Size = new Size(195, 30);
            SharedDirectoryControl.TabIndex = 18;
            // 
            // FileServicePortLabel
            // 
            FileServicePortLabel.AutoSize = true;
            FileServicePortLabel.Location = new Point(485, 19);
            FileServicePortLabel.Margin = new Padding(6, 12, 6, 12);
            FileServicePortLabel.Name = "FileServicePortLabel";
            FileServicePortLabel.Size = new Size(41, 23);
            FileServicePortLabel.TabIndex = 16;
            FileServicePortLabel.Text = "Port";
            // 
            // FileServiceStartStopButton
            // 
            FileServiceStartStopButton.Location = new Point(664, 15);
            FileServiceStartStopButton.Margin = new Padding(12);
            FileServiceStartStopButton.Name = "FileServiceStartStopButton";
            FileServiceStartStopButton.Size = new Size(94, 30);
            FileServiceStartStopButton.TabIndex = 13;
            FileServiceStartStopButton.Text = "start_stop";
            FileServiceStartStopButton.UseVisualStyleBackColor = true;
            // 
            // FileServicePortControl
            // 
            FileServicePortControl.Location = new Point(538, 15);
            FileServicePortControl.Margin = new Padding(6, 12, 6, 12);
            FileServicePortControl.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            FileServicePortControl.Name = "FileServicePortControl";
            FileServicePortControl.Size = new Size(103, 30);
            FileServicePortControl.TabIndex = 14;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 453);
            Controls.Add(TabPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(820, 500);
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