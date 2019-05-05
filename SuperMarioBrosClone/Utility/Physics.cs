using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal static class Physics
    {
        public static Vector2 GravitationalForce = new Vector2(0, 50f);

        public static Vector2 TopRightDebrisVelocity = new Vector2(2f, -7f);
        public static Vector2 TopLeftDebrisVelocity = new Vector2(-2f, -7f);
        public static Vector2 BottomRightDebrisVelocity = new Vector2(2f, -5f);
        public static Vector2 BottomLeftDebrisVelocity = new Vector2(-2f, -5f);

        public static Vector2 RightProjectileVelocity = new Vector2(7f, 3f);
        public static Vector2 LeftProjectileVelocity = new Vector2(-7f, 3f);

        public static Vector2 BlockBumpVelocity = new Vector2(0, 1f);

        public static Vector2 FlippedEnemyImpulse = new Vector2(0, -5f);
        public static Vector2 FlippedEnemyMaxVelocity = new Vector2(1f, 5f);

        public static Vector2 ShellMaxVelocity = new Vector2(7f, 3f);

        public static Vector2 EnemyWakeUpImpulse = new Vector2(-1f, 0);

        public static Vector2 BouncingItemImpulse = new Vector2(2f, -2f);
        public static Vector2 BouncingItemBounceImpulse = new Vector2(0, -7f);
        public static Vector2 MovingItemImpulse = new Vector2(2f, 0);
        public static Vector2 SpawningItemImpulse = new Vector2(0, -1f);

        public static Vector2 ProjectileBounceImpulse = new Vector2(0, -4f);

        public static Vector2 MaxDebrisVelocity = new Vector2(2f, 12f);

        public static Vector2 MaxEnemyVelocity = new Vector2(1f, 3f);

        public static Vector2 SpinningCoinImpulse = new Vector2(0, -9f);
        public static Vector2 MaxSpinningCoinVelocity = new Vector2(0, 9f);

        public static Vector2 MaxItemVelocity = new Vector2(2f, 3f);

        public static Vector2 MaxPlayerVelocity = new Vector2(2.75f, 9f);

        public static Vector2 MaxProjectileVelocity = new Vector2(7f, 3f);

        public static Vector2 IndicatorVelocity = new Vector2(0, 1);

        public static Vector2 PlayerFallingGravitationalForce = new Vector2(0, 80f);
        public static Vector2 PlayerJumpingGravitationalForce = new Vector2(0, 45f);
        public static Vector2 PlayerJumpImpulse = new Vector2(0, -12f);
        public static Vector2 HorizontalPlayerAerialForce = new Vector2(7.5f, 20f);
        public static Vector2 DeadPlayerImpulse = new Vector2(0, -5f);
        public static Vector2 DeadPlayerGravitationalForce = new Vector2(0, 25f);
        public static Vector2 PlayerHorizontalAcceleration = new Vector2(7.5f, 0);
        public static Vector2 PlayerMaxRunningVelocity = new Vector2(5.65f, 9f);
        public static Vector2 PlayerSlidingAcceleration = new Vector2(20f, 0);

        public static Vector2 VerticalWarpVelocity = new Vector2(0, 0.5f);
        public static Vector2 HorizontalWarpVelocity = new Vector2(0.5f, 0);
        public const float WarpSpeed = 0.5f;

        public const float StopJumpingThreshold = 6f;

        public const float ShellSpeed = 7f;

        public static Vector2 BlockBumpForce = new Vector2(0, 2f);
        public static Vector2 BumpEnemyForce = new Vector2(0, -8f);
        public static Vector2 SlideDownFlagImpulse = new Vector2(0, 5f);

        public const float CollisionsDelta = 0.2f;
        public const float DeltaTime = 0.0066667f;
    }
}
