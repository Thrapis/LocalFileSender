using LocalFileSender.Library.Classify;
using LocalFileSender.Library.Models.Progress;
using LocalFileSender.Library.Status;
using System.Net.Sockets;
using System.Text;

namespace LocalFileSender.Library.Handlers
{
    public class FileRecieveHandler
    {
        public void Recieve(string fileName, string toDirectory, string hostname, int port, Action<DownloadProgress> onDownload)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(hostname, port);
                var socket = client.GetStream().Socket;
                socket.ReceiveTimeout = 5000;
                socket.SendTimeout = 5000;

                byte[] ourAnswer, serverAnswer = new byte[1];

                ourAnswer = new byte[1] { (byte)RequestType.SendFile };
                socket.Send(ourAnswer);

                byte[] byteFileName = Encoding.UTF8.GetBytes(fileName);
                socket.Send(byteFileName);

                socket.Receive(serverAnswer);
                AnswerStatus answerStatus = (AnswerStatus)serverAnswer[0];

                if (answerStatus == AnswerStatus.Approved)
                {
                    byte[] fileSizeB = new byte[64];
                    socket.Receive(fileSizeB);
                    string fileSizeS = Encoding.UTF8.GetString(fileSizeB).Replace("\0", string.Empty);
                    long fileSize = Convert.ToInt64(fileSizeS);

                    ourAnswer = new byte[1] { (byte)AnswerStatus.Continue };
                    socket.Send(ourAnswer);

                    SaveFile(socket, fileName, toDirectory, fileSize, onDownload);

                    ourAnswer = new byte[1] { (byte)AnswerStatus.Complete };
                    socket.Send(ourAnswer);
                }
            }
            finally
            {
                client.Close();
            }
        }

        public void SaveFile(Socket socket, string fileName, string directory, long fileSize, Action<DownloadProgress> onDownload)
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

            DownloadProgressTimer progress = new DownloadProgressTimer(fileSize, 500);
            progress.ProgressChanged += onDownload;
            progress.Start();
            using (FileStream fs = new FileStream(fullPath, FileMode.Create))
            {
                int bytes = 0;
                long sumBytes = 0;
                byte[] responseData = new byte[512];
                int attempt = 0;
                int maxAttempts = 50;
                do
                {
                    do
                    {
                        if (attempt != 0) Thread.Sleep(100);

                        bytes = socket.Receive(responseData);
                        attempt++;
                    } while (bytes == 0 && attempt < maxAttempts);

                    if (bytes == 0 && attempt >= maxAttempts)
                    {
                        throw new TimeoutException();
                    }
                    attempt = 0;

                    fs.Write(responseData, 0, bytes);
                    sumBytes += bytes;
                    progress.AddProgress(bytes);
                }
                while (sumBytes < fileSize);
            }
            progress.Stop();
            progress.ProgressChanged -= onDownload;
        }
    }
}
