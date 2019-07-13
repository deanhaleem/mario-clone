using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrosClone.Graphics;
using SuperMarioBrosClone.Statistics;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.Display
{
    internal class Hud : IHud
    {
        private readonly ISprite coinSprite;
        private readonly ISprite crossSprite;
        private readonly Point screenSize;

        public Hud(Point size)
        {
            this.coinSprite = SpriteFactory.Instance.CreateSprite(GetType().Name);
            this.crossSprite = SpriteFactory.Instance.CreateSprite(Game1.Instance.GameState.GetType().Name);
            this.screenSize = size;
        }

        public void Update(GameTime gameTime)
        {
            coinSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFactory.Instance.Font, Strings.PlayerHudName, Locations.PlayerHudLocation, Color.White);
            spriteBatch.DrawString(SpriteFactory.Instance.Font, Strings.GameWorldName, new Vector2(screenSize.X / 2f + Offsets.WorldHudOffset.X, 0), Color.White);
            spriteBatch.DrawString(SpriteFactory.Instance.Font, Strings.GameTimeName, new Vector2(3 * screenSize.X / 4f + Offsets.TimeHudOffset.X, 0), Color.White);

            spriteBatch.DrawString(SpriteFactory.Instance.Font, StatManager.Instance.Score.ToString(Strings.ScoreDigits), Locations.ScoreHudLocation, Color.White);
            coinSprite.Draw(spriteBatch, new Vector2(screenSize.X / 4f + Offsets.CoinHudOffset.X, Offsets.CoinHudOffset.Y), Color.White);
            crossSprite.Draw(spriteBatch, new Vector2(screenSize.X / 4f + Offsets.CrossHudOffset.X, Offsets.CrossHudOffset.Y), Color.White);
            spriteBatch.DrawString(SpriteFactory.Instance.Font, StatManager.Instance.Coins.ToString(Strings.CoinsDigits), new Vector2(screenSize.X / 4f + Offsets.CoinCountHudOffset.X, Offsets.CoinCountHudOffset.Y), Color.White);
            spriteBatch.DrawString(SpriteFactory.Instance.Font, Game1.Instance.LevelName, new Vector2(screenSize.X / 2f + Offsets.LevelNameHudOffset.X, Offsets.LevelNameHudOffset.Y), Color.White);
            spriteBatch.DrawString(SpriteFactory.Instance.Font, StatManager.Instance.Time.ToString(Strings.TimeDigits), new Vector2(3 * screenSize.X / 4f + Offsets.TimeLeftHudOffset.X, Offsets.TimeLeftHudOffset.Y), Color.White);
        }
    }
}
