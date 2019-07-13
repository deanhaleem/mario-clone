using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrosClone.Graphics;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Indicators
{
    internal class Indicator : GameObject, IIndicator
    {
        private readonly string pointIndicator;

        public Indicator(Vector2 location, Color color, int points) : base(location, color)
        {
            this.pointIndicator = points.ToString();

            TimedActionManager.Instance.RegisterTimedAction(null, DisposeOfIndicator, Timers.IndicatorRiseTime);
        }

        public override void Update(GameTime gameTime)
        {
            Location -= Physics.IndicatorVelocity;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFactory.Instance.Font, pointIndicator, Location, Color.White, 0, Vector2.Zero,
                Utilities.IndicatorScale, SpriteEffects.None, Utilities.IndicatorDepth);
        }

        private void DisposeOfIndicator()
        {
            Game1.Instance.DisposeOfObject(this);
        }
    }
}
