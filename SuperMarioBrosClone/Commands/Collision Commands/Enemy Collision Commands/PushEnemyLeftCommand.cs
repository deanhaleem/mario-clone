namespace SuperMarioBrosClone
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
