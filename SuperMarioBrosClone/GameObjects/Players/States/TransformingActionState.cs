using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Audio;

namespace SuperMarioBrosClone.GameObjects.Players.States
{
    internal abstract class TransformingActionState : ActionState
    {
        protected TransformingActionState(IPlayer player, float time) : base(player)
        {
            base.Player.CutXVelocity();
            base.Player.CutYVelocity();

            TimedActionManager.Instance.RegisterTimedAction(null, SetStateAfterTransformation, time);
            Game1.Instance.Transition();
            Game1.Instance.UnregisterGameObject(Player);

            SoundManager.Instance.PlaySoundEffect(GetType().Name);
        }

        public override void Update(GameTime gameTime)
        {
            Player.CutXVelocity();
            Player.CutYVelocity();

            base.Update(gameTime);
        }

        protected virtual void SetStateAfterTransformation()
        {
            Game1.Instance.RegisterGameObject(Player);
            Game1.Instance.Transition();
        }
    }
}
