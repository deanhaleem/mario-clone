using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal abstract class BlockState : IBlockState
    {
        protected IBlock Block { get; }

        protected BlockState(IBlock block)
        {
            this.Block = block;
        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Bump() { }
        public virtual void Destroy() { }
    }
}
