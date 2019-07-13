using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.GameObjects.Players;
using SuperMarioBrosClone.Statistics;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.Audio
{
    internal class BackgroundSongManager
    {
        public static BackgroundSongManager Instance { get; } = new BackgroundSongManager();

        private BackgroundSongManager()
        {

        }

        public string GetBackgroundSongName(IPlayer player)
        {
            if (player is StarMario)
            {
                return StatManager.Instance.Time <= Utilities.PlayHurryUpSongTime
                    ? Strings.HurrySongCode + player.GetType().Name
                    : player.GetType().Name;
            }

            return StatManager.Instance.Time <= Utilities.PlayHurryUpSongTime ? player.Location.X > 10000
                    ?
                    Strings.HurryUnderworldSong
                    :
                    Strings.HurryOverworldSong :
                player.Location.X > Locations.UnderworldLocation.X ? Strings.UnderworldSong : Strings.OverworldSong;
        }
    }
}
