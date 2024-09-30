using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using LevelUpCSharp.Networking;
using LevelUpCSharp.Production;
using LevelUpCSharp.Products;
using LevelUpCSharp.Reflection;
using Newtonsoft.Json;

namespace LevelUpCSharp.Server
{
    class Program
    {
        private static readonly IEnumerable<Vendor> _vendors = new[]
            {new Vendor("Slimak")};

        private static IDictionary<string, Route> _handlers;

        static void Main(string[] args)
        {
            var server = BuildServer();

            // Start listening for client requests.
            server.Start();

            var listener = new Task(() => Listen(server), TaskCreationOptions.LongRunning);

            listener.Start();

            Console.ReadKey(true);
            Console.WriteLine("Killing server...");
        }

        private static void Listen(TcpListener server)
        {
            // Enter the listening loop.
            while (true)
            {
                Console.Write("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                TcpClient client = server.AcceptTcpClient();

                Console.WriteLine("Connected!");
                ProcessRequest(client);
                client.Close();
                Console.WriteLine("Closed!");
            }
        }

        private static Sandwich[] GetSandwiches()
        {
            return new ProductionHandler(_vendors).Sandwiches().ToArray();
        }

        #region networking
        private static TcpListener BuildServer()
        {
            throw new NotImplementedException();
        }

        private static void ProcessRequest(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {

                var cmd = ReadCommand(stream);

                Console.WriteLine("Received: {0}", cmd);

                var sandwiches = GetSandwiches();
                
                SendResponse(sandwiches, stream);

                Console.WriteLine("Responsed");
            }

        }
        private static string ReadCommand(NetworkStream stream)
        {
            throw new NotImplementedException();
        }

        public static void SendResponse<TValue>(TValue value, Stream s)
        {
            using (StreamWriter writer = new StreamWriter(s))
            {
                using (JsonTextWriter jsonWriter = new JsonTextWriter(writer))
                {
                    JsonSerializer ser = new JsonSerializer();
                    ser.Serialize(jsonWriter, value);
                    jsonWriter.Flush();
                }
            }
        }

        #endregion
        
        #region reflection

        private static object InvokeWorker(Route handler, string method, object instance)
        {
            throw new NotImplementedException();
        }

        private static object ConstructHandler(Route handler)
        {
            throw new NotImplementedException();
        }

        private static IDictionary<string, Route> ScanForHandlers(Assembly assembly)
        {
            var ctrlType = typeof(CtrlAttribute);


            return Reflector.FindByAttributes(assembly, ctrlType)
                .ToDictionary(
                    t => ((CtrlAttribute) t.GetCustomAttribute(ctrlType)).Name,
                    BuildMethodMap);
        }

        private static Route BuildMethodMap(TypeInfo ctrl)
        {
            var workerType = typeof(WorkerAttribute);
            var methods = Reflector.FindByAttributes(ctrl, workerType)
                .ToDictionary(
                    m => ((WorkerAttribute) m.GetCustomAttribute(workerType)).Name,
                    m => m.Name);
            return new Route(ctrl, methods);
        }

        #endregion
    }
}
