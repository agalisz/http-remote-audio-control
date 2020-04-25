using AudioSwitcher.AudioApi.CoreAudio;
using System.Threading.Tasks;

namespace RemoteAudioController
{
    public class AudioSwitchController : IAudioController
    {
        private readonly CoreAudioController audioController = new CoreAudioController();

        public async Task<int> GetVolume()
        {
            double volume = await GetDefaultDevice().GetVolumeAsync();
            return (int) volume;
        }

        public async Task SetVolume(int value)
        {
            await GetDefaultDevice().SetVolumeAsync(value);
        }

        private CoreAudioDevice GetDefaultDevice()
        {
            return audioController.DefaultPlaybackDevice;
        }
    }
}
