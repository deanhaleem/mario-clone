using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class GreenMushroom : SpawningItem
    {
        public GreenMushroom(Vector2 location, Color color) : base(location, color, typeof(MovingItemState))
        {

        }
    }
}
