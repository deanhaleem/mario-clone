using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrosClone
{
    internal class StarMario : PlayerDecorator
    {
        private ISprite starMarioSprite;

        public override IActionState ActionState
        {
            get => DecoratedPlayer.ActionState;
            set
            {
                DecoratedPlayer.ActionState = value;
                starMarioSprite = SpriteFactory.Instance.CreateSprite(
                    GetType().Name + DecoratedPlayer.PowerUpState.GetType().Name + DecoratedPlayer.Direction +
                    DecoratedPlayer.ActionState.GetType().Name + DecoratedPlayer.GetType().Name);
            }
        }

        public StarMario(IPlayer player) : base(player, Color.White, Timers.StarTimer)
        {
            starMarioSprite = SpriteFactory.Instance.CreateSprite(
                GetType().Name + DecoratedPlayer.PowerUpState.GetType().Name + DecoratedPlayer.Direction +
                DecoratedPlayer.ActionState.GetType().Name + DecoratedPlayer.GetType().Name);

            SoundManager.Instance.StopSong();
            SoundManager.Instance.PlaySong(this);
        }

        public override void Update(GameTime gameTime)
        {
            starMarioSprite.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            starMarioSprite.Draw(spriteBatch, DecoratedPlayer.Location, Color.White);
        }

        public override void RemoveDecorator()
        {
            SoundManager.Instance.StopSong();
            SoundManager.Instance.PlaySong(DecoratedPlayer);
            base.RemoveDecorator();
        }

        public override void TakeDamage() { }
        public override void Decorate() { }
    }
}
