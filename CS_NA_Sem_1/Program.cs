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

        
    }
}
