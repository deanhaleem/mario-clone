using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Projectile
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
