namespace SuperMarioBrosClone
{
    internal class WarpUpCommand : Command<PlayerWarpPipeCollisionHandler>
    {
        public WarpUpCommand(IPlayer player, IPipe pipe) :
            base(new PlayerWarpPipeCollisionHandler(player, pipe))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBottomPlayerWarpPipeCollision();
        }
    }
}
