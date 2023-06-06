using LocalFileSender.Library.Client;
using LocalFileSender.Library.Connection;
using LocalFileSender.Library.Models.Storage;
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
    public partial class PollingView : Form
    {
        private HostParameters _hostParameters;
        private Action<StoredDirectory> _onPollResults;

        public PollingView(HostParameters hostParameters, Action<StoredDirectory> onPollResults)
        {
            _hostParameters = hostParameters;
            _onPollResults = onPollResults;
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e) => ExecutePoll();

        private async void ExecutePoll()
        {
            try
            {
                ClientInstance<StoredDirectory> client = new ClientInstance<StoredDirectory>();
                FileListPollRequest request = new FileListPollRequest();

                StoredDirectory storedDirectory = new StoredDirectory();
                await Task.Run(() =>
                {
                    storedDirectory = client.HandleRequest(_hostParameters, request);
                });
                _onPollResults?.Invoke(storedDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }
    }
}
