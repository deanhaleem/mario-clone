namespace SuperMarioBrosClone
{
    internal class PushEnemyUpCommand : Command<EnemyBlockCollisionHandler>
    {
        public PushEnemyUpCommand(IEnemy enemy, IBlock block, ICollision collision) :
            base(new EnemyBlockCollisionHandler(enemy, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleTopEnemyBlockCollision();
        }
    }
}
