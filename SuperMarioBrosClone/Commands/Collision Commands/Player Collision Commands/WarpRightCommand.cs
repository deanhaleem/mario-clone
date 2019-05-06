namespace SuperMarioBrosClone
{
    internal class WarpRightCommand : Command<PlayerWarpPipeCollisionHandler>
    {
        public WarpRightCommand(IPlayer player, Pipe pipe) :
            base(new PlayerWarpPipeCollisionHandler(player, pipe))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightPlayerWarpPipeCollision();
        }
    }
}
