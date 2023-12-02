using System.Net.Sockets;
using System.Net;

namespace CS_NA_Sem_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Thread(() => Server.UdpServer("Hello")).Start();
            //Server.UdpServer("Hello");
        }

        
    }
}
