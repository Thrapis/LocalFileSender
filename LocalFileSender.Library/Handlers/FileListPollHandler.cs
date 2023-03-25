using LocalFileSender.Library.Classify;
using LocalFileSender.Library.Models.Storage;
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
        public List<StoredFile> GetFileList(string hostname, int port)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(hostname, port);
                var socket = client.GetStream().Socket;
                socket.ReceiveTimeout = 5000;
                socket.SendTimeout = 5000;

                byte[] ourAnswer, serverAnswer = new byte[1];

                ourAnswer = new byte[1] { (byte)RequestType.GetFileList };
                socket.Send(ourAnswer);

                socket.Receive(serverAnswer);

                AnswerStatus answerStatus = (AnswerStatus)serverAnswer[0];
                if (answerStatus == AnswerStatus.Approved)
                {
                    byte[] jsonSizeB = new byte[64];
                    socket.Receive(jsonSizeB);
                    string jsonSizeS = Encoding.UTF8.GetString(jsonSizeB).Replace("\0", string.Empty);
                    long jsonSize = Convert.ToInt64(jsonSizeS);

                    ourAnswer = new byte[1] { (byte)AnswerStatus.Continue };
                    socket.Send(ourAnswer);

                    int bytes = 0;
                    var response = new MemoryStream();
                    byte[] responseData = new byte[512];
                    do
                    {
                        bytes = socket.Receive(responseData);
                        response.Write(responseData, 0, bytes);
                    }
                    while (response.Length < jsonSize);

                    ourAnswer = new byte[1] { (byte)AnswerStatus.Complete };
                    socket.Send(ourAnswer);

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
