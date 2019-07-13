using System;
using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone.GameObjects.Blocks
{
    internal class HiddenBlock : ItemContainingBlock
    {
        public HiddenBlock(Vector2 location, Color color, Type itemType) : base(location, color, itemType)
        {

        }

        public override void Bump()
        {
            BlockFactory.Instance.CreateBlock(GetType(), Location);
            Game1.Instance.DisposeOfObject(this);

            base.Bump();
        }
    }
}
