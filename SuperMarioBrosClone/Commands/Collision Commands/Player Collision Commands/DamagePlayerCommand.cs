namespace SuperMarioBrosClone
{
    internal class DamagePlayerCommand : Command<PlayerEnemyCollisionHandler>
    {
        public DamagePlayerCommand(IPlayer player, IEnemy enemy, ICollision collision) :
            base(new PlayerEnemyCollisionHandler(player, enemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleToNonTopPlayerEnemyCollision();
        }
    }
}
