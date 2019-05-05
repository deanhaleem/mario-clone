namespace SuperMarioBrosClone
{
    internal class IdleItemState : ItemState
    {
        public IdleItemState(IItem item) : base(item)
        {
            base.Item.CutYVelocity();
        }
    }
}
