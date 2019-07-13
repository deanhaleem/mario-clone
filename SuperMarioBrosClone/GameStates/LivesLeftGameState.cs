using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrosClone.Graphics;
using SuperMarioBrosClone.Levels;
using SuperMarioBrosClone.Statistics;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameStates
{
    internal class LivesLeftGameState : GameState
    {
        private readonly ISprite standingPlayerSprite;
        private readonly ISprite crossSprite;

        public LivesLeftGameState(Game1 game, ILevel level) : base(game, level)
        {
            this.standingPlayerSprite = SpriteFactory.Instance.CreateSprite(GetType().Name + Game.Player.GetType().Name);
            this.crossSprite = SpriteFactory.Instance.CreateSprite(GetType().Name);
            base.CameraController.SetCameraLocation(Vector2.Zero);

            Game.Player.Location = Locations.GameOverPlayerLocation;
            TimedActionManager.Instance.RegisterTimedAction(null, Game.SoftReset, Timers.LivesLeftTimer);
        }

        public override void Update(GameTime gameTime)
        {
            standingPlayerSprite.Update(gameTime);
            crossSprite.Update(gameTime);
            TimedActionManager.Instance.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            standingPlayerSprite.Draw(spriteBatch, new Vector2(Game.ScreenSize.X / 2f - Offsets.LivesLeftSpriteOffset.X, Game.ScreenSize.Y / 2f), Color.White);
            crossSprite.Draw(spriteBatch, new Vector2(Game.ScreenSize.X / 2f, Game.ScreenSize.Y / 2f - Offsets.LivesLeftSpriteOffset.Y), Color.White);
            spriteBatch.DrawString(SpriteFactory.Instance.Font, StatManager.Instance.Lives.ToString(),
                new Vector2(Game.ScreenSize.X / 2f + Offsets.LivesLeftOffset.X,
                    Game.ScreenSize.Y / 2f - Offsets.LivesLeftOffset.Y), Color.White);
        }
    }
}
