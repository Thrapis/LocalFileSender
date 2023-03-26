using System.Net.Sockets;

namespace LocalFileSender.Library.Client
{
    public interface IClientRequestScenario<T>
    {
        T Execute(Socket socket);
    }
}
