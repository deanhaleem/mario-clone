using System;
using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class FallingActionState : AerialActionState
    {
        public FallingActionState(IPlayer player) : base(player)
        {
            base.Player.ApplyForce(Physics.PlayerFallingGravitationalForce + new Vector2(Player.Acceleration.X, 0));
        }

        public override void Land()
        {
            if (Math.Abs(Player.Velocity.X) <= float.Epsilon * 2f)
            {
                Player.ActionState = new StandingActionState(Player);
            }
            else
            {
                Player.Direction = Player.Velocity.X > 0 ? Directions.Right : Directions.Left;
                Player.ActionState = new WalkingActionState(Player);
            }
        }
    }
}