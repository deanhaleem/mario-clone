using Microsoft.Xna.Framework;
using IDrawable = SuperMarioBrosClone.Graphics.IDrawable;

namespace SuperMarioBrosClone.GameStates
{
    public interface IGameState : IUpdatable, IDrawable
    {
        void EndLevel();
        void Pause();
        void LoseLife();
        void Transition();
        void Die();
        void Warp();
        void Warp(Vector2 location);
        void TallyUp();
    }
}
