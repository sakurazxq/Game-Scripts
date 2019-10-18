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
            UdpClient client = new UdpClient();

            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                client.Send(data, data.Length, new IPEndPoint(IPAddress.Parse("222.20.75.33"), 7788));
            }
            
            client.Close();
            Console.ReadKey();
        }
    }
}
