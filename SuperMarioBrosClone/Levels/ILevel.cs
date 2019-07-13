using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;
using SuperMarioBrosClone.GameObjects;
using IDrawable = SuperMarioBrosClone.Graphics.IDrawable;

namespace SuperMarioBrosClone.Levels
{
    public interface ILevel : IUpdatable, IDrawable
    {
        IPlayer Player { get; set; }
        string Name { get; }
        void LoadContent(string fileName);
        void DisposeOfGameObject(IGameObject gameObject);
        void RegisterGameObject(IGameObject gameObject);
        void UnregisterGameObject(IGameObject gameObject);
        Collection<IGameObject> GetObjectsOnScreen(Rectangle levelBounds);
        void CleanUp(Rectangle levelBounds);
        void Reset();
    }
}
