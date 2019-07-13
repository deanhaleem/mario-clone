using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone.GameObjects.Background
{
    internal abstract class Scenery : GameObject, IScenery
    {
        protected Scenery(Vector2 location, Color color) : base(location, color)
        {
            base.SetSprite();
        }
    }
}
