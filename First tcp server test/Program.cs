using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace First_tcp_server_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = null;
            try
            {
                IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0];

                TcpListener server = new TcpListener(ip, 5466);

                server.Start();
                Console.WriteLine("server startet:  " + server.ToString());

                TcpClient serverclient = server.AcceptTcpClient();
                Console.WriteLine("client forbundet:  " + server.Server.Connected);

                stream = serverclient.GetStream();


                string message = "messege";

                StreamWriter serverStreamWriter = new StreamWriter(stream);
                StreamReader serverStreamReader = new StreamReader(stream);
                serverStreamWriter.AutoFlush = true;

                while (message.ToLower() != "stop")
                {
                    
                    message = serverStreamReader.ReadLine();
                    Console.Clear();
                    Console.WriteLine("message reshived:  " + message);

                    serverStreamWriter.WriteLine(message.ToUpper() + " DIN MONGOL");

                    Console.WriteLine("messege send:  " + message.ToUpper() + " DIN MONGOL");

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

           
        }
    }
}
