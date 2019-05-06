namespace SuperMarioBrosClone
{
    internal class PushRightOrDamagePlayerCommand : Command<PlayerEnemyCollisionHandler>
    {
        public PushRightOrDamagePlayerCommand(IPlayer player, IEnemy enemy, ICollision collision) :
            base(new PlayerEnemyCollisionHandler(player, enemy, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleLeftPlayerShellCollision();
        }
    }
}
