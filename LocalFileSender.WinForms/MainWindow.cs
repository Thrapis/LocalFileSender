using LocalFileSender.Library.Handlers;
using LocalFileSender.Library.Models;
using LocalFileSender.Library.Services;
using LocalFileSender.WinForms.Properties;

namespace LocalFileSender.WinForms
{
    public partial class MainWindow : Form, IDisposable
    {
        private const string DefaultHostname = "127.0.0.1";
        private const int DefaultPort = 8877;

        private string _stateFile = "application-state.json";
        private string _currentDirectory = Directory.GetCurrentDirectory();
        private string _stateFileFullPath => Path.Combine(_currentDirectory, _stateFile);

        private ApplicationState? _applicationState;

        private FileService _fileService = new FileService();

        public MainWindow()
        {
            InitializeComponent();
            
            _applicationState = ApplicationState.Load(_stateFileFullPath);

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

            NotifyMessageLabel.Text = "";
            NotifyMessageImage.Image = null;
            GlobalTimer.Interval = 100;
            GlobalTimer.Enabled = true;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _fileService.StopService();
            _applicationState!.Save(_stateFileFullPath);
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
            FileListPollHandler handler = new FileListPollHandler();
            NotifyMessageImage.Image = Resources.Loading;
            NotifyMessageLabel.Text = "Polling files...";

            try
            {
                var list = await handler.GetFileList(_applicationState!.Hostname, _applicationState.Hostport);
                StoredFileList.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception", ex.Message);
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
                FileRecieveHandler handler = new FileRecieveHandler();

                DownloadProgress progress = new DownloadProgress();
                EventHandler action = (obj, evnt) =>
                {
                    NotifyMessageLabel.Text = progress.DownloadSpeedFor(1);
                    DownloadProgressBar.Value = progress.DownloadedPercent();
                };

                NotifyMessageImage.Image = Resources.Downloading;
                GlobalTimer.Tick += action;

                try
                {
                    await handler.Recieve(file.FileName, _applicationState!.SaveDirectory, 
                        _applicationState.Hostname, _applicationState.Hostport, progress);
                }
                catch (Exception ex)
                {
                    MessageBox .Show("Exception", ex.Message);
                }
                
                GlobalTimer.Tick -= action;
                NotifyMessageImage.Image = null;
                NotifyMessageLabel.Text = "";
                DownloadProgressBar.Value = 0;
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