using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public string ipaddress = "222.20.75.33";
    public int port = 7788;
    public InputField textInput;
    public Text chatText;

    private Socket clientSocket;
    private Thread t;
    private byte[] data = new byte[1024];
    private string message = "";   //消息容器

    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    // Update is called once per frame
    void Update()
    {
        if(message != null && message != "")
        {
            chatText.text += message + "\n";
            message = "";
        }
    }

    void ConnectToServer()
    {
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipaddress), port));

        //创建一个新的线程，用来接收消息
        t = new Thread(ReceiveMessage);
        t.Start();
    }

    void ReceiveMessage()
    {
        while (true)
        {
            if (clientSocket.Connected == false)
                break;
            int length = clientSocket.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, length);
            print(message);
            //chatText.text += "\n" + message;
        }
        
    }

    void SendMessage(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        clientSocket.Send(data);
    }

    public void OnSendButtonClick()
    {
        string value = textInput.text;
        SendMessage(value);
        textInput.text = "";
    }

    void OnDestroy()
    {
        clientSocket.Close();   //关闭连接
    }
}
