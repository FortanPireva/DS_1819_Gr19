using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projekti2
{
    class UDPClient
    {
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private EndPoint epFrom = new IPEndPoint(IPAddress.Parse("127.0.0.1"),11000);
        private string address;
        private int port;
        
        public UDPClient(string address, int port)
        {
          
          
            this.address = address;
            this.port = port;
        }
        public byte[] SendAndReceive(byte[] data)
        {
            socket.SendBufferSize = 128;
            socket.ReceiveBufferSize = 128;
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(address), port);
            socket.SendTo(data,0,data.Length,SocketFlags.None,serverAddress);
            byte[] receivedData=new byte[1028];
            int length=socket.Receive(receivedData);

            byte[] incomingByte = new byte[length];

            Array.Copy(receivedData, incomingByte, length);
            return incomingByte;
        }
        public static byte[] getPublicKey()
        {
            //Merr absolute path per fajllin e certifikates se serverit
            string Certificate = Path.GetFullPath("UdpServer.cer");

            // Load the certificate into an X509Certificate object.
            X509Certificate cert = new X509Certificate(Certificate);


            byte[] results = cert.GetPublicKey();
            return results;
        }
    }
}
