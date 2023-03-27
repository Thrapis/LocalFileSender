using LocalFileSender.Library.Client;
using LocalFileSender.Library.Connection;
using LocalFileSender.Library.Models.Bytes;
using LocalFileSender.Library.Models.Storage;
using LocalFileSender.Library.Services;
using LocalFileSender.WinForms.Properties;

namespace LocalFileSender.WinForms
{
    public partial class MainWindow : Form, IDisposable
    {
        private const string AppStateFileName = "application-state.json";

        private const string DefaultHostname = "127.0.0.1";
        private const int DefaultPort = 8877;

        private string _currentDirectory = Directory.GetCurrentDirectory();

        private StoredDirectory _polledDirectory = new();

        private ApplicationState? _applicationState;
        private FileService _fileService = new FileService();

        private string StateFileFullPath => Path.Combine(_currentDirectory, AppStateFileName);
        private HostParameters Host => new HostParameters()
        {
            Name = _applicationState!.Hostname,
            Port = _applicationState.Hostport
        };

        public MainWindow()
        {
            InitializeComponent();

            _applicationState = ApplicationState.Load(StateFileFullPath);

            if (_applicationState != null)
            {
                FileServicePortControl.Value = _applicationState.FileServicePort;
                SharedDirectoryControl.Text = _applicationState.SharedDirectory;
                HostnameControl.Text = _applicationState.Hostname;
                HostPortControl.Value = _applicationState.Hostport;
                SaveDirectoryControl.Text = _applicationState.SaveDirectory;
            }
            else
            {
                _applicationState = new ApplicationState();

                FileServicePortControl.Value = DefaultPort;
                SharedDirectoryControl.Text = Path.Combine(_currentDirectory, "Shared");

                HostnameControl.Text = DefaultHostname;
                HostPortControl.Value = DefaultPort;
                SaveDirectoryControl.Text = Path.Combine(_currentDirectory, "Downloads");
            }

            DownloadProgressBar.Visible = false;
            NotifyMessageLabel.Text = "";
            NotifyMessageImage.Image = null;
            GlobalTimer.Interval = 100;
            GlobalTimer.Enabled = true;

            LoadTreeViewImageSet();
        }


        private void LoadTreeViewImageSet()
        {
            Point destPt = new Point(6, 0);
            Size size = new Size(22, 16);
            StoredFileTreeView.ImageList = new ImageList();
            StoredFileTreeView.ImageList.ImageSize = size;
            foreach (string key in HierarchyImageList.Images.Keys)
            {
                Bitmap bmp = new Bitmap(size.Width, size.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(HierarchyImageList.Images[key], destPt);
                g.Dispose();
                StoredFileTreeView.ImageList.Images.Add(key, (Image)bmp);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _fileService.StopService();
            _applicationState!.Save(StateFileFullPath);
        }

        //
        // Tree View
        //

        private void UpdateFileTreeView()
        {
            StoredFileTreeView.Nodes.Clear();
            TreeNode[] nodes = DirectoryToTreeNodeList(_polledDirectory, _polledDirectory);
            StoredFileTreeView.Nodes.AddRange(nodes);
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
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
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

        private void StoredFileTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node!.Tag is StoredDirectory && e.Action == TreeViewAction.ByMouse)
            {
                CheckChildren(e.Node, e.Node.Checked);
            }
            else if (e.Node!.Tag is StoredFile)
            {
                VerifyParentCheck(e.Node);
            }

            var total = StoredFileTreeView.Nodes.Descendants()
                    .Where(n => n.Tag is StoredFile && n.Checked)
                    .Sum(n => ((StoredFile)n.Tag).ByteSize.Count);
            TotalByteSizeLabel.Text = MemoryBytes.Format(total);
        }

        private void CheckAllButton_Click(object sender, EventArgs e)
        {
            foreach (var node in StoredFileTreeView.Nodes.Descendants())
            {
                node.Checked = true;
            }
        }

        private void UncheckAllButton_Click(object sender, EventArgs e)
        {
            foreach (var node in StoredFileTreeView.Nodes.Descendants())
            {
                node.Checked = false;
            }
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

        //
        // File Service
        //

        private void FileServiceStartStopButton_Click(object sender, EventArgs e)
        {
            if (!_fileService.IsExecuted)
            {
                _fileService.ExecuteService(_applicationState!.FileServicePort);
                FileServiceStartStopButton.Text = "Stop";
            }
            else
            {
                _fileService.StopService();
                FileServiceStartStopButton.Text = "Start";
            }
        }

        private void FileServicePortControl_ValueChanged(object sender, EventArgs e)
        {
            _applicationState!.FileServicePort = (int)FileServicePortControl.Value;
        }

        private void DirectoryControl_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SharedDirectoryControl.Text = fbd.SelectedPath;
                }
            }
        }

