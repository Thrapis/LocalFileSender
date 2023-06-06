using LocalFileSender.Library.Client;
using LocalFileSender.Library.Connection;
using LocalFileSender.Library.Logger;
using LocalFileSender.Library.Models.Bytes;
using LocalFileSender.Library.Models.Storage;
using LocalFileSender.Library.Services;
using LocalFileSender.WinForms.Controls;
using LocalFileSender.WinForms.Models;
using LocalFileSender.WinForms.Properties;
using LocalFileSender.WinForms.ViewModels;
using System.Windows.Forms;

namespace LocalFileSender.WinForms.Views
{
    public partial class MainView : Form, IDisposable
    {
        private const string AppStateFileName = "application-state.json";

        private const string DefaultHostname = "127.0.0.1";
        private const int DefaultPort = 8877;

        private string _currentDirectory = Directory.GetCurrentDirectory();

        private ApplicationState? _appState;

        private string StateFileFullPath => Path.Combine(_currentDirectory, AppStateFileName);
        private HostParameters Host => new HostParameters()
        {
            Name = _appState!.Hostname,
            Port = _appState.Hostport
        };

        public MainView()
        {
            InitializeComponent();

            _appState = ApplicationState.Load(StateFileFullPath);

            if (_appState == null)
            {
                _appState = new ApplicationState();

                _appState.FileServicePort = DefaultPort;
                _appState.SharedDirectory = Path.Combine(_currentDirectory, "Shared");

                _appState.Hostname = DefaultHostname;
                _appState.Hostport = DefaultPort;
                _appState.SaveDirectory = Path.Combine(_currentDirectory, "Downloads");
            }

            StoredCommander.SharedDirectoryFullPath = _appState.SharedDirectory;

            DataContext = new MainViewModel(this, _appState, StoredFileTreeView.Nodes, UpdateFileTreeView);

            FileServicePortControl.DataBindings.Add(new Binding("Value", DataContext, "FileServicePort", true, DataSourceUpdateMode.OnPropertyChanged));

            FileServiceStartStopButton.DataBindings.Add(new Binding("Text", DataContext, "ServerStartStopButtonText", true, DataSourceUpdateMode.OnPropertyChanged));
            FileServiceStartStopButton.DataBindings.Add(new Binding("CommandParameter", DataContext, "FileServicePort"));
            FileServiceStartStopButton.DataBindings.Add(new Binding("Command", DataContext, "ToggleServiceCommand", true));

            SharedDirectoryControl.DataBindings.Add(new Binding("Text", DataContext, "SharedDirectory", true, DataSourceUpdateMode.OnPropertyChanged));

            SelectSharedDirectoryButton.DataBindings.Add(new Binding("Command", DataContext, "SelectSharedDirectoryCommand", true));

            HostnameControl.DataBindings.Add(new Binding("Text", DataContext, "Hostname", true, DataSourceUpdateMode.OnPropertyChanged));
            HostportControl.DataBindings.Add(new Binding("Value", DataContext, "Hostport", true, DataSourceUpdateMode.OnPropertyChanged));

            PollButton.DataBindings.Add(new Binding("CommandParameter", DataContext, "HostParameters"));
            PollButton.DataBindings.Add(new Binding("Command", DataContext, "PollCommand", true));

            SaveDirectoryControl.DataBindings.Add(new Binding("Text", DataContext, "SaveDirectory", true, DataSourceUpdateMode.OnPropertyChanged));

            SelectSaveDirectoryButton.DataBindings.Add(new Binding("Command", DataContext, "SelectSaveDirectoryCommand", true));

            DownloadButton.DataBindings.Add(new Binding("CommandParameter", DataContext, "DownloadParameters"));
            DownloadButton.DataBindings.Add(new Binding("Command", DataContext, "DownloadCommand", true));

            ServerLoggerRichBox.DataBindings.Add(new Binding("Text", DataContext, "LoggerOutput", true, DataSourceUpdateMode.OnPropertyChanged));

            GlobalTimer.Interval = 100;
            GlobalTimer.Enabled = true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _appState!.Save(StateFileFullPath);
        }

        //
        // Tree View
        //

