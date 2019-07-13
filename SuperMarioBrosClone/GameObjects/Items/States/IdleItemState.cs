namespace SuperMarioBrosClone.GameObjects.Items.States
{
    internal class IdleItemState : ItemState
    {
        public IdleItemState(IItem item) : base(item)
        {
            base.Item.CutYVelocity();
        }
    }
}
