using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace _6_tcplistener
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Parse("222.20.75.33"), 7788);   //TcpListener对socket进行了一层封装，会自己创建socket对象

            listener.Start();   //开始监听
            Console.WriteLine("开始监听");

            TcpClient client = listener.AcceptTcpClient();   //等待客户端连接
            //Console.WriteLine("一个客户端连接过来");
            NetworkStream stream = client.GetStream();   //得到网络流，可以取得客户端发送过来的数据
            byte[] data = new byte[1024];

            while (true) {
                int length = stream.Read(data, 0, 1024);   //从网络流中读取数据存在data数组中，length为实际读取的字节数
                string message = Encoding.UTF8.GetString(data, 0, length);
                Console.WriteLine("收到了消息：" + message);
            }
            
            

            stream.Close();
            client.Close();
            listener.Stop();
            Console.ReadKey();
        }
    }
}
