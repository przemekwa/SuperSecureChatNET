using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SuperSecureChatNET
{
    internal class ServerSide : TcpIpBase
    {
        public ServerSide(string ip, int port) 
            : base(ip,port)
        {
        }

        public ServerSide(IPAddress ip, int port)
            : base(ip, port)
        {
        }

        public void ServerTask()
        {

            Console.WriteLine("Start serwera o ip {0}", this.Ip);

            this.SerwerWorker();
        }

        private void SerwerWorker()
        {
            TcpListener serverSocket = new TcpListener(this.Ip, this.Port);

            TcpClient clientSocket = default(TcpClient);

            serverSocket.Start();

            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                NetworkStream networkStream = clientSocket.GetStream();

                byte[] bytesFrom = new byte[10025];

                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);

                string dataFromClient = System.Text.Encoding.UTF8.GetString(bytesFrom);

                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                Console.WriteLine(" >> Data from {0}: {1} ", this.Ip, dataFromClient);
            }

        }

    }
}
