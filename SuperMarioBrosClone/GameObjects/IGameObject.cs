using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Collisions;
using IDrawable = SuperMarioBrosClone.Graphics.IDrawable;

namespace SuperMarioBrosClone.GameObjects
{
    public interface IGameObject : IUpdatable, IDrawable, ICollidable
    {
        Vector2 Location { get; set; }
        void SetSprite(string spriteName);
    }
}
