using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Enemy
{
    internal class RightEnemyCameraCollisionCommand : Command<EnemyCameraCollisionHandler>
    {
        public RightEnemyCameraCollisionCommand(IEnemy enemy) :
            base(new EnemyCameraCollisionHandler(enemy))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightEnemyCameraCollision();
        }
    }
}
