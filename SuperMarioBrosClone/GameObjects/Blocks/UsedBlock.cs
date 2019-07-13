using Microsoft.Xna.Framework;
using SuperMarioBrosClone.GameObjects.Blocks.States;

namespace SuperMarioBrosClone.GameObjects.Blocks
{
    internal class UsedBlock : NonBumpableBlock
    {
        public UsedBlock(Vector2 location, Color color) : base(location, color)
        {
            base.BlockState = new BumpedBlockState(this, typeof(UsedBlockState));
        }
    }
}
