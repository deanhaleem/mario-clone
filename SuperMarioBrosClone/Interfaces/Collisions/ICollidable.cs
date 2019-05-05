using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    public interface ICollidable
    {
        Rectangle HitBox { get; }
    }
}
