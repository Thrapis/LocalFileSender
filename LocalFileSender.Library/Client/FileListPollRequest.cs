using LocalFileSender.Library.Classify;
using LocalFileSender.Library.Models.Convert;
using LocalFileSender.Library.Models.Storage;
using LocalFileSender.Library.Status;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace LocalFileSender.Library.Client
{
    public class FileListPollRequest : IClientRequestScenario<List<StoredFile>>
    {
        public List<StoredFile> Execute(Socket socket)
        {
            List<StoredFile> result = new();

            byte[] ourAnswer = new byte[1];
            byte[] serverAnswer = new byte[1];

            ourAnswer[0] = (byte)RequestStatus.GetFileList;
            socket.Send(ourAnswer);

            socket.Receive(serverAnswer);

            if ((ResponseStatus)serverAnswer[0] == ResponseStatus.Approved)
            {
                byte[] jsonSizeB = new byte[8];
                socket.Receive(jsonSizeB);
                long jsonSize = LongByteArrayConverter.Convert(jsonSizeB);

                ourAnswer[0] = (byte)RequestStatus.Continue;
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

                ourAnswer[0] = (byte)RequestStatus.Complete;
                socket.Send(ourAnswer);

                string json = Encoding.UTF8.GetString(response.ToArray());
                var deserialized = JsonConvert.DeserializeObject<List<StoredFile>>(json);
                if (deserialized != null)
                {
                    result = deserialized;
                }
            }
            return result;
        }
    }
}
