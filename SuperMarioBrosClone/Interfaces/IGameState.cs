using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
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
