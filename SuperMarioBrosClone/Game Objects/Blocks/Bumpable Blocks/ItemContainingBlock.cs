using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBrosClone
{
    internal abstract class ItemContainingBlock : Block, IItemContainer
    {
        public Type ItemType { get; set; }

        protected ItemContainingBlock(Vector2 location, Color color, Type itemType) : base(location, color)
        {
            this.ItemType = itemType;
            base.BlockState = new BumpableBlockState(this);
        }
    }
}
