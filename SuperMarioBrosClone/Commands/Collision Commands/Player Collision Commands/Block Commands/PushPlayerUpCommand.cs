namespace SuperMarioBrosClone
{
    internal class PushPlayerUpCommand : Command<PlayerBlockCollisionHandler>
    {
        public PushPlayerUpCommand(IPlayer player, IBlock block, ICollision collision) :
            base(new PlayerBlockCollisionHandler(player, block, collision))
        {

        }

        public override void Execute()
        {
            Receiver.HandleTopPlayerBlockCollision();
        }
    }
}
