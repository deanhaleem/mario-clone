namespace SuperMarioBrosClone
{
    internal class PushEnemyLeftOtherRightCommand : Command<EnemyEnemyCollisionHandler>
    {
        public PushEnemyLeftOtherRightCommand(IEnemy instigatingEnemy, IEnemy receivingEnemy, ICollision collision) :
            base(new EnemyEnemyCollisionHandler(instigatingEnemy, receivingEnemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightEnemyEnemyCollision();
        }
    }
}
