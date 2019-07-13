using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Projectile
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
