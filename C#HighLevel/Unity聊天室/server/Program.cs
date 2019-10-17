using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace 聊天室socket_TCP服务器端
{
    class Program
    {
        static List<Client> clientList = new List<Client>();

        public static void BroadcastMessage(string message)
        {
            var notConnectedList = new List<Client>();
            foreach(var client in clientList)
            {
                if (client.Connected)
                    client.SendMessage(message);
                else
                {
                    notConnectedList.Add(client);
                }
            }
            foreach(var temp in notConnectedList)
            {
                clientList.Remove(temp);
            }
        }
        static void Main(string[] args)
        {
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpServer.Bind(new IPEndPoint(IPAddress.Parse("222.20.75.33"), 7788));
            tcpServer.Listen(100);
            Console.WriteLine("server running...");

            while (true)      //循环，使服务器端能连接多个客户端
            {
                Socket clientSocket = tcpServer.Accept();
                Console.WriteLine("a client is connected!");
                Client client = new Client(clientSocket);    //把与每个客户端通信的逻辑放到client类中处理
                clientList.Add(client);
            }
            

        }
    }
}
