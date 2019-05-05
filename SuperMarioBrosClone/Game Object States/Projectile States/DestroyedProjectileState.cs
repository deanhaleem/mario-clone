namespace SuperMarioBrosClone
{
    internal class DestroyedProjectileState : ProjectileState
    {
        public DestroyedProjectileState(IProjectile projectile) : base(projectile)
        {
            base.Projectile.CutXVelocity();
            base.Projectile.CutYVelocity();
            base.Projectile.SetSprite(GetType().Name + projectile.GetType().Name);

            TimedActionManager.Instance.RegisterTimedAction(null, DisposeOfProjectile, Timers.ProjectileDestroyTimer);
            Game1.Instance.UnregisterGameObject(Projectile);
        }

        private void DisposeOfProjectile()
        {
            Game1.Instance.DisposeOfObject(Projectile);
        }
    }
}
