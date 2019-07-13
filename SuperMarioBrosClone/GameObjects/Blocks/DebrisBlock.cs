using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Blocks
{
    internal class DebrisBlock : KinematicGameObject
    {
        public DebrisBlock(Vector2 location, Color color, Vector2 impulse) : base(location, color, Physics.MaxDebrisVelocity)
        {
            base.ApplyImpulse(impulse);
            base.ApplyForce(Physics.GravitationalForce);
            base.Direction = (Directions) (impulse.X / impulse.X);
        }
    }
}
