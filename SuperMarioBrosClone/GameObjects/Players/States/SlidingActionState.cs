using System;
using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class SlidingActionState : ActionState
    {
        public SlidingActionState(IPlayer player) : base(player)
        {
            base.Player.Direction = base.Player.Direction == Directions.Left ? Directions.Right : Directions.Left;
            base.Player.ApplyForce(Physics.PlayerSlidingAcceleration * (int) Player.Direction);
        }

        public override void Update(GameTime gameTime)
        {
            if (Math.Abs(Player.Velocity.X) <= 0.1f)
            {
                Player.Direction = base.Player.Direction == Directions.Left ? Directions.Right : Directions.Left;
                Player.ActionState = new StandingActionState(Player);
            }

            base.Update(gameTime);
        }

        public override void Jump()
        {
            Player.ActionState = new JumpingActionState(Player);
        }

        public override void Fall()
        {
            Player.ActionState = new FallingActionState(Player);
        }
    }
}