using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Blocks.States;

namespace SuperMarioBrosClone.GameObjects.Blocks
{
    internal abstract class NonBumpableBlock : Block
    {
        protected NonBumpableBlock(Vector2 location, Color color) : base(location, color)
        {
            base.BlockState = new NonBumpableBlockState(this);
        }
    }
}
