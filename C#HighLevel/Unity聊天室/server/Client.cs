using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace 聊天室socket_TCP服务器端
{
    class Client
    {
        private Socket clientSocket;
        private Thread t;
        private byte[] data = new byte[1024];

        public Client(Socket s)
        {
            clientSocket = s;
            //启动一个线程处理一个客户端的数据接收
            t = new Thread(ReceiveMessage);
            t.Start();
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                if(clientSocket.Poll(10,SelectMode.SelectRead))    //判断服务器端在10ms的超时时间内是否能从客户端收到消息，即判断socket是否断开
                {
                    clientSocket.Close();
                    break;    //跳出循环，终止线程的执行
                }

                int length = clientSocket.Receive(data);
                string message = Encoding.UTF8.GetString(data, 0, length);
                Program.BroadcastMessage(message);
                Console.WriteLine("收到了消息：" + message);

            }
        }

        public void SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            clientSocket.Send(data);
        }

        public bool Connected
        {
            get { return clientSocket.Connected; }
        }
    }
}
