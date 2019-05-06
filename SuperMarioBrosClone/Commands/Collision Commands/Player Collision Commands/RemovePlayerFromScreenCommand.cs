namespace SuperMarioBrosClone
{
    internal class RemovePlayerFromScreenCommand : Command<PlayerItemCollisionHandler>
    {
        public RemovePlayerFromScreenCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandlePlayerCastleDoorCollision();
        }
    }
}
