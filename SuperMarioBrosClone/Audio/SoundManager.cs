using SuperMarioBrosClone.GameObjects;

namespace SuperMarioBrosClone.Audio
{
    internal class SoundManager
    {
        private readonly SoundPlayer soundPlayer = new SoundPlayer();

        public static SoundManager Instance { get; } = new SoundManager();

        private SoundManager()
        {

        }

        public void LoadContent(string soundEffectsFile, string soundEffectNamesFile, string songsFile)
        {
            soundPlayer.LoadContent(soundEffectsFile, soundEffectNamesFile, songsFile);
        }

        public void PlaySong(IPlayer player)
        {
            soundPlayer.PlaySong(player);
        }

        public void PlaySoundEffect(string soundEffectEventName)
        {
            soundPlayer.PlaySoundEffect(soundEffectEventName);
        }

        public void PlayTimeTick()
        {
            soundPlayer.PlayTimeTick();
        }

        public void StopSoundEffect()
        {
            soundPlayer.StopSoundEffect();
        }

        public void StopSong()
        {
            soundPlayer.StopSong();
        }

        public void PauseSong()
        {
            soundPlayer.PauseSong();
        }
    }
}
