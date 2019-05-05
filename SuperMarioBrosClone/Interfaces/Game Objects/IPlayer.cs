﻿using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    public interface IPlayer : IGameObject, ITransformable, IRigidBody
    {
        bool CanWarp { get; set; }
        IPowerUpState PowerUpState { get; set; }
        IActionState ActionState { get; set; }
        void Stand();
        void Jump();
        void WalkRight();
        void WalkLeft();
        void Crouch();
        void Run();
        void Attack();
        void StopJumping();
        void StopMovingRight();
        void StopMovingLeft();
        void StopCrouching();
        void StopRunning();
        void Warp(Vector2 location, Vector2 velocity);
        void WinLevel();
    }
}
