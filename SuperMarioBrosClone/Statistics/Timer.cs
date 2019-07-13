using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Audio;
using SuperMarioBrosClone.GameStates;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.Statistics
{
    internal class Timer
    {
        private readonly int initialTime;
        private float elapsedTime;
        private int remainingTime;

        private float ElapsedTime
        {
            get => elapsedTime;
            set
            {
                elapsedTime = value;
                if (elapsedTime >= Utilities.TimeToDecrement)
                {
                    Time--;
                    elapsedTime = 0;
                }
            }
        }

        public int Time
        {
            get => remainingTime;
            set
            {
                remainingTime = value;
                if (!(Game1.Instance.GameState is VictoryGameState))
                {
                    if (remainingTime == Utilities.PlayWarningTime)
                    {
                        SoundManager.Instance.StopSong();
                        SoundManager.Instance.PlaySoundEffect(GetType().Name);
                    }
                    if (remainingTime == Utilities.PlayHurryUpSongTime)
                    {
                        SoundManager.Instance.StopSong();
                        SoundManager.Instance.PlaySong(Game1.Instance.Player);
                    }
                }
                if (remainingTime < 0)
                {
                    remainingTime = 0;
                }
            }
        }

        public Timer(int initialTime)
        {
            this.initialTime = initialTime;
            this.Time = initialTime;
        }

        public void Update(GameTime gameTime)
        {
            ElapsedTime += (float) gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void TallyUp()
        {
            Time--;
        }

        public void Reset()
        {
            Time = initialTime;
        }
    }
}
