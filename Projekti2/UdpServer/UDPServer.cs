using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UdpServer
{
    class UDPServer
    {
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private EndPoint client;
        private EndPoint point;
        public UDPServer(string address,int port)
        {
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
           client= new IPEndPoint(IPAddress.Any,0);
            socket.Bind(new IPEndPoint(IPAddress.Parse(address),port));
        }
        public byte[] Receive()
        {
            socket.SendBufferSize = 128;
            socket.ReceiveBufferSize = 128;
             point = (EndPoint)client;
            byte[] receivedData = new byte[1024];
            int length = socket.ReceiveFrom(receivedData, SocketFlags.None, ref point);
            byte[] incomingByte = new byte[length];
            Array.Copy(receivedData, incomingByte, length);
            
            
           
            return incomingByte;
        }
       
        public void Send(byte[] data)
        {
            socket.SendBufferSize = 128;
            socket.ReceiveBufferSize = 128;
          

            socket.SendTo(data, 0, data.Length, SocketFlags.None, point);
        }
    }
}
