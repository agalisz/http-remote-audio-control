using log4net;
using Nancy;

namespace RemoteAudioController.Nancy
{
    public class MainModule : NancyModule
    {
        private static readonly ILog Logger = LogManager.GetLogger(nameof(MainModule));

        public MainModule(IAudioController audioController)
        {
            Get("/", parameters =>
            {
                return Response.AsFile($"{Program.RootDir}/index.html", "text/html");
            });

            Get("/volume/set/{Volume}", async parameters =>
            {
                Logger.Info($"Request: /volume/set/{parameters.Volume}");
                await audioController.SetVolume(parameters.Volume);
                return string.Empty;
            });

            Get("/volume/get/", async parameters =>
            {
                Logger.Info($"Request: /volume/get/");
                int volume = await audioController.GetVolume();
                return volume.ToString();
            });
        }
    }
}
