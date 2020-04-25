using CommandLine;
using log4net;
using Nancy.Hosting.Self;
using RemoteAudioController.Nancy;
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
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    try
                    {
                        Logger.Info($"Starting Nancy server localhost:{o.Port}...");
                        NancyHost host = new NancyHost(
                            new NancyBootstrapper(),
                            new HostConfiguration
                            {
                                RewriteLocalhost = true
                            },
                            new Uri($"http://localhost:{o.Port}"));
                        host.Start();
                        Logger.Info($"Server started. Press any key to stop it.");

                        Console.ReadKey();

                        Logger.Info($"Stopping the server...");
                        host.Stop();
                        Logger.Info($"Server stopped.");
                    }
                    catch (Exception e)
                    {
                        Logger.Error("Unknown error", e);
                    }
                });
        }
    }
}
