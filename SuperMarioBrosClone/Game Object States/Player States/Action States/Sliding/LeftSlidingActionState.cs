using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class LeftSlidingActionState : RightActionState
    {
        public LeftSlidingActionState(IPlayer player) : base(player)
        {
            base.Player.ApplyForce(-Physics.PlayerSlidingAcceleration);
        }

        public override void Update(GameTime gameTime)
        {
            if (Player.Velocity.X <= 0)
            {
                Player.ActionState = new RightStandingActionState(Player);
            }

            base.Update(gameTime);
        }

        public override void Jump()
        {
            Player.ActionState = new LeftJumpingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new LeftFallingActionState(Player);
        }
    }
}
