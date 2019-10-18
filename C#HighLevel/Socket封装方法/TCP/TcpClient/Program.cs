using System;
using System.Net.Sockets;
using System.Text;

namespace tcpclient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("222.20.75.33", 7788);   //当创建tcpclient对象时，就会自动连接server
            NetworkStream stream = client.GetStream();   //通过网络流进行数据交换
            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);    //write用来写入数据
            }
            

            stream.Close();
            client.Close();
            Console.ReadKey();
        }
    }
}
