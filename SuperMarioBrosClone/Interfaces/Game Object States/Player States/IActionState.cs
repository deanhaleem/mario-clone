using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBrosClone
{
    public interface IActionState : IUpdatable
    {
        void Stand();
        void Jump();
        void WalkRight();
        void WalkLeft();
        void Crouch();
        void Fall();
        void Land();
        void Run();
        void Attack(Type projectileType);
        void StopJumping();
        void StopMovingRight();
        void StopMovingLeft();
        void StopCrouching();
        void StopRunning();
        void Decorate();
        void Upgrade();
        void Downgrade();
        void Warp(Vector2 location, Vector2 velocity);
        void WinLevel();
    }
}
