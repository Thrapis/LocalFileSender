using LocalFileSender.Library.Client;
using LocalFileSender.WinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalFileSender.WinForms.Views
{
    public partial class DownloadView : Form
    {
        DownloadParameters _downloadParameters;

        public DownloadView(DownloadParameters downloadParameters)
        {
            _downloadParameters = downloadParameters;
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e) => ExecuteDownload();

        private async void ExecuteDownload()
        {
            ClientInstance<int> client = new ClientInstance<int>();
            FileRecieveRequest request = new FileRecieveRequest()
            {
                FilePoll = _downloadParameters.DownloadList,
                SaveDirectory = _downloadParameters.SaveDirectory,
                OnDownload = (p) =>
                {
                    DownloadProgressBar.Invoke(() => DownloadProgressBar.Value = p.Progress);

                    SpeedLabel.Text = $"Speed: {p.ProgressDetails}";
                    FileNumberLabel.Text = $"Progress: {p.File.PollNumber}/{p.File.PollTotal}";
                    FileNameLabel.Text = $"File: {Path.GetFileName(p.File.Name)}";
                    //NotifyMessageImage.Image = Processes.Downloading;
                }
            };

            try
            {
                FileNumberLabel.Text = $"Progress: {1}/{_downloadParameters.DownloadList.Count}";
                FileNameLabel.Text = $"File: {Path.GetFileName(_downloadParameters.DownloadList.First())}";
                await Task.Run(() =>
                {
                    client.HandleRequest(_downloadParameters.HostParameters, request);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }
    }
}
