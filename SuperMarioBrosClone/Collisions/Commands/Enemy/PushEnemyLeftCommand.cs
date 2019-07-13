using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Enemy
{
    internal class PushEnemyLeftCommand : Command<EnemyBlockCollisionHandler>
    {
        public PushEnemyLeftCommand(IEnemy enemy, IBlock block, ICollision collision) :
            base(new EnemyBlockCollisionHandler(enemy, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightEnemyBlockCollision();
        }
    }
}
