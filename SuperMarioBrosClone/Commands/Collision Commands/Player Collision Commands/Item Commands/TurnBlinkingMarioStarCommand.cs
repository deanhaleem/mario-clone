namespace SuperMarioBrosClone
{
    internal class TurnBlinkingMarioStarCommand : Command<PlayerItemCollisionHandler>
    {
        public TurnBlinkingMarioStarCommand(IPlayer player, IItem item, ICollision collision)
            : base(new PlayerItemCollisionHandler(player, item, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBlinkingPlayerStarCollision();
        }
    }
}
