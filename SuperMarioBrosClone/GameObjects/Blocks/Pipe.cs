using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Blocks
{
    internal abstract class Pipe : NonBumpableBlock, IPipe
    {
        public Vector2 WarpLocation { get; }

        public virtual Rectangle WarpHitBox => new Rectangle(HitBox.X + HitBox.Width / 2 - Offsets.WarpWidthOffset,
            HitBox.Y, Offsets.WarpHitBoxWidthOffset, HitBox.Height);

        protected Pipe(Vector2 location, Color color, Vector2 warpLocation) : base(location, color)
        {
            this.WarpLocation = warpLocation;
        }
    }
}
