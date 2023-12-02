using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using CS_NA_Sem_1;
namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            new Thread(() => SentMessage(args[0], args[1])).Start();
            //SentMessage(args[0], args[1]);

        }


        public static void SentMessage(string From, string ip)
        {


            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);
            using (UdpClient udpClient = new UdpClient())
            {

                while (true)
                {
                    string messageText;
                    do
                    {
                        //Console.Clear();
                        Console.WriteLine("Введите сообщение.");
                        messageText = Console.ReadLine();

                    }
                    while (string.IsNullOrEmpty(messageText));

                    Message message = new Message() { Text = messageText, NicknameFrom = From, NicknameTo = "Server", DateTime = DateTime.Now };
                    string json = message.SerializeMessageToJson();

                    byte[] data = Encoding.UTF8.GetBytes(json);
                    udpClient.Send(data, data.Length, iPEndPoint);

                    byte[] buffer = udpClient.Receive(ref iPEndPoint);
                    var answer = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine(answer);
                }
            }
        }

    }

}
