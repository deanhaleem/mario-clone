namespace SuperMarioBrosClone
{
    internal class TurnPlayerFireCommand : Command<PlayerItemCollisionHandler>
    {
        public TurnPlayerFireCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandlePlayerFireFlowerCollision();
        }
    }
}
