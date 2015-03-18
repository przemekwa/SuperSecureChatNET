using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SuperSecureChatNET
{
    public static class Helper
    {
        public static IPAddress GetIpFromString(string ipAdress)
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

        public static IPAddress GetMyIp()
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
