using SuperMarioBrosClone.Audio;
using SuperMarioBrosClone.Statistics;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal class DeadActionState : ActionState
    {
        public DeadActionState(IPlayer player) : base(player)
        {
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();
            base.Player.ApplyImpulse(Physics.DeadPlayerImpulse);
            base.Player.ApplyForce(Physics.DeadPlayerGravitationalForce);

            StatManager.Instance.GainOrLoseLife(false);
            SoundManager.Instance.PlaySoundEffect(GetType().Name);
            Game1.Instance.Die();
            Game1.Instance.UnregisterGameObject(Player);
        }
    }
}
