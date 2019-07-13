using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Audio;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class JumpingActionState : AerialActionState
    {
        public JumpingActionState(IPlayer player) : base(player)
        {
            base.Player.ApplyForce(Physics.PlayerJumpingGravitationalForce + new Vector2(Player.Acceleration.X, 0));

            if (Player.Velocity.Y <= 0)
            {
                Player.ApplyImpulse(Physics.PlayerJumpImpulse - new Vector2(0, Player.Velocity.Y));
            }

            SoundManager.Instance.PlaySoundEffect(Player.PowerUpState.GetType().Name + GetType().Name);
        }

        public override void Update(GameTime gameTime)
        {
            if (Player.Velocity.Y >= 0)
            {
                Player.ActionState = new FallingActionState(Player);
            }

            base.Update(gameTime);
        }

        public override void StopJumping()
        {
            if (Player.Velocity.Y < -Physics.StopJumpingThreshold)
            {
                Player.ApplyImpulse(new Vector2(0, -Player.Velocity.Y - Physics.StopJumpingThreshold));
            }
        }
    }
}