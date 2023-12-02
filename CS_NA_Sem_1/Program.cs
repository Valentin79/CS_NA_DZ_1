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

        public static void Task1()
        {
            Message msg = new Message() { Text = "Hello", DateTime = DateTime.Now, NicknameFrom = "Artem", NicknameTo = "All" };
            string json = msg.SerializeMessageToJson();
            Console.WriteLine(json);
            Message? msgDeserialaze = Message.DeserializeFromJson(json);
            Console.WriteLine(msgDeserialaze);
        }

        /*public bool SendMessage(string message)
        {
            using (Socket listner = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var remoteEndpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
                listner.Blocking = true;
                listner.Bind(remoteEndpoint);
                listner.Listen(100);

                Console.WriteLine("wait");
                var socket = listner.Accept();

                Console.WriteLine("connected");
                listner.Close();
            }
        }*/
    }
}
