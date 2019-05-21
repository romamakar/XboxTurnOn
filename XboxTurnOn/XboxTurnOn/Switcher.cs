using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace XboxTurnOn
{
    public class Switcher
    {
        public static void StartClient(IPAddress ipAddress, string liveId, int retries = 5)
        {

            // Connect to a remote device.  

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPEndPoint endPoint = new IPEndPoint(ipAddress, 5050);
            sock.Connect(endPoint);
          
            for (int retry = 0; retry < retries; retry++)
            {
                byte[] payload = new byte[3 + liveId.Length];
                payload[0] = 0x00;
                payload[1] = (byte)liveId.Length;

                for (int i = 0; i < liveId.Length; i++)
                    payload[i + 2] = (byte)liveId[i];
                payload[payload.Length - 1] = 0x00;

                byte[] header = new byte[6];
                header[0] = 0xdd;
                header[1] = 0x02;
                header[2] = 0x00;
                header[3] = (byte)payload.Length;
                header[4] = 0x00;
                header[5] = 0x00;

                using (var ms = new MemoryStream(header.Length + payload.Length))
                {
                    ms.Write(header, 0, header.Length);
                    ms.Write(payload, 0, payload.Length);

                    sock.SendTo(ms.ToArray(), endPoint);
                }
            }

            // Release the socket.  
            sock.Shutdown(SocketShutdown.Both);
            sock.Close();
        }
    }
}
