using LocalFileSender.Library.Connection;
using LocalFileSender.Library.Models.Storage;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LocalFileSender.Library.Client
{
    public class ClientInstance<T>
    {
        public T HandleRequest(HostParameters host, IClientRequestScenario<T> clientHandleable)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(host.Name, host.Port);
                var socket = client.GetStream().Socket;
                socket.ReceiveTimeout = 5000;
                socket.SendTimeout = 5000;
                return clientHandleable.Execute(socket);
            }
            finally
            {
                client.Close();
            }
        }
    }
}