        private void DirectoryControl_TextChanged(object sender, EventArgs e)
        {
            StoredCommander.SharedDirectoryFullPath = SharedDirectoryControl.Text;
            _applicationState!.SharedDirectory = SharedDirectoryControl.Text;
        }

        //
        // List Poll Handler
        //

        private async void PollButton_Click(object sender, EventArgs e)
        {
            ClientInstance<StoredDirectory> client = new ClientInstance<StoredDirectory>();
            FileListPollRequest request = new FileListPollRequest();

            NotifyMessageImage.Image = Resources.Loading;
            NotifyMessageLabel.Text = "Polling files...";

            try
            {
                await Task.Run(() =>
                {
                    _polledDirectory = client.HandleRequest(Host, request);
                });
                UpdateFileTreeView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            NotifyMessageImage.Image = null;
            NotifyMessageLabel.Text = "";
        }

        private void HostnameControl_TextChanged(object sender, EventArgs e)
        {
            _applicationState!.Hostname = HostnameControl.Text;
        }

        private void HostPortControl_ValueChanged(object sender, EventArgs e)
        {
            _applicationState!.Hostport = (int)HostPortControl.Value;
        }

        //
        // Recieve Handler
        //

        private async void DownloadButton_Click(object sender, EventArgs e)
        {
            List<string> filesToDownload = StoredFileTreeView.Nodes.Descendants()
                    .Where(n => n.Tag is StoredFile && n.Checked)
                    .Select(n => _polledDirectory.GetRelativePath((IStored)n.Tag))
                    .ToList();

            if (filesToDownload.Count != 0)
            {
                ClientInstance<int> client = new ClientInstance<int>();
                FileRecieveRequest request = new FileRecieveRequest()
                {
                    FilePoll = filesToDownload,
                    SaveDirectory = _applicationState!.SaveDirectory,
                    OnDownload = (p) =>
                    {
                        DownloadProgressBar.Control.Invoke(() => DownloadProgressBar.Value = p.Progress);
                        string text = $"{p.ProgressDetails} for {p.File.Name} ({p.File.PollNumber}/{p.File.PollTotal})";
                        NotifyMessageLabel.Text = text;
                        NotifyMessageLabel.ToolTipText = text;
                        NotifyMessageImage.Image = Resources.Downloading;
                    }
                };

                DownloadProgressBar.Visible = true;
                NotifyMessageImage.Image = Resources.Downloading;
                DownloadButton.Enabled = false;

                try
                {
                    await Task.Run(() =>
                    {
                        client.HandleRequest(Host, request);
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DownloadButton.Enabled = true;
                NotifyMessageImage.Image = null;
                NotifyMessageLabel.Text = string.Empty;
                NotifyMessageLabel.ToolTipText = string.Empty;
                DownloadProgressBar.Value = 0;
                DownloadProgressBar.Visible = false;
            }
        }

        private void SaveDirectoryControl_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    SaveDirectoryControl.Text = fbd.SelectedPath;
                }
            }
        }

        private void SaveDirectoryControl_TextChanged(object sender, EventArgs e)
        {
            _applicationState!.SaveDirectory = SaveDirectoryControl.Text;
        }
    }
}