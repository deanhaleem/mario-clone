namespace SuperMarioBrosClone
{
    internal class PushLeftExplodeProjectileCommand : Command<ProjectileBlockCollisionHandler>
    {
        public PushLeftExplodeProjectileCommand(IProjectile projectile, ICollision collision) :
            base(new ProjectileBlockCollisionHandler(projectile, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightProjectileBlockCollision();
        }
    }
}
