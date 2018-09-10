using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Udp); // 报错
            IPHostEntry iPHostEntry = Dns.GetHostEntry("gitlab.xinbuxin.top");  // dns 和 IP
            IPAddress iPAddress = iPHostEntry.AddressList[0];
            Console.WriteLine(iPAddress);

            IPEndPoint ipe = new IPEndPoint(iPAddress, 22);
            try
            {
                s.Connect(ipe);
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine("ArgumentNullException : {0}", ae.ToString());
            }catch(SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }catch(Exception e)
            {
                Console.WriteLine("Exception : {0}", e.ToString());
            }

            byte[] msg = System.Text.Encoding.ASCII.GetBytes("This is a test.");
            int bytesSent = s.Send(msg);

            byte[] bytes = new byte[1024];
            int bytesRec = s.Receive(bytes);
            Console.WriteLine("Echoed text = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

            s.Shutdown(SocketShutdown.Both);
            s.Close();
        }
    }
}
