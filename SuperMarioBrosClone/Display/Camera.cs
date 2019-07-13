using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone.Display
{
    internal class Camera : ICamera
    {
        public Vector2 Location { get; set; }
        public Matrix Transform => Matrix.CreateTranslation(-Location.X, -Location.Y, 0);
        public Rectangle HitBox => new Rectangle((int)Location.X, (int)Location.Y, screenSize.X, screenSize.Y);

        private readonly Point screenSize;

        public Camera(Vector2 location, Point size)
        {
            this.Location = location;
            this.screenSize = size;
        }
    }
}
