namespace SuperMarioBrosClone
{
    internal class WarpDownCommand : Command<PlayerWarpPipeCollisionHandler>
    {
        public WarpDownCommand(IPlayer player, Pipe pipe) :
            base(new PlayerWarpPipeCollisionHandler(player, pipe))
        {

        }

        public override void Execute()
        {
            Receiver.HandleTopPlayerWarpPipeCollision();
        }
    }
}
