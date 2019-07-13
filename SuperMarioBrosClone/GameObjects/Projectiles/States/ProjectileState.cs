using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone.GameObjects.Projectiles.States
{
    internal abstract class ProjectileState : IProjectileState
    {
        protected  IProjectile Projectile { get; }

        protected ProjectileState(IProjectile projectile)
        {
            this.Projectile = projectile;
        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Destroy() { }
        public virtual void Land() { }
    }
}
