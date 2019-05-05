namespace SuperMarioBrosClone
{
    internal class DestroyableBlockState : BlockState
    {
        public DestroyableBlockState(IBlock block) : base(block)
        {

        }

        public override void Bump()
        {
            Block.BlockState = new BumpedBlockState(Block, typeof(DestroyableBlockState));
        }

        public override void Destroy()
        {
            Block.BlockState = new DestroyedBlockState(Block);
        }
    }
}
