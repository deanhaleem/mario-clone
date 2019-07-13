using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone.Collisions
{
    public interface ICollidable
    {
        Rectangle HitBox { get; }
    }
}
