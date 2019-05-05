namespace SuperMarioBrosClone
{
    internal class MovingItemState : ItemState
    {
        public MovingItemState(IItem item) : base(item)
        {
            base.Item.CutYVelocity();
            base.Item.ApplyImpulse(Physics.MovingItemImpulse);
        }
    }
}
