using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Socket同步server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[5];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5858);

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(100);
            byte[] bytes = new byte[1024];

            Console.WriteLine("Waiting for a connection...");
            Socket handler = listener.Accept();
            String data = null;

            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf("\n") >= 1)
                {
                    Console.WriteLine("Text received : {0}", data);
                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    handler.Send(msg);
                    data = "";
                }
                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }

            Console.WriteLine("Text received : {0}", data);

            //byte[] msg = Encoding.ASCII.GetBytes(data);
            //handler.Send(msg);
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }
    }
}
