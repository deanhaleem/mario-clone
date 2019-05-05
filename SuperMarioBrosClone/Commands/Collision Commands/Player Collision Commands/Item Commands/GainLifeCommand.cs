namespace SuperMarioBrosClone
{
    internal class GainLifeCommand : Command<PlayerItemCollisionHandler>
    {
        public GainLifeCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandlePlayerGreenMushroomCollision();
        }
    }
}
