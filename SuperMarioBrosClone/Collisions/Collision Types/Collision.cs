using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal abstract class Collision : ICollision
    {
        public Rectangle Intersection { get; }

        protected Collision(Rectangle collisionIntersection)
        {
            this.Intersection = collisionIntersection;
        }
    }
}
