using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class FireFlower : SpawningItem
    {
        public FireFlower(Vector2 location, Color color) : base(location, color, typeof(IdleItemState))
        {

        }
    }
}
