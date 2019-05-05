namespace SuperMarioBrosClone
{
    internal class PushPlayerLeftCommand : Command<PlayerBlockCollisionHandler>
    {
        public PushPlayerLeftCommand(IPlayer player, IBlock block, ICollision collision) :
            base(new PlayerBlockCollisionHandler(player, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleRightPlayerBlockCollision();
        }
    }
}
