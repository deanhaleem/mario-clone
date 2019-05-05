﻿using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal abstract class ItemState : IItemState
    {
        protected IItem Item { get; }

        protected ItemState(IItem item)
        {
            this.Item = item;
        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Land() { }
    }
}
