namespace SuperMarioBrosClone
{
    internal class TurnPlayerBigCommand : Command<PlayerItemCollisionHandler>
    {
        public TurnPlayerBigCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandlePlayerRedMushroomCollision();
        }
    }
}
