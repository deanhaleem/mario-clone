namespace SuperMarioBrosClone
{
    internal class PushPlayerLeftNotWarpingCommand : Command<PlayerBlockCollisionHandler>
    {
        public PushPlayerLeftNotWarpingCommand(IPlayer player, IBlock block, ICollision collision) :
            base(new PlayerBlockCollisionHandler(player, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightPlayerPipeCollision();
        }
    }
}
