using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class Fireball : Projectile
    {
        public Fireball(Vector2 location, Color color, Vector2 velocity) : base(location, color, velocity, Physics.MaxProjectileVelocity)
        {

        }

        public override void Land()
        {
            ProjectileState.Land();
        }

        public override void Fall() { }
    }
}
