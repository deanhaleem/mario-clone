using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal abstract class AerialActionState : ActionState
    {
        protected AerialActionState(IPlayer player) : base(player)
        {

        }

        public override void WalkRight()
        {
            Player.ApplyForce(Player.Velocity.X > 0
                ? new Vector2(Physics.HorizontalPlayerAerialForce.X, Player.Acceleration.Y)
                : new Vector2(Physics.HorizontalPlayerAerialForce.Y, Player.Acceleration.Y));
        }

        public override void WalkLeft()
        {
            Player.ApplyForce(Player.Velocity.X < 0
                ? new Vector2(-Physics.HorizontalPlayerAerialForce.X, Player.Acceleration.Y)
                : new Vector2(-Physics.HorizontalPlayerAerialForce.Y, Player.Acceleration.Y));
        }

        public override void StopMovingRight()
        {
            Player.ApplyForce(new Vector2(0, Player.Acceleration.Y));
        }

        public override void StopMovingLeft()
        {
            Player.ApplyForce(new Vector2(0, Player.Acceleration.Y));
        }
    }
}