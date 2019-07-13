using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone.GameObjects.Indicators
{
    internal class IndicatorFactory
    {
        public static IndicatorFactory Instance { get; } = new IndicatorFactory();

        private IndicatorFactory()
        {

        }

        public static void CreateIndicator(Rectangle pointEventIntersection, int points)
        {
            Game1.Instance.UnregisterGameObject(new Indicator(new Vector2(pointEventIntersection.Right, pointEventIntersection.Top), Color.White, points));
        }
    }
}
