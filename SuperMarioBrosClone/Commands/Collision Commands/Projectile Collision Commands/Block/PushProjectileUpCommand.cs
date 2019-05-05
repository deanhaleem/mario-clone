namespace SuperMarioBrosClone
{
    internal class PushProjectileUpCommand : Command<ProjectileBlockCollisionHandler>
    {
        public PushProjectileUpCommand(IProjectile projectile, ICollision collision) :
            base(new ProjectileBlockCollisionHandler(projectile, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleTopProjectileBlockCollision();
        }
    }
}
