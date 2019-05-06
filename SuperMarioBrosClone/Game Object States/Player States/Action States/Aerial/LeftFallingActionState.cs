using System;
using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class LeftFallingActionState : LeftAerialActionState
    {
        public LeftFallingActionState(IPlayer player) : base(player)
        {
            base.Player.ApplyForce(Physics.PlayerFallingGravitationalForce + new Vector2(Player.Acceleration.X, 0));
        }

        public override void Land()
        {
            Player.ActionState = Math.Abs(Player.Velocity.X) <= float.Epsilon * 2f
                ? new LeftStandingActionState(Player)
                : Player.Velocity.X > 0
                    ? (IActionState) new RightWalkingActionState(Player)
                    : new LeftWalkingActionState(Player);
        }
    }
}
