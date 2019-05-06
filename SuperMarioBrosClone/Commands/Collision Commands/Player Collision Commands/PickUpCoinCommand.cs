namespace SuperMarioBrosClone
{
    internal class PickUpCoinCommand : Command<PlayerItemCollisionHandler>
    {
        public PickUpCoinCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandlePlayerNonSpinningCoinCollision();
        }
    }
}
