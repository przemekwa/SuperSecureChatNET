using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SuperSecureChatNET
{
    class ClientSide : TcpIpBase
    {
        public ClientSide(string ip, int port) 
            : base(ip, port)
        {
        }

        public ClientSide(IPAddress ip, int port)
            : base(ip, port)
        {
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

                Console.WriteLine("Wysłanie wiadomośći od {0} ",this.Ip);

                clientSocket.Connect(this.Ip, this.Port);

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
