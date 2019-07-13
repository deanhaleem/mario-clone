using SuperMarioBrosClone.Collisions.Handlers;
using SuperMarioBrosClone.GameObjects;
using SuperMarioBrosClone.Input.Commands;

namespace SuperMarioBrosClone.Collisions.Commands.Enemy
{
    internal class PushEnemyRightOtherLeftCommand : Command<EnemyEnemyCollisionHandler>
    {
        public PushEnemyRightOtherLeftCommand(IEnemy instigatingEnemy, IEnemy receivingEnemy, ICollision collision) :
            base(new EnemyEnemyCollisionHandler(instigatingEnemy, receivingEnemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleLeftEnemyEnemyCollision();
        }
    }
}
