using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SuperSecureChatNET
{
    abstract class TcpIpBase
    {
        public IPAddress Ip { get; set; }
        public int Port { get; set; }

        public TcpIpBase(string Ip, int port)
        {
            this.Ip = Helper.GetIpFromString(Ip);
            this.Port = port;
        }

        public TcpIpBase(IPAddress Ip, int port)
        {
            this.Ip = Ip;
            this.Port = port;
        }
    }
}
