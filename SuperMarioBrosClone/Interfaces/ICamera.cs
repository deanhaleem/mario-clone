using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    public interface ICamera : ICollidable
    {
        Vector2 Location { get; set; }
        Matrix Transform { get; }
    }
}
