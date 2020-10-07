using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private const int bufferSize = 4096;

        IDictionary<string, Func<HttpRequest, HttpResponse>>
            routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);
            }
        }

        public async Task StartAsync(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();

                ProcessClientAsync(tcpClient);
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            // TODO: using
            using (NetworkStream stream = tcpClient.GetStream())
            {
                // TODO: research if there is faster data structure for array of bytes
                List<byte> data = new List<byte>();
                int possition = 0;
                byte[] buffer = new byte[bufferSize];  // chunk

                while (true)
                {
                    int count = await stream.ReadAsync(buffer, possition, buffer.Length);
                    possition += count;

                    if (count < buffer.Length)
                    {
                        var partialBuffer = new byte[count];
                        Array.Copy(buffer, partialBuffer, count);
                        data.AddRange(partialBuffer);
                        break;
                    }
                    else
                    {
                        data.AddRange(buffer);
                    }
                }

                var requestAsString =  Encoding.UTF8.GetString(data.ToArray());

                Console.WriteLine(requestAsString);
                // await stream.WriteAsync();
            }
        }
    }
}
