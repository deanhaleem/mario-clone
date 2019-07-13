using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Collisions;

namespace SuperMarioBrosClone.Display
{
    public interface ICamera : ICollidable
    {
        Vector2 Location { get; set; }
        Matrix Transform { get; }
    }
}
