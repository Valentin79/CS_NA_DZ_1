using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS_NA_Sem_1
{
    internal class Server
    {
        public static void UdpServer(string name)
        {

            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            using (UdpClient udpClient = new UdpClient(12345)) 
            { 

                Console.WriteLine("Сервер ждет сообщение от клиента");

                while (true)
                {
                    byte[] buffer = udpClient.Receive(ref iPEndPoint);

                    if (buffer == null) break;
                    var messageText = Encoding.UTF8.GetString(buffer);

                    Message message = Message.DeserializeFromJson(messageText);
                    message.Print();

                    byte[] answer = Encoding.UTF8.GetBytes("Сообщение получено");
                    udpClient.Send(answer, answer.Length, iPEndPoint);
                }


            }
        }
    }
}
