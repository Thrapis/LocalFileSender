using System.Net;
using System.Net.Sockets;
using System.Text;
using LocalFileSender.Library.Classify;
using LocalFileSender.Library.Models.Convert;
using LocalFileSender.Library.Models.Storage;
using LocalFileSender.Library.Status;

namespace LocalFileSender.Library.Services
{
    public static class FileSendProcessor
    {
        public static async Task Process(Socket socket, CancellationToken token)
        {
            byte[] clientAnswer = new byte[1];

            do
            {
                byte[] fileNameB = new byte[1024];
                await socket.ReceiveAsync(fileNameB, cancellationToken: token);
                if (token.IsCancellationRequested) return;

                string fileName = Encoding.UTF8.GetString(fileNameB).Replace("\0", string.Empty);
                StoredDirectory sharedDirectory = await StoredCommander.GetSharedDirectoryAsync();
                StoredFile? file = sharedDirectory.GetStoredFileByRelativePath(fileName);

                await HandleFileRequestAsync(socket, file, token);
                if (token.IsCancellationRequested) return;

                await socket.ReceiveAsync(clientAnswer, cancellationToken: token);
                if (token.IsCancellationRequested) return;

            } while ((RequestStatus)clientAnswer[0] == RequestStatus.Continue);
        }

        private static async Task HandleFileRequestAsync(Socket socket, StoredFile? file, CancellationToken token)
        {
            byte[] ourAnswer = new byte[1];
            byte[] clientAnswer = new byte[1];

            if (file != null)
            {
                byte[] approved = new byte[1] { (byte)ResponseStatus.Approved };
                await socket.SendAsync(approved, cancellationToken: token);
                if (token.IsCancellationRequested) return;

                byte[] fileSizeB = LongByteArrayConverter.Convert(file.ByteSize.Count);
                await socket.SendAsync(fileSizeB);
                if (token.IsCancellationRequested) return;

                await socket.ReceiveAsync(clientAnswer, cancellationToken: token);
                if (token.IsCancellationRequested) return;

                if ((RequestStatus)clientAnswer[0] == RequestStatus.Continue)
                {
                    await SendFileAsync(socket, file, token);
                    if (token.IsCancellationRequested) return;
                }
            }
            else
            {
                ourAnswer[0] = (byte)ResponseStatus.NoFileException;
                await socket.SendAsync(ourAnswer, cancellationToken: token);
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