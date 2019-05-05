namespace SuperMarioBrosClone
{
    internal class BumpableBlockState : BlockState
    {
        private readonly IItemContainer itemContainer;

        public BumpableBlockState(IItemContainer block) : base(block)
        {
            this.itemContainer = block;
        }

        public override void Bump()
        {
            ItemFactory.Instance.CreateItem(itemContainer.ItemType, Block.Location);
            Block.BlockState = new BumpedBlockState(Block, typeof(UsedBlockState));
        }
    }
}
