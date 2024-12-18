using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace P2Pc
{
    public class P2PClient
    {
        public void SendMessage(string ipAddress, int port, string message)
        {
            using TcpClient client = new TcpClient(ipAddress, port);
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }
    }
}