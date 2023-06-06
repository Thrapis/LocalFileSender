using LocalFileSender.Library.Connection;
using LocalFileSender.Library.Logger;
using LocalFileSender.Library.Models.Storage;
using LocalFileSender.Library.Services;
using LocalFileSender.WinForms.Commands;
using LocalFileSender.WinForms.Controls;
using LocalFileSender.WinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace LocalFileSender.WinForms.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged, IDisposable
    {
        private Form _view;
        private ApplicationState _appState;
        private TreeNodeCollection _hiererchy;
        private Action<StoredDirectory> _updateFileHiererchy;

        private ResponsibleLogger _logger;
        private FileService _fileService;
        private StoredDirectory _polledDirectory;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand ToggleServiceCommand { get; set; }
        public ICommand SelectSharedDirectoryCommand { get; set; }
        public ICommand PollCommand { get; set; }
        public ICommand SelectSaveDirectoryCommand { get; set; }
        public ICommand DownloadCommand { get; set; }

        public bool ServerExecuted { get => _fileService.IsExecuted; }
        public string ServerStartStopButtonText {
            get { return ServerExecuted ? "Stop" : "Start"; }
        }
        public int FileServicePort
        {
            get => _appState.FileServicePort;
            set
            {
                _appState.FileServicePort = value;
                OnPropertyChanged();
            }
        }
        public string SharedDirectory
        {
            get => _appState.SharedDirectory;
            set
            {
                _appState.SharedDirectory = value;
                StoredCommander.SharedDirectoryFullPath = value;
                OnPropertyChanged();
            }
        }
        public string Hostname
        {
            get => _appState.Hostname;
            set
            {
                _appState.Hostname = value;
                OnPropertyChanged();
                OnPropertyChanged("HostParameters");
                OnPropertyChanged("DownloadParameters");
            }
        }
        public int Hostport
        {
            get => _appState.Hostport;
            set
            {
                _appState.Hostport = value;
                OnPropertyChanged();
                OnPropertyChanged("HostParameters");
                OnPropertyChanged("DownloadParameters");
            }
        }
        public HostParameters HostParameters
        {
            get => new HostParameters()
            {
                Name = _appState.Hostname,
                Port = _appState.Hostport
            };
        }
        public string SaveDirectory
        {
            get => _appState.SaveDirectory;
            set
            {
                _appState.SaveDirectory = value;
                OnPropertyChanged();
                OnPropertyChanged("DownloadParameters");
            }
        }
        public DownloadParameters DownloadParameters
        {
            get => new DownloadParameters()
            {
                HostParameters = new HostParameters()
                {
                    Name = _appState.Hostname,
                    Port = _appState.Hostport
                },
                DownloadList = _hiererchy.Descendants()
                    .Where(n => n.Tag is StoredFile && n.Checked)
                    .Select(n => _polledDirectory.GetRelativePath((IStored)n.Tag))
                    .ToList(),
                SaveDirectory = SaveDirectory
            };
        }

        const int _lastLogsCount = 100;
        public string LoggerOutput
        { 
            get
            {
                var log = _logger.LogHistory.TakeLast(_lastLogsCount);
                return string.Join("\n", log.Select(l => $"{l.Key} - {l.Value}"));
            }
        }

        public MainViewModel(Form view, ApplicationState applicationState, TreeNodeCollection hiererchy, Action<StoredDirectory> updateFileHiererchy)
        {
            _view = view;
            _appState = applicationState;
            _hiererchy = hiererchy;
            _updateFileHiererchy = updateFileHiererchy;

            _logger = new();
            _fileService = new(_logger);
            _polledDirectory = new();

            ToggleServiceCommand = new ToggleServiceCommand(_fileService);
            SelectSharedDirectoryCommand = new SelectDirectoryCommand(path =>
            {
                SharedDirectory = path;
            });
            PollCommand = new PollCommand(_view, directory =>
            {
                _polledDirectory = directory;
                _updateFileHiererchy?.Invoke(directory);
                OnPropertyChanged("DownloadParameters");
            });
            SelectSaveDirectoryCommand = new SelectDirectoryCommand(path =>
            {
                SaveDirectory = path;
            });
            DownloadCommand = new DownloadCommand(_view);

            _fileService.ExecutionStateChanged += ServiceExecutionChange;
            _logger.OnLogged += LoggerGotMessage;
        }
        
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void ServiceExecutionChange()
        {
            OnPropertyChanged("ServerExecuted");
            OnPropertyChanged("ServerStartStopButtonText");
        }

        public void LoggerGotMessage()
        {
            OnPropertyChanged();
            OnPropertyChanged("LoggerOutput");
        }

        //
        // Dispose
        //

        public void Dispose()
        {
            _fileService.ExecutionStateChanged -= ServiceExecutionChange;
            _logger.OnLogged -= LoggerGotMessage;
        }
    }
}
