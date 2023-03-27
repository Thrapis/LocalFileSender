using System.Net.Sockets;
using System.Net;
using System.Text;
using LocalFileSender.Library.Classify;
using Newtonsoft.Json;
using System;
using LocalFileSender.Library.Status;
using LocalFileSender.Library.Models.Storage;
using LocalFileSender.Library.Models.Convert;

namespace LocalFileSender.Library.Services
{
    public static class FileListProcessor
    {
        public static async Task Process(Socket socket, CancellationToken token)
        {
            byte[] ourAnswer = new byte[1];
            byte[] clientAnswer = new byte[1];

            ourAnswer[0] = (byte)ResponseStatus.Approved;
            await socket.SendAsync(ourAnswer, cancellationToken: token);
            if (token.IsCancellationRequested) return;

            StoredDirectory storedDirectory = await StoredCommander.GetSharedDirectoryAsync();
            string json = JsonConvert.SerializeObject(storedDirectory);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            byte[] jsonSizeB = LongByteArrayConverter.Convert(jsonBytes.LongLength);
            await socket.SendAsync(jsonSizeB);
            if (token.IsCancellationRequested) return;

            await socket.ReceiveAsync(clientAnswer, cancellationToken: token);
            if (token.IsCancellationRequested) return;
            
            if ((RequestStatus)clientAnswer[0] == RequestStatus.Continue)
            {
                await socket.SendAsync(jsonBytes, cancellationToken: token);
                if (token.IsCancellationRequested) return;

                await socket.ReceiveAsync(clientAnswer, cancellationToken: token);
                if (token.IsCancellationRequested) return;
            }
        }
    }
}
