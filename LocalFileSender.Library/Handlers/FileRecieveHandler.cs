using LocalFileSender.Library.Classify;
using LocalFileSender.Library.Models;
using LocalFileSender.Library.Status;
using System.Net.Sockets;
using System.Text;

namespace LocalFileSender.Library.Handlers
{
    public class FileRecieveHandler
    {
        public async Task Recieve(string fileName, string toDirectory, string hostname, int port, DownloadProgress progress)
        {
            TcpClient client = new TcpClient();
            try
            {
                await client.ConnectAsync(hostname, port);
                var socket = client.GetStream().Socket;
                socket.ReceiveTimeout = 10;
                socket.SendTimeout = 10;

                byte[] request = new byte[1] { (byte)RequestType.SendFile };
                await socket.SendAsync(request);

                byte[] byteFileName = Encoding.UTF8.GetBytes(fileName);
                await socket.SendAsync(byteFileName);

                byte[] answer = new byte[1];
                await socket.ReceiveAsync(answer);
                AnswerStatus answerStatus = (AnswerStatus)answer[0];

                if (answerStatus == AnswerStatus.Approved)
                {
                    byte[] fileSizeB = new byte[64];
                    await socket.ReceiveAsync(fileSizeB);
                    string fileSizeS = Encoding.UTF8.GetString(fileSizeB).Replace("\0", string.Empty);
                    long fileSize = Convert.ToInt64(fileSizeS);

                    await socket.SendAsync(new byte[1] { (byte)AnswerStatus.Continue });

                    await SaveFileAsync(socket, fileName, toDirectory, fileSize, progress);

                    await socket.SendAsync(new byte[1] { (byte)AnswerStatus.Complete });
                }
            }
            finally
            {
                client.Close();
            }
        }

        public async Task SaveFileAsync(Socket socket, string fileName, string directory, long fileSize, DownloadProgress progress)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string targetFileName = fileName;
            var extension = Path.GetExtension(fileName) ?? "";
            int counter = 1;
            while (File.Exists(Path.Combine(directory, targetFileName)))
            {
                var newFileNameWithoutExt = Path.GetFileNameWithoutExtension(fileName) + $" ({counter})";
                targetFileName = newFileNameWithoutExt + extension;
                counter++;
            }

            string fullPath = Path.Combine(directory, targetFileName);

            progress.Start(fileSize);
            using (FileStream fs = new FileStream(fullPath, FileMode.Create))
            {
                int bytes = 0;
                long sumBytes = 0;
                byte[] responseData = new byte[512];
                do
                {
                    bytes = await socket.ReceiveAsync(responseData);
                    await fs.WriteAsync(responseData, 0, bytes);
                    sumBytes += bytes;
                    progress.AddProgress(bytes);
                }
                while (sumBytes < fileSize);
            }
            progress.Stop();
        }
    }
}
