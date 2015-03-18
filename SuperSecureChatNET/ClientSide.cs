using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SuperSecureChatNET
{
    class ClientSide
    {
        private IPAddress IpClient; 

        public ClientSide(string ip)
        {
            this.IpClient = Helper.GetIpFromString(ip);
        }

        public ClientSide(IPAddress ip)
        {
            this.IpClient = ip;
        }

        public void ReadLineFromConsole()
        {
            while (true)
            {
                var inputMsg = Console.ReadLine();

                this.SendMsg(inputMsg);
            }
        }

        public void SendMsg(string msg)
        {
            try
            {
                var clientSocket = new System.Net.Sockets.TcpClient();

                Console.WriteLine("Wysłanie wiadomośći od {0} ",IpClient);

                clientSocket.Connect(IpClient, 1235);

                NetworkStream serverStream = clientSocket.GetStream();

                byte[] outStream = System.Text.Encoding.UTF8.GetBytes(msg + "$");

                serverStream.Write(outStream, 0, outStream.Length);

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

    }
}
