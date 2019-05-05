using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    public interface IPipe : IBlock
    {
        Vector2 WarpLocation { get; }
        Rectangle WarpHitBox { get; }
    }
}
