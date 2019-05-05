using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class RedMushroom : SpawningItem
    {
        public RedMushroom(Vector2 location, Color color) : base(location, color, typeof(MovingItemState))
        {

        }
    }
}
