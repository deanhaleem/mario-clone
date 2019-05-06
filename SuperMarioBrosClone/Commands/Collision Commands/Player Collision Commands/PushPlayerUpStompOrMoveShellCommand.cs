namespace SuperMarioBrosClone
{
    internal class PushPlayerUpStompOrMoveShellCommand : Command<PlayerEnemyCollisionHandler>
    {
        public PushPlayerUpStompOrMoveShellCommand(IPlayer player, IEnemy enemy, ICollision collision) :
            base(new PlayerEnemyCollisionHandler(player, enemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleTopPlayerShellCollision();
        }
    }
}
