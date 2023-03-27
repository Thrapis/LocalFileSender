using LocalFileSender.Library.Classify;
using LocalFileSender.Library.Models.Convert;
using LocalFileSender.Library.Models.Progress;
using LocalFileSender.Library.Status;
using System.Net.Sockets;
using System.Text;

namespace LocalFileSender.Library.Client
{
    public class FileRecieveRequest : IClientRequestScenario<int>
    {
        public List<string> FilePoll = new List<string>();
        public string SaveDirectory = "\\Downloads";
        public Action<DownloadProgress> OnDownload = (dp) => { };

        public int Execute(Socket socket)
        {
            int downloadNumber = 0;
            int downloaded = 0;
            byte[] ourAnswer = new byte[1];
            byte[] serverAnswer = new byte[1];

            ourAnswer[0] = (byte)RequestStatus.SendFile;
            socket.Send(ourAnswer);

            for (int i = 0; i < FilePoll.Count; i++)
            {
                downloadNumber++;
                var fileName = FilePoll[i];

                byte[] byteFileName = Encoding.UTF8.GetBytes(fileName);
                socket.Send(byteFileName);

                socket.Receive(serverAnswer);

                if ((ResponseStatus)serverAnswer[0] == ResponseStatus.Approved)
                {
                    byte[] fileSizeB = new byte[8];
                    socket.Receive(fileSizeB);
                    long fileSize = LongByteArrayConverter.Convert(fileSizeB);

                    ourAnswer[0] = (byte)RequestStatus.Continue;
                    socket.Send(ourAnswer);

                    DownloadFile file = new DownloadFile()
                    {
                        Name = fileName,
                        Size = fileSize,
                        PollNumber = downloadNumber,
                        PollTotal = FilePoll.Count
                    };
                    SaveFile(socket, file, SaveDirectory, OnDownload);

                    downloaded++;
                }

                if (i + 1 < FilePoll.Count)
                {
                    ourAnswer[0] = (byte)RequestStatus.Continue;
                    socket.Send(ourAnswer);
                }
            }

            ourAnswer[0] = (byte)RequestStatus.Complete;
            socket.Send(ourAnswer);

            return downloaded;
        }

        public void SaveFile(Socket socket, DownloadFile file, string directory, Action<DownloadProgress> onDownload)
        {
            string directoryToFile = Path.GetDirectoryName(file.Name) ?? string.Empty;
            string accurateDownloadDirectory = Path.Combine(directory, directoryToFile);

            if (!Directory.Exists(accurateDownloadDirectory))
            {
                Directory.CreateDirectory(accurateDownloadDirectory);
            }

            string targetFileName = file.Name;
            var extension = Path.GetExtension(file.Name) ?? "";
            int counter = 1;
            while (File.Exists(Path.Combine(directory, targetFileName)))
            {
                var newFileNameWithoutExt = Path.GetFileNameWithoutExtension(file.Name) + $" ({counter})";
                targetFileName = newFileNameWithoutExt + extension;
                counter++;
            }

            string fullPath = Path.Combine(directory, targetFileName);

            DownloadProgressTimer progress = new DownloadProgressTimer(file, 500);
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
                while (sumBytes < file.Size);
            }
            progress.Stop();
            progress.ProgressChanged -= onDownload;
        }
    }
}
