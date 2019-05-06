using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal abstract class NonBumpableBlock : Block
    {
        protected NonBumpableBlock(Vector2 location, Color color) : base(location, color)
        {
            base.BlockState = new NonBumpableBlockState(this);
        }
    }
}
