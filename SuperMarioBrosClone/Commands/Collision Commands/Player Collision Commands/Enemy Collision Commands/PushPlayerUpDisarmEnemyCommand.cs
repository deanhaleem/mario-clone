namespace SuperMarioBrosClone
{
    internal class PushPlayerUpDisarmEnemyCommand : Command<PlayerEnemyCollisionHandler>
    {
        public PushPlayerUpDisarmEnemyCommand(IPlayer player, IEnemy enemy, ICollision collision) :
            base(new PlayerEnemyCollisionHandler(player, enemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleDisarmingPlayerEnemyCollision();
        }
    }
}
