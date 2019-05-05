using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class RightSlidingActionState : LeftActionState
    {
        public RightSlidingActionState(IPlayer player) : base(player)
        {
            base.Player.ApplyForce(Physics.PlayerSlidingAcceleration);
        }

        public override void Update(GameTime gameTime)
        {
            if (Player.Velocity.X >= 0)
            {
                Player.ActionState = new LeftStandingActionState(Player);
            }

            base.Update(gameTime);
        }

        public override void Jump()
        {
            Player.ActionState = new RightJumpingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new RightFallingActionState(Player);
        }
    }
}
