namespace SuperMarioBrosClone
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
