namespace SuperMarioBrosClone
{
    internal class PushRightExplodeProjectileCommand : Command<ProjectileBlockCollisionHandler>
    {
        public PushRightExplodeProjectileCommand(IProjectile projectile, ICollision collision) :
            base(new ProjectileBlockCollisionHandler(projectile, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleLeftProjectileBlockCollision();
        }
    }
}
