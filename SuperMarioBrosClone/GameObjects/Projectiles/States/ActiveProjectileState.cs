using Microsoft.Xna.Framework;
using SuperMarioBrosClone.Utility;

namespace SuperMarioBrosClone.GameObjects.Projectiles.States
{
    internal class ActiveProjectileState : ProjectileState
    {
        public ActiveProjectileState(IProjectile projectile) : base(projectile)
        {
            base.Projectile.ApplyForce(Physics.GravitationalForce);
        }

        public override void Destroy()
        {
            Projectile.ProjectileState = new DestroyedProjectileState(Projectile);
        }

        public override void Land()
        {
            Projectile.ApplyImpulse(Physics.ProjectileBounceImpulse - new Vector2(0, Projectile.Velocity.Y));
        }
    }
}
