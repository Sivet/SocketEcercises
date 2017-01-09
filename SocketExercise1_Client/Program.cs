using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketExercise1_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketClient_Ex1 client = new SocketClient_Ex1("127.0.0.1", 11000);
            client.Run();
        }
    }
}
