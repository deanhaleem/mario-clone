namespace SuperMarioBrosClone
{
    internal class PickUpPowerUpCommand : Command<PlayerItemCollisionHandler>
    {
        public PickUpPowerUpCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleNonUpgradingPlayerPowerUpCollision();
        }
    }
}
