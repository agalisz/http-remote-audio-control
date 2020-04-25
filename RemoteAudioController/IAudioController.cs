using System.Threading.Tasks;

namespace RemoteAudioController
{
    public interface IAudioController
    {
        Task<int> GetVolume();
        Task SetVolume(int value);
    }
}
