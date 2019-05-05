using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal abstract class DestroyableBlock : Block
    {
        protected DestroyableBlock(Vector2 location, Color color) : base(location, color)
        {
            base.BlockState = new DestroyableBlockState(this);
        }
    }
}
