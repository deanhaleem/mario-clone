namespace SuperMarioBrosClone
{
    internal class WinLevelCommand : Command<PlayerItemCollisionHandler>
    {
        public WinLevelCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandlePlayerFlagpoleCollision();
        }
    }
}
