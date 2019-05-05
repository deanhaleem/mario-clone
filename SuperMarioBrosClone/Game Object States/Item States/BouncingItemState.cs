using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class BouncingItemState : ItemState
    {
        public BouncingItemState(IItem item) : base(item)
        {
            base.Item.ApplyImpulse(Physics.BouncingItemImpulse);
            base.Item.ApplyForce(Physics.GravitationalForce);
        }

        public override void Land()
        {
            Item.ApplyImpulse(Physics.BouncingItemBounceImpulse - new Vector2(0, Item.Velocity.Y));
        }
    }
}
