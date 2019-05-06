using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class ItemBlockCollisionHandler
    {
        private readonly IItem item;
        private readonly IBlock block;
        private readonly ICollision collision;

        public ItemBlockCollisionHandler(IItem item, IBlock block, ICollision collision)
        {
            this.item = item;
            this.block = block;
            this.collision = collision;
        }

        public void HandleTopItemBlockCollision()
        {
            item.Location -= new Vector2(0, collision.Intersection.Height);
            item.Land();
        }

        public void HandleBottomItemBlockCollision()
        {
            item.Location += new Vector2(0, collision.Intersection.Height);
        }

        public void HandleLeftItemBlockCollision()
        {
            item.Location += new Vector2(collision.Intersection.Width, 0);
            item.ChangeDirection();
        }

        public void HandleRightItemBlockCollision()
        {
            item.Location -= new Vector2(collision.Intersection.Width, 0);
            item.ChangeDirection();
        }
    }
}
