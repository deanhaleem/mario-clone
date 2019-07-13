using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Blocks.States;

namespace SuperMarioBrosClone.GameObjects.Blocks
{
    internal abstract class DestroyableBlock : Block
    {
        protected DestroyableBlock(Vector2 location, Color color) : base(location, color)
        {
            base.BlockState = new DestroyableBlockState(this);
        }
    }
}