        private void UpdateFileTreeView(StoredDirectory directoryTree)
        {
            StoredFileTreeView.Nodes.Clear();
            TreeNode[] nodes = DirectoryToTreeNodeList(directoryTree, directoryTree);
            StoredFileTreeView.Nodes.AddRange(nodes);
        }

        private int GetFileImageIndexByExtension(string ext)
        {
            int index = StoredFileTreeView.ImageList.Images
                .IndexOfKey($"File{ext.ToUpper()}.png");
            return index == -1 ? 1 : index;
        }

        private TreeNode[] DirectoryToTreeNodeList(StoredDirectory rootDirectory, StoredDirectory storedDirectory)
        {
            var result = new List<TreeNode>();

            foreach (IStored stored in storedDirectory.Stored)
            {
                TreeNode node = new TreeNode(stored.Name);
                node.Tag = stored;

                if (stored is StoredFile)
                {
                    StoredFile file = (StoredFile)stored;
                    int imageIndex = GetFileImageIndexByExtension(file.Extension);
                    node.ImageIndex = imageIndex;
                    node.SelectedImageIndex = imageIndex;
                    node.ToolTipText = $"File {stored.ByteSize.Formatted}";
                }
                else if (stored is StoredDirectory)
                {
                    TreeNode[] subNodes = DirectoryToTreeNodeList(rootDirectory, (StoredDirectory)stored);
                    node.Nodes.AddRange(subNodes);
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    node.ToolTipText = $"Folder {stored.ByteSize.Formatted}";
                }

                result.Add(node);
            }

            return result.ToArray();
        }

        private void ChecksChanged()
        {
            var viewModel = (MainViewModel)DataContext!;
            viewModel?.OnPropertyChanged("DownloadParameters");
        }

        private void CalculateTotalByteSize()
        {
            var total = StoredFileTreeView.Nodes.Descendants()
                    .Where(n => n.Tag is StoredFile && n.Checked)
                    .Sum(n => ((StoredFile)n.Tag).ByteSize.Count);
            TotalByteSizeLabel.Text = MemoryBytes.Format(total);
        }

        private void StoredFileTreeView_AfterCheck(object? sender, TreeViewEventArgs e)
        {
            StoredFileTreeView.AfterCheck -= StoredFileTreeView_AfterCheck;

            if (e.Node!.Tag is StoredDirectory && e.Action == TreeViewAction.ByMouse)
            {
                CheckChildren(e.Node, e.Node.Checked);
            }
            else if (e.Node!.Tag is StoredFile)
            {
                VerifyParentCheck(e.Node);
            }

            CalculateTotalByteSize();
            ChecksChanged();
            StoredFileTreeView.AfterCheck += StoredFileTreeView_AfterCheck;
        }

        private void CheckAllButton_Click(object sender, EventArgs e)
        {
            StoredFileTreeView.AfterCheck -= StoredFileTreeView_AfterCheck;
            foreach (var node in StoredFileTreeView.Nodes.Descendants())
            {
                node.Checked = true;
            }
            CalculateTotalByteSize();
            ChecksChanged();
            StoredFileTreeView.AfterCheck += StoredFileTreeView_AfterCheck;
        }

        private void UncheckAllButton_Click(object sender, EventArgs e)
        {
            StoredFileTreeView.AfterCheck -= StoredFileTreeView_AfterCheck;
            foreach (var node in StoredFileTreeView.Nodes.Descendants())
            {
                node.Checked = false;
            }
            CalculateTotalByteSize();
            ChecksChanged();
            StoredFileTreeView.AfterCheck += StoredFileTreeView_AfterCheck;
        }

        private void CheckChildren(TreeNode rootNode, bool isChecked)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }

        private void VerifyParentCheck(TreeNode childNode)
        {
            if (childNode.Parent == null) return;

            bool allRestChecked = true;
            foreach (TreeNode node in childNode.Parent.Nodes)
            {
                if (!node.Checked)
                {
                    allRestChecked = false;
                    break;
                }
            }
            childNode.Parent.Checked = allRestChecked;

            VerifyParentCheck(childNode.Parent);
        }

        private void ServerLoggerRichBox_TextChanged(object sender, EventArgs e)
        {
            ServerLoggerRichBox.SelectionStart = ServerLoggerRichBox.Text.Length;
            ServerLoggerRichBox.ScrollToCaret();
        }
    }
}