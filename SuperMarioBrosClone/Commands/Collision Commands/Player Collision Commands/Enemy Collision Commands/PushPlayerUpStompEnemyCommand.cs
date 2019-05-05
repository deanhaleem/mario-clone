namespace SuperMarioBrosClone
{
    internal class PushPlayerUpStompEnemyCommand : Command<PlayerEnemyCollisionHandler>
    {
        public PushPlayerUpStompEnemyCommand(IPlayer player, IEnemy enemy, ICollision collision) :
            base(new PlayerEnemyCollisionHandler(player, enemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleTopPlayerEnemyCollision();
        }
    }
}
