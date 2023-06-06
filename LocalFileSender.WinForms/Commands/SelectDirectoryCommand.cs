using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalFileSender.WinForms.Commands
{
    internal class SelectDirectoryCommand : ICommand
    {
        private Action<string> _onSetDirectory;

        public event EventHandler? CanExecuteChanged;

        public SelectDirectoryCommand(Action<string> onSetDirectory)
        {
            _onSetDirectory = onSetDirectory;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    _onSetDirectory?.Invoke(fbd.SelectedPath);
                }
            }
        }
    }
}
