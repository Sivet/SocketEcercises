using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketExercise1_Server
{
    class ClientHandlerEx1
    {
        TcpListener listener;
        NetworkStream stream;
        StreamReader reader;
        StreamWriter writer;

        private Socket client;

        private volatile bool stop = false;

        public ClientHandlerEx1(Socket client)
        {
            //tager den socket den får fra serveren
            this.client = client;
        }


        public void Run()
        {
            //Vælg hvilken exercise du vil kører, skal matche clienten

            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise 5 var at tilføje threads til 3 og 4
        }
        public void Exercise1()
        {
            //skaber en stream mellem clienten og serveren
            stream = new NetworkStream(client);
            //tilføjer en reader til den stream
            reader = new StreamReader(stream);
            //tilføjer en writer til den stream
            writer = new StreamWriter(stream);

            while (!stop)
            {
                string Temp = reader.ReadLine();

                writer.WriteLine("Hello Client");
                writer.Flush();
                

                if (Temp == "Hello server")
                {
                    writer.Close();
                    reader.Close();
                    stream.Close();
                    client.Close();
                    stop = true;
                }

            }
        }
        public void Exercise2()
        {
           
            stream = new NetworkStream(client);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            while (!stop)
            {
                writer.WriteLine("Ready");
                writer.Flush();

                string Temp = reader.ReadLine();

                if (Temp == "Time?")
                {
                    writer.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                    writer.Flush();
                }
                
                    writer.Close();
                    reader.Close();
                    stream.Close();
                    client.Close();
                    stop = true;
            }
        }
        public void Exercise3()
        {
            stream = new NetworkStream(client);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
            
            writer.WriteLine("Ready");
            writer.Flush();

            while (!stop)
            {
                string Temp = reader.ReadLine();

                if (Temp == "Time?")
                {
                    writer.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                    writer.Flush();
                }
                if (Temp == "Date?")
                {
                    writer.WriteLine(DateTime.Today);
                    writer.Flush();
                }
                if (Temp == "Exit")
                {
                    writer.WriteLine("Bye");
                    writer.Flush();
                    stop = true;
                }
                
            }
            writer.Close();
            reader.Close();
            stream.Close();
            client.Close();
        }
        public void Exercise4()
        {
            
            stream = new NetworkStream(client);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            writer.WriteLine("Ready");
            writer.Flush();

            while (!stop)
            {
                //får en string fra clienten og gemmer den
                string input = reader.ReadLine();
                if (input == "Exit")
                {
                    writer.WriteLine("Bye");
                    writer.Flush();
                    stop = true;
                }

                //splitter den string ved mellemrum
                string[] temp = input.Split(null);

                //tjekker hvilken funktion vi skal bruge ud fra arrayets plads 0
                if (temp[0] == "add")
                {
                    string result;
                    //udregner resultatet ved at tilgå arrayets plads 1 og 2, parse dem, ligge dem sammen, og tilbage til string
                    result = Convert.ToString(int.Parse(temp[1]) + int.Parse(temp[2]));
                    writer.WriteLine(result);
                    writer.Flush();
                }
                if (temp[0] == "sub")
                {
                    string result;
                    result = Convert.ToString(int.Parse(temp[1]) - int.Parse(temp[2]));
                    writer.WriteLine(result);
                    writer.Flush();
                }
                if (temp[0] == "multi")
                {
                    string result;
                    result = Convert.ToString(int.Parse(temp[1]) * int.Parse(temp[2]));
                    writer.WriteLine(result);
                    writer.Flush();
                }
                if (temp[0] == "diff")
                {
                    string result;
                    result = Convert.ToString(int.Parse(temp[1]) / int.Parse(temp[2]));
                    writer.WriteLine(result);
                    writer.Flush();
                }
                
            }
            writer.Close();
            reader.Close();
            stream.Close();
            client.Close();
        }
    }
}
