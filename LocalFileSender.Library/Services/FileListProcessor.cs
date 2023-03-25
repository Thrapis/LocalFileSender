using LocalFileSender.Library.Models;
using System.Net.Sockets;
using System.Net;
using System.Text;
using LocalFileSender.Library.Classify;
using Newtonsoft.Json;
using System;
using LocalFileSender.Library.Status;

namespace LocalFileSender.Library.Services
{
    public static class FileListProcessor
    {
        public static async Task Process(Socket socket, CancellationToken token)
        {
            byte[] approved = new byte[] { (byte)AnswerStatus.Approved };
            await socket.SendAsync(approved, cancellationToken: token);
            if (token.IsCancellationRequested) return;

            List<StoredFile> list = StoredFileCommander.StoredFiles;
            string json = JsonConvert.SerializeObject(list);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

            byte[] fileSize = Encoding.UTF8.GetBytes(jsonBytes.Length.ToString());
            await socket.SendAsync(fileSize);
            if (token.IsCancellationRequested) return;

            byte[] clientAnswer = new byte[1];

            await socket.ReceiveAsync(clientAnswer, cancellationToken: token);
            if (token.IsCancellationRequested) return;

            AnswerStatus answer = (AnswerStatus)clientAnswer[0];
            if (answer == AnswerStatus.Continue)
            {
                await socket.SendAsync(jsonBytes, cancellationToken: token);
                if (token.IsCancellationRequested) return;

                await socket.ReceiveAsync(clientAnswer, cancellationToken: token);
                if (token.IsCancellationRequested) return;
            }
        }
    }
}
