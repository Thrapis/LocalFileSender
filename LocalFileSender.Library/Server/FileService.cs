using LocalFileSender.Library.Models;
using System.Net.Sockets;
using System.Net;
using System.Text;
using LocalFileSender.Library.Classify;
using Newtonsoft.Json;
using System;
using LocalFileSender.Library.Status;
using System.Threading;
using System.Globalization;
using System.ComponentModel;
using LocalFileSender.Library.Logger;

namespace LocalFileSender.Library.Services
{
    public class FileService
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private Task? _service;

        public delegate void ExecutionState();
        public event ExecutionState? ExecutionStateChanged;

        private ResponsibleLogger _logger;

        public bool IsExecuted => _service != null;

        public FileService(ResponsibleLogger logger)
        {
            _logger = logger;
        }

        public void ExecuteService(int port)
        {
            if (!IsExecuted)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                var token = _cancellationTokenSource.Token;
                _service = Task.Run(() => Service(port, token), token);
                _service.ContinueWith(t =>
                {
                    _cancellationTokenSource = null;
                    _service = null;
                    ExecutionStateChanged?.Invoke();
                });
                ExecutionStateChanged?.Invoke();
                _logger.MakeLog("File Server started");
            }
        }

        public void StopService() 
        {
            _cancellationTokenSource?.Cancel();
            _logger.MakeLog("File Server stopped");
        }

        private async Task Service(int port, CancellationToken token)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            try
            {
                listener.Start();
                while (!token.IsCancellationRequested)
                {
                    var client = await listener.AcceptTcpClientAsync(token);
                    if (client == null) continue;

                    var socket = client.GetStream().Socket;
                    socket.ReceiveTimeout = 10;
                    socket.SendTimeout = 10;

                    byte[] request = new byte[1];
                    await socket.ReceiveAsync(request, cancellationToken: token);
                    
                    if (token.IsCancellationRequested)
                    {
                        socket.Close();
                        continue;
                    }

                    RequestStatus requestType = (RequestStatus)request[0];
                    if (requestType == RequestStatus.GetStored)
                    {
                        _logger.MakeLog($"Request 'Get Stored' from {socket.RemoteEndPoint}");
                        var task = Task.Run(() => FileListProcessor.Process(socket, token), token);
                        task.ContinueWith(t => socket.Close());
                    }
                    else if (requestType == RequestStatus.SendFile)
                    {
                        _logger.MakeLog($"Request 'Send File' from {socket.RemoteEndPoint}");
                        var task = Task.Run(() => FileSendProcessor.Process(socket, token), token);
                        task.ContinueWith(t => socket.Close());
                    }
                    else
                    {
                        socket.Close();
                    }
                }
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}
