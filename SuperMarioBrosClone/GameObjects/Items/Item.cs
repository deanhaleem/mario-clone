using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Items
{
    internal abstract class Item : KinematicGameObject, IItem
    {
        public IItemState ItemState { get; set; }

        protected Item(Vector2 location, Color color) : base(location, color, Physics.MaxItemVelocity)
        {
            base.Direction = Directions.Right;
        }

        public override void Update(GameTime gameTime)
        {
            ItemState.Update(gameTime);

            base.Update(gameTime);
        }
    }
}
