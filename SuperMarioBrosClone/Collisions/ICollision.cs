using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone.Collisions
{
    public interface ICollision
    {
        Rectangle Intersection { get; }
    }
}
