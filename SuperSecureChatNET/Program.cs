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
        public static void Main(string[] args)
        {
            Console.WriteLine(">> Start SuperSecureChatNet");

            var receiverIP = Helper.GetIpFromString(args[0]);

            receiverIP = Helper.GetMyIp();

            var server = new ServerSide(receiverIP);
            
            var serwerThread = new Task(server.ServerTask);
            
            serwerThread.Start();

            var client = new ClientSide(receiverIP);

            client.ReadLineFromConsole();
        }
    }
}
