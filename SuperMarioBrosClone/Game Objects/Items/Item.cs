using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal abstract class Item : KinematicGameObject, IItem
    {
        public IItemState ItemState { get; set; }

        protected Item(Vector2 location, Color color) : base(location, color, Physics.MaxItemVelocity)
        {
            base.SetSprite(GetType().Name);
        }

        public override void Update(GameTime gameTime)
        {
            ItemState.Update(gameTime);
            base.Update(gameTime);
        }
    }
}
