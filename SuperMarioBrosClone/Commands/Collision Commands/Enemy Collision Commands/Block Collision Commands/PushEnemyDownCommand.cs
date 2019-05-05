namespace SuperMarioBrosClone
{
    internal class PushEnemyDownCommand : Command<EnemyBlockCollisionHandler>
    {
        public PushEnemyDownCommand(IEnemy enemy, IBlock block, ICollision collision) :
            base(new EnemyBlockCollisionHandler(enemy, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBottomEnemyBlockCollision();
        }
    }
}
