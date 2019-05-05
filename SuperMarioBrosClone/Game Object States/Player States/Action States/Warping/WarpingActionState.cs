using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class WarpingActionState : ActionState
    {
        private readonly Vector2 warpLocation;
        private readonly Vector2 warpVelocity;
        private readonly int warpTime;
        private float warpTimer;

        public WarpingActionState(IPlayer player, Vector2 location, Vector2 velocity) : base(player)
        {
            this.warpLocation = location;
            this.warpVelocity = velocity;
            this.warpTime = Offsets.TileOffset;
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();

            Game1.Instance.Warp();
            Game1.Instance.UnregisterGameObject(Player);
        }

        public override void Update(GameTime gameTime)
        {
            SetWarpTimer(Physics.WarpSpeed);
            Player.Location += warpVelocity;

            base.Update(gameTime);
        }

        private void SetWarpTimer(float speed)
        {
            warpTimer += speed;
            if (warpTimer >= warpTime)
            {
                Player.ActionState = new RightStandingActionState(Player);
                Game1.Instance.RegisterGameObject(Player);
                if (warpLocation != Vector2.Zero)
                {
                    Player.Location = new Vector2(warpLocation.X, warpLocation.Y + Offsets.TileOffset);
                    Game1.Instance.Warp(warpLocation);
                }
                else
                {
                    Game1.Instance.Warp();
                }
            }
        }

        public override void WarpDown(Vector2 location) { }
        public override void WarpRight(Vector2 location) { }
        public override void WarpUp() { }
    }
}
