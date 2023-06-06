using LocalFileSender.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalFileSender.WinForms.Commands
{
    internal class ToggleServiceCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private FileService _fileService;
        public ToggleServiceCommand(FileService fileService)
        {
            _fileService = fileService;
        }

        public bool CanExecute(object? parameter)
        {
            return parameter != null && !_fileService.IsExecuted || _fileService.IsExecuted;
        }

        public void Execute(object? parameter)
        {
            if (!_fileService.IsExecuted)
            {
                if (parameter == null)
                    throw new ArgumentNullException(nameof(parameter));

                int port = (int)parameter;
                _fileService.ExecuteService(port);
            }
            else
            {
                _fileService.StopService();
            }
        }
    }
}
