using Owin;
using RemoteAudioController.Nancy;
using CorsOptions = Microsoft.Owin.Cors.CorsOptions;

namespace RemoteAudioController
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.UseNancy(options =>
            {
                options.Bootstrapper = new NancyBootstrapper();
            });
        }
    }
}
