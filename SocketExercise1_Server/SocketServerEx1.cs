using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketExercise1_Server
{
    class SocketServerEx1
    {
        IPAddress ip;
        Socket client;
        
        int port;
        private volatile bool stop = false;

        public SocketServerEx1(string ip, int port)
        {
            this.ip = IPAddress.Parse(ip);
            this.port = port;
        }

        public void Run()
        {
            //skaber og starter en listener
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();

            while (!stop)
            {
                //venter på at der kommer en client
                //når der gør acceptere den
                client = listener.AcceptSocket();

                //starter en thread til den nye client og sender acceptet fra listeneren med som en socket
                ClientHandlerEx1 ch = new ClientHandlerEx1(client);
                new Thread(ch.Run).Start();
            }
        }
    }
}
