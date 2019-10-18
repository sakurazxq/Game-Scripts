using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace udpclient
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(new IPEndPoint(IPAddress.Parse("222.20.75.33"), 7788));

            while (true)
            {
                IPEndPoint point = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = udpClient.Receive(ref point);
                string message = Encoding.UTF8.GetString(data);
                Console.WriteLine("收到了消息：" + message);
            }
            

            udpClient.Close();
            Console.ReadKey();
        }
    }
}
