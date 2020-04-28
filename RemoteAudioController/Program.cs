using CommandLine;
using log4net;
using Microsoft.Owin.Hosting;
using System;

namespace RemoteAudioController
{
    class Program
    {
        public class Options
        {
            [Option('p', "port", Required = false, HelpText = "Port", Default = 8080)]
            public int Port { get; set; }
        }

        public const string RootDir = "wwwroot";

        private static readonly ILog Logger = LogManager.GetLogger(nameof(Program));

        static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    try
                    {
                    //http://*:10281/
                        Logger.Info($"Starting server localhost:{o.Port}...");

                        string url = $"http://+:{o.Port}";
                        using (WebApp.Start(url))
                        {
                            Logger.Info($"Server started. Press enter to stop it.");
                            Console.ReadLine();
                            Logger.Info($"Stopping the server...");
                            Logger.Info($"Server stopped.");
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.Error("Unknown error", e);
                    }
                });
        }
    }
}
