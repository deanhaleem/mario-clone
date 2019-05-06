using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    public interface ICameraController
    {
        void Update(float location, float velocity);
        void SetCameraLocation(Vector2 location);
    }
}
