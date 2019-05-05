using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal static class Offsets
    {
        public const int TileOffset = 32;

        public const int ExtendedHeightOffset = 1;

        public static Vector2 TopRightDebrisSpawnOffset = new Vector2(8, -16);
        public static Vector2 TopLeftDebrisSpawnOffset = new Vector2(-8, -16);
        public static Vector2 BottomRightDebrisSpawnOffset = new Vector2(8, 0);
        public static Vector2 BottomLeftDebrisSpawnOffset = new Vector2(-8, 0);

        public const int WarpWidthOffset = 1;
        public const int WarpHitBoxWidthOffset = 2;

        public const int FlagpoleWidthOffset = 3;

        public static Vector2 GameOverOffset = new Vector2(75, 25);

        public static Vector2 LivesLeftSpriteOffset = new Vector2(50, 10);
        public static Vector2 LivesLeftOffset = new Vector2(40, 25);

        public const int WarpCameraOffset = 64;

        public static Vector2 WorldHudOffset = new Vector2(50, 0);
        public static Vector2 TimeHudOffset = new Vector2(50, 0);
        public static Vector2 CoinHudOffset = new Vector2(35, 38);
        public static Vector2 CrossHudOffset = new Vector2(60, 37);
        public static Vector2 CoinCountHudOffset = new Vector2(75, 20);
        public static Vector2 LevelNameHudOffset = new Vector2(50, 20);
        public static Vector2 TimeLeftHudOffset = new Vector2(50, 20);

        public const int OutOfLevelOffset = 4000;
    }
}
