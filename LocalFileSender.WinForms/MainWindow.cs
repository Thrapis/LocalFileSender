using LocalFileSender.Library.Client;
using LocalFileSender.Library.Connection;
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
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _fileService.StopService();
            _applicationState!.Save(StateFileFullPath);
        }

        // File Service

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
            StoredFileCommander.SharedDirectory = SharedDirectoryControl.Text;
            _applicationState!.SharedDirectory = SharedDirectoryControl.Text;
        }

        // List Poll Handler

        private async void PollButton_Click(object sender, EventArgs e)
        {
            ClientInstance<List<StoredFile>> client = new ClientInstance<List<StoredFile>>();
            FileListPollRequest request = new FileListPollRequest();

            NotifyMessageImage.Image = Resources.Loading;
            NotifyMessageLabel.Text = "Polling files...";

            try
            {
                List<StoredFile> list = new();
                await Task.Run(() =>
                {
                    list = client.HandleRequest(Host, request);
                });
                StoredFileList.DataSource = list;
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

        // Recieve Handler

        private async void DownloadButton_Click(object sender, EventArgs e)
        {
            var item = StoredFileList.SelectedItems[0];
            if (item != null)
            {
                var file = (StoredFile)item;
                ClientInstance<int> client = new ClientInstance<int>();
                FileRecieveRequest request = new FileRecieveRequest()
                {
                    FilePoll = new List<string>() { file.FileName },
                    SaveDirectory = _applicationState!.SaveDirectory,
                    OnDownload = (p) =>
                    {
                        DownloadProgressBar.Control.Invoke(() => DownloadProgressBar.Value = p.Progress);
                        NotifyMessageLabel.Text = $"{p.ProgressDetails} for {p.FileName}";
                    }
                };

                DownloadProgressBar.Visible = true;
                NotifyMessageImage.Image = Resources.Downloading;

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

                NotifyMessageImage.Image = null;
                NotifyMessageLabel.Text = "";
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