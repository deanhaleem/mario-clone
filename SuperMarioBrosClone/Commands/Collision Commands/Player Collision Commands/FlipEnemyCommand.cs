namespace SuperMarioBrosClone
{
    internal class FlipEnemyCommand : Command<PlayerEnemyCollisionHandler>
    {
        public FlipEnemyCommand(IPlayer player, IEnemy enemy, ICollision collision) :
            base(new PlayerEnemyCollisionHandler(player, enemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleFlippingPlayerEnemyCollision();
        }
    }
}
