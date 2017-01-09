using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocketExercise1_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketServerEx1 server = new SocketServerEx1("127.0.0.1", 11000);
            server.Run();
        }
    }
}
