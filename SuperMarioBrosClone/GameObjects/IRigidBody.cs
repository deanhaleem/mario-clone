using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Collisions;

namespace SuperMarioBrosClone.GameObjects
{
    public enum Directions { Left = -1, Right = 1 }

    public interface IRigidBody : ICollidable
    {
        Rectangle ExtendedHitBox { get; }
        Vector2 Velocity { get; }
        Vector2 Acceleration { get; }
        Directions Direction { get; set; }
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
