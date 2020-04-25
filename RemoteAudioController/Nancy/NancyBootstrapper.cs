using Nancy;
using Nancy.Conventions;
using Nancy.TinyIoc;

namespace RemoteAudioController.Nancy
{
    public class NancyBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<IAudioController>(new AudioSwitchController());
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/", Program.RootDir));
            base.ConfigureConventions(nancyConventions);
        }
    }
}
