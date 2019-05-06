namespace SuperMarioBrosClone
{
    internal class TurnPlayerStarCommand : Command<PlayerItemCollisionHandler>
    {
        public TurnPlayerStarCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandlePlayerStarCollision();
        }
    }
}
