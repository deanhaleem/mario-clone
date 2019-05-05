using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    public interface ICollision
    {
        Rectangle Intersection { get; }
    }
}
