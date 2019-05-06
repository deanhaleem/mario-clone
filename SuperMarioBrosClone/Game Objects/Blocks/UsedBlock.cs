using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class UsedBlock : NonBumpableBlock
    {
        public UsedBlock(Vector2 location, Color color) : base(location, color)
        {
            base.BlockState = new BumpedBlockState(this, typeof(UsedBlockState));
        }
    }
}
