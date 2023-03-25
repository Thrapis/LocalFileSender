using LocalFileSender.Library.Classify;
using LocalFileSender.Library.Models;
using LocalFileSender.Library.Status;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Handlers
{
    public class FileListPollHandler
    {
        public async Task<List<StoredFile>> GetFileList(string hostname, int port)
        {
            TcpClient client = new TcpClient();
            try
            {
                await client.ConnectAsync(hostname, port);
                var socket = client.GetStream().Socket;
                socket.ReceiveTimeout = 10;
                socket.SendTimeout = 10;

                byte[] request = new byte[1] { (byte)RequestType.GetFileList };
                await socket.SendAsync(request);

                byte[] answer = new byte[1];
                await socket.ReceiveAsync(answer);

                AnswerStatus answerStatus = (AnswerStatus)answer[0];
                if (answerStatus == AnswerStatus.Approved)
                {
                    byte[] jsonSizeB = new byte[64];
                    await socket.ReceiveAsync(jsonSizeB);
                    string jsonSizeS = Encoding.UTF8.GetString(jsonSizeB).Replace("\0", string.Empty);
                    long jsonSize = Convert.ToInt64(jsonSizeS);

                    byte[] contin = new byte[1] { (byte)AnswerStatus.Continue };
                    await socket.SendAsync(contin);

                    int bytes = 0;
                    var response = new MemoryStream();
                    byte[] responseData = new byte[512];
                    do
                    {
                        bytes = await socket.ReceiveAsync(responseData);
                        await response.WriteAsync(responseData, 0, bytes);
                    }
                    while (response.Length < jsonSize);

                    byte[] complete = new byte[1] { (byte)AnswerStatus.Complete };
                    await socket.SendAsync(complete);

                    byte[] data = response.ToArray();
                    string json = Encoding.UTF8.GetString(data);
                    var list = JsonConvert.DeserializeObject<List<StoredFile>>(json);
                    return list ?? new List<StoredFile>();
                }
            }
            finally
            {
                client.Close();
            }
            return new List<StoredFile>();
        }
    }
}
