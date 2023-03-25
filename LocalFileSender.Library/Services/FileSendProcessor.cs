using System.Net;
using System.Net.Sockets;
using System.Text;
using LocalFileSender.Library.Models;
using LocalFileSender.Library.Status;

namespace LocalFileSender.Library.Services
{
    public static class FileSendProcessor
    {
        public static async Task Process(Socket socket, CancellationToken token)
        {
            byte[] buffer = new byte[1024];
            await socket.ReceiveAsync(buffer, cancellationToken: token);
            if (token.IsCancellationRequested) return;

            string fileName = Encoding.UTF8.GetString(buffer).Replace("\0", string.Empty);
            StoredFile? file = StoredFileCommander.StoredFiles.FirstOrDefault(s => s.FileName == fileName);

            if (file != null)
            {
                byte[] approved = new byte[1] { (byte)AnswerStatus.Approved };
                await socket.SendAsync(approved, cancellationToken: token);
                if (token.IsCancellationRequested) return;

                byte[] fileSize = Encoding.UTF8.GetBytes(file.ByteSize.Count.ToString());
                await socket.SendAsync(fileSize);
                if (token.IsCancellationRequested) return;

                byte[] clientAnswer = new byte[1];

                await socket.ReceiveAsync(clientAnswer, cancellationToken: token);
                if (token.IsCancellationRequested) return;

                AnswerStatus answer = (AnswerStatus)clientAnswer[0];
                if (answer == AnswerStatus.Continue)
                {
                    await SendFileAsync(socket, file, token);
                    if (token.IsCancellationRequested) return;

                    await socket.ReceiveAsync(clientAnswer, cancellationToken: token);
                    if (token.IsCancellationRequested) return;
                }
            }
            else
            {
                byte[] nofileexception = new byte[1] { (byte)AnswerStatus.NoFileException };
                await socket.SendAsync(nofileexception, cancellationToken: token);
                if (token.IsCancellationRequested) return;
            }
        }

        private static async Task SendFileAsync(Socket socket, StoredFile file, CancellationToken token)
        {
            using (FileStream fs = new FileStream(file.FullPath, FileMode.Open, FileAccess.Read))
            {
                int bytes = 0;
                long sumBytes = 0;
                byte[] sendingData = new byte[512];
                do
                {
                    bytes = await fs.ReadAsync(sendingData, 0, sendingData.Length, cancellationToken: token);
                    if (token.IsCancellationRequested) return;
                    await socket.SendAsync(sendingData, cancellationToken: token);
                    if (token.IsCancellationRequested) return;
                    sumBytes += bytes;
                } while (sumBytes < file.ByteSize.Count);
            }
        }
    }
}