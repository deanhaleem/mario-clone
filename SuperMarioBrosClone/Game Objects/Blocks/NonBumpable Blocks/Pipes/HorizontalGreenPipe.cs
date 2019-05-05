using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class HorizontalGreenPipe : Pipe
    {
        public override Rectangle WarpHitBox =>
            new Rectangle(HitBox.X, HitBox.Y + HitBox.Height / 2, HitBox.Width, HitBox.Height / 2);

        public HorizontalGreenPipe(Vector2 location, Color color, Vector2 warpLocation) : base(location, color, warpLocation)
        {

        }
    }
}
