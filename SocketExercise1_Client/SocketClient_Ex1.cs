using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketExercise1_Client
{
    class SocketClient_Ex1
    {
        TcpClient server;
        NetworkStream stream;
        StreamReader reader;
        StreamWriter writer;

        private string ip;
        private int port;

        private volatile bool stop = false;

        public SocketClient_Ex1(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }
        public void Run()
        {
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise 5 var at tilføje threads til 3 og 4
            
        }
        public void Exercise1()
        {
            server = new TcpClient(ip, port);
            stream = server.GetStream();

            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);


            while (!stop)
            {
                writer.WriteLine("Hello server");
                writer.Flush();

                string Temp = reader.ReadLine();
                Console.WriteLine(Temp);

                Console.ReadKey();

                if (Temp == "Hello Client")
                {
                    writer.Close();
                    reader.Close();
                    stream.Close();
                    server.Close();
                    stop = true;
                }

            }
        }
        public void Exercise2()
        {
            server = new TcpClient(ip, port);
            stream = server.GetStream();

            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);


            while (!stop)
            {
                string Temp = reader.ReadLine();
                Console.WriteLine(Temp);

                writer.WriteLine("Time?");
                writer.Flush();

                Temp = reader.ReadLine();
                Console.WriteLine(Temp);

                Console.ReadKey();


                writer.Close();
                reader.Close();
                stream.Close();
                server.Close();
                stop = true;


            }
        }
        public void Exercise3()
        {
            server = new TcpClient(ip, port);
            stream = server.GetStream();

            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);

            string temp = reader.ReadLine();
            Console.WriteLine(temp);

            while (!stop)
            {
                string message;
                message = Console.ReadLine();

                writer.WriteLine(message);
                writer.Flush();

                string answer = reader.ReadLine();
                Console.WriteLine(answer);
                if (answer == "Bye")
                {
                    stop = true;
                }
                
            }
            writer.Close();
            reader.Close();
            stream.Close();
            server.Close();
        }
        public void Exercise4()
        {
            server = new TcpClient(ip, port);
            stream = server.GetStream();

            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);

            string temp = reader.ReadLine();
            Console.WriteLine(temp);

            while (!stop)
            {
                string message;
                message = Console.ReadLine();

                writer.WriteLine(message);
                writer.Flush();

                string answer = reader.ReadLine();
                Console.WriteLine(answer);
                if (answer == "Bye")
                {
                    stop = true;
                }

            }
            writer.Close();
            reader.Close();
            stream.Close();
            server.Close();
        }
        
    }
}
