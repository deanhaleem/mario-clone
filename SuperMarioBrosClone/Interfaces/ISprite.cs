﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrosClone
{
    public interface ISprite : IUpdatable
    {
        Point Size { get; }
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
    }
}
