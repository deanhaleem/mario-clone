namespace SuperMarioBrosClone
{
    internal class PushPlayerRightNotWarpingCommand : Command<PlayerBlockCollisionHandler>
    {
        public PushPlayerRightNotWarpingCommand(IPlayer player, IBlock block, ICollision collision) :
            base(new PlayerBlockCollisionHandler(player, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleLeftPlayerPipeCollision();
        }
    }
}
