using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Projectile
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
