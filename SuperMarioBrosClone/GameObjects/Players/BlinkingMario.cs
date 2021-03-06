﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Players
{
    internal class BlinkingMario : PlayerDecorator
    {
        public BlinkingMario(IPlayer player) : base(player, Color.White, Timers.BlinkTimer)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (DecorationTimer % 2 == 0)
            {
                base.Draw(spriteBatch);
            }
        }

        public override void TakeDamage() { }
    }
}
