using Microsoft.Xna.Framework;

namespace SuperMarioBrosClone
{
    internal class ProjectileBlockCollisionHandler
    {
        private readonly IProjectile projectile;
        private readonly ICollision collision;

        public ProjectileBlockCollisionHandler(IProjectile projectile, ICollision collision)
        {
            this.projectile = projectile;
            this.collision = collision;
        }

        public void HandleTopProjectileBlockCollision()
        {
            projectile.Location -= new Vector2(0, collision.Intersection.Height);
            projectile.Land();
        }

        public void HandleBottomProjectileBlockCollision()
        {
            projectile.Location += new Vector2(0, collision.Intersection.Height);
        }

        public void HandleLeftProjectileBlockCollision()
        {
            projectile.Location -= new Vector2(collision.Intersection.Width, 0);
            projectile.Destroy();
        }

        public void HandleRightProjectileBlockCollision()
        {
            projectile.Location += new Vector2(collision.Intersection.Width, 0);
            projectile.Destroy();
        }
    }
}
