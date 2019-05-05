﻿using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    public interface IRigidBody : ICollidable
    {
        Rectangle ExtendedHitBox { get; }
        Vector2 Velocity { get; }
        Vector2 Acceleration { get; }
        void ApplyImpulse(Vector2 impulse);
        void ApplyForce(Vector2 force);
        void CutXVelocity();
        void CutYVelocity();
        void Fall();
        void Land();
        void ChangeDirection();
        void SetMaxVelocity(Vector2 velocity);
    }
}
