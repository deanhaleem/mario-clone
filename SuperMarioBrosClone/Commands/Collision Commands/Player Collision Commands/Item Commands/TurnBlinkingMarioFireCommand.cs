namespace SuperMarioBrosClone
{
    internal class TurnBlinkingMarioFireCommand : Command<PlayerItemCollisionHandler>
    {
        public TurnBlinkingMarioFireCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBlinkingPlayerFireFlowerCollision();
        }
    }
}
