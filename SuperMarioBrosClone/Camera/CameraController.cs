using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class CameraController : ICameraController
    {
        private readonly ICamera camera;

        public CameraController(ICamera camera)
        {
            this.camera = camera;
        }

        public void Update(float location, float velocity)
        {
            if (location > camera.Location.X + camera.HitBox.Width / 2f)
            {
                if (velocity > 0)
                {
                    camera.Location += new Vector2(velocity, 0);
                }
            }
        }

        public void SetCameraLocation(Vector2 location)
        {
            camera.Location = location;
        }
    }
}
