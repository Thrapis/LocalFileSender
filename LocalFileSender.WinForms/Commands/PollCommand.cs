using LocalFileSender.Library.Client;
using LocalFileSender.Library.Connection;
using LocalFileSender.Library.Models.Storage;
using LocalFileSender.WinForms.Properties;
using LocalFileSender.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalFileSender.WinForms.Commands
{
    internal class PollCommand : ICommand
    {
        private Form _view;
        private Action<StoredDirectory> _onPollResults;

        private bool _isExecuted { get; set; }

        public event EventHandler? CanExecuteChanged;

        public PollCommand(Form view, Action<StoredDirectory> onPollResults)
        {
            _view = view;
            _onPollResults = onPollResults;
        }

        public bool CanExecute(object? parameter)
        {
            return !_isExecuted && parameter != null && parameter is HostParameters;
        }

        public void Execute(object? parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            HostParameters host = (HostParameters)parameter;
            
            _isExecuted = true;

            PollingView pv = new PollingView(host, _onPollResults);
            pv.ShowDialog(_view);
            
            _isExecuted = false;
        }
    }
}
