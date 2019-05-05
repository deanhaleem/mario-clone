namespace SuperMarioBrosClone
{
    internal class PushPlayerRightCommand : Command<PlayerBlockCollisionHandler>
    {
        public PushPlayerRightCommand(IPlayer player, IBlock block, ICollision collision) :
            base(new PlayerBlockCollisionHandler(player, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleLeftPlayerBlockCollision();
        }
    }
}
