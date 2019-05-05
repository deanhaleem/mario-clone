using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    public interface IGameObject : IUpdatable, IDrawable, ICollidable
    {
        Vector2 Location { get; set; }
        void SetSprite(string sprite);
    }
}
