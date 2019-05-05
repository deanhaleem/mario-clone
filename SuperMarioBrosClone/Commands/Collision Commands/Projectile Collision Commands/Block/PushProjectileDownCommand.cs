namespace SuperMarioBrosClone
{
    internal class PushProjectileDownCommand : Command<ProjectileBlockCollisionHandler>
    {
        public PushProjectileDownCommand(IProjectile projectile, ICollision collision) :
            base(new ProjectileBlockCollisionHandler(projectile, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBottomProjectileBlockCollision();
        }
    }
}
