using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace MTKKokpitTesst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            // create the socket
            int port = 31090;
            Socket listenSocket = new Socket(AddressFamily.InterNetwork,
                                             SocketType.Stream,
                                             ProtocolType.Tcp);

            // bind the listening socket to the port
            IPHostEntry heserver = Dns.GetHostEntry("127.0.0.1");



            IPAddress hostIP = heserver.AddressList[0];
            IPEndPoint ep = new IPEndPoint(hostIP, port);
            listenSocket.Bind(ep);

            // start listening
            listenSocket.Listen(5);

            Console.WriteLine("Listening on {0}:{1}", hostIP.ToString(), port);


            byte[] bytes = new Byte[1024];
            string data = null;

            Socket handler = listenSocket.Accept();

            Console.WriteLine("Someone connected !!!");
            

            while(true)
            {
                int bytesReceived = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesReceived);
                Console.WriteLine(data);
                if(data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }
            


            /*
            //string request = "GET / HTTP/1.1\r\nHost: " + "192.168.69.223" +
            string request = "GET / HTTP/1.1\r\nHost: " + "127.0.0.1" +
            "\r\nConnection: Close\r\n\r\n";
            Byte[] bytesSent = Encoding.ASCII.GetBytes(request);
            Byte[] bytesReceived = new Byte[256];
            string page = "";

            //Socket s = ConnectSocket("192.168.69.223", 12345);
            Socket s = ConnectSocket("127.0.0.1", 31090);
            if (s == null)
            {
                Console.WriteLine("Connection failed");
                return;
            } else
            {
                Console.WriteLine("Connected...");
            }

            // Receive the server home page content.
            int bytes = 0;

            do
            {
                bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);

                Console.WriteLine(page);
            }
            while (bytes > 0);
            */








        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}
