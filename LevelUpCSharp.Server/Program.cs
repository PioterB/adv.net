using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
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

            _handlers = ScanForHandlers(Assembly.GetExecutingAssembly());

            // Start listening for client requests.
            server.Start();

            var listener = new Task(() => Listen(server), TaskCreationOptions.LongRunning);

            listener.Start();

            Console.ReadKey(true);
            Console.WriteLine("Killing server...");
        }

        private static TcpListener BuildServer()
        {
            var server = new TcpListener(IPAddress.Any, 13000);
            return server;
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

        private static void ProcessRequest(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {

                var cmd = ReadCommand(stream);

                Console.WriteLine("Received: {0}", cmd);

				var action = Parse(cmd);

                var sandwiches = Execute(action);
                                
                SendResponse(sandwiches, stream);

                Console.WriteLine("Responsed");
            }
        }

        private static string ReadCommand(NetworkStream stream)
        {
            Byte[] bytes = new Byte[256];
            string data;
            var i = stream.Read(bytes, 0, bytes.Length);
            // Translate data bytes to a ASCII string.
            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
            return data;
        }

        private static AskedAction Parse(string cmd)
        {
            return new AskedAction("p", "s");
        }

        private static IEnumerable<Sandwich> Execute(AskedAction request)
        {
            var maker = Locate(request);
            var instance = ConstructHandler(maker.Group);
            var sandwiches = InvokeWorker(maker, instance);
            return sandwiches;
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

        private static SandwichesMaker Locate(AskedAction action)
		{
            var route = _handlers[action.Group];
            var group = route.Type;
            var method = route.Methods[action.Worker];
            return new SandwichesMaker(group, method);
		}

        #region reflection
        private static object ConstructHandler(Type handler)
        {
            return Activator.CreateInstance(handler, _vendors);
        }

        private static IEnumerable<Sandwich> InvokeWorker(SandwichesMaker maker, object instance)
        {
            return (IEnumerable<Sandwich>)maker.Group.GetMethod(maker.Method).Invoke(instance, null);
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
