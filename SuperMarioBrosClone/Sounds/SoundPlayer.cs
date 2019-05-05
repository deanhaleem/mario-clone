using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using static System.IO.File;

namespace SuperMarioBrosClone
{
    internal class SoundPlayer
    {
        private readonly Dictionary<string, Song> songs = new Dictionary<string, Song>();
        private readonly Dictionary<string, SoundEffect> soundEffects = new Dictionary<string, SoundEffect>();
        private Dictionary<string, string> soundEffectNames;

        private SoundEffectInstance soundEffectInstance;

        public void LoadContent(string soundEffectsFile, string soundEffectNamesFile, string songsFile)
        {
            Dictionary<string, string> songNames = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(ReadAllText(songsFile));
            soundEffectNames = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(ReadAllText(soundEffectNamesFile));
            Dictionary<string, string> soundEffectFileNames = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(ReadAllText(soundEffectsFile));

            foreach (string songName in songNames.Keys)
            {
                songs.Add(songName, Game1.Instance.Content.Load<Song>(songNames[songName]));
            }
            foreach (string soundEffectName in soundEffectFileNames.Keys)
            {
                soundEffects.Add(soundEffectName, Game1.Instance.Content.Load<SoundEffect>(soundEffectFileNames[soundEffectName]));
            }
        }

        public void PlaySong(IPlayer player)
        {
            if (MediaPlayer.State != MediaState.Stopped)
            {
                MediaPlayer.Resume();
            }
            else
            {
                MediaPlayer.Play(songs[BackgroundSongManager.Instance.GetBackgroundSongName(player)]);
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlaySoundEffect(string soundEffectEventName)
        {
            soundEffects[soundEffectNames[soundEffectEventName]].Play();
        }

        public void PlayTimeTick()
        {
            soundEffectInstance = soundEffects[Strings.TimeTickSound].CreateInstance();
            soundEffectInstance.IsLooped = true;
            soundEffectInstance.Play();
        }

        public void StopSoundEffect()
        {
            soundEffectInstance.Stop();
        }

        public void StopSong()
        {
            MediaPlayer.Stop();
        }

        public void PauseSong()
        {
            MediaPlayer.Pause();
        }
    }
}
