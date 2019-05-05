using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBrosClone
{
    internal abstract class SpawningItem : Item
    {
        protected SpawningItem(Vector2 location, Color color, Type itemState) : base(location, color)
        {
            base.ItemState = new SpawningItemState(this, itemState);
        }
    }
}
