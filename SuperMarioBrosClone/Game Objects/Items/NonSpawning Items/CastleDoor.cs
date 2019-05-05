using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class CastleDoor : Item
    {
        public CastleDoor(Vector2 location, Color color) : base(location, color)
        {
            base.ItemState = new IdleItemState(this);
        }
    }
}
