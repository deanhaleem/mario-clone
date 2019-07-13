using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone.GameObjects
{
    public interface IPipe : IBlock
    {
        Vector2 WarpLocation { get; }
        Rectangle WarpHitBox { get; }
    }
}
