namespace SuperMarioBrosClone
{
    internal class PushPlayerDownNotWarpingCommand : Command<PlayerBlockCollisionHandler>
    {
        public PushPlayerDownNotWarpingCommand(IPlayer player, IBlock block, ICollision collision) :
            base(new PlayerBlockCollisionHandler(player, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleBottomPlayerPipeCollision();
        }
    }
}
