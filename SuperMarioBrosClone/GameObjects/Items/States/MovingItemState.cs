using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Items.States
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
