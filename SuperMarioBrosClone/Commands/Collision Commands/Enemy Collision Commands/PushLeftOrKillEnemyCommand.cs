namespace SuperMarioBrosClone
{
    internal class PushLeftOrKillEnemyCommand : Command<EnemyEnemyCollisionHandler>
    {
        public PushLeftOrKillEnemyCommand(IEnemy instigatingEnemy, IEnemy receivingEnemy, ICollision collision) :
            base(new EnemyEnemyCollisionHandler(instigatingEnemy, receivingEnemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightEnemyShellCollision();
        }
    }
}
