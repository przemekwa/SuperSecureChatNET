using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SuperSecureChatNET
{
    class Program
    {
        private static string IP = "";

        private static void Main(string[] args)
        {
            Console.WriteLine(">> Start SuperSecureChatNet");

            IP = args[0];

            var b = new Task(Serwer);

            b.Start();

            while (true)
            {
                var teskt = Console.ReadLine();
                Console.WriteLine("Czekanie na dane");
                Cilent(teskt, GetIp(args[0]));
            }
        }

        private static void Cilent(string text, IPAddress ip)
        {
            try
            {
                var clientSocket = new System.Net.Sockets.TcpClient();

                clientSocket.Connect(ip, 12345);


                NetworkStream serverStream = clientSocket.GetStream();
                byte[] outStream = System.Text.Encoding.UTF8.GetBytes(text + "$");
                serverStream.Write(outStream, 0, outStream.Length);
            }
            catch (Exception exp)
            {

                Console.WriteLine(exp);
            }




        }

        private static void Serwer()
        {
            TcpListener serverSocket = new TcpListener(MyIp(), 12345);

            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();

            Console.WriteLine(">> Server Start");



            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                NetworkStream networkStream = clientSocket.GetStream();

                byte[] bytesFrom = new byte[10025];

                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);

                string dataFromClient = System.Text.Encoding.UTF8.GetString(bytesFrom);

                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));

                Console.WriteLine(" >> Data from {0}: {1} ", IP, dataFromClient);
            }

        }


        private static IPAddress GetIp(string ipAdress)
        {
            var ipStringArrya = ipAdress.Split('.');

            var ipLenght = ipStringArrya.Count();

            var ipByte = new byte[ipLenght];

            for (int i = 0; i < ipLenght; i++)
            {
                ipByte[i] = Convert.ToByte(ipStringArrya[i]);
            }

            return new IPAddress(ipByte);
        }

        private static IPAddress MyIp()
        {
            IPHostEntry host;

            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork))
            {
                return ip;
            }

            return null;
        }
    }
}
