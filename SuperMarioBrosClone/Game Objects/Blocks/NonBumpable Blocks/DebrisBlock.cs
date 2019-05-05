using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class DebrisBlock : KinematicGameObject
    {
        public DebrisBlock(Vector2 location, Color color, Vector2 impulse) : base(location, color, Physics.MaxDebrisVelocity)
        {
            base.ApplyImpulse(impulse);
            base.ApplyForce(Physics.GravitationalForce);
            base.SetSprite(GetType().Name);
        }
    }
}
