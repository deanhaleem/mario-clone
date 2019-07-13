using Microsoft.Xna.Framework;
using System;
using SuperMarioBrosClone.GameObjects.Items.States;

namespace SuperMarioBrosClone.GameObjects.Items
{
    internal abstract class SpawningItem : Item
    {
        protected SpawningItem(Vector2 location, Color color, Type itemState) : base(location, color)
        {
            base.ItemState = new SpawningItemState(this, itemState);
        }
    }
}
