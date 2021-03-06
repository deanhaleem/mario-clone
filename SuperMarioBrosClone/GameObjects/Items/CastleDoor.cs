﻿using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Items.States;

namespace SuperMarioBrosClone.GameObjects.Items
{
    internal class CastleDoor : Item
    {
        public CastleDoor(Vector2 location, Color color) : base(location, color)
        {
            base.ItemState = new IdleItemState(this);
        }
    }
}
