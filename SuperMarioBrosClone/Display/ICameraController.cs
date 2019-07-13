using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone.Display
{
    public interface ICameraController
    {
        void Update(float location, float velocity);
        void SetCameraLocation(Vector2 location);
    }
}
