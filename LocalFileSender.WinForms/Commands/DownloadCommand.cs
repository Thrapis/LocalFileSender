using LocalFileSender.Library.Client;
using LocalFileSender.Library.Connection;
using LocalFileSender.Library.Models.Storage;
using LocalFileSender.WinForms.Models;
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
    internal class DownloadCommand : ICommand
    {
        private Form _view;
        private bool _isExecuted { get; set; }

        public event EventHandler? CanExecuteChanged;

        public DownloadCommand(Form view)
        {
            _view = view;
        }

        public bool CanExecute(object? parameter)
        {
            return !_isExecuted && parameter != null && parameter is DownloadParameters;
        }

        public void Execute(object? parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            DownloadParameters downloadParameters = (DownloadParameters)parameter;

            _isExecuted = true;

            DownloadView dv = new(downloadParameters);
            dv.ShowDialog(_view);

            _isExecuted = false;
        }
    }
}
