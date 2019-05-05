using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrosClone
{
    internal class GameOverGameState : GameState
    {
        public GameOverGameState(Game1 game, ILevel level) : base(game, level)
        {
            base.CameraController.SetCameraLocation(Vector2.Zero);

            Game.Player.Location = Locations.GameOverPlayerLocation;
            TimedActionManager.Instance.RegisterTimedAction(null, Game.HardReset, Timers.GameOverTimer);
            SoundManager.Instance.PlaySoundEffect(GetType().Name);
        }

        public override void Update(GameTime gameTime)
        {
           TimedActionManager.Instance.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFactory.Instance.Font, Strings.GameOverText,
                new Vector2(Game.ScreenSize.X / 2f - Offsets.GameOverOffset.X,
                    Game.ScreenSize.Y / 2f - Offsets.GameOverOffset.Y), Color.White);
        }
    }
}
